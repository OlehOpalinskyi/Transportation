using AutoMapper;
using Transportation.Data.Models;
using Transportation.Models;
using System.Linq;
using System.Collections.Generic;

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
                .ForMember(dest => dest.Buses, opt => opt.MapFrom(src => GetBuses(src)))
                .ReverseMap();
                config.CreateMap<RouteDataModel, UpdateRouteModel>().ReverseMap();
                config.CreateMap<TimeTableUpdateModel, TimeTableDataModel>().ReverseMap();
                config.CreateMap<TimeTableDataModel, TimeTableViewModel>()
                .ForMember(dest => dest.NumberBus, opt => opt.MapFrom(src => src.Bus.NumberOfBus))
                .ForMember(dest => dest.RouteName, opt => opt.MapFrom(src => src.Route.NameRoute))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Route.Price))
                .ReverseMap();
            });
        }
        public static List<int> GetBuses(RouteDataModel route)
        {
            var names = new List<int>();
            foreach (var item in route.Buses)
                names.Add(item.NumberOfBus);
            return names;
        }
    }
}