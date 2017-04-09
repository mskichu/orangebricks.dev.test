using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Infrastructure
{
    public interface IMapCustom
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}