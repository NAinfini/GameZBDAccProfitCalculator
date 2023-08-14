namespace GameZProfitCalculator
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemGrossProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StackNoBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EveCheck = new System.Windows.Forms.CheckBox();
            this.PreCheck = new System.Windows.Forms.CheckBox();
            this.EnhanceChanceLbl = new System.Windows.Forms.Label();
            this.URLBox = new System.Windows.Forms.TextBox();
            this.URLLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.ItemName,
            this.ItemGrade,
            this.ItemProfit,
            this.ItemGrossProfit});
            this.dataGridView1.Location = new System.Drawing.Point(468, 287);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(2047, 1207);
            this.dataGridView1.TabIndex = 0;
            // 
            // ItemID
            // 
            this.ItemID.HeaderText = "ItemID";
            this.ItemID.MinimumWidth = 6;
            this.ItemID.Name = "ItemID";
            this.ItemID.Width = 125;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.MinimumWidth = 6;
            this.ItemName.Name = "ItemName";
            this.ItemName.Width = 125;
            // 
            // ItemGrade
            // 
            this.ItemGrade.HeaderText = "Item Grade";
            this.ItemGrade.MinimumWidth = 6;
            this.ItemGrade.Name = "ItemGrade";
            this.ItemGrade.Width = 125;
            // 
            // ItemProfit
            // 
            this.ItemProfit.HeaderText = "Item Profit";
            this.ItemProfit.MinimumWidth = 6;
            this.ItemProfit.Name = "ItemProfit";
            this.ItemProfit.Width = 125;
            // 
            // ItemGrossProfit
            // 
            this.ItemGrossProfit.HeaderText = "Gross Profit";
            this.ItemGrossProfit.MinimumWidth = 6;
            this.ItemGrossProfit.Name = "ItemGrossProfit";
            this.ItemGrossProfit.Width = 125;
            // 
            // StackNoBox
            // 
            this.StackNoBox.Location = new System.Drawing.Point(309, 14);
            this.StackNoBox.Margin = new System.Windows.Forms.Padding(7);
            this.StackNoBox.Name = "StackNoBox";
            this.StackNoBox.Size = new System.Drawing.Size(232, 44);
            this.StackNoBox.TabIndex = 1;
            this.StackNoBox.Text = "50";
            this.StackNoBox.TextChanged += new System.EventHandler(this.StackNoBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stack Count";
            // 
            // EveCheck
            // 
            this.EveCheck.AutoSize = true;
            this.EveCheck.Location = new System.Drawing.Point(28, 90);
            this.EveCheck.Margin = new System.Windows.Forms.Padding(7);
            this.EveCheck.Name = "EveCheck";
            this.EveCheck.Size = new System.Drawing.Size(127, 42);
            this.EveCheck.TabIndex = 5;
            this.EveCheck.Text = "Event";
            this.EveCheck.UseVisualStyleBackColor = true;
            this.EveCheck.CheckedChanged += new System.EventHandler(this.EveCheck_CheckedChanged);
            // 
            // PreCheck
            // 
            this.PreCheck.AutoSize = true;
            this.PreCheck.Location = new System.Drawing.Point(309, 90);
            this.PreCheck.Margin = new System.Windows.Forms.Padding(7);
            this.PreCheck.Name = "PreCheck";
            this.PreCheck.Size = new System.Drawing.Size(191, 42);
            this.PreCheck.TabIndex = 6;
            this.PreCheck.Text = "Preminum";
            this.PreCheck.UseVisualStyleBackColor = true;
            this.PreCheck.CheckedChanged += new System.EventHandler(this.PreCheck_CheckedChanged);
            // 
            // EnhanceChanceLbl
            // 
            this.EnhanceChanceLbl.AutoSize = true;
            this.EnhanceChanceLbl.Location = new System.Drawing.Point(22, 272);
            this.EnhanceChanceLbl.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.EnhanceChanceLbl.Name = "EnhanceChanceLbl";
            this.EnhanceChanceLbl.Size = new System.Drawing.Size(103, 38);
            this.EnhanceChanceLbl.TabIndex = 7;
            this.EnhanceChanceLbl.Text = "label2";
            // 
            // URLBox
            // 
            this.URLBox.Location = new System.Drawing.Point(132, 159);
            this.URLBox.Margin = new System.Windows.Forms.Padding(7);
            this.URLBox.Name = "URLBox";
            this.URLBox.Size = new System.Drawing.Size(479, 44);
            this.URLBox.TabIndex = 8;
            this.URLBox.TextChanged += new System.EventHandler(this.URLBox_TextChanged);
            // 
            // URLLbl
            // 
            this.URLLbl.AutoSize = true;
            this.URLLbl.Location = new System.Drawing.Point(21, 162);
            this.URLLbl.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.URLLbl.Name = "URLLbl";
            this.URLLbl.Size = new System.Drawing.Size(83, 38);
            this.URLLbl.TabIndex = 9;
            this.URLLbl.Text = "URL";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2700, 1263);
            this.Controls.Add(this.URLLbl);
            this.Controls.Add(this.URLBox);
            this.Controls.Add(this.EnhanceChanceLbl);
            this.Controls.Add(this.PreCheck);
            this.Controls.Add(this.EveCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StackNoBox);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox StackNoBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox EveCheck;
        private System.Windows.Forms.CheckBox PreCheck;
        private System.Windows.Forms.Label EnhanceChanceLbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemGrossProfit;
        private System.Windows.Forms.TextBox URLBox;
        private System.Windows.Forms.Label URLLbl;
    }
}

