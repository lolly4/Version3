﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace Chem4Word.UI.UserControls
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public string InputValue { get; set; }

        public delegate void EventHandler(object sender, WpfEventArgs args);

        public event EventHandler OnOkButtonClick;

        public UserControl2()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            textBox.Text = "User Control #2" + Environment.NewLine + InputValue;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            WpfEventArgs args = new WpfEventArgs();
            args.OutputValue = "Two is done !";
            args.Button = "OK";

            if (OnOkButtonClick != null)
            {
                OnOkButtonClick(this, args);
            }
        }
    }
}