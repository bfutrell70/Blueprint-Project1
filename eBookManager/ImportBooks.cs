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
                    txtFileName.Text = fileName;
                    txtFileExtension.Text = fileExtension;
                    dtCreated.Value = dateCreated;
                    dtLastAccessed.Value = dateLastAccessed;
                    txtFilePath.Text = e.Node.Tag.ToString();
                    txtFileSize.Text = $"{Round(fileLength.ToMegabytes(), 2).ToString()} MB";
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
                txtNewStorageSpaceName.Visible = true;
                lblStorageSpaceDescription.Visible = true;
                txtStorageSpaceDescription.ReadOnly = false;
                btnSaveNewStorageSpace.Visible = true;
                btnCancelNewStorageSpaceSave.Visible = true;
                dlVirtualStorageSpaces.Enabled = false;
                btnAddNewStorageSpace.Enabled = false;
                lbleBookCount.Text = string.Empty;                
            }
            else if (selectedValue != (int)StorageSpaceSelection.NoSelection)
            {
                // find the contents of the selected storage space
                int contentCount = (from c in spaces
                                    where c.ID == selectedValue
                                    select c).Count();
                if (contentCount > 0)
                {
                    StorageSpace selectedSpace = (from c in spaces
                                                  where c.ID == selectedValue
                                                  select c).First();
                    txtStorageSpaceDescription.Text = selectedSpace.Description;

                    List<Document> eBooks = (selectedSpace.BookList == null) ? new List<Document> { } : selectedSpace.BookList;
                    lbleBookCount.Text = $"Storage Space contains {eBooks.Count()} {(eBooks.Count() == 1 ? "eBook" : "eBooks")}";
                }
            }
            else
            {
                lbleBookCount.Text = "";
            }
        }

        private void btnSaveNewStorageSpace_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewStorageSpaceName.Text.Length != 0)
                {
                    string newName = txtNewStorageSpaceName.Text;

                    // throw expressions: bool spaceExists = (spaceExists = false) ? return false : throw exception

                    // out variables
                    bool spaceExists = (!spaces.StorageSpaceExists(newName, out int nextID)) ?
                        false :
                        throw new Exception("The storage space you are trying to add already exists");

                    if (!spaceExists)
                    {
                        StorageSpace newSpace = new StorageSpace();
                        newSpace.Name = newName;
                        newSpace.ID = nextID;
                        newSpace.Description = txtStorageSpaceDescription.Text;
                        spaces.Add(newSpace);
                        PopulateStorageSpacesList();

                        // Save new Storage Space Name
                        txtNewStorageSpaceName.Clear();
                        txtNewStorageSpaceName.Visible = false;
                        lblStorageSpaceDescription.Visible = false;
                        txtStorageSpaceDescription.ReadOnly = true;
                        txtStorageSpaceDescription.Clear();
                        btnSaveNewStorageSpace.Visible = false;
                        btnCancelNewStorageSpaceSave.Visible = false;
                        dlVirtualStorageSpaces.Enabled = true;
                        btnAddNewStorageSpace.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                txtNewStorageSpaceName.SelectAll();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddeBookToStorageSpace_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedStorageSpaceID = dlVirtualStorageSpaces.SelectedValue.ToString().ToInt();
                if ((selectedStorageSpaceID != (int)StorageSpaceSelection.NoSelection) &&
                    (selectedStorageSpaceID != (int)StorageSpaceSelection.New))
                {
                    UpdateStorageSpaceBooks(selectedStorageSpaceID);
                }
                else
                    throw new Exception("Please select a Storage Space to add your eBook to");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateStorageSpaceBooks(int storageSpaceID)
        {
            try
            {
                int iCount = (from s in spaces
                              where s.ID == storageSpaceID
                              select s).Count();

                if (iCount > 0) // the space will always exist
                {
                    // Update
                    StorageSpace existingSpace = (from s in spaces
                                                  where s.ID == storageSpaceID
                                                  select s).First();

                    List<Document> ebooks = existingSpace.BookList;

                    int iBooksExist = (ebooks != null) ? 
                        (from b in ebooks where $"{b.FileName}".Equals($"{txtFileName.Text.Trim()}") select b).Count() : 
                        0;

                    if (iBooksExist > 0)
                    {
                        // update exisitng book
                        DialogResult dlgResult = 
                            MessageBox.Show($"A book with the same name has been found in Storage Space {existingSpace.Name}. Do you want to replace the existing book entry with this one?", 
                            "Duplicate Title", 
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2);

                        if (dlgResult == DialogResult.Yes)
                        {
                            Document exisitngBook = (from b in ebooks
                                                     where $"{b.FileName}".Equals($"{txtFileName.Text.Trim()}")
                                                     select b).First();

                            exisitngBook.FileName = txtFileName.Text;
                            exisitngBook.Extension = txtFileExtension.Text;
                            exisitngBook.LastAccessed = dtLastAccessed.Value;
                            exisitngBook.Created = dtCreated.Value;
                            exisitngBook.FilePath = txtFilePath.Text;
                            exisitngBook.Title = txtTitle.Text;
                            exisitngBook.Author = txtAuthor.Text;
                            exisitngBook.Publisher = txtPublisher.Text;
                            exisitngBook.Price = txtPrice.Text;
                            exisitngBook.ISBN = txtISBN.Text;
                            exisitngBook.PublishDate = dtDatePublished.Value;
                            exisitngBook.Category = txtCategory.Text;
                        }
                        else
                        {
                            // Insert new book
                            Document newBook = new Document
                            {
                                FileName = txtFileName.Text,
                                Extension = txtFileExtension.Text,
                                LastAccessed = dtLastAccessed.Value,
                                Created = dtCreated.Value,
                                FilePath = txtFilePath.Text,
                                FileSize = txtFileSize.Text,
                                Title = txtTitle.Text,
                                Author = txtAuthor.Text,
                                Publisher = txtPublisher.Text,
                                Price = txtPrice.Text,
                                ISBN = txtISBN.Text,
                                PublishDate = dtDatePublished.Value,
                                Category = txtCategory.Text
                            };

                            if (ebooks == null)
                                ebooks = new List<Document>();

                            ebooks.Add(newBook);
                            existingSpace.BookList = ebooks;
                        }
                    }

                    spaces.WriteToDataStore(_jsonPath);
                    PopulateStorageSpacesList();
                    MessageBox.Show("Book added");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelNewStorageSpaceSave_Click(object sender, EventArgs e)
        {
            txtNewStorageSpaceName.Clear();
            txtNewStorageSpaceName.Visible = false;
            lblStorageSpaceDescription.Visible = false;
            txtStorageSpaceDescription.ReadOnly = true;
            txtStorageSpaceDescription.Clear();
            btnSaveNewStorageSpace.Visible = false;
            btnCancelNewStorageSpaceSave.Visible = false;
            dlVirtualStorageSpaces.Enabled = true;
            btnAddNewStorageSpace.Enabled = true;
        }

        private void btnAddNewStorageSpace_Click(object sender, EventArgs e)
        {
            txtNewStorageSpaceName.Visible = true;
            lblStorageSpaceDescription.Visible = true;
            txtStorageSpaceDescription.ReadOnly = false;
            btnSaveNewStorageSpace.Visible = true;
            btnCancelNewStorageSpaceSave.Visible = true;
            dlVirtualStorageSpaces.Enabled = false;
            btnAddNewStorageSpace.Enabled = false;
        }
    }
}
