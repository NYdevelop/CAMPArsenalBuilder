using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CAMPArsenalBuilder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region 共通装備
        private void AddList(string str)
        {
            // 重複チェック
            foreach (string item in listArsenal.Items)
            {
                if (item == str)
                {
                    MessageBox.Show(
                        this,
                        "既に追加済みです\n共通装備\n項目名：" + item,
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

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            listArsenal.Items.Clear();
        }

        private void btnRemoveOne_Click(object sender, EventArgs e)
        {
            if (listArsenal.SelectedItem == null) return;
            var index = listArsenal.SelectedIndex;
            listArsenal.Items.Remove(listArsenal.SelectedItem);
            if (listArsenal.Items.Count != index) listArsenal.SelectedIndex = index;
            else listArsenal.SelectedIndex = index - 1;
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
            var ctrl = new ArmyArsenal();
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

                if (ctrl == null) AddList(item);
                else ctrl.AddList(item);
            }
            return false;
        }
        #endregion

        #region 出力
        private void btnCreate_Click(object sender, EventArgs e)
        {
            var saveFile = new SaveFileDialog();
            saveFile.Filter = "sqfファイル(*.sqf)|*.sqf";
            saveFile.FileName = "Arsenal_by_Military_Department_ver2";

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
    [BOX_01, true, false] call ace_arsenal_fnc_removeVirtualItems;
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
    }
}

