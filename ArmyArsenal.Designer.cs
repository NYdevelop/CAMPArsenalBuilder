namespace CAMPArsenalBuilder
{
    partial class ArmyArsenal
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxArmyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listArsenal = new System.Windows.Forms.ListBox();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnRemoveSelect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxAdd = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.grpCopy = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.cbxCopy = new System.Windows.Forms.ComboBox();
            this.lblCopyTo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpCopy.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxArmyName
            // 
            this.textBoxArmyName.Location = new System.Drawing.Point(65, 1);
            this.textBoxArmyName.Name = "textBoxArmyName";
            this.textBoxArmyName.Size = new System.Drawing.Size(180, 19);
            this.textBoxArmyName.TabIndex = 0;
            this.textBoxArmyName.Leave += new System.EventHandler(this.textBoxArmyName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "兵科名：";
            // 
            // listArsenal
            // 
            this.listArsenal.FormattingEnabled = true;
            this.listArsenal.ItemHeight = 12;
            this.listArsenal.Location = new System.Drawing.Point(3, 91);
            this.listArsenal.Name = "listArsenal";
            this.listArsenal.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listArsenal.Size = new System.Drawing.Size(242, 184);
            this.listArsenal.TabIndex = 2;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(262, 120);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(90, 23);
            this.btnRemoveAll.TabIndex = 5;
            this.btnRemoveAll.Text = "全て除去";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnRemoveSelect
            // 
            this.btnRemoveSelect.Location = new System.Drawing.Point(262, 91);
            this.btnRemoveSelect.Name = "btnRemoveSelect";
            this.btnRemoveSelect.Size = new System.Drawing.Size(90, 23);
            this.btnRemoveSelect.TabIndex = 5;
            this.btnRemoveSelect.Text = "選択を除去";
            this.btnRemoveSelect.UseVisualStyleBackColor = true;
            this.btnRemoveSelect.Click += new System.EventHandler(this.btnRemoveSelect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "追加済みリスト";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxAdd);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(3, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 45);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "クラス追加欄";
            // 
            // textBoxAdd
            // 
            this.textBoxAdd.Location = new System.Drawing.Point(6, 18);
            this.textBoxAdd.Name = "textBoxAdd";
            this.textBoxAdd.Size = new System.Drawing.Size(185, 19);
            this.textBoxAdd.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "追加";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // grpCopy
            // 
            this.grpCopy.Controls.Add(this.btnCopy);
            this.grpCopy.Controls.Add(this.cbxCopy);
            this.grpCopy.Controls.Add(this.lblCopyTo);
            this.grpCopy.Location = new System.Drawing.Point(251, 185);
            this.grpCopy.Name = "grpCopy";
            this.grpCopy.Size = new System.Drawing.Size(113, 90);
            this.grpCopy.TabIndex = 21;
            this.grpCopy.TabStop = false;
            this.grpCopy.Text = "コピー";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(6, 60);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(101, 23);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "移動";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // cbxCopy
            // 
            this.cbxCopy.FormattingEnabled = true;
            this.cbxCopy.Location = new System.Drawing.Point(6, 34);
            this.cbxCopy.Name = "cbxCopy";
            this.cbxCopy.Size = new System.Drawing.Size(101, 20);
            this.cbxCopy.TabIndex = 1;
            this.cbxCopy.DropDown += new System.EventHandler(this.cbxCopy_DropDown);
            // 
            // lblCopyTo
            // 
            this.lblCopyTo.AutoSize = true;
            this.lblCopyTo.Location = new System.Drawing.Point(7, 19);
            this.lblCopyTo.Name = "lblCopyTo";
            this.lblCopyTo.Size = new System.Drawing.Size(44, 12);
            this.lblCopyTo.TabIndex = 0;
            this.lblCopyTo.Text = "コピー先";
            // 
            // ArmyArsenal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpCopy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRemoveSelect);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.listArsenal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxArmyName);
            this.Name = "ArmyArsenal";
            this.Size = new System.Drawing.Size(367, 283);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpCopy.ResumeLayout(false);
            this.grpCopy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxArmyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listArsenal;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnRemoveSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxAdd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grpCopy;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ComboBox cbxCopy;
        private System.Windows.Forms.Label lblCopyTo;
    }
}
