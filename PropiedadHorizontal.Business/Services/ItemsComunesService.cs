using AutoMapper;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Business.Services
{
    public class ItemsComunesService : IItemsComunesService
    {
        private readonly IItemsComunesRepository _itemsComunesRepository;
        private readonly IMapper _mapper;

        public ItemsComunesService(IItemsComunesRepository itemsComunesRepository
            , IMapper mapper)
        {
            _itemsComunesRepository = itemsComunesRepository;
            _mapper = mapper;
        }

        ///<see cref="IItemsComunesService.GetItemsComunesByCodigoAgrupador(string)"/>
        public ICollection<ItemsComunesDto> GetItemsComunesByCodigoAgrupador(string codigoAgrupador)
        {
            try
            {
                var items = _itemsComunesRepository.GetItemsComunesByCodigoAgrupador(codigoAgrupador);
                return _mapper.Map<IList<ItemsComunesDto>>(items);
            }
            catch (Exception exc)
            {
                Log.Error("Error GetItemsComunesByCodigoAgrupador: " + exc.Message);
                throw;
            }
        }

        public IEnumerable<ItemsComunesDto> GetAllItemsComunes()
        {
            try
            {
                var items = _itemsComunesRepository.GetAllItemsComunes();
                return _mapper.Map<IList<ItemsComunesDto>>(items);
            }
            catch (Exception exc)
            {
                Log.Error("Error GetAllItemsComunes: " + exc.Message);
                throw;
            }
        }
    }
}
