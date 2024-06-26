﻿using Microsoft.Win32;
using ProjectForEmploee.Models;
using ProjectForEmploee.Services;
using ProjectForEmploee.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ProjectForEmploee.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    /// //Зберігаємо данні у файлі Json, розташованої у папці бин. Отримання данних, видалення, додавання відбувається через інтерфейс грида.
    /// У горі відображається статистика данних.
    /// відповідні кнопки створюють CRUD операції з нашщю колекцією, також зберігають у файл.
    /// у другому проєкті - Unit test.
    public partial class MainView : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\emloeeList.json";
        

        public Emploee SelecnedEmploee { get; set; }
        EditEmploee EditEmploee;
        ServicesCrudEmploees myListEmploee = new ServicesCrudEmploees();
        private FileService fileServices;
        
        ServicesCrudEmploees servicesCrudEmploees = new ServicesCrudEmploees();
        MainViewModel MainViewModel = new MainViewModel();
        public MainView()
        {
            InitializeComponent();
            this.DataContext = MainViewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fileServices = new FileService(PATH);
            try
            {
                myListEmploee.toEmploee = fileServices.FileEmploee();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            
            MyWindow.ItemsSource = myListEmploee.toEmploee;
            VizibilityQuantity();
            Summma();
           myListEmploee.toEmploee.ListChanged += ToEmploee_ListChanged;
            
        }

        private void ToEmploee_ListChanged(object sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType==ListChangedType.ItemAdded||e.ListChangedType==ListChangedType.ItemChanged||e.ListChangedType==ListChangedType.ItemDeleted)
            {
                try
                {
                    fileServices.SaveFile(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
            
        }
        public void VizibilityQuantity()
        {
            
            string countEmploees = Convert.ToString(Emploee.COUNT);
            
            CountEmpl.Text = $"Quantity emploees: {countEmploees}";
        }
        public void Summma()
        {
            Emploee emploee = new Emploee();
            double SalarySum=0;
            double Total = 0; 
            foreach (Emploee number in myListEmploee.toEmploee)
            {
                SalarySum +=number.SALARY;
                Total= SalarySum / Emploee.COUNT;
                CountEmpl1.Text = $"Total summa salary: {SalarySum}, SVG = {Total}";
            }
            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            AddEmploee addEmploee = new AddEmploee(this);
            addEmploee.ShowDialog();
            
        }
        public void Configure(Emploee emp)
        {
            myListEmploee.AddToEmploeeList(emp);

        }

        public void EditEmploeeMyList(Emploee emploee)
        {
            Emploee changetName = MyWindow.SelectedItem as Emploee;
            myListEmploee.EditMyList(emploee, changetName);

        }

        public Emploee changetEmplooeInWindows()
        {
           
           Emploee changetPersonInWindows = MyWindow.SelectedItem as Emploee;
           return changetPersonInWindows;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Emploee changetName = MyWindow.SelectedItem as Emploee;
            EditEmploee editEmploee = new EditEmploee(this);
            editEmploee.EditForEmploee(changetName);
            editEmploee.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Emploee changetName = MyWindow.SelectedItem as Emploee;
            myListEmploee.toEmploee.Remove(changetName);
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
            using (StreamWriter writer = new StreamWriter(@"C:\temp\MyTextFile.txt"))
            {
                if(myListEmploee.toEmploee.Count==0)
                {
                    MessageBox.Show("Your list- empty!");
                }
                else
                {
                    foreach (Emploee myList in myListEmploee.toEmploee)
                    {
                        writer.WriteLine($"\t{myList.NAME},|{myList.LASTNAME},|{myList.STATUS}|{myList.SALARY}|{myList.INFO}|{myList.EMPLOEEPOZITIONS}|{myList.Data}");
                    }
                }
                
            }
        }
    }
}
