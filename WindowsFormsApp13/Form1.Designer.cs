namespace WindowsFormsApp13
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox_Circle = new System.Windows.Forms.PictureBox();
            this.ResetCircle = new System.Windows.Forms.Button();
            this.Build_Circle = new System.Windows.Forms.Button();
            this.AddLegend = new System.Windows.Forms.Button();
            this.Delelegend = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Build_Stovp = new System.Windows.Forms.Button();
            this.ResetStovp = new System.Windows.Forms.Button();
            this.pictureBox_Stovp = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Circle)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Stovp)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox_Circle);
            this.panel2.Controls.Add(this.ResetCircle);
            this.panel2.Controls.Add(this.Build_Circle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(821, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(583, 629);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox_Circle
            // 
            this.pictureBox_Circle.Location = new System.Drawing.Point(36, 35);
            this.pictureBox_Circle.Name = "pictureBox_Circle";
            this.pictureBox_Circle.Size = new System.Drawing.Size(556, 495);
            this.pictureBox_Circle.TabIndex = 3;
            this.pictureBox_Circle.TabStop = false;
          
            // 
            // ResetCircle
            // 
            this.ResetCircle.Location = new System.Drawing.Point(413, 549);
            this.ResetCircle.Name = "ResetCircle";
            this.ResetCircle.Size = new System.Drawing.Size(80, 55);
            this.ResetCircle.TabIndex = 1;
            this.ResetCircle.Text = "Reset";
            this.ResetCircle.UseVisualStyleBackColor = true;
            this.ResetCircle.Click += new System.EventHandler(this.ResetCircle_Click);
            // 
            // Build_Circle
            // 
            this.Build_Circle.Location = new System.Drawing.Point(65, 549);
            this.Build_Circle.Name = "Build_Circle";
            this.Build_Circle.Size = new System.Drawing.Size(80, 55);
            this.Build_Circle.TabIndex = 0;
            this.Build_Circle.Text = "Build";
            this.Build_Circle.UseVisualStyleBackColor = true;
            this.Build_Circle.Click += new System.EventHandler(this.Build_Circle_Click);
            // 
            // AddLegend
            // 
            this.AddLegend.Location = new System.Drawing.Point(27, 402);
            this.AddLegend.Name = "AddLegend";
            this.AddLegend.Size = new System.Drawing.Size(80, 55);
            this.AddLegend.TabIndex = 2;
            this.AddLegend.Text = "Add";
            this.AddLegend.UseVisualStyleBackColor = true;
            this.AddLegend.Click += new System.EventHandler(this.AddLegend_Click);
            // 
            // Delelegend
            // 
            this.Delelegend.Location = new System.Drawing.Point(164, 401);
            this.Delelegend.Name = "Delelegend";
            this.Delelegend.Size = new System.Drawing.Size(79, 56);
            this.Delelegend.TabIndex = 3;
            this.Delelegend.Text = "Delete";
            this.Delelegend.UseVisualStyleBackColor = true;
            this.Delelegend.Click += new System.EventHandler(this.Delelegend_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 16;
            this.listBox.Location = new System.Drawing.Point(42, 267);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(234, 84);
            this.listBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Легенда";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Значение";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(42, 94);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(234, 36);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(42, 201);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(234, 37);
            this.textBox2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.listBox);
            this.panel1.Controls.Add(this.Delelegend);
            this.panel1.Controls.Add(this.AddLegend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 629);
            this.panel1.TabIndex = 0;
            // 
            // Build_Stovp
            // 
            this.Build_Stovp.Location = new System.Drawing.Point(79, 549);
            this.Build_Stovp.Name = "Build_Stovp";
            this.Build_Stovp.Size = new System.Drawing.Size(80, 55);
            this.Build_Stovp.TabIndex = 0;
            this.Build_Stovp.Text = "Build";
            this.Build_Stovp.UseVisualStyleBackColor = true;
            this.Build_Stovp.Click += new System.EventHandler(this.Build_Stovp_Click);
            // 
            // ResetStovp
            // 
            this.ResetStovp.Location = new System.Drawing.Point(275, 548);
            this.ResetStovp.Name = "ResetStovp";
            this.ResetStovp.Size = new System.Drawing.Size(79, 56);
            this.ResetStovp.TabIndex = 1;
            this.ResetStovp.Text = "Reset";
            this.ResetStovp.UseVisualStyleBackColor = true;
            this.ResetStovp.Click += new System.EventHandler(this.ResetStovp_Click);
            // 
            // pictureBox_Stovp
            // 
            this.pictureBox_Stovp.Location = new System.Drawing.Point(22, 35);
            this.pictureBox_Stovp.Name = "pictureBox_Stovp";
            this.pictureBox_Stovp.Size = new System.Drawing.Size(482, 495);
            this.pictureBox_Stovp.TabIndex = 2;
            this.pictureBox_Stovp.TabStop = false;
            this.pictureBox_Stovp.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Stovp_Paint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox_Stovp);
            this.panel3.Controls.Add(this.ResetStovp);
            this.panel3.Controls.Add(this.Build_Stovp);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(295, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(526, 629);
            this.panel3.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 629);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Diagram Builder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Circle)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Stovp)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox_Circle;
        private System.Windows.Forms.Button ResetCircle;
        private System.Windows.Forms.Button Build_Circle;
        private System.Windows.Forms.Button AddLegend;
        private System.Windows.Forms.Button Delelegend;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Build_Stovp;
        private System.Windows.Forms.Button ResetStovp;
        private System.Windows.Forms.PictureBox pictureBox_Stovp;
        private System.Windows.Forms.Panel panel3;
    }
}

