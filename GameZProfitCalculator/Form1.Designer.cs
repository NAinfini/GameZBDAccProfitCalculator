﻿namespace GameZProfitCalculator
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemGrossProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StackNoBox = new System.Windows.Forms.TextBox();
            this.stackCountLbl = new System.Windows.Forms.Label();
            this.EveCheck = new System.Windows.Forms.CheckBox();
            this.PreCheck = new System.Windows.Forms.CheckBox();
            this.EnhanceChanceLbl = new System.Windows.Forms.Label();
            this.URLBox = new System.Windows.Forms.TextBox();
            this.URLLbl = new System.Windows.Forms.Label();
            this.updateBtn = new System.Windows.Forms.Button();
            this.SPlbl = new System.Windows.Forms.Label();
            this.SPPricelbl = new System.Windows.Forms.Label();
            this.SPDescriptionlbl = new System.Windows.Forms.Label();
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.ItemCount,
            this.ItemName,
            this.ItemGrade,
            this.ItemProfit,
            this.ItemGrossProfit});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(409, 22);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1146, 674);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dataGridView1_SortCompare);
            // 
            // ItemID
            // 
            this.ItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ItemID.HeaderText = "ItemID";
            this.ItemID.MinimumWidth = 6;
            this.ItemID.Name = "ItemID";
            this.ItemID.Width = 137;
            // 
            // ItemCount
            // 
            this.ItemCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ItemCount.HeaderText = "Count";
            this.ItemCount.MinimumWidth = 9;
            this.ItemCount.Name = "ItemCount";
            this.ItemCount.Width = 132;
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.MinimumWidth = 6;
            this.ItemName.Name = "ItemName";
            this.ItemName.Width = 192;
            // 
            // ItemGrade
            // 
            this.ItemGrade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ItemGrade.HeaderText = "Item Grade";
            this.ItemGrade.MinimumWidth = 6;
            this.ItemGrade.Name = "ItemGrade";
            this.ItemGrade.Width = 196;
            // 
            // ItemProfit
            // 
            this.ItemProfit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ItemProfit.HeaderText = "Item Profit";
            this.ItemProfit.MinimumWidth = 6;
            this.ItemProfit.Name = "ItemProfit";
            this.ItemProfit.Width = 184;
            // 
            // ItemGrossProfit
            // 
            this.ItemGrossProfit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ItemGrossProfit.HeaderText = "Gross Profit";
            this.ItemGrossProfit.MinimumWidth = 6;
            this.ItemGrossProfit.Name = "ItemGrossProfit";
            this.ItemGrossProfit.Width = 205;
            // 
            // StackNoBox
            // 
            this.StackNoBox.Location = new System.Drawing.Point(207, 9);
            this.StackNoBox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.StackNoBox.Name = "StackNoBox";
            this.StackNoBox.Size = new System.Drawing.Size(136, 44);
            this.StackNoBox.TabIndex = 1;
            this.StackNoBox.Text = "50";
            this.StackNoBox.Leave += new System.EventHandler(this.StackNoBox_TextChanged);
            // 
            // stackCountLbl
            // 
            this.stackCountLbl.AutoSize = true;
            this.stackCountLbl.Location = new System.Drawing.Point(17, 15);
            this.stackCountLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stackCountLbl.Name = "stackCountLbl";
            this.stackCountLbl.Size = new System.Drawing.Size(196, 38);
            this.stackCountLbl.TabIndex = 2;
            this.stackCountLbl.Text = "Stack Count";
            // 
            // EveCheck
            // 
            this.EveCheck.AutoSize = true;
            this.EveCheck.Location = new System.Drawing.Point(22, 57);
            this.EveCheck.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
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
            this.PreCheck.Location = new System.Drawing.Point(207, 57);
            this.PreCheck.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
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
            this.EnhanceChanceLbl.Location = new System.Drawing.Point(17, 166);
            this.EnhanceChanceLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EnhanceChanceLbl.Name = "EnhanceChanceLbl";
            this.EnhanceChanceLbl.Size = new System.Drawing.Size(103, 38);
            this.EnhanceChanceLbl.TabIndex = 7;
            this.EnhanceChanceLbl.Text = "label2";
            // 
            // URLBox
            // 
            this.URLBox.Location = new System.Drawing.Point(75, 100);
            this.URLBox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.URLBox.Name = "URLBox";
            this.URLBox.Size = new System.Drawing.Size(323, 44);
            this.URLBox.TabIndex = 8;
            // 
            // URLLbl
            // 
            this.URLLbl.AutoSize = true;
            this.URLLbl.Location = new System.Drawing.Point(13, 105);
            this.URLLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.URLLbl.Name = "URLLbl";
            this.URLLbl.Size = new System.Drawing.Size(83, 38);
            this.URLLbl.TabIndex = 9;
            this.URLLbl.Text = "URL";
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(310, 157);
            this.updateBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(92, 42);
            this.updateBtn.TabIndex = 10;
            this.updateBtn.Text = "update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // SPlbl
            // 
            this.SPlbl.AutoSize = true;
            this.SPlbl.Location = new System.Drawing.Point(17, 361);
            this.SPlbl.Name = "SPlbl";
            this.SPlbl.Size = new System.Drawing.Size(215, 44);
            this.SPlbl.TabIndex = 11;
            this.SPlbl.Text = "Stack Price";
            // 
            // SPPricelbl
            // 
            this.SPPricelbl.AutoSize = true;
            this.SPPricelbl.Location = new System.Drawing.Point(200, 361);
            this.SPPricelbl.Name = "SPPricelbl";
            this.SPPricelbl.Size = new System.Drawing.Size(53, 38);
            this.SPPricelbl.TabIndex = 12;
            this.SPPricelbl.Text = "$0";
            // 
            // SPDescriptionlbl
            // 
            this.SPDescriptionlbl.AutoSize = true;
            this.SPDescriptionlbl.Location = new System.Drawing.Point(17, 427);
            this.SPDescriptionlbl.Name = "SPDescriptionlbl";
            this.SPDescriptionlbl.Size = new System.Drawing.Size(103, 38);
            this.SPDescriptionlbl.TabIndex = 13;
            this.SPDescriptionlbl.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1575, 718);
            this.Controls.Add(this.SPDescriptionlbl);
            this.Controls.Add(this.SPPricelbl);
            this.Controls.Add(this.SPlbl);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.URLLbl);
            this.Controls.Add(this.URLBox);
            this.Controls.Add(this.EnhanceChanceLbl);
            this.Controls.Add(this.PreCheck);
            this.Controls.Add(this.EveCheck);
            this.Controls.Add(this.stackCountLbl);
            this.Controls.Add(this.StackNoBox);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
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
        private System.Windows.Forms.Label stackCountLbl;
        private System.Windows.Forms.CheckBox EveCheck;
        private System.Windows.Forms.CheckBox PreCheck;
        private System.Windows.Forms.Label EnhanceChanceLbl;
        private System.Windows.Forms.TextBox URLBox;
        private System.Windows.Forms.Label URLLbl;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemGrossProfit;
        private System.Windows.Forms.Label SPlbl;
        private System.Windows.Forms.Label SPPricelbl;
        private System.Windows.Forms.Label SPDescriptionlbl;
    }
}

