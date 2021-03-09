namespace MailSenderApp.Models
{
    public class Message
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public override string ToString() => $"{Title}";
    }
}
