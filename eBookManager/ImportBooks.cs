using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static eBookManager.Helper.ExtensionMethods;
using static System.Math;
using eBookManager.Engine;

namespace eBookManager
{
    public partial class ImportBooks : Form
    {
        private string _jsonPath;
        private List<StorageSpace> spaces;
        private enum StorageSpaceSelection { New = -9999, NoSelection = -1}

        private HashSet<string> AllowedExtensions => new
            HashSet<string>(StringComparer.InvariantCultureIgnoreCase)
            {".doc", ".docx", ".pdf", ".epub" };
        private enum Extention { doc = 0, docx = 1, pdf = 2, epub = 3}

        public ImportBooks()
        {
            InitializeComponent();
            _jsonPath = Path.Combine(Application.StartupPath, "bookData.txt");
            spaces = spaces.ReadFromDataStore(_jsonPath);
        }

        public void PopulateBookList(string paramDir, TreeNode paramNode)
        {
            DirectoryInfo dir = new DirectoryInfo(paramDir);
            foreach (DirectoryInfo dirInfo in dir.GetDirectories())
            {
                TreeNode node = new TreeNode(dirInfo.Name);
                node.ImageIndex = 4;
                node.SelectedImageIndex = 5;

                if (paramNode != null)
                {
                    paramNode.Nodes.Add(node);
                }
                else
                {
                    tvFoundBooks.Nodes.Add(node);
                }
                PopulateBookList(dirInfo.FullName, node);
            }

            foreach (FileInfo fileInfo in 
                dir.GetFiles().Where(x => AllowedExtensions.Contains(x.Extension)).ToList())
            {
                TreeNode node = new TreeNode(fileInfo.Name);
                node.Tag = fileInfo.FullName;
                int iconIndex = Enum.Parse(typeof(Extention), fileInfo.Extension.TrimStart('.'), true).GetHashCode();

                node.ImageIndex = iconIndex;
                node.SelectedImageIndex = iconIndex;
                if (paramNode != null)
                    paramNode.Nodes.Add(node);
                else
                    tvFoundBooks.Nodes.Add(node);
            }
        }

        private void btnSelectSourceFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Select the location of your eBooks and documents";

                DialogResult dlgResult = fbd.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    tvFoundBooks.Nodes.Clear();
                    tvFoundBooks.ImageList = tvImages;

                    string path = fbd.SelectedPath;
                    DirectoryInfo di = new DirectoryInfo(path);
                    TreeNode root = new TreeNode(di.Name);
                    root.ImageIndex = 4;
                    root.SelectedImageIndex = 5;
                    tvFoundBooks.Nodes.Add(root);
                    PopulateBookList(di.FullName, root);
                    tvFoundBooks.Sort();

                    root.Expand();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void tvFoundBooks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DocumentEngine engine = new DocumentEngine();
            string path = e.Node.Tag?.ToString() ?? "";

            if (File.Exists(path))
            {
                var (dateCreated, dateLastAccessed, fileName, fileExtension, fileLength, hasError) = engine.GetFileProperties(e.Node.Tag.ToString());
                if (!hasError)
                {
                    lblFileName.Text = fileName;
                    lblFileExtension.Text = fileExtension;
                    dtCreated.Value = dateCreated;
                    dtLastAccessed.Value = dateLastAccessed;
                    lblFilePath.Text = e.Node.Tag.ToString();
                    lblSize.Text = $"{Round(fileLength.ToMegabytes(), 2).ToString()} MB";
                }
            }

        }

        private void PopulateStorageSpacesList()
        {
            List<KeyValuePair<int, string>> lstSpaces =
                new List<KeyValuePair<int, string>>();
            BindStorageSpaceList((int)StorageSpaceSelection.NoSelection, "Select Storage Space");

            void BindStorageSpaceList(int key, string value)
            {
                // local function
                lstSpaces.Add(new KeyValuePair<int, string>(key, value));
            }

            if (spaces is null || spaces.Count() == 0) // Pattern matching
            {
                BindStorageSpaceList((int)StorageSpaceSelection.New, "<Create New>");
            }
            else
            {
                foreach (var space in spaces)
                {
                    BindStorageSpaceList(space.ID, space.Name);
                }
            }

            dlVirtualStorageSpaces.DataSource = new
                BindingSource(lstSpaces, null);
            dlVirtualStorageSpaces.DisplayMember = "Value";
            dlVirtualStorageSpaces.ValueMember = "Key";

        }

        private void ImportBooks_Load(object sender, EventArgs e)
        {
            PopulateStorageSpacesList();

            if (dlVirtualStorageSpaces.Items.Count == 0)
            {
                dlVirtualStorageSpaces.Items.Add("<create new storage space>");
            }

            lbleBookCount.Text = "";
        }

        private void dlVirtualStorageSpaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedValue = dlVirtualStorageSpaces.SelectedValue.ToString().ToInt();
            
            if (selectedValue == (int)StorageSpaceSelection.New) // -9999
            {
                txtewStorageSpaceName.Visible = true;
                lblStorageSpaceDescription.Visible = true;
                
            }
        }
    }
}
