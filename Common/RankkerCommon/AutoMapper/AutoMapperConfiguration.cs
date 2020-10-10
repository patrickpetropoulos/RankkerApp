using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace RankkerCommon.AutoMapper
{
    public class AutoMapperConfiguration
    {
        //https://stackoverflow.com/a/49456783
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg => {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<ModelToDTOProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;

    }
}
