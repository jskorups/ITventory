using ITventory_v2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITventory_v2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections;
using System.Runtime.CompilerServices;
using ITventory_v2.ViewModel;
using System.Diagnostics;

namespace ITventory_v2.ViewModel
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
     

    public class ComputerViewModel : ViewModelBase, IDevices, INotifyPropertyChanged, IDataErrorInfo
    {


        public ComputerViewModel()
        {
            OkCommand = new RelayCommand(() =>
            {
                Trace.TraceInformation("OK");
            },
            () => IsOK);
        }

        public RelayCommand OkCommand { get; private set; }


        private Dictionary<string, string> Errors { get; } = new Dictionary<string, string>();




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
        public int userId { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string ImieInazwisko { get { return imie + " " + nazwisko; } }




        #region IDataErrorInfo
        //IDataErrorInfo


        public string this[string PropertyName]
        {
            get
            {
                CollectErrors();
                return Errors.ContainsKey(PropertyName) ? Errors[PropertyName] : string.Empty;
            }
        }

        private void CollectErrors()
        {
            Errors.Clear();
            if (string.IsNullOrEmpty(GAno))
            {
                Errors.Add(nameof(GAno), "Podaj numer GA");
            }
            
            if (string.IsNullOrEmpty(SilesiaNo.ToString()))
            {
                Errors.Add(nameof(SilesiaNo), "Podaj numer Silesia");
            }

            if (string.IsNullOrEmpty(NazwaKomputera) || NazwaKomputera.Length > 3)
            {
                Errors.Add(nameof(NazwaKomputera), "Podaj nazwe komputera");
            }


            OkCommand.RaiseCanExecuteChanged();
        }

        public string Error => string.Empty;
        public bool HasErrors => Errors.Any();
        public bool IsOK => !HasErrors;
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
       // public string DataZakupu { get; set; }
        public string Licencja { get; set; }
        //  public string CdRomSn { get; set; }




        #endregion
        #region Pola dodatkowe 4





        #endregion
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
