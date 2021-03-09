using MailSenderApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderApp.Models
{
    public class Sender : Entity
    {        
        public string Name { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            return $"{Name} : {Address}";
        }
    }
}
