namespace TestProject.Forms.Register
{
    partial class AddRegisterForm
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
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            nameRegistertextBox = new TextBox();
            descriptionRegisterTextBox = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 34);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 6);
            label1.Name = "label1";
            label1.Size = new Size(105, 25);
            label1.TabIndex = 1;
            label1.Text = "Устройство";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 70);
            label2.Name = "label2";
            label2.Size = new Size(167, 25);
            label2.TabIndex = 2;
            label2.Text = "Название регистра";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 132);
            label3.Name = "label3";
            label3.Size = new Size(169, 25);
            label3.TabIndex = 3;
            label3.Text = "Описание регистра";
            // 
            // nameRegistertextBox
            // 
            nameRegistertextBox.Location = new Point(12, 98);
            nameRegistertextBox.Name = "nameRegistertextBox";
            nameRegistertextBox.Size = new Size(182, 31);
            nameRegistertextBox.TabIndex = 4;
            // 
            // descriptionRegisterTextBox
            // 
            descriptionRegisterTextBox.Location = new Point(12, 160);
            descriptionRegisterTextBox.Name = "descriptionRegisterTextBox";
            descriptionRegisterTextBox.Size = new Size(182, 31);
            descriptionRegisterTextBox.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(223, 34);
            button1.Name = "button1";
            button1.Size = new Size(182, 58);
            button1.TabIndex = 6;
            button1.Text = "Добавить регистр";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AddRegisterForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(descriptionRegisterTextBox);
            Controls.Add(nameRegistertextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "AddRegisterForm";
            Text = "AddRegisterForm";
            Load += AddRegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox nameRegistertextBox;
        private TextBox descriptionRegisterTextBox;
        private Button button1;
    }
}