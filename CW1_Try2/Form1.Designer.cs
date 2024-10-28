
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
            this.historyView = new System.Windows.Forms.ListView();
            this.History = new System.Windows.Forms.ColumnHeader();
            this.htmlTextbox = new System.Windows.Forms.TextBox();
            this.favouritesBox = new System.Windows.Forms.ComboBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.favouriteButton = new System.Windows.Forms.Button();
            this.buttonForward = new System.Windows.Forms.Button();
            this.bulkButton = new System.Windows.Forms.Button();
            this.titleTextbox = new System.Windows.Forms.TextBox();
            this.codeTextbox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.homepageButton = new System.Windows.Forms.Button();
            this.editHomepageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(347, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gongle";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(263, 70);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(305, 23);
            this.urlTextBox.TabIndex = 1;
            this.urlTextBox.TextChanged += new System.EventHandler(this.urlTextBox_TextChanged);
            this.urlTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onTextboxEnter);
            // 
            // historyView
            // 
            this.historyView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.historyView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.historyView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.History});
            this.historyView.FullRowSelect = true;
            this.historyView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.historyView.HideSelection = false;
            this.historyView.Location = new System.Drawing.Point(12, 30);
            this.historyView.Name = "historyView";
            this.historyView.Size = new System.Drawing.Size(180, 466);
            this.historyView.TabIndex = 4;
            this.historyView.UseCompatibleStateImageBehavior = false;
            this.historyView.View = System.Windows.Forms.View.Details;
            // 
            // History
            // 
            this.History.Text = "History";
            this.History.Width = 150;
            // 
            // htmlTextbox
            // 
            this.htmlTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.htmlTextbox.Location = new System.Drawing.Point(231, 101);
            this.htmlTextbox.Multiline = true;
            this.htmlTextbox.Name = "htmlTextbox";
            this.htmlTextbox.ReadOnly = true;
            this.htmlTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.htmlTextbox.Size = new System.Drawing.Size(555, 395);
            this.htmlTextbox.TabIndex = 5;
            // 
            // favouritesBox
            // 
            this.favouritesBox.DisplayMember = "Name";
            this.favouritesBox.FormattingEnabled = true;
            this.favouritesBox.Location = new System.Drawing.Point(606, 69);
            this.favouritesBox.Name = "favouritesBox";
            this.favouritesBox.Size = new System.Drawing.Size(182, 23);
            this.favouritesBox.TabIndex = 6;
            this.favouritesBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.favouriteBox_Enter);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(12, 1);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(71, 23);
            this.buttonBack.TabIndex = 7;
            this.buttonBack.Text = "←";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // favouriteButton
            // 
            this.favouriteButton.Location = new System.Drawing.Point(574, 39);
            this.favouriteButton.Name = "favouriteButton";
            this.favouriteButton.Size = new System.Drawing.Size(26, 24);
            this.favouriteButton.TabIndex = 8;
            this.favouriteButton.Text = "☆";
            this.favouriteButton.UseVisualStyleBackColor = true;
            this.favouriteButton.Click += new System.EventHandler(this.favouriteButton_Click);
            // 
            // buttonForward
            // 
            this.buttonForward.Location = new System.Drawing.Point(125, 1);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(67, 23);
            this.buttonForward.TabIndex = 9;
            this.buttonForward.Text = "→";
            this.buttonForward.UseVisualStyleBackColor = true;
            this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
            // 
            // bulkButton
            // 
            this.bulkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bulkButton.AutoSize = true;
            this.bulkButton.Location = new System.Drawing.Point(198, 470);
            this.bulkButton.Name = "bulkButton";
            this.bulkButton.Size = new System.Drawing.Size(25, 26);
            this.bulkButton.TabIndex = 10;
            this.bulkButton.Text = "⇓";
            this.bulkButton.UseVisualStyleBackColor = true;
            this.bulkButton.Click += new System.EventHandler(this.bulkButton_Click);
            // 
            // titleTextbox
            // 
            this.titleTextbox.Location = new System.Drawing.Point(231, 41);
            this.titleTextbox.Name = "titleTextbox";
            this.titleTextbox.Size = new System.Drawing.Size(220, 23);
            this.titleTextbox.TabIndex = 11;
            // 
            // codeTextbox
            // 
            this.codeTextbox.Location = new System.Drawing.Point(457, 41);
            this.codeTextbox.Name = "codeTextbox";
            this.codeTextbox.ReadOnly = true;
            this.codeTextbox.Size = new System.Drawing.Size(111, 23);
            this.codeTextbox.TabIndex = 12;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(574, 69);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(26, 23);
            this.searchButton.TabIndex = 13;
            this.searchButton.Text = "🔍";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(231, 70);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(26, 23);
            this.refreshButton.TabIndex = 14;
            this.refreshButton.Text = "⟳";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // homepageButton
            // 
            this.homepageButton.Location = new System.Drawing.Point(606, 39);
            this.homepageButton.Name = "homepageButton";
            this.homepageButton.Size = new System.Drawing.Size(26, 24);
            this.homepageButton.TabIndex = 15;
            this.homepageButton.Text = "🏠";
            this.homepageButton.UseVisualStyleBackColor = true;
            this.homepageButton.Click += new System.EventHandler(this.homepageButton_Click);
            // 
            // editHomepageButton
            // 
            this.editHomepageButton.Location = new System.Drawing.Point(638, 39);
            this.editHomepageButton.Name = "editHomepageButton";
            this.editHomepageButton.Size = new System.Drawing.Size(42, 24);
            this.editHomepageButton.TabIndex = 16;
            this.editHomepageButton.Text = "✎🏠";
            this.editHomepageButton.UseVisualStyleBackColor = true;
            this.editHomepageButton.Click += new System.EventHandler(this.editHomepageButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(803, 505);
            this.Controls.Add(this.editHomepageButton);
            this.Controls.Add(this.homepageButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.codeTextbox);
            this.Controls.Add(this.titleTextbox);
            this.Controls.Add(this.bulkButton);
            this.Controls.Add(this.buttonForward);
            this.Controls.Add(this.favouriteButton);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.favouritesBox);
            this.Controls.Add(this.htmlTextbox);
            this.Controls.Add(this.historyView);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Gongle";
            this.Text = "Gongle Search Engine";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.ListView historyView;
        private System.Windows.Forms.ColumnHeader History;
        private System.Windows.Forms.TextBox htmlTextbox;
        private System.Windows.Forms.ComboBox favouritesBox;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button favouriteButton;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.Button bulkButton;
        private System.Windows.Forms.TextBox titleTextbox;
        private System.Windows.Forms.TextBox codeTextbox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button homepageButton;
        private System.Windows.Forms.Button editHomepageButton;
    }
}

