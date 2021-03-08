using MailSender.lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib
{
    public class DebugMailService : IMailService
    {
        public IMailSender GetSender(string Server, int Port, bool SSL, string Login, string Password)
        {
            return new DebugMailSender(Server, Port, SSL, Login, Password) ;
        }
    }

    internal class DebugMailSender : IMailSender
    {
        private readonly string _Server;
        private readonly int _Port;
        private readonly bool _SSL;
        private readonly string _Login;
        private readonly string _Password;

        public DebugMailSender(string Server, int Port, bool SSL, string Login, string Password)
        {

        }
        public void Send(string SenderAddress, string RecipientAddress, string Subject, string Body)
        {
            Debug.WriteLine($"Отправка почты от {SenderAddress} к {RecipientAddress}, тема письма {Subject}");           
            
        }
    }

    //Дебаг мейл сервис с подвязкой к статистике
    //public readonly IStatistic _Statistic;
    //public DebugMailService(IStatistic Statistic) => _Statistic = Statistic;
    //public void SendEMail(string From, string To, string Title, string Body)
    //{
    //    Debug.WriteLine($"Отправка письма от {From} к {To}: {Title} - {Body}");
    //}
}
