using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.AccessControl;

namespace ZHelper
{
    public class Client
    {
        private string name;

        public Client(string name, int phNumber, string address)
        {
            this.Name = name;
            this.PhoneNumber = phNumber;
            this.Address = address;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Client name too short!");
                }
                this.name = value;
            }
        }

        public int PhoneNumber { get; }

        public string Address { get; set; }
    }
}
