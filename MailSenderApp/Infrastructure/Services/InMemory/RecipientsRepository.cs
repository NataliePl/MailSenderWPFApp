using MailSenderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApp.Infrastructure.Services.InMemory
{
    class RecipientsRepository
    {
        private List<Recipient> _Recipients;

        public RecipientsRepository()
        {
            _Recipients = Enumerable.Range(1, 100)
                .Select(i => new Recipient
                {
                    Name = $"Получатель {i}",
                    Address = $"recipient_{i}@server.com"
                }).ToList();
        }

        public IEnumerable<Recipient> GetAll() => _Recipients;

        public void Add (Recipient recipient)
        {
            _Recipients.Add(recipient);
        }

        public void Remove (Recipient recipient)
        {
            _Recipients.Remove(recipient);
        }

        public int Count() => _Recipients.Count();
    }
}
