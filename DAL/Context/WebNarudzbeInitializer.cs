using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DAL.Model;
using DAL;


namespace WebNaruzdba.DAL.Context
{
    public class WebNarudzbeInitializer : DropCreateDatabaseIfModelChanges<WebNarudzbaContext>
    {
        protected override void Seed(WebNarudzbaContext context)
        {
            //PROIZVOD
            var proizvodi = new List<Proizvod>
            {
                
                new Proizvod{Naziv="Galaxy S3",Cijena=2030.8},
                new Proizvod{Naziv="Galaxy S4",Cijena=3000.5},
                new Proizvod{Naziv="Galaxy S5",Cijena=4030.3}
            };

            foreach (Proizvod item in proizvodi)
            {
                context.Proizvod.Add(item);
            }

            context.SaveChanges();

            //DOBAVLJAC
            var dobavljac = new List<Dobavljac>
            {
                new Dobavljac{Naziv="T-Mobile",Adresa="Zagrebačka ulica 7, 10000 Zagreb",Telefon="01/555-5555"},
                new Dobavljac{Naziv="VIP",Adresa="Osječka ulica 74, 10000 Zagreb",Telefon="01/666-5555"},
                new Dobavljac{Naziv="Tele2",Adresa="Splitska ulica 33, 10000 Zagreb",Telefon="01/777-5555"}
            };

            foreach (Dobavljac item in dobavljac)
            {
                context.Dobavljac.Add(item);
            }

            context.SaveChanges();

            //Kupac
            var kupac = new List<Kupac>
            {
                new Kupac{Ime="Pero",Prezime="Peric",Adresa="Zagrebačka ulica 3, 35000 Slavonski Brod",Telefon="098/999-4322"},
                new Kupac{Ime="Ivo",Prezime="Perković",Adresa="Osječka ulica 34, 35000 Slavonski Brod",Telefon="095/999-4887"},
                new Kupac{Ime="Mato",Prezime="Andrijević",Adresa="Splitska ulica 23, 31000 Osijek",Telefon="091/883-2112"},
            };
            foreach (Kupac item in kupac)
            {
                context.Kupac.Add(item);
            }

            context.SaveChanges();

            //Narudzba
            var narudzba = new List<Narudzbe>
            {
                new Narudzbe{KupacID=1,ProizvodID=3},
                new Narudzbe{KupacID=1,ProizvodID=2},
                new Narudzbe{KupacID=1,ProizvodID=1},
                new Narudzbe{KupacID=2,ProizvodID=3},
                new Narudzbe{KupacID=3,ProizvodID=3}
            };

            foreach (Narudzbe item in narudzba)
            {
                context.Narudzbe.Add(item);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}