using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace WebNarudzbe.Mappings
{
    public class AutoMapperConfig
    {
        public static void Configure() 
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewMapper>();
                x.AddProfile<ViewToDomainMapper>();
            });
        }
    }
}