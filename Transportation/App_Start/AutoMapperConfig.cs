using AutoMapper;
using Transportation.Data.Models;
using Transportation.Models;

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
                config.CreateMap<PointDataModel, PointViewModel>().ReverseMap();
                config.CreateMap<RouteDataModel, RouteViewModel>().ReverseMap();
                config.CreateMap<TimeTableDataModel, TimeTableViewModel>().ReverseMap();
            });
        }
    }
}