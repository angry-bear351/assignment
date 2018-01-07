namespace assignment
{
    partial class Advancedbox
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
            this.label1 = new System.Windows.Forms.Label();
            this.bugbox = new System.Windows.Forms.ListBox();
            this.morebox = new System.Windows.Forms.ListBox();
            this.commentBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.fixedBox = new System.Windows.Forms.TextBox();
            this.fixedByBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateBox = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application";
            // 
            // bugbox
            // 
            this.bugbox.FormattingEnabled = true;
            this.bugbox.Location = new System.Drawing.Point(15, 39);
            this.bugbox.Name = "bugbox";
            this.bugbox.Size = new System.Drawing.Size(155, 95);
            this.bugbox.TabIndex = 2;
            // 
            // morebox
            // 
            this.morebox.FormattingEnabled = true;
            this.morebox.Location = new System.Drawing.Point(15, 140);
            this.morebox.Name = "morebox";
            this.morebox.Size = new System.Drawing.Size(160, 95);
            this.morebox.TabIndex = 3;
            // 
            // commentBox
            // 
            this.commentBox.Location = new System.Drawing.Point(198, 148);
            this.commentBox.Multiline = true;
            this.commentBox.Name = "commentBox";
            this.commentBox.Size = new System.Drawing.Size(267, 87);
            this.commentBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Comments";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(77, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 41);
            this.button1.TabIndex = 10;
            this.button1.Text = "Commit changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Fixed? Y/N";
            // 
            // fixedBox
            // 
            this.fixedBox.Location = new System.Drawing.Point(403, 85);
            this.fixedBox.Name = "fixedBox";
            this.fixedBox.Size = new System.Drawing.Size(62, 20);
            this.fixedBox.TabIndex = 12;
            // 
            // fixedByBox
            // 
            this.fixedByBox.Location = new System.Drawing.Point(316, 46);
            this.fixedByBox.Name = "fixedByBox";
            this.fixedByBox.Size = new System.Drawing.Size(149, 20);
            this.fixedByBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Fixed By:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(207, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Fixed On:";
            // 
            // dateBox
            // 
            this.dateBox.Location = new System.Drawing.Point(265, 110);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(200, 20);
            this.dateBox.TabIndex = 16;
            // 
            // Advancedbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 318);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fixedByBox);
            this.Controls.Add(this.fixedBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commentBox);
            this.Controls.Add(this.morebox);
            this.Controls.Add(this.bugbox);
            this.Controls.Add(this.label1);
            this.Name = "Advancedbox";
            this.Text = "Developer Box";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Advancedbox_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox bugbox;
        private System.Windows.Forms.ListBox morebox;
        private System.Windows.Forms.TextBox commentBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox fixedBox;
        private System.Windows.Forms.TextBox fixedByBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateBox;
    }
}