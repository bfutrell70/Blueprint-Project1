namespace eBookManager
{
    partial class ImportBooks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportBooks));
            this.tvImages = new System.Windows.Forms.ImageList(this.components);
            this.btnSelectSourceFolder = new System.Windows.Forms.Button();
            this.tvFoundBooks = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStorageSpaceDescription = new System.Windows.Forms.TextBox();
            this.lbleBookCount = new System.Windows.Forms.Label();
            this.lblStorageSpaceDescription = new System.Windows.Forms.Label();
            this.btnCancelNewStorageSpaceSave = new System.Windows.Forms.Button();
            this.btnSaveNewStorageSpace = new System.Windows.Forms.Button();
            this.txtNewStorageSpaceName = new System.Windows.Forms.TextBox();
            this.btnAddNewStorageSpace = new System.Windows.Forms.Button();
            this.dlVirtualStorageSpaces = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFileSize = new System.Windows.Forms.TextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.txtFileExtension = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.dtCreated = new System.Windows.Forms.DateTimePicker();
            this.dtLastAccessed = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnAddeBookToStorageSpace = new System.Windows.Forms.Button();
            this.dtDatePublished = new System.Windows.Forms.DateTimePicker();
            this.dlClassification = new System.Windows.Forms.ComboBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvImages
            // 
            this.tvImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tvImages.ImageStream")));
            this.tvImages.TransparentColor = System.Drawing.Color.Transparent;
            this.tvImages.Images.SetKeyName(0, "docx16.png");
            this.tvImages.Images.SetKeyName(1, "docxx16.png");
            this.tvImages.Images.SetKeyName(2, "pdfx16.png");
            this.tvImages.Images.SetKeyName(3, "epubx16.png");
            this.tvImages.Images.SetKeyName(4, "folder-close-x16.png");
            this.tvImages.Images.SetKeyName(5, "folder_exp_x16.png");
            // 
            // btnSelectSourceFolder
            // 
            this.btnSelectSourceFolder.AutoSize = true;
            this.btnSelectSourceFolder.Location = new System.Drawing.Point(12, 12);
            this.btnSelectSourceFolder.Name = "btnSelectSourceFolder";
            this.btnSelectSourceFolder.Size = new System.Drawing.Size(116, 23);
            this.btnSelectSourceFolder.TabIndex = 0;
            this.btnSelectSourceFolder.Text = "Select Source Folder";
            this.btnSelectSourceFolder.UseVisualStyleBackColor = true;
            this.btnSelectSourceFolder.Click += new System.EventHandler(this.btnSelectSourceFolder_Click);
            // 
            // tvFoundBooks
            // 
            this.tvFoundBooks.Location = new System.Drawing.Point(12, 41);
            this.tvFoundBooks.Name = "tvFoundBooks";
            this.tvFoundBooks.Size = new System.Drawing.Size(499, 190);
            this.tvFoundBooks.TabIndex = 1;
            this.tvFoundBooks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFoundBooks_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtStorageSpaceDescription);
            this.groupBox1.Controls.Add(this.lbleBookCount);
            this.groupBox1.Controls.Add(this.lblStorageSpaceDescription);
            this.groupBox1.Controls.Add(this.btnCancelNewStorageSpaceSave);
            this.groupBox1.Controls.Add(this.btnSaveNewStorageSpace);
            this.groupBox1.Controls.Add(this.txtNewStorageSpaceName);
            this.groupBox1.Controls.Add(this.btnAddNewStorageSpace);
            this.groupBox1.Controls.Add(this.dlVirtualStorageSpaces);
            this.groupBox1.Location = new System.Drawing.Point(12, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 192);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Virtual Storage Space";
            // 
            // txtStorageSpaceDescription
            // 
            this.txtStorageSpaceDescription.Location = new System.Drawing.Point(234, 62);
            this.txtStorageSpaceDescription.Multiline = true;
            this.txtStorageSpaceDescription.Name = "txtStorageSpaceDescription";
            this.txtStorageSpaceDescription.Size = new System.Drawing.Size(257, 98);
            this.txtStorageSpaceDescription.TabIndex = 11;
            // 
            // lbleBookCount
            // 
            this.lbleBookCount.AutoSize = true;
            this.lbleBookCount.Location = new System.Drawing.Point(7, 45);
            this.lbleBookCount.Name = "lbleBookCount";
            this.lbleBookCount.Size = new System.Drawing.Size(0, 13);
            this.lbleBookCount.TabIndex = 10;
            // 
            // lblStorageSpaceDescription
            // 
            this.lblStorageSpaceDescription.AutoSize = true;
            this.lblStorageSpaceDescription.Location = new System.Drawing.Point(231, 46);
            this.lblStorageSpaceDescription.Name = "lblStorageSpaceDescription";
            this.lblStorageSpaceDescription.Size = new System.Drawing.Size(137, 13);
            this.lblStorageSpaceDescription.TabIndex = 8;
            this.lblStorageSpaceDescription.Text = "Storage Space Description:";
            // 
            // btnCancelNewStorageSpaceSave
            // 
            this.btnCancelNewStorageSpaceSave.Location = new System.Drawing.Point(439, 17);
            this.btnCancelNewStorageSpaceSave.Name = "btnCancelNewStorageSpaceSave";
            this.btnCancelNewStorageSpaceSave.Size = new System.Drawing.Size(52, 23);
            this.btnCancelNewStorageSpaceSave.TabIndex = 7;
            this.btnCancelNewStorageSpaceSave.Text = "cancel";
            this.btnCancelNewStorageSpaceSave.UseVisualStyleBackColor = true;
            this.btnCancelNewStorageSpaceSave.Click += new System.EventHandler(this.btnCancelNewStorageSpaceSave_Click);
            // 
            // btnSaveNewStorageSpace
            // 
            this.btnSaveNewStorageSpace.Location = new System.Drawing.Point(373, 17);
            this.btnSaveNewStorageSpace.Name = "btnSaveNewStorageSpace";
            this.btnSaveNewStorageSpace.Size = new System.Drawing.Size(60, 23);
            this.btnSaveNewStorageSpace.TabIndex = 6;
            this.btnSaveNewStorageSpace.Text = "save";
            this.btnSaveNewStorageSpace.UseVisualStyleBackColor = true;
            this.btnSaveNewStorageSpace.Click += new System.EventHandler(this.btnSaveNewStorageSpace_Click);
            // 
            // txtNewStorageSpaceName
            // 
            this.txtNewStorageSpaceName.Location = new System.Drawing.Point(231, 19);
            this.txtNewStorageSpaceName.Name = "txtNewStorageSpaceName";
            this.txtNewStorageSpaceName.Size = new System.Drawing.Size(136, 20);
            this.txtNewStorageSpaceName.TabIndex = 5;
            // 
            // btnAddNewStorageSpace
            // 
            this.btnAddNewStorageSpace.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewStorageSpace.Image")));
            this.btnAddNewStorageSpace.Location = new System.Drawing.Point(187, 17);
            this.btnAddNewStorageSpace.Name = "btnAddNewStorageSpace";
            this.btnAddNewStorageSpace.Size = new System.Drawing.Size(38, 23);
            this.btnAddNewStorageSpace.TabIndex = 4;
            this.btnAddNewStorageSpace.UseVisualStyleBackColor = true;
            this.btnAddNewStorageSpace.Click += new System.EventHandler(this.btnAddNewStorageSpace_Click);
            // 
            // dlVirtualStorageSpaces
            // 
            this.dlVirtualStorageSpaces.FormattingEnabled = true;
            this.dlVirtualStorageSpaces.Location = new System.Drawing.Point(6, 19);
            this.dlVirtualStorageSpaces.Name = "dlVirtualStorageSpaces";
            this.dlVirtualStorageSpaces.Size = new System.Drawing.Size(175, 21);
            this.dlVirtualStorageSpaces.TabIndex = 3;
            this.dlVirtualStorageSpaces.SelectedIndexChanged += new System.EventHandler(this.dlVirtualStorageSpaces_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFileSize);
            this.groupBox2.Controls.Add(this.txtFilePath);
            this.groupBox2.Controls.Add(this.txtFileExtension);
            this.groupBox2.Controls.Add(this.txtFileName);
            this.groupBox2.Controls.Add(this.dtCreated);
            this.groupBox2.Controls.Add(this.dtLastAccessed);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(517, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 176);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Details";
            // 
            // txtFileSize
            // 
            this.txtFileSize.Location = new System.Drawing.Point(98, 143);
            this.txtFileSize.Name = "txtFileSize";
            this.txtFileSize.Size = new System.Drawing.Size(216, 20);
            this.txtFileSize.TabIndex = 15;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(98, 117);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(216, 20);
            this.txtFilePath.TabIndex = 14;
            // 
            // txtFileExtension
            // 
            this.txtFileExtension.Location = new System.Drawing.Point(98, 39);
            this.txtFileExtension.Name = "txtFileExtension";
            this.txtFileExtension.Size = new System.Drawing.Size(216, 20);
            this.txtFileExtension.TabIndex = 13;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(98, 13);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(216, 20);
            this.txtFileName.TabIndex = 12;
            // 
            // dtCreated
            // 
            this.dtCreated.Location = new System.Drawing.Point(98, 93);
            this.dtCreated.Name = "dtCreated";
            this.dtCreated.Size = new System.Drawing.Size(216, 20);
            this.dtCreated.TabIndex = 11;
            // 
            // dtLastAccessed
            // 
            this.dtLastAccessed.Location = new System.Drawing.Point(98, 67);
            this.dtLastAccessed.Name = "dtLastAccessed";
            this.dtLastAccessed.Size = new System.Drawing.Size(216, 20);
            this.dtLastAccessed.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Size;";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "File Path:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Created:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Last Accessed:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "File extension:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "File name:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPrice);
            this.groupBox3.Controls.Add(this.btnAddeBookToStorageSpace);
            this.groupBox3.Controls.Add(this.dtDatePublished);
            this.groupBox3.Controls.Add(this.dlClassification);
            this.groupBox3.Controls.Add(this.txtCategory);
            this.groupBox3.Controls.Add(this.txtISBN);
            this.groupBox3.Controls.Add(this.txtPublisher);
            this.groupBox3.Controls.Add(this.txtAuthor);
            this.groupBox3.Controls.Add(this.txtTitle);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(517, 223);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 215);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Book Details";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(98, 81);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(216, 20);
            this.txtPrice.TabIndex = 18;
            // 
            // btnAddeBookToStorageSpace
            // 
            this.btnAddeBookToStorageSpace.Image = ((System.Drawing.Image)(resources.GetObject("btnAddeBookToStorageSpace.Image")));
            this.btnAddeBookToStorageSpace.Location = new System.Drawing.Point(98, 186);
            this.btnAddeBookToStorageSpace.Name = "btnAddeBookToStorageSpace";
            this.btnAddeBookToStorageSpace.Size = new System.Drawing.Size(38, 23);
            this.btnAddeBookToStorageSpace.TabIndex = 17;
            this.btnAddeBookToStorageSpace.UseVisualStyleBackColor = true;
            this.btnAddeBookToStorageSpace.Click += new System.EventHandler(this.btnAddeBookToStorageSpace_Click);
            // 
            // dtDatePublished
            // 
            this.dtDatePublished.Location = new System.Drawing.Point(98, 120);
            this.dtDatePublished.Name = "dtDatePublished";
            this.dtDatePublished.Size = new System.Drawing.Size(200, 20);
            this.dtDatePublished.TabIndex = 16;
            // 
            // dlClassification
            // 
            this.dlClassification.FormattingEnabled = true;
            this.dlClassification.Location = new System.Drawing.Point(98, 162);
            this.dlClassification.Name = "dlClassification";
            this.dlClassification.Size = new System.Drawing.Size(121, 21);
            this.dlClassification.TabIndex = 14;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(98, 140);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(216, 20);
            this.txtCategory.TabIndex = 13;
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(98, 101);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(216, 20);
            this.txtISBN.TabIndex = 12;
            // 
            // txtPublisher
            // 
            this.txtPublisher.Location = new System.Drawing.Point(98, 60);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(216, 20);
            this.txtPublisher.TabIndex = 11;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(98, 40);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(216, 20);
            this.txtAuthor.TabIndex = 10;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(98, 19);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(216, 20);
            this.txtTitle.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 162);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Classification:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 142);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Category:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 122);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Date published:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "ISBN:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Price:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Publisher:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Author:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Title:";
            // 
            // ImportBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(849, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tvFoundBooks);
            this.Controls.Add(this.btnSelectSourceFolder);
            this.Name = "ImportBooks";
            this.Text = "ImportBooks";
            this.Load += new System.EventHandler(this.ImportBooks_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList tvImages;
        private System.Windows.Forms.Button btnSelectSourceFolder;
        private System.Windows.Forms.TreeView tvFoundBooks;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbleBookCount;
        private System.Windows.Forms.Label lblStorageSpaceDescription;
        private System.Windows.Forms.Button btnCancelNewStorageSpaceSave;
        private System.Windows.Forms.Button btnSaveNewStorageSpace;
        private System.Windows.Forms.TextBox txtNewStorageSpaceName;
        private System.Windows.Forms.Button btnAddNewStorageSpace;
        private System.Windows.Forms.ComboBox dlVirtualStorageSpaces;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtCreated;
        private System.Windows.Forms.DateTimePicker dtLastAccessed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddeBookToStorageSpace;
        private System.Windows.Forms.DateTimePicker dtDatePublished;
        private System.Windows.Forms.ComboBox dlClassification;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtStorageSpaceDescription;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtFileExtension;
        private System.Windows.Forms.TextBox txtFileSize;
        private System.Windows.Forms.TextBox txtFilePath;
    }
}