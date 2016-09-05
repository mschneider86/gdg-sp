﻿/*
 * Copyright (C) 2016 Alefe Souza <http://alefesouza.com>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using GDGSPCheckIn.Properties;
using Microsoft.Win32;
using System.Windows;

namespace GDGSPCheckIn
{
    /// <summary>
    /// Janela de configuração da impressora Dymo
    /// </summary>
    public partial class PrinterConfigWindow : Window
    {
        public PrinterConfigWindow()
        {
            InitializeComponent();

            UseDymo.IsChecked = Settings.Default.UseDymo;
            DotLabelPath.Text = Settings.Default.LabelPath;

            DotLabelPath.IsEnabled = (bool)UseDymo.IsChecked;
            DotLabelButton.IsEnabled = (bool)UseDymo.IsChecked;
        }

        private void DotLabelButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Arquivo Dymo Label|*.label";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            bool? userClickedOK = openFileDialog1.ShowDialog();

            if (userClickedOK == true)
            {
                DotLabelPath.Text = openFileDialog1.FileName;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)UseDymo.IsChecked && DotLabelPath.Text.Length != 0 && DotLabelPath.Text.EndsWith(".label"))
            {
                Settings.Default.UseDymo = (bool)UseDymo.IsChecked;
                Settings.Default.LabelPath = DotLabelPath.Text;
                Close();
            }
            else if(!(bool)UseDymo.IsChecked)
            {
                Settings.Default.UseDymo = (bool)UseDymo.IsChecked;
                Close();
            }
            else
            {
                MessageBox.Show("Escolha um arquivo .label");
            }
        }

        private void UseDymo_Click(object sender, RoutedEventArgs e)
        {
            DotLabelPath.IsEnabled = (bool)UseDymo.IsChecked;
            DotLabelButton.IsEnabled = (bool)UseDymo.IsChecked;
        }
    }
}
