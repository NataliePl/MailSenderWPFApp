using MailSenderApp.Models.Base;
using System.ComponentModel;

namespace MailSenderApp.Models
{
    public class Recipient : Entity, IDataErrorInfo
    {
        string IDataErrorInfo.this[string PropertyName]
        {
            get
            {
                switch (PropertyName)
                {
                    default: return null;
                    
                    case nameof(Name):
                        var name = Name;
                        if (name is null) return "Имя не может быть пустым";
                        if (name.Length <= 2) return "Имя должно содержать не менее 3 симоволов";
                        if (name.Length > 20) return "Имя должно содержать не больше 20 символов";

                        return null;
                }

            }
        }

        public string Name { get; set; }

        public string Address { get; set; }

        string IDataErrorInfo.Error => null;


    }
}
