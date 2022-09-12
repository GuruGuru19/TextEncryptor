using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace TextEncryptor
{
    public partial class Form1 : Form
    {
        private bool keyValid = false;
        private string key = "";
        

        private FileHelper file;

        public Form1()
        {
            InitializeComponent();
        }

        public void UpdateInputs()
        {
            if (keyValid && file.IsEncrypted(key))// if the text after decryption has the flag it means: 1. the key is right 2. the file is encrypted
            {
                originalFileStatus.Text = "Encrypted";
                originalFileStatus.ForeColor = Color.DarkGreen;
                
            }
            else
            {
                originalFileStatus.Text = "Normal";
                originalFileStatus.ForeColor = Color.DarkRed;
            }
            if (keyValid)//if the key is valid
            {
                if (file.IsEncrypted(key))//and the file has a flag after decryption -> gives the option to decrypt
                {
                    o_decrypt_button.Enabled = true;
                    o_encrypt_button.Enabled = false;
                }
                else//the file doesnt have a flag after decryption (un-encrypted file) -> gives the option to encrypt
                {
                    o_decrypt_button.Enabled = false;
                    o_encrypt_button.Enabled = true;
                }
            }
            else
            {
                o_decrypt_button.Enabled = false;
                o_encrypt_button.Enabled = false;
            }

            textValueBox.Enabled = file.Exists(); //if the path is valid (pointing to a .txt file) -> enable the text box
            if (keyValid)
            {
                save_Button.Enabled = file.Exists() && ((file.IsEncrypted(key) && keyValid) || (!file.IsEncrypted(key))); //pointing to a editable file -> enable the save option

                save_Button.Enabled = textValueBox.Text != file.GetRealText(key).Replace(FileHelper.flag, "");// changes from last save? -> enable the save option
            }
            else
            {
                save_Button.Enabled = textValueBox.Text != file.GetFileText();// changes from last save? -> enable the save option
            }

            original_button.Enabled = save_Button.Enabled;//if you can save changes it means you can also revert them

            if (save_Button.Enabled) // you cant encrypt with unsaved text
            {
                o_decrypt_button.Enabled = false;
                o_encrypt_button.Enabled = false;
            }

        }

        public void UpdateText()
        {
            if (!file.Exists() || !keyValid)// in cases we dont need to look for an encrypted file
            {
                textValueBox.Text = file.GetFileText();
                return;
            }

            //string filePath = filePath_textBox.Text;
            //string[] fileTextLines = File.ReadAllLines(filePath);//gets the lines of text from the .txt file

            //fileText = string.Join("", fileTextLines);//updates the 'fileText'

            //string text = string.Join("\r\n", fileTextLines);// builds the presentable text

            //if (fileEncrypted && keyValid)// if we can decrypt then we do it
            //{
            //    text = Encryptor.Decrypt(fileText, key, IV);
            //}
            //realText = text;// updates the 'realText'
            
            textValueBox.Text = file.GetRealText(key).Replace(FileHelper.flag, "");//TODO: here
            
        }

        private void LocateFile_Button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog1.ShowDialog(this); // opens the LocateFile dialog and updates the 'filePath_textBox.Text'
            if (dialogResult == DialogResult.OK)
            {
                filePath_textBox.Text = openFileDialog1.FileName;
            }
        }

        private void FilePath_TextBox_TextChanged(object sender, EventArgs e)//controlls the pathStatusLable and updates the 'pathValid'
        {
            file = new FileHelper(filePath_textBox.Text);
            if (file.Exists())
            {
                if (filePath_textBox.Text.Contains(".txt"))
                {
                    pathStatus.Text = "file found";
                    pathStatus.ForeColor = Color.DarkGreen;
                }
                else
                {
                    pathStatus.Text = "path needs to lead to a .txt file";
                    pathStatus.ForeColor = Color.DarkRed;
                }
            }
            else
            {
                pathStatus.Text = "Invalid path";
                pathStatus.ForeColor = Color.DarkRed;
            }
            UpdateInputs();
            UpdateText();
        }


        private void save_Button_Click(object sender, EventArgs e)
        {
            if (textValueBox.Text.Contains(FileHelper.flag))
            {

                //cant save text with flag in it
                return;
            }
            if (file.Exists())
            {
                if (keyValid && file.IsEncrypted(key))
                {
                    string textInBox = textValueBox.Text;
                    textInBox += FileHelper.flag;
                    string encryptedData = Encryptor.Encrypt(textInBox, key, FileHelper.IV);
                    file.SetFileText(encryptedData);
                }
                else if (keyValid && !file.IsEncrypted(key))
                {
                    string textInBox = textValueBox.Text;
                    file.SetFileText(textInBox);
                }
                else if (!keyValid)
                {
                    string textInBox = textValueBox.Text;
                    file.SetFileText(textInBox);
                }
            }
            UpdateInputs();
        }

        private void original_button_Click(object sender, EventArgs e)
        {
            if (!keyValid)// if the key is not valid we cant use 'GetRealText(key)'
            {
                textValueBox.Text = file.GetFileText();
            }
            textValueBox.Text = file.GetRealText(key).Replace(FileHelper.flag, "");
        }

        private void o_decrypt_button_Click(object sender, EventArgs e)
        {
            if (file.Exists() && keyValid && file.IsEncrypted(key))
            {
                string newText = file.GetRealText(key).Replace(FileHelper.flag, "");
                file.SetFileText(newText);
                new Alert("File successfully Decrypted");
            }
            else
            {
                o_decrypt_button.Enabled = false;
                new Alert("File was unable to Decrypt");
            }
            UpdateInputs();
            UpdateText();
        }

        private void o_encrypt_button_Click(object sender, EventArgs e)
        {
            if (file.Exists() && keyValid && !file.IsEncrypted(key))
            {
                string textToEncrypt = file.GetFileText() + FileHelper.flag;
                string newText = Encryptor.Encrypt(textToEncrypt, key, FileHelper.IV);
                file.SetFileText(newText);
                new Alert("File successfully Encrypted");
            }
            else
            {
                o_encrypt_button.Enabled = false;
                new Alert("File was unable to Encrypt");
            }
            UpdateInputs();
            UpdateText();
        }

        private void textValueBox_TextChanged(object sender, EventArgs e)
        {
            UpdateInputs();
        }

        private void key_textBox_TextChanged(object sender, EventArgs e)
        {
            if (key_textBox.Text.Length == 0)
            {
                key = "";
                keyValid = false;
                keyStatus.Text = "select key";
                keyStatus.ForeColor = Color.Black;
            }
            else if (key_textBox.Text.Length>16)
            {
                key = "";
                keyValid = false;
                keyStatus.Text = "key needs to be 16 char max length";
                keyStatus.ForeColor = Color.DarkRed;
            }
            else if (key_textBox.Text.Length<16)
            {
                string add = "";
                for (int i = 0; i < (16-key_textBox.Text.Length); i++)
                {
                    add += " ";
                }
                key = key_textBox.Text + add;
                keyValid = true;
                keyStatus.Text = "key valid";
                keyStatus.ForeColor = Color.DarkGreen;
            }
            else
            {
                key = key_textBox.Text;
                keyValid = true;
                keyStatus.Text = "key valid";
                keyStatus.ForeColor = Color.DarkGreen;
            }
            UpdateInputs();
            UpdateText();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
