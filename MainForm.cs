using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CAMPArsenalBuilder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void WriteError(string str)
        {
            lbxError.Items.Insert(0, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss: ") + str);
        }

        #region 共通装備

        /// <summary>
        /// アイテムクラス追加
        /// </summary>
        /// <returns>エラー無い場合null, エラー時エラー内容文字列</returns>
        private string AddList(string str)
        {
            // 重複チェック
            foreach (string item in listArsenal.Items)
            {
                if (item == str)
                {
                    return "既に追加済み [共通装備] ：" + item;
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

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            listArsenal.Items.Clear();
        }

        private void btnRemoveSelect_Click(object sender, EventArgs e)
        {
            while (listArsenal.SelectedItems.Count != 0)
            {
                listArsenal.Items.Remove(listArsenal.SelectedItems[0]);
            }
        }

        private void btnLoadMinimum_Click(object sender, EventArgs e)
        {
            using (var sr = new StreamReader("Minimum.txt"))
            {
                while (sr.EndOfStream == false)
                {
                    var line = sr.ReadLine();

                    var elements = line.Split(',');
                    foreach (var item in elements)
                    {
                        var ret = RemoveComment(item);
                        ret = ret.Replace("\t", "");
                        ret = ret.Replace(" ", "");
                        ret = ret.Replace("\"", "");
                        if (ret == "") continue;

                        AddList(ret);
                    }
                }
            }
        }

        private void textBoxAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddList(textBoxAdd.Text);
                textBoxAdd.Clear();
            }
        }
        #endregion

        private ArmyArsenal AddArmy(string name)
        {
            var ctrl = new ArmyArsenal(this);
            ctrl.SetName(name);

            var page = new TabPage();
            tabControlArmy.Controls.Add(page);
            page.Location = new System.Drawing.Point(4, 22);
            page.Text = name;
            page.Controls.Add(ctrl);

            ctrl.EventLeaveArmyName += (o, s) => { page.Text = s; };
            return ctrl;
        }

        private void btnAddArmy_Click(object sender, EventArgs e)
        {
            AddArmy("新規兵科");
        }

        #region LoadScript
        enum ELoadState
        {
            none = 0,
            findArmy,
            array,
        }

        private void btnLoadScript_Click(object sender, EventArgs e)
        {
            var loadFileDiag = new OpenFileDialog();
            loadFileDiag.Filter = "sqfファイル(*.sqf)|*.sqf";
            loadFileDiag.FileOk += (o, ev) => 
            {
                // 準備
                if (tabControlArmy.Controls.Count > 0)
                {
                    var ret = MessageBox.Show(
                        this,
                        "既に兵科が追加されていますが、全削除しますか？",
                        "兵科確認",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (ret == DialogResult.Yes)
                    {
                        tabControlArmy.Controls.Clear();
                    }
                }

                // 読込
                using (var sr = new StreamReader(loadFileDiag.OpenFile()))
                {
                    try
                    {
                        LoadScript(sr);
                    }
                    catch (Exception ex)
                    {
                        using (var sw = new StreamWriter("log.txt", false))
                        {
                            sw.WriteLine(ex.Message);
                            sw.WriteLine(ex.InnerException);
                            sw.WriteLine(ex.StackTrace);
                            sw.WriteLine();
                        }
                        MessageBox.Show(
                            this,
                            "読込エラーが発生しました\n下記2つをtowaに送付してもらえると解析します\n・読み込んだsqfファイル\n・exeフォルダに出力されたlog.txt",
                            "読込エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            };

            loadFileDiag.ShowDialog(this);
        }

        private void LoadScript(StreamReader sr)
        {
            lbxError.Items.Clear();

            ELoadState state = ELoadState.none;
            ArmyArsenal ctrl = null;
            while (sr.EndOfStream == false)
            {
                var line = sr.ReadLine();

                // 下記コメントで読み込み終了
                if (line.Contains("プレイヤーの変数を取得") || line.Contains("以下、分岐処理") ) break;

                line = RemoveComment(line);
                if (line == "") continue;

                switch (state)
                {
                    case ELoadState.array:
                        if (processArray(line, ctrl)) state = ELoadState.none;
                        break;

                    default:
                        ctrl = processNone(line, ref state);
                        break;
                }
            }

            if (lbxError.Items.Count > 0)
            {
                MessageBox.Show(
                    this,
                    "エラーが発生しています",
                    "重複",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private ArmyArsenal processNone(string line, ref ELoadState state)
        {
            var find = line.IndexOf("_equip_");
            if (find == -1) return null;

            var army = line.Substring(find + "_equip_".Length);
            army = army.Replace(" ", "");
            army = army.Replace("\t", "");
            army = army.Replace("=", "");
            army = army.Replace("[", "");

            state = ELoadState.array;
            if (army.Contains("default") || army.Contains("defalt"))
            {
                return null;
            }

            // 兵科生成
            return AddArmy(army);
        }

        private bool processArray(string line, ArmyArsenal ctrl)
        {
            line = line.Replace(" ", "");
            line = line.Replace("\t", "");
            line = line.Replace("\"", "");
            line = line.Replace("[", "");
            if (line == "") return false;

            var items = line.Split(new char[]{ ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items)
            {
                if (item.Contains("]")) return true;

                string err = null;
                if (ctrl == null) err = AddList(item);
                else err = ctrl.AddList(item);

                if (err != null)
                {
                    WriteError(err);
                }
            }
            return false;
        }
        #endregion

        #region LoadGearScript
        private void processLine(string line, ref ArmyArsenal ctrl, ref ELoadState state)
        {
            switch (state)
            {
                case ELoadState.none:
                    {
                        var find = line.IndexOf("_roleVar");
                        if (find == -1)
                        {
                            find = line.IndexOf("_commonItem");
                            if (find == -1) return;  // 何もしない

                            // 共通装備読込
                            state = ELoadState.findArmy;
                            return;
                        }

                        // 各兵科読込
                        var armyString = line.Split('\"')[1];
                        ctrl = AddArmy(armyString);

                        state = ELoadState.findArmy;
                    }
                    break;

                case ELoadState.findArmy:
                    {
                        var find = line.IndexOf("{");
                        if (find == -1) return;

                        state = ELoadState.array;
                    }
                    break;

                case ELoadState.array:
                    {
                        var find = line.IndexOf("}");
                        if (find == 0)
                        {
                            ctrl = null;
                            state = ELoadState.none;
                            return;
                        }

                        var splitStr = line.Split('\"');
                        if (splitStr.Length <= 2) return;

                        var className = (splitStr.Length > 3) ? splitStr[3] : splitStr[1];

                        if (ctrl == null)
                        {
                            AddList(className);
                        }
                        else
                        {
                            ctrl.AddList(className);
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        private void LoadGearScript(StreamReader sr)
        {
            ELoadState state = ELoadState.none;
            ArmyArsenal ctrl = null;
            while (sr.EndOfStream == false)
            {
                var line = sr.ReadLine();

                line = RemoveComment(line);
                if (line == "") continue;

                processLine(line, ref ctrl, ref state);
            }
        }

        private void btnGearLoadScript_Click(object sender, EventArgs e)
        {
            var loadFileDiag = new OpenFileDialog();
            loadFileDiag.Filter = "sqfファイル(*.sqf)|*.sqf";
            loadFileDiag.FileOk += (o, ev) =>
            {
                // 準備
                if (tabControlArmy.Controls.Count > 0)
                {
                    var ret = MessageBox.Show(
                        this,
                        "既に兵科が追加されていますが、全削除しますか？",
                        "兵科確認",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (ret == DialogResult.Yes)
                    {
                        tabControlArmy.Controls.Clear();
                    }
                }

                // 読込
                using (var sr = new StreamReader(loadFileDiag.OpenFile()))
                {
                    try
                    {
                        LoadGearScript(sr);
                    }
                    catch (Exception ex)
                    {
                        using (var sw = new StreamWriter("log.txt", false))
                        {
                            sw.WriteLine(ex.Message);
                            sw.WriteLine(ex.InnerException);
                            sw.WriteLine(ex.StackTrace);
                            sw.WriteLine();
                        }
                        MessageBox.Show(
                            this,
                            "読込エラーが発生しました\n下記2つをtowaに送付してもらえると解析します\n・読み込んだsqfファイル\n・exeフォルダに出力されたlog.txt",
                            "読込エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            };

            loadFileDiag.ShowDialog(this);
        }
        #endregion

        #region 出力
        private void btnCreate_Click(object sender, EventArgs e)
        {
            var saveFile = new SaveFileDialog();
            saveFile.Filter = "sqfファイル(*.sqf)|*.sqf";
            saveFile.FileName = "Arsenal_by_Military_Department_ver3";

            saveFile.FileOk += (o, ev) =>
            {
                using (StreamWriter sw = new StreamWriter(saveFile.OpenFile()))
                {
                    WriteScriptHeader(sw);
                    WriteDefault(sw);
                    WriteArmy(sw);

                    // フッター
                    sw.WriteLine("\n\n");
                    sw.WriteLine(@"
[BOX_01, _equip_default] call ace_arsenal_fnc_addVirtualItems;
BOX_01 call _openBox;");
                    sw.WriteLine("hint 'ERROR: role name'");
                }
            };

            saveFile.ShowDialog(this);
        }

        private void WriteScriptHeader(StreamWriter sw)
        {
            var sb = new StringBuilder();
            #region header
            string header;
            using (StreamReader sr = new StreamReader("SQFHeader.txt"))
            {
                header = sr.ReadToEnd() + "\n";
            }

            sb.Append(header + 
@"BOX_01 = _this;
_thisRole = roleDescription player;

// シングルプレイ時は、何もしない
if (_thisRole == """") exitwith {hint ""single play..."";};


//プレイヤーにアーセナルを表示する
_openBox =
{
    BOX_01 = _this;
    [BOX_01, player] call ace_arsenal_fnc_openBox;
    // [BOX_01, true, false] call ace_arsenal_fnc_removeVirtualItems;
};"
            );
            #endregion
            sw.WriteLine(sb.ToString());
        }

        private void WriteItems(StreamWriter sw, string name, ListBox.ObjectCollection collection)
        {
            var sb = new StringBuilder();
            sb.AppendLine("_equip_" + name + " =\n[");

            if (collection.Count != 0)
            {
                var size = collection.Count;
                for (int i = 0; i < size - 1; i++)
                {
                    sb.AppendLine("    \"" + (string)(collection[i]) + "\", ");
                }
                sb.AppendLine("    \"" + (string)(collection[size - 1]) + "\"");
            }

            sb.AppendLine("];");
            sw.WriteLine(sb.ToString());
        }

        private void WriteDefault(StreamWriter sw)
        {
            sw.WriteLine(@"
//// 以下、装備内容
//_equip_defaultに、全兵科に共通して追加したいアイテムのクラスネームを記述");
            WriteItems(sw, "default", listArsenal.Items);
        }

        private void WriteArmy(StreamWriter sw)
        {
            // 各兵科データの連装配列作成
            var map = new Dictionary<string, ListBox.ObjectCollection>();
            foreach (TabPage page in tabControlArmy.TabPages)
            {
                var arsenal = (ArmyArsenal)page.Controls[0];
                var data = arsenal.GetProparty();
                if (data.Key == "") continue;

                map.Add(data.Key, data.Value);
            }

            foreach (var item in map)
            {
                WriteItems(sw, item.Key, item.Value);
            }

            sw.WriteLine("//// 以下、分岐処理");

            var tmp = new List<string>();
            foreach (var item in map)
            {
                tmp.Insert(0, item.Key);
            }
            foreach (var item in tmp)
            {
                sw.WriteLine("//" + item);
                sw.WriteLine(@"_roleVar = """+ item + @""";
if ([_roleVar, _thisRole, true] call BIS_fnc_inString) exitWith {
    _equip_" + item + @"= _equip_default + _equip_" + item + @";
    [BOX_01, _equip_" + item + @"] call ace_arsenal_fnc_addVirtualItems;
    BOX_01 call _openBox;
};");
            }
        }
        #endregion

        #region 共通処理
        private string RemoveComment(string src, string commentPrefix = "//")
        {
            var ret = src;
            var comment = src.IndexOf("//");
            if (comment != -1)
            {
                ret = src.Substring(0, comment);
            }
            return ret;
        }

        public Control.ControlCollection GetTabs ()
        {
            return tabControlArmy.Controls;
        }
        #endregion

        #region CloseTab
        private void CloseTab()
        {
            tabControlArmy.Controls.Remove(tabControlArmy.SelectedTab);
        }

        private void toolStripMenuItemTabClose_Click(object sender, EventArgs e)
        {
            CloseTab();
        }
        #endregion

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
                    Clipboard.SetText(text.Substring(0, text.Length - 2));
                }
                e.SuppressKeyPress = true; // システムのデフォルト挙動を無効化
            }
        }

    }
}

