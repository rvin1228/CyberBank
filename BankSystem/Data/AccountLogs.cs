using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Data
{
    class AccountLogs
    {
        static FileStream fs;
        static BinaryReader br;
        static BinaryWriter bw;

        //Opens up the Logs.txt
        public static string OpenStreams()
        {
            try
            {
                fs = new FileStream("Logs.txt", FileMode.Open, FileAccess.ReadWrite);
                br = new BinaryReader(fs);
                bw = new BinaryWriter(fs);
                return "Opened";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Function part of Login
        public static void SetAdress(int Address)
        {
            fs.Seek(2 * Address, SeekOrigin.Begin);
        }

        //Collects the data from Logs.txt
        public static void GetLogs(DataGridView dg)
        {
            while (br.PeekChar() == '|')
            {
                br.ReadChar();
                dg.Rows.Add(br.ReadString(), br.ReadString(), br.ReadString());
            }
        }

        //Stores a transaction from the user
        public static void AddLog(string s1, string s2, string s3)
        {
            bw.Write('|');
            bw.Write(s1);
            bw.Write(s2);
            bw.Write(s3);
            bw.Flush();
        }

        //Closes access from Logs.txt
        public static bool CloseStreams()
        {
            try
            {
                br.Close();
                bw.Close();
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
