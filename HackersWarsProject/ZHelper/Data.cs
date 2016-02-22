using System;
using System.Collections.Generic;
using System.Linq;


namespace ZHelper
{
   public class Data
   {

        public Data()
        {
            this.Dictionary = new Dictionary<int, Client>();
        }

       public IDictionary<int, Client> Dictionary { get; }

       public void AddData(Client client)
        { 
          Dictionary.Add(client.PhoneNumber, client);
       }
    }
}
