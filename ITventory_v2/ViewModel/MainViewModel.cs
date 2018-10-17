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
            List<MainViewModel> MainObject = ent.Devices.Select(x => new MainViewModel()
            {
                Id = x.dev_id,
                GAno = x.dev_GAno,
                Silno = x.dev_SilesiaNo.ToString(),

                ImieInaziwsko = x.Uzytkownicy.uzyt_imie + " " + x.Uzytkownicy.uzyt_nazwisko
            }
            ).ToList();

            return MainObject;
        }

    }
}
