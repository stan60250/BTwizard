using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BTTool;
using System.Text.RegularExpressions;

namespace BTwizard
{
    public partial class MainForm : Form
    {

        List<string> MissionList_filepath = new List<string>();

        string TorrentList_name = "";
        List<string> TorrentList_filepath = new List<string>();
        List<int> TorrentList_filelength = new List<int>();

        public MainForm()
        {
            InitializeComponent();

            //清除並載入MissionList
            cleanMissionList();
            loadMissionList();
        }

        //清除MissionList
        private void cleanMissionList()
        {
            listView_Mission.Clear();
            listView_Mission.SmallImageList = imgIcon;
        }

        //載入MissionList
        private void loadMissionList()
        {
            /*listView_Mission.BeginUpdate();
            for (int i = 0; i < 10; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = 0;
                lvi.Text = "item" + i;
                listView_Mission.Items.Add(lvi);
            }
            listView_Mission.EndUpdate(); */
        }

        //加入任務至MissionList
        private void addMissionList(string fileName)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.ImageIndex = 0;
            lvi.Text = fileName;
            listView_Mission.Items.Add(lvi);
        }

        private void listView_Mission_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView_Mission_DragEnter(object sender, DragEventArgs e)
        {
            // 確定使用者抓進來的是檔案
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // 允許拖拉動作繼續 (這時滑鼠游標應該會顯示 +)
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listView_Mission_DragDrop(object sender, DragEventArgs e)
        {
            List<string> filepaths = new List<string>();
            foreach (var s in (string[])e.Data.GetData(DataFormats.FileDrop, false))
            {
                if (Directory.Exists(s))
                {
                    //Add files from folder
                    filepaths.AddRange(Directory.GetFiles(s));
                }
                else
                {
                    //Add filepath
                    filepaths.Add(s);
                }
            }

            filepaths.ForEach(delegate(String filepath)
            {
                if (new FileInfo(filepath).Extension.ToLower().Equals(".torrent") && !MissionList_filepath.Exists(s => s.Equals(filepath)))
                {
                    MissionList_filepath.Add(filepath);
                    addMissionList(Path.GetFileNameWithoutExtension(filepath));
                    TorrentList_name = Path.GetFileNameWithoutExtension(filepath);
                    AnalyseTorrent(filepath);
                }
            });
        }

        private void AnalyseTorrent(string filename)
        {
            SetLogger(BTToolLogger.Start('f', filename));
            TorrentFile torrentFile = new TorrentFile();
            try
            {
                torrentFile.OpenFile(filename);
            }
            catch
            {
                SetLogger(BTToolLogger.Start('e', filename));
            }
            SetLogger(BTToolLogger.End('f'));
            SetLogger(BTToolLogger.Start('s'));
            TreeNode rootNode = torrentFile.RootNode;
            rootNode.Expand();
            treeView_Structure.Nodes.Clear();
            treeView_Structure.Nodes.Add(rootNode);
            SetLogger(BTToolLogger.End('s'));
            
            GetFileList(rootNode);
            addTorrentFileList();
            addTorrentFileTree();
        }

        private void SetLogger(string message)
        {
            this.Invoke(new Action(() =>
            {
                tbLogger.Text += message;
                tbLogger.Text += Environment.NewLine;
            }));
        }

        private bool GetFileList(TreeNode treeNode)
        {
            TreeNode[] nodeMap = GetAllNodes(treeNode);

            int i = 0;
            int index_file = 0;
            int value_file = 0;
            foreach (TreeNode node in nodeMap)
            {
                if (nodeGetName(node.Text).Equals("files"))
                {
                    value_file = nodeGetIndex(node.Text, '[', ']');
                    index_file = i;
                    break;
                }
                i++;
            }

            i = 0;
            if (value_file > 0 && index_file > 0)
            {
                int p = 0;
                while (value_file > 0)
                {
                    int p_skip = 0;
                    string file_path = "";
                    int file_length = -1;
                    if (nodeGetName(nodeMap[index_file + (p+1)].Text).StartsWith("ITEM"))
                    {
                        value_file--;
                        for (int ip = 0; ip < nodeGetIndex(nodeMap[index_file + (p+1)].Text, '[', ']'); ip++)
                        {
                            if (nodeGetName(nodeMap[index_file + (p+1) + (ip+1)].Text).StartsWith("length"))
                            {
                                string str = nodeMap[index_file + (p+1) + (ip+1)].Text;
                                file_length = Int32.Parse(str.Substring(str.LastIndexOf('=') + 1));
                            }
                            else if (nodeGetName(nodeMap[index_file + (p+1) + (ip+1)].Text).StartsWith("path"))
                            {
                                for (int pp = 0; pp < nodeGetIndex(nodeMap[index_file + (p+1) + (ip+1)].Text, '[', ']'); pp++)
                                {
                                    file_path += "\\" + nodeMap[index_file + (p+1) + (ip+1) + (pp+1)].Text;
                                    p_skip++;
                                }
                            }
                            p_skip++;
                        }
                    }

                    if (file_path != "" && file_length >= 0)
                    {
                        TorrentList_filepath.Add(file_path);
                        TorrentList_filelength.Add(file_length);
                    }
                    p += p_skip;
                    p++;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private string nodeGetName(string str)
        {
            return Regex.Replace(Regex.Replace(str, @"\([^>]*\)", String.Empty), @"\[[^>]*\]", String.Empty);
        }

        private int nodeGetIndex(string str, char start, char end)
        {
            int cFrom = str.IndexOf(start) + 1;
            int cTo = str.LastIndexOf(end);
            return Int32.Parse(str.Substring(cFrom, cTo - cFrom));
        }

        private TreeNode FindNode(TreeNode tvSelection, string matchText)
        {
            foreach (TreeNode node in tvSelection.Nodes)
            {
                if (node.Tag.ToString().StartsWith(matchText))
                {
                    return node;
                }
                else
                {
                    TreeNode nodeChild = FindNode(node, matchText);
                    if (nodeChild != null) return nodeChild;
                }
            }
            return (TreeNode)null;
        }

        private TreeNode[] GetAllNodes(object treeOrNode)
        {
            if (!(treeOrNode is TreeNode) && !(treeOrNode is TreeView))
            {
                throw new ArgumentException("Error param type!!");
            }
            List<TreeNode> nodes = new List<TreeNode>();
            if (treeOrNode is TreeNode)
            {
                nodes.Add((TreeNode)treeOrNode);
            }
            foreach (TreeNode tn in ((TreeNode)treeOrNode).Nodes)
            {
                nodes.AddRange(GetAllNodes(tn));
            }
            return nodes.ToArray();
        }

        private void addTorrentFileList()
        {
            listView_File.Clear();
            listView_File.SmallImageList = imgIcon;
            listView_File.Columns.Add("file name", 120, HorizontalAlignment.Left);
            listView_File.Columns.Add("length", 80, HorizontalAlignment.Left);
            listView_File.Columns.Add("path", 500, HorizontalAlignment.Left);

            listView_File.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            for (int i = 0; i < TorrentList_filepath.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = 1;     //通过与imageList绑定，显示imageList中第i项图标

                lvi.Text = Path.GetFileName(TorrentList_filepath[i]);
                lvi.SubItems.Add(SizeSuffix(TorrentList_filelength[i]));
                lvi.SubItems.Add(TorrentList_filepath[i]);
                listView_File.Items.Add(lvi);
            }
            listView_File.EndUpdate();  //结束数据处理，UI界面一次性绘制。
        }

        /// <summary>
        /// an easy way convert bytes to KB, MB, GB, etc.
        /// </summary>
        /// <param name="value"></param>
        static string SizeSuffix(Int64 value)
        {
            string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return "0 " + SizeSuffixes[0]; }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            return string.Format("{0:0.##} {1}", adjustedSize, SizeSuffixes[mag]); //"{0:n1} {1}" "{0:0.##} {1}"
        }

        private void addTorrentFileTree()
        {
            List<string> filepath = new List<string>(TorrentList_filepath);

            foreach (string line in filepath)
            {
                CreatePath(treeView_File.Nodes, TorrentList_name + line);
            }
        }

        private void CreatePath(TreeNodeCollection nodeList, string path)
        {
            TreeNode node = null;
            string folder = string.Empty;

            int p = path.IndexOf('\\');
            if (p == -1)
            {
                folder = path;
                path = "";
            }
            else
            {
                folder = path.Substring(0, p);
                path = path.Substring(p + 1, path.Length - (p + 1));
            }
            node = null;
            foreach (TreeNode item in nodeList)
            {
                if (item.Text == folder)
                {
                    node = item;
                }
            }
            if (node == null)
            {
                node = new TreeNode(folder);
                nodeList.Add(node);
            }
            if (path != "")
            {
                CreatePath(node.Nodes, path);
            }
        }

        private void treeView_File_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.Expand();
        }
    }
}
