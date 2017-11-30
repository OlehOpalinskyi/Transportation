using AutoMapper;
using Transportation.Data.Models;
using Transportation.Models;
using System.Linq;

namespace Transportation.App_Start
{
    public class AutoMapperConfig
    {
        public static void Intialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<BusDataModel, BusViewModel>().ReverseMap();
                config.CreateMap<CityDataModel, CityViewModel>().ReverseMap();
                config.CreateMap<OrderDataModel, OrderViewModel>().ReverseMap();
                config.CreateMap<PointDataModel, PointViewModel>()
                .ForMember(dest => dest.Point, opt => opt.MapFrom(src => src.City.Name))
                .ReverseMap();
                config.CreateMap<RouteDataModel, RouteViewModel>()
                .ForMember(dest => dest.PointA, opt => opt.MapFrom(src => src.Cities.First().Name))
                .ForMember(dest => dest.PointB, opt => opt.MapFrom(src => src.Cities.Last().Name))
                .ReverseMap();
                config.CreateMap<RouteDataModel, UpdateRouteModel>().ReverseMap();
                config.CreateMap<TimeTableDataModel, TimeTableViewModel>().ReverseMap();
            });
        }
    }
}