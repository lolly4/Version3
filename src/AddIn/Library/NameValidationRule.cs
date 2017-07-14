﻿using Chem4Word.Core.UI.Forms;
using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Controls;

namespace Chem4Word.Library
{
    public class NameValidationRule : ValidationRule
    {
        private static string _product = Assembly.GetExecutingAssembly().FullName.Split(',')[0];
        private static string _class = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public NameValidationRule()
        {
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string module = $"{_product}.{_class}.{MethodBase.GetCurrentMethod().Name}()";
            try
            {
                if (string.IsNullOrWhiteSpace((string)value))
                {
                    return new ValidationResult(false, "Please enter a valid name for the compound");
                }

                return new ValidationResult(true, null);
            }
            catch (Exception ex)
            {
                new ReportError(Globals.Chem4WordV3.Telemetry, Globals.Chem4WordV3.WordTopLeft, module, ex.Message, ex.StackTrace).ShowDialog();
            }

            return new ValidationResult(false, null);
        }
    }
}