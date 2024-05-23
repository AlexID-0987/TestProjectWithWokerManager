using Microsoft.Win32;
using ProjectForEmploee.Models;
using ProjectForEmploee.Views;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace ProjectForEmploee.Services
{
    public class ServicesCrudEmploees
    {

        public BindingList<Emploee> toEmploee;
        public void AddToEmploeeList(Emploee emp)
        {
            try
            {
                Emploee e = new Emploee() { NAME = emp.NAME, LASTNAME = emp.LASTNAME, SALARY = emp.SALARY, INFO = emp.INFO };
                toEmploee.Add(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Not value{ex}");
            }

        }
        public void EditMyList(Emploee emploee, Emploee changetName)
        {
            changetName.NAME = emploee.NAME;
            changetName.LASTNAME = emploee.LASTNAME;
            changetName.INFO = emploee.INFO;
        }

        public void SaveFileEmploee(Emploee changetName)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files|*.txt|All files|*.*";
            string saveFile = $"Name:{changetName.NAME}, Lastname:{changetName.NAME}, Info:{changetName.INFO}, Salary:{changetName.SALARY}";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, saveFile.ToString());
            }
        }
    }
}
