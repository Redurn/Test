namespace TestProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Button button4;
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button3 = new Button();
            label4 = new Label();
            comboBox2 = new ComboBox();
            button5 = new Button();
            posXDeviceTextBox = new TextBox();
            posYDeviceTextBox = new TextBox();
            editingDateDeviceTextBox = new TextBox();
            sizeDeviceTextBox = new TextBox();
            colorDeviceTextBox = new TextBox();
            typeDeviceTextBox = new TextBox();
            descriptionDeviceTextBox = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            addRegisterButton = new Button();
            comboBox3 = new ComboBox();
            descriptionRegisterTextBox = new TextBox();
            editingDateRegisterTextBox = new TextBox();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            button6 = new Button();
            changeStatusButton = new Button();
            statusDeviceTextBox = new TextBox();
            label15 = new Label();
            comboBox4 = new ComboBox();
            panel1 = new Panel();
            button7 = new Button();
            button8 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button4
            // 
            button4.Location = new Point(231, 225);
            button4.Name = "button4";
            button4.Size = new Size(180, 71);
            button4.TabIndex = 10;
            button4.Text = "Добавить устройство";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 101);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(192, 31);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 163);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(192, 31);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(231, 36);
            button1.Name = "button1";
            button1.Size = new Size(177, 71);
            button1.TabIndex = 2;
            button1.Text = "Добавить интерфейс";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(231, 116);
            button2.Name = "button2";
            button2.Size = new Size(177, 66);
            button2.TabIndex = 4;
            button2.Text = "Изменить параметры интерфейса";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 37);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(192, 33);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(101, 25);
            label1.TabIndex = 6;
            label1.Text = "Интерфейс";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 73);
            label2.Name = "label2";
            label2.Size = new Size(192, 25);
            label2.TabIndex = 7;
            label2.Text = "Описание интерфейса";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 135);
            label3.Name = "label3";
            label3.Size = new Size(189, 25);
            label3.TabIndex = 8;
            label3.Text = "Дата редактирования";
            // 
            // button3
            // 
            button3.Location = new Point(1351, 3);
            button3.Name = "button3";
            button3.Size = new Size(158, 67);
            button3.TabIndex = 9;
            button3.Text = "Обновить данные ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 197);
            label4.Name = "label4";
            label4.Size = new Size(103, 25);
            label4.TabIndex = 11;
            label4.Text = "Устройства";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(12, 225);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(192, 33);
            comboBox2.TabIndex = 12;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // button5
            // 
            button5.Location = new Point(231, 302);
            button5.Name = "button5";
            button5.Size = new Size(180, 71);
            button5.TabIndex = 13;
            button5.Text = "Изменить устройство";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // posXDeviceTextBox
            // 
            posXDeviceTextBox.Location = new Point(231, 413);
            posXDeviceTextBox.Name = "posXDeviceTextBox";
            posXDeviceTextBox.ReadOnly = true;
            posXDeviceTextBox.Size = new Size(180, 31);
            posXDeviceTextBox.TabIndex = 14;
            // 
            // posYDeviceTextBox
            // 
            posYDeviceTextBox.Location = new Point(231, 475);
            posYDeviceTextBox.Name = "posYDeviceTextBox";
            posYDeviceTextBox.ReadOnly = true;
            posYDeviceTextBox.Size = new Size(177, 31);
            posYDeviceTextBox.TabIndex = 15;
            // 
            // editingDateDeviceTextBox
            // 
            editingDateDeviceTextBox.Location = new Point(12, 537);
            editingDateDeviceTextBox.Name = "editingDateDeviceTextBox";
            editingDateDeviceTextBox.ReadOnly = true;
            editingDateDeviceTextBox.Size = new Size(196, 31);
            editingDateDeviceTextBox.TabIndex = 16;
            // 
            // sizeDeviceTextBox
            // 
            sizeDeviceTextBox.Location = new Point(12, 475);
            sizeDeviceTextBox.Name = "sizeDeviceTextBox";
            sizeDeviceTextBox.ReadOnly = true;
            sizeDeviceTextBox.Size = new Size(196, 31);
            sizeDeviceTextBox.TabIndex = 17;
            // 
            // colorDeviceTextBox
            // 
            colorDeviceTextBox.Location = new Point(12, 413);
            colorDeviceTextBox.Name = "colorDeviceTextBox";
            colorDeviceTextBox.ReadOnly = true;
            colorDeviceTextBox.Size = new Size(196, 31);
            colorDeviceTextBox.TabIndex = 18;
            // 
            // typeDeviceTextBox
            // 
            typeDeviceTextBox.Location = new Point(12, 351);
            typeDeviceTextBox.Name = "typeDeviceTextBox";
            typeDeviceTextBox.ReadOnly = true;
            typeDeviceTextBox.Size = new Size(196, 31);
            typeDeviceTextBox.TabIndex = 19;
            // 
            // descriptionDeviceTextBox
            // 
            descriptionDeviceTextBox.Location = new Point(12, 289);
            descriptionDeviceTextBox.Name = "descriptionDeviceTextBox";
            descriptionDeviceTextBox.ReadOnly = true;
            descriptionDeviceTextBox.Size = new Size(196, 31);
            descriptionDeviceTextBox.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 261);
            label5.Name = "label5";
            label5.Size = new Size(187, 25);
            label5.TabIndex = 21;
            label5.Text = "Описание устройства";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 323);
            label6.Name = "label6";
            label6.Size = new Size(108, 25);
            label6.TabIndex = 22;
            label6.Text = "Тип фигуры";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 385);
            label7.Name = "label7";
            label7.Size = new Size(51, 25);
            label7.TabIndex = 23;
            label7.Text = "Цвет";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 447);
            label8.Name = "label8";
            label8.Size = new Size(72, 25);
            label8.TabIndex = 24;
            label8.Text = "Размер";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 509);
            label9.Name = "label9";
            label9.Size = new Size(189, 25);
            label9.TabIndex = 25;
            label9.Text = "Дата редактирования";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(231, 385);
            label10.Name = "label10";
            label10.Size = new Size(126, 25);
            label10.TabIndex = 26;
            label10.Text = "Координата X";
            label10.Click += label10_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(231, 447);
            label11.Name = "label11";
            label11.Size = new Size(125, 25);
            label11.TabIndex = 27;
            label11.Text = "Координата Y";
            // 
            // addRegisterButton
            // 
            addRegisterButton.Location = new Point(612, 36);
            addRegisterButton.Name = "addRegisterButton";
            addRegisterButton.Size = new Size(177, 70);
            addRegisterButton.TabIndex = 28;
            addRegisterButton.Text = "Добавить регистр";
            addRegisterButton.UseVisualStyleBackColor = true;
            addRegisterButton.Click += button6_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(414, 37);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(192, 33);
            comboBox3.TabIndex = 29;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // descriptionRegisterTextBox
            // 
            descriptionRegisterTextBox.Location = new Point(414, 101);
            descriptionRegisterTextBox.Name = "descriptionRegisterTextBox";
            descriptionRegisterTextBox.ReadOnly = true;
            descriptionRegisterTextBox.Size = new Size(192, 31);
            descriptionRegisterTextBox.TabIndex = 30;
            // 
            // editingDateRegisterTextBox
            // 
            editingDateRegisterTextBox.Location = new Point(414, 163);
            editingDateRegisterTextBox.Name = "editingDateRegisterTextBox";
            editingDateRegisterTextBox.ReadOnly = true;
            editingDateRegisterTextBox.Size = new Size(192, 31);
            editingDateRegisterTextBox.TabIndex = 31;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(414, 9);
            label12.Name = "label12";
            label12.Size = new Size(87, 25);
            label12.TabIndex = 32;
            label12.Text = "Регистры";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(414, 135);
            label13.Name = "label13";
            label13.Size = new Size(189, 25);
            label13.TabIndex = 33;
            label13.Text = "Дата редактирования";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(414, 73);
            label14.Name = "label14";
            label14.Size = new Size(169, 25);
            label14.TabIndex = 34;
            label14.Text = "Описание регистра";
            // 
            // button6
            // 
            button6.Location = new Point(612, 112);
            button6.Name = "button6";
            button6.Size = new Size(177, 70);
            button6.TabIndex = 35;
            button6.Text = "Изменить регистр";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click_1;
            // 
            // changeStatusButton
            // 
            changeStatusButton.Location = new Point(231, 537);
            changeStatusButton.Name = "changeStatusButton";
            changeStatusButton.Size = new Size(177, 71);
            changeStatusButton.TabIndex = 36;
            changeStatusButton.Text = "Изменить статус";
            changeStatusButton.UseVisualStyleBackColor = true;
            changeStatusButton.Click += button7_Click;
            // 
            // statusDeviceTextBox
            // 
            statusDeviceTextBox.Location = new Point(12, 599);
            statusDeviceTextBox.Name = "statusDeviceTextBox";
            statusDeviceTextBox.ReadOnly = true;
            statusDeviceTextBox.Size = new Size(196, 31);
            statusDeviceTextBox.TabIndex = 37;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(15, 571);
            label15.Name = "label15";
            label15.Size = new Size(158, 25);
            label15.TabIndex = 38;
            label15.Text = "Статус устройства";
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(553, 287);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(182, 33);
            comboBox4.TabIndex = 39;
            // 
            // panel1
            // 
            panel1.Location = new Point(795, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(550, 618);
            panel1.TabIndex = 40;
            panel1.Paint += panel1_Paint;
            // 
            // button7
            // 
            button7.Location = new Point(471, 438);
            button7.Name = "button7";
            button7.Size = new Size(149, 68);
            button7.TabIndex = 41;
            button7.Text = "button7";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click_1;
            // 
            // button8
            // 
            button8.Location = new Point(626, 438);
            button8.Name = "button8";
            button8.Size = new Size(134, 68);
            button8.TabIndex = 42;
            button8.Text = "button8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1519, 661);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(panel1);
            Controls.Add(comboBox4);
            Controls.Add(label15);
            Controls.Add(statusDeviceTextBox);
            Controls.Add(changeStatusButton);
            Controls.Add(button6);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(editingDateRegisterTextBox);
            Controls.Add(descriptionRegisterTextBox);
            Controls.Add(comboBox3);
            Controls.Add(addRegisterButton);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(descriptionDeviceTextBox);
            Controls.Add(typeDeviceTextBox);
            Controls.Add(colorDeviceTextBox);
            Controls.Add(sizeDeviceTextBox);
            Controls.Add(editingDateDeviceTextBox);
            Controls.Add(posYDeviceTextBox);
            Controls.Add(posXDeviceTextBox);
            Controls.Add(button5);
            Controls.Add(comboBox2);
            Controls.Add(label4);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button3;
        private Label label4;
        private ComboBox comboBox2;
        private Button button5;
        private TextBox posXDeviceTextBox;
        private TextBox posYDeviceTextBox;
        private TextBox editingDateDeviceTextBox;
        private TextBox sizeDeviceTextBox;
        private TextBox colorDeviceTextBox;
        private TextBox typeDeviceTextBox;
        private TextBox descriptionDeviceTextBox;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Button addRegisterButton;
        private ComboBox comboBox3;
        private TextBox descriptionRegisterTextBox;
        private TextBox editingDateRegisterTextBox;
        private Label label12;
        private Label label13;
        private Label label14;
        private Button button6;
        private Button changeStatusButton;
        private TextBox statusDeviceTextBox;
        private Label label15;
        private ComboBox comboBox4;
        private Panel panel1;
        private Button button7;
        private Button button8;
    }
}
