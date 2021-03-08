﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MailSenderApp.Infrastructure.ValidationRules
{
    class RegExValidation : ValidationRule
    {
        private Regex _Regex;

        public string Pattern 
        {
            get => _Regex.ToString();
            set => _Regex = string.IsNullOrEmpty(value) ? null : new(value);
        }

        public bool AllowNull { get; set; }

        public string ErrorMessage { get; set; }
        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is null)
                return AllowNull
                    ? ValidationResult.ValidResult
                    : new ValidationResult(false, ErrorMessage ?? $"Строка не удовлетворяет требованию {Pattern}");

            if (_Regex is null) return ValidationResult.ValidResult;

            if (value is not string str)
                str = value.ToString();

            return _Regex.IsMatch(str)
                ? ValidationResult.ValidResult
                : new ValidationResult(false, ErrorMessage ?? $"Строка не удовлетворяет требованию {Pattern}");
        }
    }
}
