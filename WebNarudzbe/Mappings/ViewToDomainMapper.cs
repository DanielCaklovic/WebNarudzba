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
    public class ViewToDomainMapper:Profile
    {

        public override string ProfileName
        {
            get
            {
                return "ViewToDomainMapping";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<DobavljacDTO, Dobavljac>();
            Mapper.CreateMap<KupacDTO, Kupac>();
            Mapper.CreateMap<NarudzbeDTO, Narudzbe>();
            Mapper.CreateMap<ProizvodDTO, Proizvod>();
            
        }

    }
}