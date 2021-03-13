using MailSenderApp.Models.Base;

namespace MailSenderApp.Models
{
    public class Message : Entity
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public override string ToString() => $"{Title}";
    }
}
