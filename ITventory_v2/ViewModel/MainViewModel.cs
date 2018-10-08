using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITventory_v2.Models
{
    public  class MainViewModel
    {

        public int Id { get; set; }
        public string GAno { get; set; }
        public string Silno { get; set; }
        public string ImieInaziwsko { get; set; }


        public List<MainViewModel> mainDane()
        {
            ITventoryEntities ent = new ITventoryEntities();
            List<MainViewModel> MainObject = ent.Main.Select(x => new MainViewModel()
            {
                Id = x.main_id,
                GAno = x.main_GAno,
                Silno = x.main_SilesiaNo.ToString(),
                ImieInaziwsko = x.Name.nam_imie + " " + x.Name.nam_nazwisko
            }
            ).ToList();

            return MainObject;
        }

    }
}
