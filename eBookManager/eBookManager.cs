using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eBookManager.Engine;
using eBookManager.Helper;
using System.IO;
using System.Diagnostics;

namespace eBookManager
{
    public partial class eBookManager : Form
    {
        private string _jsonPath;
        private List<StorageSpace> spaces;

        public eBookManager()
        {
            InitializeComponent();
            _jsonPath = Path.Combine(Application.StartupPath, "bookData.txt");
            spaces = spaces.ReadFromDataStore(_jsonPath);
        }

        private void eBookManager_Load(object sender, EventArgs e)
        {
            // reads any availavle storage spaces and populates the storage spaces list view
            // control with the previously saved storage spaces
            PopulateStorageSpaceList();
        }

        private void PopulateStorageSpaceList()
        {
            lstStorageSpaces.Clear();
            if (spaces != null)
            {
                foreach (StorageSpace space in spaces)
                {
                    ListViewItem lvItem = new ListViewItem(space.Name, 0);
                    lvItem.Tag = space.BookList;
                    lvItem.Name = space.ID.ToString();
                    lstStorageSpaces.Items.Add(lvItem);
                }
            }
        }

        private void lstStorageSpaces_MouseClick(object sender, MouseEventArgs e)
        {
            // reads the books contained in the selected storage space
            ListViewItem selectedStorageSpace = lstStorageSpaces.SelectedItems[0];
            int spaceID = selectedStorageSpace.Name.ToInt();

            txtStorageSpaceDescription.Text = (from d in spaces
                                               where d.ID == spaceID
                                               select d.Description).First();

            List<Document> ebookList = (List<Document>)selectedStorageSpace.Tag;
            PopulateContainedEbooks(ebookList);
        }

        private void PopulateContainedEbooks(List<Document> ebookList)
        {
            // Populates the lstBooks list view with the books contained in the selected
            // storage space
            lstBooks.Clear();
            ClearSelectedBook();

            if (ebookList != null)
            {
                foreach (Document eBook in ebookList)
                {
                    ListViewItem book = new ListViewItem(eBook.Title, 1);
                    book.Tag = eBook;
                    lstBooks.Items.Add(book);
                }
            }
            else
            {
                ListViewItem book = new ListViewItem("This storage space contains no eBooks", 2);
                book.Tag = "";
                lstBooks.Items.Add(book);
            }
        }

        private void ClearSelectedBook()
        {
            foreach (Control ctrl in gbBookDetails.Controls)
            {
                if (ctrl is TextBox)
                    ctrl.Text = string.Empty;
            }

            foreach (Control ctrl in gbFileDetails.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = string.Empty;
                }
            }

            dtLastAccessed.Value = DateTime.Now;
            dtCreated.Value = DateTime.Now;
            dtPublished.Value = DateTime.Now;
        }

        private void importEBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportBooks import = new ImportBooks();
            import.ShowDialog();
            spaces = spaces.ReadFromDataStore(_jsonPath);
            PopulateStorageSpaceList();
        }

        private void lstBooks_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectedBook = lstBooks.SelectedItems[0];
            if (!string.IsNullOrEmpty(selectedBook.Tag.ToString()))
            {
                Document ebook = (Document)selectedBook.Tag;
                txtFileName.Text = ebook.FileName;
                txtFileExtension.Text = ebook.Extension;
                dtLastAccessed.Value = ebook.LastAccessed;
                dtCreated.Value = ebook.Created;
                txtFilePath.Text = ebook.FilePath;
                txtSize.Text = ebook.FileSize;
                txtTitle.Text = ebook.Title;
                txtAuthor.Text = ebook.Author;
                txtPublisher.Text = ebook.Publisher;
                txtPrice.Text = ebook.Price;
                txtISBN.Text = ebook.ISBN;
                dtPublished.Value = ebook.PublishDate;
                txtCategory.Text = ebook.Category;

            }
        }

        private void btnReadEBook_Click(object sender, EventArgs e)
        {
            string filePath = txtFilePath.Text;
            FileInfo fi = new FileInfo(filePath);
            if (fi.Exists)
            {
                Process.Start(Path.GetDirectoryName(filePath));
            }
        }
    }
}
