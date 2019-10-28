FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["PropiedadHorizontal.Api/PropiedadHorizontal.Api.csproj", "PropiedadHorizontal.Api/"]
RUN dotnet restore "PropiedadHorizontal.Api/PropiedadHorizontal.Api.csproj"
COPY . .
WORKDIR "/src/PropiedadHorizontal.Api"
RUN dotnet build "PropiedadHorizontal.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PropiedadHorizontal.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PropiedadHorizontal.Api.dll"]