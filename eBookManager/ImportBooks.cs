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

        private HashSet<string> AllowedExtension => new
            HashSet<string>(StringComparer.InvariantCultureIgnoreCase)
            {".doc", ".docx", ".pdf", ".epub" };
        private enum Extention { doc = 0, docx = 1, pdf = 2, epub = 3}

        public ImportBooks()
        {
            InitializeComponent();
            _jsonPath = Path.Combine(Application.StartupPath, "bookData.txt");
            spaces = spaces.ReadFromDataStore(_jsonPath);
        }

        
    }
}
