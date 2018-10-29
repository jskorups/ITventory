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




        //pola obowiazkowe
        public string GAno {get;set;} 
        public int? SilesiaNo {get;set;} 
        public string NazwaKomputera {get;set;}
        // pola wybieralne
        public int Status { get; set; }
        public int Użytkownicy { get; set; }
        public int Typ { get; set; }
        //
        public int Producent { get; set; }
        public string Model { get; set; }
        public string PartNumber { get; set; }
        public string SerialNumber { get; set; }
        // pole wybieralne
        public int Dostawca { get; set; }
        //
        public string DataZakupu { get; set; }
        public string NumerFaktury { get; set; }


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
                dev.dev_SilesiaNo = SilesiaNo;
                dev.dev_Nazwa = NazwaKomputera;

                //dev.dev_status = Status;
                dev.dev_uzyt = Użytkownicy;
                //dev.dev_typ = Typ;
                //dev.dev_producent = Producent;

                dev.dev_model = Model;
                dev.dev_pn = PartNumber;
                dev.dev_sn = SerialNumber;
                //dev.dev_dostawca = Dostawca;
                dev.dev_dataZakupu = DataZakupu;
                dev.dev_nrFaktury = NumerFaktury;


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


        //lista uzytkowników
        public List<ComputerViewModel> mainDane()
        {
            ITventoryEntities ent = new ITventoryEntities();
            List<ComputerViewModel> MainObject = ent.Devices.Select(x => new ComputerViewModel()
            {


          //      Użytkownicy = x.Uzytkownicy.uzyt_imie + " " + x.Uzytkownicy.uzyt_nazwisko
            }
            ).ToList();

            return MainObject;
        }


        public List<IDevices> ListOfDevices()
        {
            Devices dev = new Devices();
            Models.ITventoryEntities ent = new Models.ITventoryEntities();
            List<IDevices> komputery = new List<IDevices>();
            komputery.AddRange(ent.Devices.Select(x => new ComputerViewModel()
            {
                Id = x.dev_id,
                GAno = x.dev_GAno,
                SilesiaNo = x.dev_SilesiaNo

            }));
            return komputery;
        }

        public List<IDevices> ListOfDevices(string filter)
        {
            Devices dev = new Devices();
            Models.ITventoryEntities ent = new Models.ITventoryEntities();
            IDevices test = new ComputerViewModel();
            List<IDevices> komputery = new List<IDevices>();
            komputery.AddRange(ent.Devices.Where(x=>x.dev_Nazwa.Contains(filter)).Select(x => new ComputerViewModel()
            {
                Id = x.dev_id,
                GAno = x.dev_GAno,
                SilesiaNo = x.dev_SilesiaNo

            }));
            //List<IDevices> komputery = ent.Devices.Select(x => new ComputerViewModel()
            //{
            //    Id = x.dev_id,
            //    GAno = x.dev_GAno,
            //    SilesiaNo = x.dev_SilesiaNo

            //}).ToList();
            return komputery;
        }
    }
}
