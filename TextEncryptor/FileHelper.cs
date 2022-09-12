using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEncryptor
{
    internal class FileHelper
    {
        private string fileText;
        //private string un_encryptedText;

        private string path;

        //private bool pathValid;
        //private bool fileEncrypted;

        public static byte[] IV = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public const string flag = "!@#$%^&*()";// the flag helps not accidentally de\en-crypting a file twice

        public FileHelper(string path)
        {
            this.path = path;
            UpdateFileText();
        }

        public bool Exists()
        {
            return File.Exists(path);
        }

        public string GetFileText()
        {
            UpdateFileText();
            return fileText;
        }

        public string GetRealText(string key)
        {
            string text = fileText;
            try
            {
                string decrypted = Encryptor.Decrypt(text, key, IV);
                if (decrypted.Contains(flag))
                {
                    text = decrypted;
                }
            }
            catch (System.FormatException)
            {

                //throw;
            }
            catch (System.Security.Cryptography.CryptographicException)// wrong key
            {

            }

            return text;
        }

        public bool IsEncrypted(string key)
        {
            string text = fileText;
            try
            {
                string decrypted = Encryptor.Decrypt(text, key, IV);
                return decrypted.Contains(flag);
            }
            catch (System.FormatException)
            {
                
                return false; // IDK
                throw;
            }
            catch (System.Security.Cryptography.CryptographicException)
            {
                return false;// wrong key
            }
            
        }

        public void UpdateFileText()
        {
            if (File.Exists(path))
            {
                fileText = File.ReadAllText(path);
            }
            else
            {
                fileText = "";
            }
        }

        public void SetFileText(string text)
        {
            File.WriteAllText(path, text);
            UpdateFileText();
        }
    }
}
