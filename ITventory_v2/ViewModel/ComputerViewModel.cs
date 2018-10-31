using ITventory_v2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITventory_v2.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections;
using System.Runtime.CompilerServices;

namespace ITventory_v2.ViewModel
{
    public class ComputerViewModel : IDevices, INotifyPropertyChanged, IDataErrorInfo
    {

        #region Pola obowiązkowe
        public int? Id { get; set; }
        public string GAno { get; set; }
        public int? SilesiaNo { get; set; }
        public string NazwaKomputera { get; set; }


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
        //[Column(TypeName = "Date")]
        public DateTime? DataZakupu { get; set; }
        public string NumerFaktury { get; set; }


        //Uzytkownicy
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string ImieInazwisko { get { return imie + " " + nazwisko; } }

        #region IDataErrorInfo
        //IDataErrorInfo
        public string Error
        {
            get {
                return null;
            }
        }

        public string this[string PropertyName]
        {
            get
            {
                string result = string.Empty;
                switch (PropertyName)
                {
                    case "GAno":
                        if (string.IsNullOrEmpty(GAno))
                            result = "Wymagany jest numer GA";
                        break;
                    case "SilesiaNo":
                        if (string.IsNullOrEmpty(SilesiaNo.ToString()))
                            result = "Wymagany jest numer Sielsia";
                        break;
                    case "NazwaKomputera":
                        if (string.IsNullOrEmpty(NazwaKomputera))
                            result = "Wymagana jest nazwa komputera";
                        break;
                    case "ImieInazwisko":
                        if (string.IsNullOrEmpty(ImieInazwisko))
                            result = "Wymagany jest użytkownik";
                        break;
                }
                return result;
            }
        }
        //IDataErrorInfo
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
        #region Pola dodatkowe 2

        public string Procesor { get; set; }
        public string Pamiec { get; set; }
        public string ProducentDysku { get; set; }
        public string DyskModel { get; set; }
        public string DyskSN { get; set; }
        public string DyskRozmiar { get; set; }
        public string Grafika { get; set; }
        public string CdRom { get; set; }
        public string CdRomSn { get; set; }

        #endregion
        #region Pola dodatkowe 3


        public string Lan { get; set; }
        public string LanMac { get; set; }
        public string Wlan { get; set; }
        public string WlanMac { get; set; }
        public string BatterySN { get; set; }
        public string SystemOpercyjny { get; set; }
        public string DataZakupu { get; set; }
        public string Licencja { get; set; }
        public string CdRomSn { get; set; }




        #endregion
        #region Pola dodatkowe 4





        #endregion

        //lista uzytkowników


        public List<ComputerViewModel> ListOfNames()
        {
            ITventoryEntities ent = new ITventoryEntities();
            List<ComputerViewModel> names = ent.Uzytkownicy.Select(x => new ComputerViewModel()
            {
                imie = x.uzyt_imie,
                nazwisko = x.uzyt_nazwisko,
                Id = x.uzyt_id
            }).ToList();
            return names;
        }


        #region Save


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
                dev.dev_dataZakupu = DataZakupu.Value;
                dev.dev_nrFaktury = NumerFaktury;

                if (Id == null || Id == 0)
                {
                    ent.Devices.Add(dev);
                }
                ent.SaveChanges();
            }

            catch(Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
            return "";
        }
        #endregion
        #region Delete
        public string DeleteFromDatabase(IDevices device)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region ListaOfDevices

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

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
