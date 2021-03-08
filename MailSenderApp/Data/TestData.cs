using MailSender.lib.Service;
using MailSenderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailSenderApp.Data
{
    internal static class TestData
    {

        //public static List<Sender> Senders { get; } = Enumerable.Range(1, 10)
        //    .Select(i => new Sender
        //    {
        //        Name = $"Отправитель {i}",
        //        Address = $"sender_{i}@server.com"
        //    }).ToList();

        public static List<Recipient> Recipients { get; } = Enumerable.Range(1, 10)
            .Select(i => new Recipient
            {
                Name = $"Получатель {i}",
                Address = $"recipient_{i}@server.com"
            }).ToList();

        public static List<Message> Messages { get; } = Enumerable.Range(1, 100)
            .Select(i => new Message
            {
                Title = $"Тема письма {i}",
                Text = $"Текст письма {i}"
            }).ToList();
    }
}
