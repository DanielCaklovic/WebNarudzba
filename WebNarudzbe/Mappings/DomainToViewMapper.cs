using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DAL;
using DAL.Model;
using WebNarudzbe.Models;

namespace WebNarudzbe.Mappings
{
    public class DomainToViewMapper:Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewMapping";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Dobavljac,DobavljacDTO>();
            Mapper.CreateMap<Kupac, KupacDTO>();
            Mapper.CreateMap<Narudzbe, NarudzbeDTO>();
            Mapper.CreateMap<Proizvod, ProizvodDTO>();
            
        }
    }
}