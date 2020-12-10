using AutoMapper;
using Data.Models.Models;
using Data.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Map
{
    public class MapperConfigurator
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
          {
              var config = new MapperConfiguration(cnf =>
                {
                    //cnf.ShouldMapProperty = p => p.GetMethod.IsStatic || p.GetMethod.IsAssembly;
                    
                    cnf.AddProfile<MapperProfile>();
                });

              var mapper = config.CreateMapper();
              return mapper;
             
          });
        public static IMapper Mapper => Lazy.Value;
    }
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Image, ImageDto>().ReverseMap();
        }
    }
}
