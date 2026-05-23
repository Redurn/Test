namespace TestProject.Forms
{
    partial class AddDeviceForm
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
            button1 = new Button();
            comboBox1 = new ComboBox();
            nameTextBox = new TextBox();
            descriptionTextBox = new TextBox();
            sizeTextBox = new TextBox();
            posXTextBox = new TextBox();
            posYTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            typeComboBox = new ComboBox();
            colorComboBox = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(303, 36);
            button1.Name = "button1";
            button1.Size = new Size(230, 34);
            button1.TabIndex = 0;
            button1.Text = "Создать устройство";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 37);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(230, 33);
            comboBox1.TabIndex = 2;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(12, 101);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(230, 31);
            nameTextBox.TabIndex = 3;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(12, 163);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(230, 31);
            descriptionTextBox.TabIndex = 5;
            // 
            // sizeTextBox
            // 
            sizeTextBox.Location = new Point(303, 101);
            sizeTextBox.Name = "sizeTextBox";
            sizeTextBox.Size = new Size(230, 31);
            sizeTextBox.TabIndex = 6;
            // 
            // posXTextBox
            // 
            posXTextBox.Location = new Point(303, 163);
            posXTextBox.Name = "posXTextBox";
            posXTextBox.Size = new Size(230, 31);
            posXTextBox.TabIndex = 7;
            // 
            // posYTextBox
            // 
            posYTextBox.Location = new Point(303, 226);
            posYTextBox.Name = "posYTextBox";
            posYTextBox.Size = new Size(230, 31);
            posYTextBox.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(101, 25);
            label1.TabIndex = 11;
            label1.Text = "Интерфейс";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 73);
            label2.Name = "label2";
            label2.Size = new Size(185, 25);
            label2.TabIndex = 12;
            label2.Text = "Название устройства";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 135);
            label3.Name = "label3";
            label3.Size = new Size(187, 25);
            label3.TabIndex = 13;
            label3.Text = "Описание устройства";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 197);
            label4.Name = "label4";
            label4.Size = new Size(108, 25);
            label4.TabIndex = 14;
            label4.Text = "Тип фигуры";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(303, 73);
            label5.Name = "label5";
            label5.Size = new Size(72, 25);
            label5.TabIndex = 15;
            label5.Text = "Размер";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(303, 135);
            label6.Name = "label6";
            label6.Size = new Size(126, 25);
            label6.TabIndex = 16;
            label6.Text = "Координата X";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(303, 197);
            label7.Name = "label7";
            label7.Size = new Size(125, 25);
            label7.TabIndex = 17;
            label7.Text = "Координата Y";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(303, 260);
            label8.Name = "label8";
            label8.Size = new Size(51, 25);
            label8.TabIndex = 18;
            label8.Text = "Цвет";
            // 
            // typeComboBox
            // 
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Location = new Point(12, 226);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(230, 33);
            typeComboBox.TabIndex = 19;
            // 
            // colorComboBox
            // 
            colorComboBox.FormattingEnabled = true;
            colorComboBox.Location = new Point(303, 288);
            colorComboBox.Name = "colorComboBox";
            colorComboBox.Size = new Size(230, 33);
            colorComboBox.TabIndex = 20;
            // 
            // AddDeviceForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 618);
            Controls.Add(colorComboBox);
            Controls.Add(typeComboBox);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(posYTextBox);
            Controls.Add(posXTextBox);
            Controls.Add(sizeTextBox);
            Controls.Add(descriptionTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Name = "AddDeviceForm";
            Text = "AddDeviceForm";
            Load += AddDeviceForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ComboBox comboBox1;
        private TextBox nameTextBox;
        private TextBox descriptionTextBox;
        private TextBox sizeTextBox;
        private TextBox posXTextBox;
        private TextBox posYTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private ComboBox typeComboBox;
        private ComboBox colorComboBox;
    }
}