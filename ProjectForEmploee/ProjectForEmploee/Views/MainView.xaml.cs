using ProjectForEmploee.Models;
using ProjectForEmploee.Services;
using ProjectForEmploee.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectForEmploee.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\emloeeList.json";
        public BindingList<Emploee> toEmploee;
        private FileService fileServices;
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
                toEmploee = fileServices.FileEmploee();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            
            MyWindow.ItemsSource = toEmploee;
            VizibilityQuantity();
            Summma();
            toEmploee.ListChanged += ToEmploee_ListChanged;
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
            foreach (Emploee number in toEmploee)
            {
                SalarySum +=number.SALARY;
                Total= SalarySum / Emploee.COUNT;
                CountEmpl1.Text = $"Total summa salary: {SalarySum}, SVG = {Total}";
            }
            
        }
        
    }
}
