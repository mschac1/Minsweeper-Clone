using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsApplication1
{
	/// <summary>
	/// Summary description for frmCustom.
	/// </summary>
	public class frmCustom : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblMines;
		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.TextBox txtHeight;
		private System.Windows.Forms.TextBox txtMines;
		private System.Windows.Forms.TextBox txtWidth;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCustom()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCustom));
			this.lblMines = new System.Windows.Forms.Label();
			this.lblWidth = new System.Windows.Forms.Label();
			this.lblHeight = new System.Windows.Forms.Label();
			this.txtHeight = new System.Windows.Forms.TextBox();
			this.txtMines = new System.Windows.Forms.TextBox();
			this.txtWidth = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblMines
			// 
			this.lblMines.Location = new System.Drawing.Point(24, 88);
			this.lblMines.Name = "lblMines";
			this.lblMines.Size = new System.Drawing.Size(48, 20);
			this.lblMines.TabIndex = 1;
			this.lblMines.Text = "Mines:";
			// 
			// lblWidth
			// 
			this.lblWidth.Location = new System.Drawing.Point(24, 56);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new System.Drawing.Size(48, 20);
			this.lblWidth.TabIndex = 2;
			this.lblWidth.Text = "Width:";
			// 
			// lblHeight
			// 
			this.lblHeight.Location = new System.Drawing.Point(24, 24);
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.Size = new System.Drawing.Size(48, 20);
			this.lblHeight.TabIndex = 3;
			this.lblHeight.Text = "Height:";
			// 
			// txtHeight
			// 
			this.txtHeight.Location = new System.Drawing.Point(80, 24);
			this.txtHeight.Name = "txtHeight";
			this.txtHeight.Size = new System.Drawing.Size(56, 20);
			this.txtHeight.TabIndex = 4;
			this.txtHeight.Text = "";
			// 
			// txtMines
			// 
			this.txtMines.Location = new System.Drawing.Point(80, 88);
			this.txtMines.Name = "txtMines";
			this.txtMines.Size = new System.Drawing.Size(56, 20);
			this.txtMines.TabIndex = 6;
			this.txtMines.Text = "";
			// 
			// txtWidth
			// 
			this.txtWidth.Location = new System.Drawing.Point(80, 56);
			this.txtWidth.Name = "txtWidth";
			this.txtWidth.Size = new System.Drawing.Size(56, 20);
			this.txtWidth.TabIndex = 5;
			this.txtWidth.Text = "";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(152, 24);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(72, 32);
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(152, 72);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 32);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmCustom
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(250, 128);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancel,
																		  this.btnOK,
																		  this.txtWidth,
																		  this.txtMines,
																		  this.txtHeight,
																		  this.lblHeight,
																		  this.lblWidth,
																		  this.lblMines});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCustom";
			this.ShowInTaskbar = false;
			this.Text = "frmCustom";
			this.Load += new System.EventHandler(this.frmCustom_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmCustom_Load(object sender, System.EventArgs e)
		{
		
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	
		public int gridHeight
		{
			get
			{
				return Convert.ToInt32(txtHeight.Text);
			}
			set
			{
				txtHeight.Text = value.ToString();
			}
		}

		public int gridWidtht
		{
			get
			{
				return Convert.ToInt32(txtWidth.Text);
			}
			set
			{
				txtWidth.Text = value.ToString();
			}
		}

		public int Mines
		{
			get
			{
				return Convert.ToInt32(txtMines.Text);
			}
			set
			{
				txtMines.Text = value.ToString();
			}
		}


	}
}
