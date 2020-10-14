using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Data
{
    class Account
    {
        protected readonly string AccNum, FirstName, LastName, BirthDate, Email, Country, VisaCard, Password, Mobile, Gender;
        protected int Balance = 100;

        //Collects the information from a registering user
        public Account(string Email, string Password, string AccNum, string FirstName, string LastName, string Country, string BirthDate, string Gender, string VisaCard, string Mobile, bool Vip)
        {
            this.AccNum = AccNum;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.VisaCard = VisaCard;
            this.Email = Email;
            this.Country = Country;
            this.BirthDate = BirthDate;
            this.Gender = Gender;
            this.Password = Password;
            this.Mobile = Mobile;
            if (Vip) Balance = 300;
        }
        
        //Also collects information with balance included
        public Account(string Email, string Password, string AccNum, string FirstName, string LastName, string Country, string BirthDate, string Gender, string VisaCard, string Mobile, int balance)
        {
            this.AccNum = AccNum;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.VisaCard = VisaCard;
            this.Email = Email;
            this.Country = Country;
            this.BirthDate = BirthDate;
            this.Gender = Gender;
            this.Password = Password;
            this.Mobile = Mobile;
            this.Balance = balance;
        }

        public string AccNumber
        {
            get { return AccNum; }
        }
        public string FName
        {
            get { return FirstName; }
        }
        public string LName
        {
            get { return LastName; }
        }
        public string EM
        {
            get { return Email; }
        }
        public string Ctry
        {
            get { return Country; }
        }
        public string DOB
        {
            get { return BirthDate; }
        }
        public string Pass
        {
            get { return Password; }
        }
        public string Visa
        {
            get { return VisaCard; }
        }
        public string Phone
        {
            get { return Mobile; }
        }
        public int Am
        {
            set { Balance = value; }
            get { return Balance; }
        }
        public string Sex
        {
            get { return Gender; }
        }
    }
}
