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
            Client client = new Client("Tony", 0895433227, "Sofia");
            Client client2 = new Client("Vasil", 089, "Sofia");

            Data data = new Data();
            data.AddData(client);
            data.AddData(client2);

            foreach (var person in data.Dictionary)
            {
                Console.WriteLine(person.Value.Name + " " + person.Value.PhoneNumber); 
            }
            string word = "Wood";
           // Types = "Wood" == Types.Wood.ToString() ? Types.Wood : Types.Iron;
        }


    }
}
