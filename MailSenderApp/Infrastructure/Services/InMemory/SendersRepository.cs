using MailSenderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApp.Infrastructure.InMemory

{
    class SendersRepository
    {
        private List<Sender> _Senders;

        public SendersRepository()
        {
            _Senders = Enumerable.Range(1, 10)
                .Select(i => new Sender
                {
                    Name = $"Отправитель {i}",
                    Address = $"sender_{i}@server.com"
                }).ToList();
        }

        public IEnumerable<Sender> GetAll() => _Senders;

        public void Add(Sender sender)
        {
            _Senders.Add(sender);
        }

        public void Remove(Sender sender)
        {
            _Senders.Remove(sender);
        }

        //public int Count() => _Senders.Count();
    }
}
