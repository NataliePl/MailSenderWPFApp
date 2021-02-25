using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Interfaces
{
    public interface IMailService
    {
        public void SendEMail(string From, string To, string Title, string Body);
    }
}
