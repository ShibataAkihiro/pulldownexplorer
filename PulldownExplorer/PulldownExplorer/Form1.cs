using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PulldownExplorer
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            var rootItem = new ANode();
            rootItem.Text = "asdf";
            folderListTreeView.Nodes.Add(rootItem);
        }

    }

    public class ANode : TreeNode
    {
        public ANode() { }
    }
    public class FileSystemNode : TreeNode
    {
        public System.IO.DirectoryInfo Directory { get; }
        public bool Exist => this.Directory.Exists;
        public new List<FileSystemNode> Nodes = new List<FileSystemNode>();
        public FileSystemNode(string path)
        {
            Directory = new System.IO.DirectoryInfo(path);
            Text = Directory.Name;
            foreach (var d in Directory.GetDirectories())
            {
                Nodes.Add(new FileSystemNode(d.FullName));
            }
        }

    }
}
