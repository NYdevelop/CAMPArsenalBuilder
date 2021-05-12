using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CAMPArsenalBuilder
{
    public partial class ArmyArsenal : UserControl
    {
        public event EventHandler<string> EventLeaveArmyName;

        public ArmyArsenal()
        {
            InitializeComponent();
        }

        public KeyValuePair<string, ListBox.ObjectCollection> GetProparty()
        {
            return new KeyValuePair<string, ListBox.ObjectCollection>(textBox1.Text, listArsenal.Items);
        }

        public void SetName(string name)
        {
            textBox1.Text = name;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            EventLeaveArmyName.Invoke(this, textBox1.Text);
        }

        public void AddList(string str)
        {
            // 重複チェック
            foreach (string item in listArsenal.Items)
            {
                if (item == str)
                {
                    MessageBox.Show(this, "重複しています\n項目名：" + item, "重複", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnRemoveOne_Click(object sender, EventArgs e)
        {
            if (listArsenal.SelectedItem == null) return;
            var index = listArsenal.SelectedIndex;
            listArsenal.Items.Remove(listArsenal.SelectedItem);
            if (listArsenal.Items.Count != index) listArsenal.SelectedIndex = index;
            else listArsenal.SelectedIndex = index - 1;
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            listArsenal.Items.Clear();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddList(textBoxAdd.Text);
                textBoxAdd.Clear();
            }
        }
    }
}
