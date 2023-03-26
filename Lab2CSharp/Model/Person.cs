using Lab2CSharp.Tools.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lab2CSharp.Model
{
    internal class Person
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;

        private readonly bool _isAdult;
        private readonly string _westernZodiac;
        private readonly string _chineseZodiac;
        private readonly bool _isBirthday;

        public Person(string name, string surname, string email, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            Email = email;
            BirthDate = birthDate;
            
            _isBirthday = CheckBirthday();
            _isAdult = CheckAdult();
            _westernZodiac = GetWesternZodiac();
            _chineseZodiac = GetChineseZodiac();
        }
        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }
        public Person(string name, string surname, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;

            _isBirthday = CheckBirthday();
            _isAdult = CheckAdult();
            _westernZodiac = GetWesternZodiac();
            _chineseZodiac = GetChineseZodiac();
        }

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
                Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                if (!regex.IsMatch(value)) throw new InvalidEmailExeption(value);
                _email = value;
            }
        }
        public DateTime BirthDate
        {
            get 
            { 
                return _birthDate; 
            }
            set
            {
                if (DateTime.Today < value) throw new FutureBirthDateException(value);
                else if (new DateTime(DateTime.Today.Subtract(value).Ticks).Year > 135) throw new OldBirthDateException(value);
                _birthDate = value;
            }
        }

        public bool IsAdult
        {
            get
            {
                return _isAdult;
            }
        }
        public bool IsBirthday
        {
            get
            {
               return _isBirthday;
            }          
        }

        public string ChineseZodiac
        {
            get
            {
                return _chineseZodiac;
            }
        }

        public string WesternZodiac
        {
            get
            {
                return _westernZodiac;
            }
        }

        private bool CheckBirthday()
        {
            return DateTime.Today.Month == _birthDate.Month && DateTime.Today.Day == _birthDate.Day;
        }

        private bool CheckAdult()
        {
            int years = DateTime.Today.Year - BirthDate.Year;

            if(years >= 18) 
            { 
                return true; 
            }
            else 
            {
                return false;
            }
        }

        private string GetWesternZodiac()
        {
            switch (_birthDate.Month)
                {
                case 1:
                    if (_birthDate.Day <= 20) 
                        return "Capricorn";
                    else
                        return "Aquarius";

                case 2:
                    if (_birthDate.Day <= 19)
                        return "Aquarius";
                    else
                        return "Pisces";

                case 3:
                    if (_birthDate.Day <= 20)
                        return "Pisces";
                    else
                        return "Aries";

                case 4:
                    if (_birthDate.Day <= 20)
                        return "Aries";
                    else
                        return "Taurus";

                case 5:
                    if (_birthDate.Day <= 21)
                        return "Taurus";
                    else
                        return "Gemini";

                case 6:
                    if (_birthDate.Day <= 22)
                        return "Gemini";
                    else
                        return "Cancer";

                case 7:
                    if (_birthDate.Day <= 22)
                        return "Cancer";
                    else
                        return "Leo";

                case 8:
                    if (_birthDate.Day <= 23)
                        return "Leo";
                    else
                        return "Virgo";

                case 9:
                    if (_birthDate.Day <= 23)
                        return "Virgo";
                    else
                        return "Libra";

                case 10:
                    if (_birthDate.Day <= 23)
                        return "Libra";
                    else
                        return "Scorpio";

                case 11:
                    if (_birthDate.Day <= 22)
                        return "Scorpio";
                    else
                        return "Sagittarius";

                case 12:
                    if (_birthDate.Day <= 21)
                        return "Sagittarius";
                    else
                        return "Capricorn";
                default:
                    return "Error!";
            }
        }
    
        private string GetChineseZodiac()
        {
            int x = _birthDate.Year;
            int a = _birthDate.Month;
            int b = _birthDate.Day;
            int y = _birthDate.Year - 4;
            int z = (_birthDate.Year - 4) % 12;
            switch (z)
            {
                case 0:
                    return "Rat";

                case 1:
                    return "Ox";

                case 2:
                    return "Tiger";

                case 3:
                    return "Rabbit";

                case 4:
                    return "Dragon";

                case 5:
                    return "Snake";

                case 6:
                    return "Horse";

                case 7:
                    return "Goat";

                case 8:
                    return "Monkey";

                case 9:
                    return "Rooster";

                case 10:
                    return "Dog";

                case 11:
                    return "Pig";

                default:
                    return "Error!";
            }
        }
    }
}
