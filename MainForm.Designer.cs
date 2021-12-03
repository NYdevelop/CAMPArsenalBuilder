namespace CAMPArsenalBuilder
{
    partial class MainForm
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnAddArmy = new System.Windows.Forms.Button();
            this.btnRemoveSelect = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.textBoxAdd = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listArsenal = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadScript = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.tabControlArmy = new System.Windows.Forms.TabControl();
            this.contextMenuStripTab = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemTabClose = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadMinimum = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStripTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddArmy
            // 
            this.btnAddArmy.Location = new System.Drawing.Point(12, 309);
            this.btnAddArmy.Name = "btnAddArmy";
            this.btnAddArmy.Size = new System.Drawing.Size(75, 23);
            this.btnAddArmy.TabIndex = 0;
            this.btnAddArmy.Text = "兵科追加";
            this.btnAddArmy.UseVisualStyleBackColor = true;
            this.btnAddArmy.Click += new System.EventHandler(this.btnAddArmy_Click);
            // 
            // btnRemoveSelect
            // 
            this.btnRemoveSelect.Location = new System.Drawing.Point(272, 235);
            this.btnRemoveSelect.Name = "btnRemoveSelect";
            this.btnRemoveSelect.Size = new System.Drawing.Size(90, 23);
            this.btnRemoveSelect.TabIndex = 10;
            this.btnRemoveSelect.Text = "選択を除去";
            this.btnRemoveSelect.UseVisualStyleBackColor = true;
            this.btnRemoveSelect.Click += new System.EventHandler(this.btnRemoveSelect_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(272, 264);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(90, 23);
            this.btnRemoveAll.TabIndex = 11;
            this.btnRemoveAll.Text = "全て除去";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // textBoxAdd
            // 
            this.textBoxAdd.Location = new System.Drawing.Point(6, 18);
            this.textBoxAdd.Name = "textBoxAdd";
            this.textBoxAdd.Size = new System.Drawing.Size(179, 19);
            this.textBoxAdd.TabIndex = 9;
            this.textBoxAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAdd_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(191, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(39, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "追加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listArsenal
            // 
            this.listArsenal.FormattingEnabled = true;
            this.listArsenal.ItemHeight = 12;
            this.listArsenal.Location = new System.Drawing.Point(12, 103);
            this.listArsenal.Name = "listArsenal";
            this.listArsenal.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listArsenal.Size = new System.Drawing.Size(236, 184);
            this.listArsenal.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "共通装備";
            // 
            // btnLoadScript
            // 
            this.btnLoadScript.Location = new System.Drawing.Point(299, 98);
            this.btnLoadScript.Name = "btnLoadScript";
            this.btnLoadScript.Size = new System.Drawing.Size(63, 39);
            this.btnLoadScript.TabIndex = 12;
            this.btnLoadScript.Text = "スクリプト読み込み";
            this.btnLoadScript.UseVisualStyleBackColor = true;
            this.btnLoadScript.Click += new System.EventHandler(this.btnLoadScript_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(299, 8);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(63, 39);
            this.btnCreate.TabIndex = 12;
            this.btnCreate.Text = "スクリプト出力";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // tabControlArmy
            // 
            this.tabControlArmy.ContextMenuStrip = this.contextMenuStripTab;
            this.tabControlArmy.Location = new System.Drawing.Point(2, 338);
            this.tabControlArmy.Name = "tabControlArmy";
            this.tabControlArmy.SelectedIndex = 0;
            this.tabControlArmy.Size = new System.Drawing.Size(372, 303);
            this.tabControlArmy.TabIndex = 14;
            // 
            // contextMenuStripTab
            // 
            this.contextMenuStripTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTabClose});
            this.contextMenuStripTab.Name = "contextMenuStripTab";
            this.contextMenuStripTab.Size = new System.Drawing.Size(166, 26);
            // 
            // toolStripMenuItemTabClose
            // 
            this.toolStripMenuItemTabClose.Name = "toolStripMenuItemTabClose";
            this.toolStripMenuItemTabClose.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItemTabClose.Text = "現在の兵科を削除";
            this.toolStripMenuItemTabClose.Click += new System.EventHandler(this.toolStripMenuItemTabClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "※上級兵科を左に";
            // 
            // btnLoadMinimum
            // 
            this.btnLoadMinimum.Location = new System.Drawing.Point(299, 53);
            this.btnLoadMinimum.Name = "btnLoadMinimum";
            this.btnLoadMinimum.Size = new System.Drawing.Size(63, 39);
            this.btnLoadMinimum.TabIndex = 16;
            this.btnLoadMinimum.Text = "最低限\r\n共通装備";
            this.btnLoadMinimum.UseVisualStyleBackColor = true;
            this.btnLoadMinimum.Click += new System.EventHandler(this.btnLoadMinimum_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxAdd);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 45);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "クラス追加欄";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "追加済みリスト";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(6, 299);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(359, 1);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 643);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLoadMinimum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControlArmy);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnLoadScript);
            this.Controls.Add(this.btnRemoveSelect);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.listArsenal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddArmy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "C.A.M.P. Arsenal Builder v1.1";
            this.contextMenuStripTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddArmy;
        private System.Windows.Forms.Button btnRemoveSelect;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.TextBox textBoxAdd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox listArsenal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadScript;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TabControl tabControlArmy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadMinimum;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTab;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTabClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

