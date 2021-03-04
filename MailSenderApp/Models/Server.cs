using MailSenderApp.Models.Base;

namespace MailSenderApp.Models
{
    public class Server : Entity
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public int Port { get; set; }

        public bool UseSSL { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public override string ToString() => $"{Name}:{Port}";
    }
}
