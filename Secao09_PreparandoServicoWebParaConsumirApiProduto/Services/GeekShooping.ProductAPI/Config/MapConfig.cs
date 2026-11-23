using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace GeekShooping.ProductAPI.Config
{
    public class MapConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Data.ValueObjects.ProductVO, Models.Product>();
                config.CreateMap<Models.Product, Data.ValueObjects.ProductVO>();
            });

            return mappingConfig;
        }
    }
}