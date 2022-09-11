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
        private bool pathValid = false;
        private bool keyValid = false;
        private bool fileEncrypted = false;

        private string key = "";
        private static byte[] IV = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public const string flag = "!@#$%^&*()";

        private string realText = "";
        private string fileText = "";

        public Form1()
        {
            InitializeComponent();
        }

        public void UpdateInputs()
        {
            if (realText.Contains(flag))
            {
                fileEncrypted = true;
                originalFileStatus.Text = "Encrypted";
                originalFileStatus.ForeColor = Color.DarkGreen;
                
            }
            else
            {
                fileEncrypted = false;
                originalFileStatus.Text = "Normal";
                originalFileStatus.ForeColor = Color.DarkRed;
            }
            if (keyValid)
            {
                if (fileEncrypted)
                {
                    o_decrypt_button.Enabled = true;
                    o_encrypt_button.Enabled = false;
                }
                else
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

            textValueBox.Enabled = pathValid;

            save_Button.Enabled = pathValid && ((fileEncrypted && keyValid) || (!fileEncrypted));

            string temp = realText;
            if (textValueBox.Text == temp.Replace(flag, ""))
            {
                save_Button.Enabled = false;
            }
            else
            {
                save_Button.Enabled = true;
            }
        }

        public void UpdateText()
        {
            if (!pathValid)
            {
                textValueBox.Text = "";
                return;
            }

            string filePath = filePath_textBox.Text;
            string[] fileTextLines = File.ReadAllLines(filePath);

            fileText = string.Join("", fileTextLines);

            string text = string.Join("\r\n", fileTextLines);

            if (fileEncrypted && keyValid)
            {
                text = Encryptor.Decrypt(fileText, key, IV);
            }
            realText = text;

            string temp = realText;
            textValueBox.Text = temp.Replace(flag, "");
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LocateFile_Button_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog1.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                filePath_textBox.Text = openFileDialog1.FileName;
            }
        }

        private void FilePath_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(filePath_textBox.Text))
            {
                if (filePath_textBox.Text.Contains(".txt"))
                {
                    pathValid = true;
                    pathStatus.Text = "file found";
                    pathStatus.ForeColor = Color.DarkGreen;
                }
                else
                {
                    pathValid = false;
                    pathStatus.Text = "path needs to lead to a .txt file";
                    pathStatus.ForeColor = Color.DarkRed;
                }
            }
            else
            {
                pathValid = false;
                pathStatus.Text = "Invalid path";
                pathStatus.ForeColor = Color.DarkRed;
            }
            UpdateInputs();
            UpdateText();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void save_Button_Click(object sender, EventArgs e)
        {
            if (textValueBox.Text.Contains(flag))
            {

                //cant save text with flag in it
                return;
            }
            if (pathValid)
            {
                if (keyValid && fileEncrypted)
                {
                    string textInBox = textValueBox.Text;
                    textInBox += flag;
                    string encryptedData = Encryptor.Encrypt(textInBox, key, IV);
                    File.WriteAllText(filePath_textBox.Text, encryptedData);
                    realText = textInBox;
                    fileText = encryptedData;
                }
                else if (!fileEncrypted)
                {
                    string textInBox = textValueBox.Text;
                    File.WriteAllText(filePath_textBox.Text, textInBox);
                    realText = textInBox;
                    fileText = textInBox;
                }
            }
            
            UpdateInputs();
            //save_Button.Enabled = false;
        }

        private void original_button_Click(object sender, EventArgs e)
        {

        }

        private void o_decrypt_button_Click(object sender, EventArgs e)
        {

        }

        private void o_encrypt_button_Click(object sender, EventArgs e)
        {

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
                return;
            }
            if (key_textBox.Text.Length>16)
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
    }
}
