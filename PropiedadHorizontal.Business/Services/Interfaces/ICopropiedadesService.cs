
using PropiedadHorizontal.Core.DTO;
using System.Collections.Generic;

namespace PropiedadHorizontal.Business.Services.Interfaces
{
    public interface ICopropiedadesService
    {
        /// <summary>
        /// Get a list of copropiedades based on a Pagination object.
        /// </summary>
        /// <param name="pagination">Pagination object.</param>
        /// <returns>List of Copropiedad objects.</returns>
        IEnumerable<CopropiedadesDto> GetAllCopropiedades(PaginationDto pagination);

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

        bool ExistsCopropiedadNombre(string copropiedadNombre);

    }
}
