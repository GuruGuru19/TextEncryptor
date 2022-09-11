namespace TextEncryptor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.filePath_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LocateFile_Button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textValueBox = new System.Windows.Forms.TextBox();
            this.pathStatus = new System.Windows.Forms.Label();
            this.save_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.key_textBox = new System.Windows.Forms.TextBox();
            this.original_button = new System.Windows.Forms.Button();
            this.keyStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.originalFileStatus = new System.Windows.Forms.Label();
            this.o_decrypt_button = new System.Windows.Forms.Button();
            this.o_encrypt_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filePath_textBox
            // 
            this.filePath_textBox.Location = new System.Drawing.Point(94, 26);
            this.filePath_textBox.Name = "filePath_textBox";
            this.filePath_textBox.Size = new System.Drawing.Size(313, 20);
            this.filePath_textBox.TabIndex = 0;
            this.filePath_textBox.TextChanged += new System.EventHandler(this.FilePath_TextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File Path";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // LocateFile_Button
            // 
            this.LocateFile_Button.Location = new System.Drawing.Point(413, 24);
            this.LocateFile_Button.Name = "LocateFile_Button";
            this.LocateFile_Button.Size = new System.Drawing.Size(23, 23);
            this.LocateFile_Button.TabIndex = 2;
            this.LocateFile_Button.UseVisualStyleBackColor = true;
            this.LocateFile_Button.Click += new System.EventHandler(this.LocateFile_Button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // textValueBox
            // 
            this.textValueBox.Enabled = false;
            this.textValueBox.Location = new System.Drawing.Point(12, 139);
            this.textValueBox.Multiline = true;
            this.textValueBox.Name = "textValueBox";
            this.textValueBox.Size = new System.Drawing.Size(763, 555);
            this.textValueBox.TabIndex = 3;
            this.textValueBox.TextChanged += new System.EventHandler(this.textValueBox_TextChanged);
            // 
            // pathStatus
            // 
            this.pathStatus.AutoSize = true;
            this.pathStatus.Location = new System.Drawing.Point(442, 29);
            this.pathStatus.Name = "pathStatus";
            this.pathStatus.Size = new System.Drawing.Size(56, 13);
            this.pathStatus.TabIndex = 4;
            this.pathStatus.Text = "Select File";
            // 
            // save_Button
            // 
            this.save_Button.Enabled = false;
            this.save_Button.Location = new System.Drawing.Point(13, 110);
            this.save_Button.Name = "save_Button";
            this.save_Button.Size = new System.Drawing.Size(75, 23);
            this.save_Button.TabIndex = 5;
            this.save_Button.Text = "SAVE";
            this.save_Button.UseVisualStyleBackColor = true;
            this.save_Button.Click += new System.EventHandler(this.save_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "encryption key";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // key_textBox
            // 
            this.key_textBox.Location = new System.Drawing.Point(94, 51);
            this.key_textBox.Name = "key_textBox";
            this.key_textBox.Size = new System.Drawing.Size(313, 20);
            this.key_textBox.TabIndex = 7;
            this.key_textBox.TextChanged += new System.EventHandler(this.key_textBox_TextChanged);
            // 
            // original_button
            // 
            this.original_button.Enabled = false;
            this.original_button.Location = new System.Drawing.Point(94, 110);
            this.original_button.Name = "original_button";
            this.original_button.Size = new System.Drawing.Size(75, 23);
            this.original_button.TabIndex = 8;
            this.original_button.Text = "ORIGINAL";
            this.original_button.UseVisualStyleBackColor = true;
            this.original_button.Click += new System.EventHandler(this.original_button_Click);
            // 
            // keyStatus
            // 
            this.keyStatus.AutoSize = true;
            this.keyStatus.Location = new System.Drawing.Point(442, 54);
            this.keyStatus.Name = "keyStatus";
            this.keyStatus.Size = new System.Drawing.Size(58, 13);
            this.keyStatus.TabIndex = 9;
            this.keyStatus.Text = "Select Key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(665, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "original file:";
            // 
            // originalFileStatus
            // 
            this.originalFileStatus.AutoSize = true;
            this.originalFileStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.originalFileStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.originalFileStatus.Location = new System.Drawing.Point(675, 71);
            this.originalFileStatus.Name = "originalFileStatus";
            this.originalFileStatus.Size = new System.Drawing.Size(96, 19);
            this.originalFileStatus.TabIndex = 11;
            this.originalFileStatus.Text = "Normal text";
            // 
            // o_decrypt_button
            // 
            this.o_decrypt_button.Enabled = false;
            this.o_decrypt_button.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.o_decrypt_button.Location = new System.Drawing.Point(655, 17);
            this.o_decrypt_button.Name = "o_decrypt_button";
            this.o_decrypt_button.Size = new System.Drawing.Size(106, 31);
            this.o_decrypt_button.TabIndex = 13;
            this.o_decrypt_button.Text = "Decrypt";
            this.o_decrypt_button.UseVisualStyleBackColor = true;
            this.o_decrypt_button.Click += new System.EventHandler(this.o_decrypt_button_Click);
            // 
            // o_encrypt_button
            // 
            this.o_encrypt_button.Enabled = false;
            this.o_encrypt_button.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.o_encrypt_button.Location = new System.Drawing.Point(655, 93);
            this.o_encrypt_button.Name = "o_encrypt_button";
            this.o_encrypt_button.Size = new System.Drawing.Size(106, 31);
            this.o_encrypt_button.TabIndex = 14;
            this.o_encrypt_button.Text = "Encrypt";
            this.o_encrypt_button.UseVisualStyleBackColor = true;
            this.o_encrypt_button.Click += new System.EventHandler(this.o_encrypt_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 706);
            this.Controls.Add(this.o_encrypt_button);
            this.Controls.Add(this.o_decrypt_button);
            this.Controls.Add(this.originalFileStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.keyStatus);
            this.Controls.Add(this.original_button);
            this.Controls.Add(this.key_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.save_Button);
            this.Controls.Add(this.pathStatus);
            this.Controls.Add(this.textValueBox);
            this.Controls.Add(this.LocateFile_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filePath_textBox);
            this.Name = "Form1";
            this.Text = "GuruGuru19\'s Text File Encryptor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePath_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LocateFile_Button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textValueBox;
        private System.Windows.Forms.Label pathStatus;
        private System.Windows.Forms.Button save_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox key_textBox;
        private System.Windows.Forms.Button original_button;
        private System.Windows.Forms.Label keyStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label originalFileStatus;
        private System.Windows.Forms.Button o_decrypt_button;
        private System.Windows.Forms.Button o_encrypt_button;
    }
}

