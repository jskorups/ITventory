using ITventory_v2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITventory_v2.Models;


namespace ITventory_v2.ViewModel
{
    public class ComputerViewModel : IDevices
    {
        public int? Id { get; set; }
        public string GAno {get;set;} 
        public string SilesiaNo {get;set;} 
        public string Nazwa {get;set; }
        public string Typ { get; set; }


        public string SaveToDatabase()
        {
            try
            {
                Devices dev = new Devices();
                Models.ITventoryEntities ent = new Models.ITventoryEntities();
                if (Id != null && Id != 0)
                {
                    dev = ent.Devices.Where(x => x.dev_id == Id).FirstOrDefault();
                }

                dev.dev_GAno = GAno;


                if (Id == null || Id == 0)
                {
                    ent.Devices.Add(dev);
                }
                ent.SaveChanges();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return "";
        }

        public string DeleteFromDatabase(IDevices device)
        {
            throw new NotImplementedException();
        }

        public List<IDevices> ListOfDevices()
        {
            throw new NotImplementedException();
        }

        public List<IDevices> ListOfDevices(string filter)
        {
            throw new NotImplementedException();
        }

        
    }
}
