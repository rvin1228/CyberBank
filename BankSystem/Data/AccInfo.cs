using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace BankSystem.Data
{
    class AccInfo
    {
        static Account Cur;
        static int CurPosition;
        static FileStream FileStream;
        static BinaryReader Br;
        static BinaryWriter Bw;


        //Opens up Data.txt to get Account details of a user
        public static string OpenStreams()
        {
            try
            {
                FileStream = new FileStream("Data.txt", FileMode.Open, FileAccess.ReadWrite);
                Br = new BinaryReader(FileStream);
                Bw = new BinaryWriter(FileStream);
                return "Opened";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Adding user from system
        public static void AddUser(Account User)
        {
            int Position = 100 * HashFunction(User.EM.ToLower());
            FileStream.Seek(Position, SeekOrigin.Begin);
            while (Br.PeekChar() == 'T')
            {
                FileStream.Seek(100, SeekOrigin.Current);
            }
            Bw.Write('T');
            Bw.Write(User.EM);
            Bw.Write(User.Pass);
            Bw.Write(User.AccNumber);
            Bw.Write(User.FName);
            Bw.Write(User.LName);
            Bw.Write(User.Ctry);
            Bw.Write(User.DOB);
            Bw.Write(User.Sex);
            Bw.Write(User.Visa);
            Bw.Write(User.Phone);
            Bw.Write(User.Am);
            Bw.Flush();
        }

        //Checks if email is already registered
        public static bool Registered(string Email)
        {
            int Position = 100 * HashFunction(Email);
            FileStream.Seek(Position, SeekOrigin.Begin);
            while (Br.PeekChar() == 'T')
            {
                Br.ReadChar();
                if (Br.ReadString().ToLower() == Email)
                {
                    return false;
                }
                Position += 100;
                FileStream.Seek(Position, SeekOrigin.Begin);
            }
            return true;
        }

        //Verifies if the user's email and password is in the system
        public static bool LogInChecker(string Email, string Pass)
        {
            int Position = 100 * HashFunction(Email);
            FileStream.Seek(Position, SeekOrigin.Begin);
            while (Br.PeekChar() == 'T')
            {
                int Temp = Position;
                Br.ReadChar();
                if (Br.ReadString().ToLower() == Email && Br.ReadString() == Pass)
                {
                    Cur = new Account(Email, Pass, Br.ReadString(), Br.ReadString(), Br.ReadString(), Br.ReadString(), Br.ReadString(),
                                     Br.ReadString(), Br.ReadString(), Br.ReadString(), Br.ReadInt32());
                    CurPosition = Position;
                    AccountLogs.SetAdress(Temp);
                    return true;
                }
                Position += 100;
                FileStream.Seek(Position, SeekOrigin.Begin);
            }
            return false;
        }

        //Function for transferring money from another user
        public static bool Transfer(string RecieverEmail, int Amount)
        {
            long Temp = FileStream.Position;
            int Position = 100 * HashFunction(RecieverEmail);
            FileStream.Seek(Position, SeekOrigin.Begin);
            while (Br.PeekChar() == 'T')
            {
                Br.ReadChar();
                if (Br.ReadString().ToLower() == RecieverEmail)
                {
                    Br.ReadString(); Br.ReadString(); Br.ReadString(); Br.ReadString(); Br.ReadString();
                    Br.ReadString(); Br.ReadString(); Br.ReadString(); Br.ReadString();
                    int RecieverAmount = Br.ReadInt32();
                    RecieverAmount += Amount;
                    Bw.Seek(-4, SeekOrigin.Current);
                    Bw.Write(RecieverAmount);
                    FileStream.Position = Position;
                    return true;
                }
                Position += 100;
                FileStream.Seek(Position, SeekOrigin.Begin);
            }
            FileStream.Position = Position;
            return false;
        }

        //Reloads and Updates the account information
        public static void UpdateAccount()
        {
            Bw.Seek(-4, SeekOrigin.Current);
            Bw.Write(Cur.Am);
            Bw.Flush();
        }

        //Removes the account from the system
        public static void DeleteAccount()
        {
            Bw.Seek(CurPosition, SeekOrigin.Begin);
            Bw.Write('F');
        }

        //Closes the access from Data.txt
        public static bool CloseStreams()
        {
            try
            {
                Br.Close();
                Bw.Close();
                FileStream.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Hashes the information given for security
        private static int HashFunction(string Key)
        {
            long Postion = 0;
            long Power = 1;
            for (int i = 0; i < Key.Length; ++i)
            {
                Postion += Key[i] * Power;
                Power *= 2;
            }
            Postion %= 997;
            return (int)Postion;
        }
        public static Account Current { get { return Cur; } }
    }
}
