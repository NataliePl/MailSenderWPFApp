
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender.lib.Commands
{
    public class CloseAppCommand: Command
    {
        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
