#region Version Info Header
/*
 * $Id$
 * $HeadURL$
 * Last modified by $Author$
 * Last modified at $Date$
 * $Revision$
 */
#endregion

using System;
using System.Linq;
using System.Windows.Forms;

using RssBandit.WinGui.Utility;
using NewsComponents;

namespace RssBandit.WinGui.Forms
{
	/// <summary>
	/// Import Feeds Dialog: requests a feed url to import
	/// </summary>
	public class ImportFeedsDialog : Form
	{
		private readonly UrlCompletionExtender urlExtender;

		private Label label2;
        private Button btnOk;
        private Button btnCancel;
        private TextBox textUrlOrFile;
		private ToolTip toolTip1;
		private Label label4;
		internal Button btnSelectFile;
		private ComboBox comboCategory;
		private Label label3;
        private ComboBox comboFeedSource;
        private Label label1;
		private System.ComponentModel.IContainer components;

        //private readonly FeedSourceManager feedSources;
        private readonly string defaultCategory; 
		/// <summary>
		/// Constructor is private because we always want the categories
		/// combo box to be filled
		/// </summary>
		private ImportFeedsDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			urlExtender = new UrlCompletionExtender(this);
			urlExtender.Add(this.textUrlOrFile); 
		}
		
		public ImportFeedsDialog(string urlOrFile, string selectedCategory, string defaultCategory, string selectedFeedSource, FeedSourceManager feedSources):
			this()	
		{
            //this.feedSources = feedSources;
            this.defaultCategory = defaultCategory; 
			this.textUrlOrFile.Text = (urlOrFile ?? String.Empty);
			
            //select the initial feed source used for populating combo boxes
            FeedSourceEntry fs; 
            if (!feedSources.TryGetValue(selectedFeedSource, out fs)) 
				fs = feedSources.Sources.FirstOrDefault();

            //initialize combo boxes	
            foreach (string category in fs.Source.GetCategories().Keys)
            {               
                    this.comboCategory.Items.Add(category);
            }
			
			this.comboCategory.Items.Add(defaultCategory);
			this.comboCategory.Text = (selectedCategory ?? String.Empty);

			this.comboFeedSource.DataSource = feedSources.GetOrderedFeedSources();
			this.comboFeedSource.SelectedItem = fs;
			
			this.comboFeedSource.SelectedIndexChanged += this.comboFeedSource_SelectedIndexChanged;			
		}
		
		public string FeedsUrlOrFile {get { return textUrlOrFile.Text; } }
		public string FeedCategory { get { return comboCategory.Text; } }
        public string FeedSource { get { return comboFeedSource.Text; } }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportFeedsDialog));
			this.label2 = new System.Windows.Forms.Label();
			this.textUrlOrFile = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSelectFile = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.comboCategory = new System.Windows.Forms.ComboBox();
			this.comboFeedSource = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// textUrlOrFile
			// 
			this.textUrlOrFile.AllowDrop = true;
			resources.ApplyResources(this.textUrlOrFile, "textUrlOrFile");
			this.textUrlOrFile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.textUrlOrFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
			this.textUrlOrFile.Name = "textUrlOrFile";
			this.toolTip1.SetToolTip(this.textUrlOrFile, resources.GetString("textUrlOrFile.ToolTip"));
			this.textUrlOrFile.TextChanged += new System.EventHandler(this.textUri_TextChanged);
			// 
			// btnOk
			// 
			resources.ApplyResources(this.btnOk, "btnOk");
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Name = "btnOk";
			this.toolTip1.SetToolTip(this.btnOk, resources.GetString("btnOk.ToolTip"));
			// 
			// btnCancel
			// 
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Name = "btnCancel";
			// 
			// btnSelectFile
			// 
			resources.ApplyResources(this.btnSelectFile, "btnSelectFile");
			this.btnSelectFile.Name = "btnSelectFile";
			this.toolTip1.SetToolTip(this.btnSelectFile, resources.GetString("btnSelectFile.ToolTip"));
			this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
			// 
			// comboCategory
			// 
			resources.ApplyResources(this.comboCategory, "comboCategory");
			this.comboCategory.Name = "comboCategory";
			this.comboCategory.Sorted = true;
			this.toolTip1.SetToolTip(this.comboCategory, resources.GetString("comboCategory.ToolTip"));
			// 
			// comboFeedSource
			// 
			resources.ApplyResources(this.comboFeedSource, "comboFeedSource");
			this.comboFeedSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboFeedSource.Name = "comboFeedSource";
			this.comboFeedSource.Sorted = true;
			this.toolTip1.SetToolTip(this.comboFeedSource, resources.GetString("comboFeedSource.ToolTip"));
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label4.Name = "label4";
			// 
			// label3
			// 
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// ImportFeedsDialog
			// 
			this.AcceptButton = this.btnOk;
			resources.ApplyResources(this, "$this");
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.comboFeedSource);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboCategory);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textUrlOrFile);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnSelectFile);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.label2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ImportFeedsDialog";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion	

		private void textUri_TextChanged(object sender, EventArgs e)
		{
			btnOk.Enabled = (textUrlOrFile.Text.Length > 0);
		}

		private void btnSelectFile_Click(object sender, EventArgs e) {
			OpenFileDialog ofd = new OpenFileDialog();

			ofd.Filter = "OPML files (*.opml)|*.opml|OCS files (*.ocs)|*.ocs|XML files (*.xml)|*.xml|All files (*.*)|*.*" ;
			ofd.FilterIndex = 1 ;
			ofd.InitialDirectory = Environment.CurrentDirectory;
			ofd.RestoreDirectory = true ;

			if(ofd.ShowDialog() == DialogResult.OK) {
				textUrlOrFile.Text = ofd.FileName;
			}
		}

        private void comboFeedSource_SelectedIndexChanged(object sender, EventArgs e)
        {
			FeedSourceEntry fs = comboFeedSource.SelectedItem as FeedSourceEntry;
			this.comboCategory.Items.Clear();

			//initialize category combo box
			if (fs != null)
				foreach (string category in fs.Source.GetCategories().Keys)
				{
					this.comboCategory.Items.Add(category);
				}

            this.comboCategory.Items.Add(defaultCategory);
            this.comboCategory.Text = defaultCategory; 
        }
	}
}
