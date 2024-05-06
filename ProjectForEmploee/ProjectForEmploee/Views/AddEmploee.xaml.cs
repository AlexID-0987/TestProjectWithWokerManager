using ProjectForEmploee.Models;
using ProjectForEmploee.Services;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddEmploee.xaml
    /// </summary>
    public partial class AddEmploee : Window
    {
        MainView MainViewWindow;
        ServicesCrudEmploees servicesCrudEmploees = new ServicesCrudEmploees();
        
        public AddEmploee(MainView mainView)
        {
            InitializeComponent();
            this.MainViewWindow = mainView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string NameItem = Name.Text;
            string lastname = LastName.Text;
            double salary = Convert.ToDouble(Salary.Text);
            string info = Info.Text;
            Emploee emploee = new Emploee() { NAME = NameItem, LASTNAME = lastname, SALARY = salary, INFO = info };
            MainViewWindow.Configure(emploee);
            this.Close();
            
            
            
        }
    }
}
