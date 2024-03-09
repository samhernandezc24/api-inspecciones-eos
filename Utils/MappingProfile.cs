using API.Inspecciones.Models;
using API.Inspecciones.ViewModels;
using API.Inspecciones.ViewModels.Reports;
using AutoMapper;

namespace API.Inspecciones.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // MAPEO PARA RETORNO DE DATASOURCE_EXPRESSION
            // U
            CreateMap<Unidad, UnidadViewModel>();

            // MAPEO PARA REPORTE
            // U
            CreateMap<UnidadViewModel, RepUnidad>()
                .ForMember(d => d.createdFecha, o => o.MapFrom(s => s.CreatedFechaNatural))
                .ForMember(d => d.updatedFecha, o => o.MapFrom(s => s.UpdatedFechaNatural));
        }
    }
}
