using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFServicios;

namespace WCFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Type serviceType = typeof(ServiceProduct);
            using (ServiceHost host = new ServiceHost(serviceType)) {
                host.Open();
                Console.WriteLine("Servicio Operativo..");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
