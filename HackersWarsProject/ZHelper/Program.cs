using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZHelper
{
    class Program
    {
        static void Main(string[] args)
        {
 
            Client client1 = new Client("Zoony", 0896554433, false);
            Client client2 = new Client("Tony", 0987654, true);
            Client Client3 = new Client("Aary", 6879596, true);

            Data data = new Data();

            data.AddData(client1);
            data.AddData(client2);
            data.AddData(Client3);

            var newData = data.Dictionary.OrderByDescending(x => x.Value.Name)
                .ThenByDescending(y => y.Value.Alive).ToDictionary(x => x.Key, y => y.Value);
            foreach (var item in newData)
            {
                Console.WriteLine(item.Value.Name + " " +item.Key);
            }

        }
    }
}
