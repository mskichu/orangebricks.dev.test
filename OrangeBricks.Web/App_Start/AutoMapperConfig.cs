using AutoMapper;
using OrangeBricks.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.App_Start
{

    public static class AutomapperConfig
    {

        public static void Configure(List<Type> types)
        {
            Mapper.Initialize(cfg =>
            {
                LoadStandardMappings(types, cfg);
                LoadReverseMappings(types, cfg);
                LoadCustomMappings(types, cfg);
            });
        }

        /// <summary>
        /// This will automagically loads most assembly.
        /// </summary>
        /// <param name="types"></param>
        private static void LoadStandardMappings(IEnumerable<Type> types, IMapperConfigurationExpression cfg)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {
                cfg.CreateMap(map.Source, map.Destination);
            }
        }

        private static void LoadReverseMappings(IEnumerable<Type> types, IMapperConfigurationExpression cfg)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapReverseFrom<>) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {
                cfg.CreateMap(map.Destination, map.Source);
            }
        }

        private static void LoadCustomMappings(IEnumerable<Type> types, IMapperConfigurationExpression cfg)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IMapCustom).IsAssignableFrom(t) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select (IMapCustom)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(cfg);
            }
        }
    }
}