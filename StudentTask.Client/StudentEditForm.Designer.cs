namespace StudentTask.Client
{
    partial class StudentEditForm
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

        public StudentModel Student { get; set; }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtFullName = new TextBox();
            txtNationalCode = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            btnSave = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(176, 106);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(198, 23);
            txtFullName.TabIndex = 0;
            txtFullName.TextChanged += textBox1_TextChanged;
            // 
            // txtNationalCode
            // 
            txtNationalCode.Location = new Point(176, 151);
            txtNationalCode.Name = "txtNationalCode";
            txtNationalCode.Size = new Size(198, 23);
            txtNationalCode.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(176, 197);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(198, 23);
            dateTimePicker1.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.Control;
            btnSave.Location = new Point(215, 255);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 30);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(109, 109);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 4;
            label1.Text = "Full Name";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(87, 154);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 5;
            label2.Text = "National Code";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(110, 201);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 6;
            label3.Text = "Birth Date";
            label3.Click += label3_Click;
            // 
            // StudentEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 381);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(dateTimePicker1);
            Controls.Add(txtNationalCode);
            Controls.Add(txtFullName);
            Name = "StudentEditForm";
            Text = "StudentEditForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox txtFullName;
        public TextBox txtNationalCode;
        public DateTimePicker dateTimePicker1;
        private Button btnSave;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}