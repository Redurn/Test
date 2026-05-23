namespace TestProject.Forms.Device
{
    partial class UpdateDeviceForm
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
            colorComboBox = new ComboBox();
            typeComboBox = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            posYTextBox = new TextBox();
            posXTextBox = new TextBox();
            sizeTextBox = new TextBox();
            descriptionTextBox = new TextBox();
            nameTextBox = new TextBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // colorComboBox
            // 
            colorComboBox.FormattingEnabled = true;
            colorComboBox.Location = new Point(303, 286);
            colorComboBox.Name = "colorComboBox";
            colorComboBox.Size = new Size(230, 33);
            colorComboBox.TabIndex = 37;
            // 
            // typeComboBox
            // 
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Location = new Point(12, 224);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(230, 33);
            typeComboBox.TabIndex = 36;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(303, 258);
            label8.Name = "label8";
            label8.Size = new Size(51, 25);
            label8.TabIndex = 35;
            label8.Text = "Цвет";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(303, 195);
            label7.Name = "label7";
            label7.Size = new Size(125, 25);
            label7.TabIndex = 34;
            label7.Text = "Координата Y";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(303, 133);
            label6.Name = "label6";
            label6.Size = new Size(126, 25);
            label6.TabIndex = 33;
            label6.Text = "Координата X";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(303, 71);
            label5.Name = "label5";
            label5.Size = new Size(72, 25);
            label5.TabIndex = 32;
            label5.Text = "Размер";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 195);
            label4.Name = "label4";
            label4.Size = new Size(108, 25);
            label4.TabIndex = 31;
            label4.Text = "Тип фигуры";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 133);
            label3.Name = "label3";
            label3.Size = new Size(187, 25);
            label3.TabIndex = 30;
            label3.Text = "Описание устройства";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 71);
            label2.Name = "label2";
            label2.Size = new Size(185, 25);
            label2.TabIndex = 29;
            label2.Text = "Название устройства";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 7);
            label1.Name = "label1";
            label1.Size = new Size(105, 25);
            label1.TabIndex = 28;
            label1.Text = "Устройство";
            // 
            // posYTextBox
            // 
            posYTextBox.Location = new Point(303, 224);
            posYTextBox.Name = "posYTextBox";
            posYTextBox.Size = new Size(230, 31);
            posYTextBox.TabIndex = 27;
            // 
            // posXTextBox
            // 
            posXTextBox.Location = new Point(303, 161);
            posXTextBox.Name = "posXTextBox";
            posXTextBox.Size = new Size(230, 31);
            posXTextBox.TabIndex = 26;
            // 
            // sizeTextBox
            // 
            sizeTextBox.Location = new Point(303, 99);
            sizeTextBox.Name = "sizeTextBox";
            sizeTextBox.Size = new Size(230, 31);
            sizeTextBox.TabIndex = 25;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(12, 161);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(230, 31);
            descriptionTextBox.TabIndex = 24;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(12, 99);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(230, 31);
            nameTextBox.TabIndex = 23;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 35);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(230, 33);
            comboBox1.TabIndex = 22;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(303, 34);
            button1.Name = "button1";
            button1.Size = new Size(230, 34);
            button1.TabIndex = 21;
            button1.Text = "Изменить устройство";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // UpdateDeviceForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(767, 494);
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
            Name = "UpdateDeviceForm";
            Text = "UpdateDeviceForm";
            Load += UpdateDeviceForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox colorComboBox;
        private ComboBox typeComboBox;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox posYTextBox;
        private TextBox posXTextBox;
        private TextBox sizeTextBox;
        private TextBox descriptionTextBox;
        private TextBox nameTextBox;
        private ComboBox comboBox1;
        private Button button1;
    }
}