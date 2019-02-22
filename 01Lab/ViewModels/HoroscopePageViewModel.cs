using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using _01Rovnina.Tools;
using _01Rovnina.Tools.Manager;

namespace _01Rovnina.ViewModels
{
    internal class HoroscopePageViewModel : BaseViewModel
    {
        #region Fields
        private string _birthday;
        private int _age;
        private string _westernZodiac;
        private string _chineseZodiac;
        private readonly string[] _chineseZodiacs = { "Monkey", "Cock", "Dog", "Pig/Boar", "Rat", "Bull", "Tiger", "Cat/Rabbit", "Dragon", "Snake", "Horse", "Goat/Sheep" };


        #region Commands
        private RelayCommand<object> _countAgeCommand;
        private RelayCommand<object> _closeCommand;
        #endregion
        #endregion

        #region Properties

        public string Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public string WesternZodiac
        {
            get { return _westernZodiac; }
            set
            {
                _westernZodiac = value.Replace(" ", "Space");
                OnPropertyChanged();
            }
        }

        public string ChineseZodiac
        {
            get { return _chineseZodiac; }
            set
            {
                _chineseZodiac = value.Replace(" ", "Space");
                OnPropertyChanged();
            }
        }
        #endregion

        public RelayCommand<object> CountAgeCommand
        {
            get
            {
                return _countAgeCommand ?? (_countAgeCommand = new RelayCommand<object>(OperateAge));
            }
        }

        public RelayCommand<Object> CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(o => Environment.Exit(0)));
            }
        }


        //count age, count horoscope
        private async void OperateAge(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() => Thread.Sleep(2000));
            LoaderManager.Instance.HideLoader();

            //Error handling when the wrong date is entered
            DateTime birthday;
            try
            {
                birthday = Convert.ToDateTime(Birthday);
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter correct date!");
                return;
            }

            DateTime today = DateTime.Today;

            //count age
            if ((today.Month > birthday.Month) || (today.Month == birthday.Month && today.Day >= birthday.Day))
                Age = today.Year - birthday.Year;
            else
                Age = today.Year - birthday.Year - 1;

            //check age and return error message if it is wrong
            if (Age < 0 || Age > 135)
            {
                Age = 0;
                MessageBox.Show("Wrong age!");
                return;
            }

            //happy birthday message
            if (today.Month == birthday.Month && today.Day == birthday.Day)
                MessageBox.Show("Happy Birthday!");

            //horoscope
            WesternZodiac = getWesternZodiac(birthday);
            ChineseZodiac = _chineseZodiacs[birthday.Year % 12];
        }


        //define western zodiac
        private string getWesternZodiac(DateTime date)
        {
            if ((date.Month == 3 && date.Day >= 21) || (date.Month == 4 && date.Day <= 20))
                return "Aries";
            if ((date.Month == 4 && date.Day >= 21) || (date.Month == 5 && date.Day <= 20))
                return "Taurus";
            if ((date.Month == 5 && date.Day >= 21) || (date.Month == 6 && date.Day <= 21))
                return "Gemini";
            if ((date.Month == 6 && date.Day >= 22) || (date.Month == 7 && date.Day <= 22))
                return "Cancer";
            if ((date.Month == 7 && date.Day >= 23) || (date.Month == 8 && date.Day <= 23))
                return "Lion";
            if ((date.Month == 8 && date.Day >= 24) || (date.Month == 9 && date.Day <= 22))
                return "Virgo";
            if ((date.Month == 9 && date.Day >= 23) || (date.Month == 10 && date.Day <= 23))
                return "Libra";
            if ((date.Month == 10 && date.Day >= 24) || (date.Month == 11 && date.Day <= 22))
                return "Scorpio";
            if ((date.Month == 11 && date.Day >= 23) || (date.Month == 12 && date.Day <= 21))
                return "Sagittarius";
            if ((date.Month == 12 && date.Day >= 22) || (date.Month == 1 && date.Day <= 20))
                return "Capricorn";
            if ((date.Month == 1 && date.Day >= 21) || (date.Month == 2 && date.Day <= 20))
                return "Aquarius";

            return "Pisces";
        }
    }
}
