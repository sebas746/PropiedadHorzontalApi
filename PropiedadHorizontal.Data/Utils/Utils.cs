using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace PropiedadHorizontal.Data.Utils
{
    public static class Utils
    {
        public static string GetCleanConnectionString(this string connection)
        {
            var conBuilder = new DbConnectionStringBuilder { ConnectionString = connection };
            conBuilder.Remove("provider");
            return conBuilder.ConnectionString;
        }

        /// <summary>
        /// OrderByFunc
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        public static Func<IQueryable<TSource>, IOrderedQueryable<TSource>> OrderByFunc<TSource>(string propertyName, bool ascending = true)
        {
            var source = Expression.Parameter(typeof(IQueryable<TSource>), "source");
            var item = Expression.Parameter(typeof(TSource), "item");
            var member = Expression.Property(item, propertyName);
            var selector = Expression.Quote(Expression.Lambda(member, item));
            var body = Expression.Call(
                typeof(Queryable), ascending ? "OrderBy" : "OrderByDescending",
                new[] { item.Type, member.Type },
                source, selector);
            var expr = Expression.Lambda<Func<IQueryable<TSource>, IOrderedQueryable<TSource>>>(body, source);
            var func = expr.Compile();
            return func;
        }

        public static LambdaExpression CreateExpression(Type type, string propertyName, bool ascending = true)
        {
            var param = Expression.Parameter(type, "x");
            var item = Expression.Parameter(type, "item");

            var prop = propertyName.Split('.').Aggregate((Expression)param, Expression.Property);
            Expression expre = param;
            foreach (var member in propertyName.Split('.'))
            {
                expre = Expression.PropertyOrField(expre, member);
            }

            var member2 = Expression.Property(prop, propertyName);
            var selector = Expression.Quote(Expression.Lambda(expre, item));

            var body = Expression.Call(
                typeof(Queryable), ascending ? "OrderBy" : "OrderByDescending",
                new[] { prop.Type, expre.Type },
                param, selector);

            //var body = Expression.Call(
            //    typeof(Queryable), ascending ? "OrderBy" : "OrderByDescending",
            //    new[] { item.Type, expre.Type },
            //    source, selector);

            return Expression.Lambda(expre, param);
        }

        public static Expression<Func<TSource, bool>> GetAndOnlyParams<TSource>(Dictionary<string, string> parametersDictionary)
        {
            if (parametersDictionary == null) return null;
            var paramList = parametersDictionary.Keys.Select(param => Expression.Parameter(typeof(TSource), param)).ToList();
            var lexList = new List<LambdaExpression>();
            var index = 0;
            foreach (var (key, value) in parametersDictionary)
            {
                if (index == 0)
                {
                    Expression bodyInner = Expression.Equal(
                        Expression.Property(
                            paramList[index], key),
                        Expression.Constant(value));
                    lexList.Add(Expression.Lambda(bodyInner, paramList[index]));
                }
                else
                {
                    var bodyOuter = Expression.AndAlso(
                        Expression.Equal(
                            Expression.Property(
                                paramList[index], key),
                            Expression.Constant(value)),
                        Expression.Invoke(lexList[index - 1], paramList[index]));
                    lexList.Add(Expression.Lambda(bodyOuter, paramList[index]));
                }
                index++;
            }
            return (Expression<Func<TSource, bool>>)lexList[lexList.Count - 1];
        }
    }
}
