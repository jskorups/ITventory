using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITventory_v2.Models
{
    public class NameViewModel
    {

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int id { get; set; }
        public string ImieINazwisko { get { return Imie + " " + Nazwisko; } }

        public NameViewModel() { }

        public NameViewModel(int id)
        {
            ITventoryEntities ent = new ITventoryEntities();
            Name name = ent.Name.Where(x => x.nam_id == id).FirstOrDefault();
            Imie = name.nam_imie;
            Nazwisko = name.nam_nazwisko;
            this.id = name.nam_id;
        }


        public void ZapiszZmiany()
        {
            ITventoryEntities ent = new ITventoryEntities();
            Name n = ent.Name.Where(x => x.nam_id == id).FirstOrDefault();
            n.nam_imie = Imie;
            n.nam_nazwisko = Nazwisko;
            ent.SaveChanges();
        }


        public void Kasuj()
        {
            ITventoryEntities ent = new ITventoryEntities();
            ent.Name.Remove(ent.Name.Where(x => x.nam_id == this.id).FirstOrDefault());
            ent.SaveChanges();
        }


        public List<NameViewModel> ListOfNames()
        {
            ITventoryEntities ent = new ITventoryEntities();
            List<NameViewModel> names = ent.Name.Select(x => new NameViewModel()
            {
                Imie = x.nam_imie,
                Nazwisko = x.nam_nazwisko,
                id = x.nam_id
            }).ToList();
            return names;
        }
    }
}
