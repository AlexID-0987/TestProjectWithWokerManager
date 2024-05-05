using ProjectForEmploee.Infrastructure;
using System;


namespace ProjectForEmploee.Models
{
    public class Emploee:BaseNotifyPropertyChange
    {
        
        private string Name;
        private string LastName;
        private string Info;
        private static int Count;
        private double Salary;
        private static double SummaCounter;
        
        public string NAME
        {
            get { return Name; }
            set
            {
                if (value != null)
                {
                    Name = value;
                    NotifyOfPropertyChanged(NAME);
                }
                else
                {
                    Name = null;
                    
                }
            }
        }
        public string LASTNAME
        {
            get { return LastName; }
            set
            {
                if (value != null)
                {
                    LastName = value;
                    NotifyOfPropertyChanged(LASTNAME);
                }
                else
                {
                    LastName = null;
                    
                }
            }
        }

        public ChangetPozitions.EmploeePozitions EMPLOEEPOZITIONS { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;
        
        public ChangetStatus.Status STATUS { get; set; }
        public double SALARY
        {
            get { return Salary; }
            set { Salary = value; }
        }

        public string INFO
        {
            get { return Info; }
            set
            {
                if (value != null)
                {
                    Info = value;

                }
                else
                {
                    Info = null;
                }
            }
        }
        public static int COUNT
        {
            get { return Count; }
            set { Count = value; }
        }
        public static double SUMMACOUNTER
        {
            get { return SummaCounter; }
            set
            {
                if (value != 0)
                {
                    SummaCounter = value;

                }
                else
                {
                    SummaCounter = 0;

                }
            }
        }
        public Emploee()
        {
            Count++;
            
        }
    }
}
