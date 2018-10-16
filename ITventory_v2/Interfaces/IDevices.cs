using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITventory_v2.Interfaces
{
    public interface IDevices
    {
        string SaveToDatabase();
        string DeleteFromDatabase(IDevices device);
        List<IDevices> ListOfDevices();
        List<IDevices> ListOfDevices(string filter);
    }
}
