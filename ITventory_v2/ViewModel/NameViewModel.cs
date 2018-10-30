using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITventory_v2.Models;

namespace ITventory_v2.Models
{
    public class NameViewModel
    {

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int id { get; set; }
        public string ImieINazwisko { get { return Imie + " " + Nazwisko; }}

        public NameViewModel() { }


        public List<NameViewModel> ListOfNames()
        {
            ITventoryEntities ent = new ITventoryEntities();
            List<NameViewModel> names = ent.Uzytkownicy.Select(x => new NameViewModel()
            {
                Imie = x.uzyt_imie,
                Nazwisko = x.uzyt_nazwisko,
                id = x.uzyt_id
            }).ToList();
            return names;
        }

  
        public NameViewModel(int id)
        {
            ITventoryEntities ent = new ITventoryEntities();
            Uzytkownicy name = ent.Uzytkownicy.Where(x => x.uzyt_id == id).FirstOrDefault();
            Imie = name.uzyt_imie;
            Nazwisko = name.uzyt_nazwisko;
            this.id = name.uzyt_id;
        }


        public void ZapiszZmiany()
        {
            ITventoryEntities ent = new ITventoryEntities();
            Uzytkownicy n = ent.Uzytkownicy.Where(x => x.uzyt_id == id).FirstOrDefault();
            n.uzyt_imie = Imie;
            n.uzyt_nazwisko = Nazwisko;
            ent.SaveChanges();
        }


        public void Kasuj()
        {
            ITventoryEntities ent = new ITventoryEntities();
            ent.Uzytkownicy.Remove(ent.Uzytkownicy.Where(x => x.uzyt_id == this.id).FirstOrDefault());
            ent.SaveChanges();
        }


    }
}
