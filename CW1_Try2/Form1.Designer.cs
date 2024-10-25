
namespace CW1_Try2
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
            this.label1 = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.History = new System.Windows.Forms.ColumnHeader();
            this.htmlTextbox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonForward = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.titleTextbox = new System.Windows.Forms.TextBox();
            this.codeTextbox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(347, -13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gongle";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(231, 51);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(337, 23);
            this.urlTextBox.TabIndex = 1;
            this.urlTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.urlTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onTextboxEnter);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.History});
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 27);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(139, 411);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // History
            // 
            this.History.Text = "History";
            this.History.Width = 200;
            // 
            // htmlTextbox
            // 
            this.htmlTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.htmlTextbox.Location = new System.Drawing.Point(231, 80);
            this.htmlTextbox.Multiline = true;
            this.htmlTextbox.Name = "htmlTextbox";
            this.htmlTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.htmlTextbox.Size = new System.Drawing.Size(312, 317);
            this.htmlTextbox.TabIndex = 5;
            this.htmlTextbox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(606, 51);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(182, 23);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.testFunc);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(12, 1);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(63, 23);
            this.buttonBack.TabIndex = 7;
            this.buttonBack.Text = "<-";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(574, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 24);
            this.button2.TabIndex = 8;
            this.button2.Text = "☆";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // buttonForward
            // 
            this.buttonForward.Location = new System.Drawing.Point(95, 1);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(56, 23);
            this.buttonForward.TabIndex = 9;
            this.buttonForward.Text = "->";
            this.buttonForward.UseVisualStyleBackColor = true;
            this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "bulk";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // titleTextbox
            // 
            this.titleTextbox.Location = new System.Drawing.Point(231, 22);
            this.titleTextbox.Name = "titleTextbox";
            this.titleTextbox.ReadOnly = true;
            this.titleTextbox.Size = new System.Drawing.Size(220, 23);
            this.titleTextbox.TabIndex = 11;
            // 
            // codeTextbox
            // 
            this.codeTextbox.Location = new System.Drawing.Point(457, 22);
            this.codeTextbox.Name = "codeTextbox";
            this.codeTextbox.ReadOnly = true;
            this.codeTextbox.Size = new System.Drawing.Size(111, 23);
            this.codeTextbox.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(574, 51);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "🔍";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.codeTextbox);
            this.Controls.Add(this.titleTextbox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonForward);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.htmlTextbox);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader History;
        private System.Windows.Forms.TextBox htmlTextbox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox titleTextbox;
        private System.Windows.Forms.TextBox codeTextbox;
        private System.Windows.Forms.Button button3;
    }
}

