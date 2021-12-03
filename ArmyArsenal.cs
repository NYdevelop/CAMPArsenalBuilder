using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CAMPArsenalBuilder
{
    public partial class ArmyArsenal : UserControl
    {
        public event EventHandler<string> EventLeaveArmyName;
        private MainForm parentForm = null;

        public ArmyArsenal(MainForm form)
        {
            InitializeComponent();
            parentForm = form;
        }

        public KeyValuePair<string, ListBox.ObjectCollection> GetProparty()
        {
            return new KeyValuePair<string, ListBox.ObjectCollection>(textBoxArmyName.Text, listArsenal.Items);
        }

        public void SetName(string name)
        {
            textBoxArmyName.Text = name;
        }

        private void textBoxArmyName_Leave(object sender, EventArgs e)
        {
            EventLeaveArmyName.Invoke(this, textBoxArmyName.Text);
        }

        public void AddList(string str)
        {
            // 重複チェック
            foreach (string item in listArsenal.Items)
            {
                if (item == str)
                {
                    MessageBox.Show(
                        this,
                        "既に追加済みです\n兵科：" + textBoxArmyName.Text + "\n項目名：" + item,
                        "重複",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }
            listArsenal.Items.Add(str);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddList(textBoxAdd.Text);
            textBoxAdd.Clear();
        }

        private void btnRemoveSelect_Click(object sender, EventArgs e)
        {
            while(listArsenal.SelectedItems.Count != 0)
            {
                listArsenal.Items.Remove(listArsenal.SelectedItems[0]);
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            var ret = MessageBox.Show(this, "全削除してよろしいですか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (ret == DialogResult.OK) listArsenal.Items.Clear();
        }

        private void textBoxAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddList(textBoxAdd.Text);
                textBoxAdd.Clear();
            }
        }

        private void cbxCopy_DropDown(object sender, EventArgs e)
        {
            List<string> ret = new List<string>();
            var tabs = parentForm.GetTabs();
            foreach (Control item in tabs)
            {
                ret.Add(item.Text);
            }
            cbxCopy.Items.AddRange(ret.ToArray());
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxCopy.Text)) return;
            if (listArsenal.SelectedItems.Count == 0) return;

            ArmyArsenal copyTo = null;
            var tabs = parentForm.GetTabs();
            foreach (TabPage item in tabs)
            {
                if (item.Text == cbxCopy.Text)
                {
                    copyTo = (ArmyArsenal)item.Controls[0];
                    break;
                }
            }

            foreach (var item in listArsenal.SelectedItems)
            {
                copyTo.AddList(item.ToString());
            }
        }
    }
}
