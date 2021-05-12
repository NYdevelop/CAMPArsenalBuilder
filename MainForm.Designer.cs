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
            this.btnRemoveOne = new System.Windows.Forms.Button();
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
            this.contextMenuStripTab.SuspendLayout();
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
            // btnRemoveOne
            // 
            this.btnRemoveOne.Location = new System.Drawing.Point(272, 211);
            this.btnRemoveOne.Name = "btnRemoveOne";
            this.btnRemoveOne.Size = new System.Drawing.Size(90, 23);
            this.btnRemoveOne.TabIndex = 10;
            this.btnRemoveOne.Text = "選択を除去";
            this.btnRemoveOne.UseVisualStyleBackColor = true;
            this.btnRemoveOne.Click += new System.EventHandler(this.btnRemoveOne_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(272, 240);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(90, 23);
            this.btnRemoveAll.TabIndex = 11;
            this.btnRemoveAll.Text = "全て除去";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // textBoxAdd
            // 
            this.textBoxAdd.Location = new System.Drawing.Point(74, 28);
            this.textBoxAdd.Name = "textBoxAdd";
            this.textBoxAdd.Size = new System.Drawing.Size(180, 19);
            this.textBoxAdd.TabIndex = 9;
            this.textBoxAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAdd_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 26);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(56, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "追加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listArsenal
            // 
            this.listArsenal.FormattingEnabled = true;
            this.listArsenal.ItemHeight = 12;
            this.listArsenal.Location = new System.Drawing.Point(12, 55);
            this.listArsenal.Name = "listArsenal";
            this.listArsenal.Size = new System.Drawing.Size(242, 208);
            this.listArsenal.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "共通";
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
            this.tabControlArmy.Size = new System.Drawing.Size(394, 303);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 643);
            this.Controls.Add(this.btnLoadMinimum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControlArmy);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnLoadScript);
            this.Controls.Add(this.btnRemoveOne);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.textBoxAdd);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listArsenal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddArmy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "C.A.M.P. Arsenal Builder v1.0";
            this.contextMenuStripTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddArmy;
        private System.Windows.Forms.Button btnRemoveOne;
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
    }
}

