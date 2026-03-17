using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
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

        /// <summary>
        /// アイテムクラス追加
        /// </summary>
        /// <returns>エラー無い場合null, エラー時エラー内容文字列</returns>
        public string AddList(string str)
        {
            // 重複チェック
            foreach (string item in listArsenal.Items)
            {
                if (item == str)
                {
                    return "既に追加済み [" + textBoxArmyName.Text + "] 項目名：" + item;
                }
            }
            listArsenal.Items.Add(str);
            return null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAdd.Text)) return;
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
            cbxCopy.Items.Clear();

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

        private void listbox_MouseDown(object sender, MouseEventArgs e)
        {
            var listbox = (ListBox)sender;

            // アイテムがクリックされたか確認
            if (listbox.SelectedItem == null) return;
            listbox.DoDragDrop(listbox.SelectedItem, DragDropEffects.Move);
        }

        private void listbox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listbox_DragDrop(object sender, DragEventArgs e)
        {
            var listbox = (ListBox)sender;
            Point point = listbox.PointToClient(new Point(e.X, e.Y));
            int index = listbox.IndexFromPoint(point);
            if (index < 0) index = listbox.Items.Count - 1;

            object data = e.Data.GetData(typeof(string));
            listbox.Items.Remove(data);
            listbox.Items.Insert(index, data);
        }

        private void listbox_KeyDown(object sender, KeyEventArgs e)
        {
            var listbox = (ListBox)sender;
            // Ctrl + C が押されたか判定
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (listbox.SelectedItems.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in listbox.SelectedItems)
                    {
                        sb.AppendLine(item.ToString());
                    }
                    // クリップボードにコピー
                    var text = sb.ToString();
                    Clipboard.SetText(text.Substring(0, text.Length - 1));
                }
                e.SuppressKeyPress = true; // システムのデフォルト挙動を無効化
            }
        }

    }
}
