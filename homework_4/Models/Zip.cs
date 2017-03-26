using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;


namespace Homework_4.Models
{
    class Zip : IDataErrorInfo, INotifyPropertyChanged
    {
        private string zipCode = string.Empty;
        private string patternUSmin = @"^[1-9][0-9]{4}$";
        private string patternUSmax = @"^[1-9][0-9]{4}-[0-9]{4}$";
        private string patternCAN = @"^[A-Z][1-9][A-Z][1-9][A-Z][1-9]$";
        private string zipError;
        private bool validZip;


        // ToString method
        public override string ToString()
        {
            return zipCode;
        }

        // zipCode Property
        public string ZipCode
        {
            get
            {
                return zipCode;
            }
            set
            {
                if(zipCode != value)
                {
                    zipCode = value;
                    OnPropertyChanged("ZipCode");
                }
            }
        }

        // zipError Property
        public string ZipError
        {
            get
            {
                return zipError;
            }
            set
            {
                if (zipError != value)
                {
                    zipError = value;
                    OnPropertyChanged("ZipError");
                }
            }
        }

        public bool ValidZip
        {
            get
            {
                return validZip;
            }
            set
            {
                validZip = value;
                OnPropertyChanged("ValidZip");
            }
        }

        // Part of the IDataErrorInfo interface
        // IDataErrorInfo required implimentation, returns the ZipError 
        public string Error
        {
            get
            {
                return ZipError;
            }
        }
        

        // Part of the IDataErrorInfo interface
        // Called when ValidatesOnDataError = True
        // This is where validation occurs
        public string this[string columnName]
        {
            get
            {
                ZipError = "";
                ValidZip = true;
                switch (columnName)
                {
                    case "ZipCode":
                        {
                            if ( (!Regex.IsMatch(zipCode, patternUSmin)) && (!Regex.IsMatch(zipCode, patternUSmax)) && (!Regex.IsMatch(zipCode, patternCAN)) )
                            {
                                ZipError = "Not a Valid Zip Code!";
                                ValidZip = false;
                            }
                        }
                        break;
                }
                return ZipError;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
