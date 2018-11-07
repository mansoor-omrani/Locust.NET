using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions.AutoMapper
{
    public static class AutoMapperExtensions
    {
        public static void CreateMap<TSource, TDestination>(this IMapperConfigurationExpression cfg,
            IDictionary<Expression<Func<TDestination, object>>, Expression<Func<TSource, object>>> memberMappings)
        {
            var result = cfg.CreateMap<TSource, TDestination>();

            foreach (var memberMapping in memberMappings)
            {
                result.ForMember(memberMapping.Key, opt => opt.MapFrom(memberMapping.Value));
            }
        }
    }
}
