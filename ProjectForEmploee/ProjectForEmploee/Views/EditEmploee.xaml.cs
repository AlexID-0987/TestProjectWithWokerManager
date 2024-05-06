using ProjectForEmploee.Models;
using ProjectForEmploee.Services;
using ProjectForEmploee.Views;
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

namespace ProjectForEmploee.ViewModel
{
    /// <summary>
    /// Interaction logic for EditEmploee.xaml
    /// </summary>
    public partial class EditEmploee : Window
    {
        MainView main;
        ServicesCrudEmploees servicesCrudEmploees = new ServicesCrudEmploees();
        private string NameEmploee { get; set; }
        private string LastNameEmploee { get; set; }
        private string LastSalary { get; set; }
        private DateTime DateTime { get; set; }
        public EditEmploee(MainView mainView)
        {
            InitializeComponent();
            this.main = mainView;
            
        }
        
        public void EditForEmploee(Emploee oneElement)
        {
            NameEmploee = oneElement.NAME;
            LastNameEmploee = oneElement.LASTNAME;
            LastSalary = Convert.ToString(oneElement.SALARY);
            GetName.Text = NameEmploee;
            GetLastName.Text = LastNameEmploee;
            GetSalary.Text = LastSalary;
            Date.Text = oneElement.Data.ToString();
            DateTime = oneElement.Data;
            Details.Text = oneElement.INFO;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = GetName.Text;
            string last = GetLastName.Text;
            string info = Details.Text;
            
            DateTime dateTime = DateTime;
            Emploee editEmploeeForMyList = new Emploee() { NAME=name,LASTNAME=last,INFO=info,Data=dateTime};
            main.EditEmploeeMyList(editEmploeeForMyList);
            this.Close();
        }

        
    }
}
