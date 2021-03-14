using MailSenderApp.Infrastructure.Services.InMemory;
using MailSenderApp.Models;
using System.Linq;

namespace MailSenderApp.Infrastructure.InMemory

{
    public class MessagesRepository : RepositoryInMemory<Message>
    {

        public MessagesRepository() : base(Enumerable.Range(1, 100)
            .Select(i => new Message
            {
                Id = i,
                Text = $"Текст письма-{i}",
                Title = $"Заголовок письма {i}"
            }))
        {
        }

        public override void Update(Message item)
        {
            var db_item = GetById(item.Id);
            if (db_item is null || ReferenceEquals(db_item, item)) return;

            db_item.Text = item.Text;
            db_item.Title = item.Title;
        }
    }
}
