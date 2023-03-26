using Lab2CSharp.Tools;
using Lab2CSharp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lab2CSharp.ViewModel
{
    internal class PersonViewModel
    {
        private Person _person;

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate = DateTime.Today;

        private RelayCommand<object> _proceedCommand;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public DateTime BirthDate
        {
            get
            {
                return (_birthDate);
            }
            set
            {
                _birthDate = value;
            }
        }
        private Person Person
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;

            }
        }

        private async void ShowResult(object obj)
        {
            await Task.Run(() =>
            {
                try
                {
                    _person = new Person(Name, Surname, Email, BirthDate);

                    DateTime today = DateTime.Today;
                    int years = today.Year - BirthDate.Year;

                    if (years < 0 || years > 135) MessageBox.Show("Illegal date!");
                    if (Person.IsBirthday) MessageBox.Show("Happy Birthday!");

                    MessageBox.Show(
                        $"Adult: {_person.IsAdult}\n" +
                        $"WesternZodiac: {_person.WesternZodiac}\n" +
                        $"ChineseZodiac: {_person.ChineseZodiac}"
                                    );

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            });
        }


        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_name) && !string.IsNullOrWhiteSpace(_surname) && !string.IsNullOrWhiteSpace(_email);
        }

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ??= (_proceedCommand = new RelayCommand<object>(ShowResult, o => CanExecuteCommand()));
            }
        }
    } 
}
