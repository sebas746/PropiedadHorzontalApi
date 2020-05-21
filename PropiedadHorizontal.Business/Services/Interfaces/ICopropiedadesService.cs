
using PropiedadHorizontal.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropiedadHorizontal.Business.Services.Interfaces
{
    public interface ICopropiedadesService
    {
        /// <summary>
        /// Get a list of copropiedades based on a Pagination object.
        /// </summary>
        /// <param name="pagination">Pagination object.</param>
        /// <returns>List of Copropiedad objects.</returns>
        IEnumerable<CopropiedadesDto> GetAllCopropiedades(PaginationDto paginationDto);

        /// <summary>
        /// Get a copropiedad by id.
        /// </summary>
        /// <param name="copropiedadId">Copropiedad id.</param>
        /// <returns>Copropiedad DTO object.</returns>
        CopropiedadesDto GetCopropiedadById(int copropiedadId);

        /// <summary>
        /// Creates a new copropiedad.
        /// </summary>
        /// <param name="copropiedadDto">Copropiedad DTO object.</param>
        /// <returns></returns>
        CopropiedadesDto CreateCopropiedad(CopropiedadesDto copropiedadDto);

        /// <summary>
        /// Bulk create of copropiedades.
        /// </summary>
        /// <param name="copropiedadesDto"></param>
        /// <returns></returns>
        bool CreateCopropiedades(List<CopropiedadesDto> copropiedadesDto);

        /// <summary>
        /// Update a copropiedad.
        /// </summary>
        /// <param name="copropiedadDto">Copropiedad DTO object.</param>
        /// <returns>Copropiedad DTO updated object.</returns>
        CopropiedadesDto UpdateCopropiedad(CopropiedadesDto copropiedadDto);

        /// <summary>
        /// Deletes a copropiedad.
        /// </summary>
        /// <param name="copropiedadId">Copropiedad id.</param>
        /// <returns>
        /// True: If copropiedad was deleted.
        /// False: If copropiedad was NOT deleted.
        /// </returns>
        bool DeleteCopropiedad(int copropiedadId);

        /// <summary>
        /// Verify if exists a copropiedad name equal.
        /// </summary>
        /// <param name="copropiedadNombre"></param>
        /// <param name="idCopropiedad"></param>
        /// <returns></returns>
        bool ExistsCopropiedadNombre(string copropiedadNombre, int idCopropiedad);

        int Count();

    }
}
