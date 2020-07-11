using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Hash_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtFile.Text = Application.ExecutablePath;
        }
        private void label7_Click(object sender, EventArgs e)
        {
            
        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
            
        }
        public static string SHA1Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            SHA1CryptoServiceProvider sha1provider = new SHA1CryptoServiceProvider();
            byte[] bytes = sha1provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();

        }
        public static string SHA256Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            SHA256CryptoServiceProvider sha256provider = new SHA256CryptoServiceProvider();
            byte[] bytes = sha256provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();

        }
        public static string SHA512Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            SHA512CryptoServiceProvider sha512provider = new SHA512CryptoServiceProvider();
            byte[] bytes = sha512provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (tb1.Text == "")
            {
                lbl1.Text = "Please enter the text";
            }
            else
            {
                lbl1.Text = " ";

                if (txt_salt.Text == "")
                {
            
                    string text = tb1.Text;
                                       
                    String  retunvalue_md5 = MD5Hash(text);
                    String retunvalue_sha1 = SHA1Hash(text);
                    String retunvalue_sha256 = SHA256Hash(text);
                    String retunvalue_sha512 = SHA512Hash(text);

                    txt_md5.Text = retunvalue_md5.ToString();
                    txt_sha1.Text = retunvalue_sha1.ToString();
                    txt_sha256.Text = retunvalue_sha256.ToString();
                    txt_sha512.Text = retunvalue_sha512.ToString();
                }
                else
                {
                    String salt = txt_salt.Text;

                    string text_all = string.Concat(tb1.Text, salt);

                    String retunvalue_md5 = MD5Hash(text_all);
                    String retunvalue_sha1 = SHA1Hash(text_all);
                    String retunvalue_sha256 = SHA256Hash(text_all);
                    String retunvalue_sha512 = SHA512Hash(text_all);

                    txt_md5.Text = retunvalue_md5.ToString();
                    txt_sha1.Text = retunvalue_sha1.ToString();
                    txt_sha256.Text = retunvalue_sha256.ToString();
                    txt_sha512.Text = retunvalue_sha512.ToString();

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
             OpenFileDialog dialog = new OpenFileDialog();
          //  dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.InitialDirectory = "C:\\";
            dialog.Title = "Select a text file";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fname = dialog.FileName;
                txtFile.Text = fname.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtmd5.Text = BytesToString(GetHashMD5(txtFile.Text));
            txtsha1.Text = BytesToString(GetHashSha1(txtFile.Text));
            txtsha256.Text = BytesToString(GetHashSha256(txtFile.Text));
            txtsha512.Text = BytesToString(GetHashSha512(txtFile.Text)); 
        }

        // The cryptographic service provider.
        private MD5 Md5 = MD5.Create();
        private SHA1 Sha1 = SHA1.Create();
        private SHA256 Sha256 = SHA256.Create();
        private SHA512 Sha512 = SHA512.Create();

        // Compute the file's hash using md5
        private byte[] GetHashMD5(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Md5.ComputeHash(stream);
            }
        }

        // Compute the file's hash using sha1
        private byte[] GetHashSha1(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Sha1.ComputeHash(stream);
            }
        }

        // Compute the file's hash using sha256
        private byte[] GetHashSha256(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Sha256.ComputeHash(stream);
            }
        }

        // Compute the file's hash using sha512
        private byte[] GetHashSha512(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Sha512.ComputeHash(stream);
            }
        }
        
        // Return a byte array as a sequence of hex values.
        public static string BytesToString(byte[] bytes)
        {
            string result = "";
            foreach (byte b in bytes) result += b.ToString("x2");
            return result;
        }

      
    }
}
