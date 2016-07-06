using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MineSweeper
{
	/// <summary>
	/// Summary description for HighScores.
	/// </summary>
	public class frmHighScores : System.Windows.Forms.Form
	{
		bool reset = false;
		public bool scoreFlag = false;
		public string newName;

		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.TextBox txt;


		private System.Windows.Forms.Label lblScore1;
		private System.Windows.Forms.Label lblScore2;
		private System.Windows.Forms.Label lblScore3;
		private System.Windows.Forms.Label HighScore1;
		private System.Windows.Forms.Label HighScore2;
		private System.Windows.Forms.Label HighScore3;
		private System.Windows.Forms.Label HighName1;
		private System.Windows.Forms.Label HighName2;
		private System.Windows.Forms.Label HighName3;
		private System.Windows.Forms.Button btnOK;
		internal System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.TextBox txtName1;
		private System.Windows.Forms.TextBox txtName3;
		private System.Windows.Forms.TextBox txtName2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHighScores()
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
			this.lblScore1 = new System.Windows.Forms.Label();
			this.lblScore2 = new System.Windows.Forms.Label();
			this.lblScore3 = new System.Windows.Forms.Label();
			this.HighScore1 = new System.Windows.Forms.Label();
			this.HighScore2 = new System.Windows.Forms.Label();
			this.HighScore3 = new System.Windows.Forms.Label();
			this.HighName1 = new System.Windows.Forms.Label();
			this.HighName2 = new System.Windows.Forms.Label();
			this.HighName3 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.txtName1 = new System.Windows.Forms.TextBox();
			this.txtName2 = new System.Windows.Forms.TextBox();
			this.txtName3 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblScore1
			// 
			this.lblScore1.Location = new System.Drawing.Point(16, 16);
			this.lblScore1.Name = "lblScore1";
			this.lblScore1.Size = new System.Drawing.Size(56, 20);
			this.lblScore1.TabIndex = 6;
			this.lblScore1.Text = "Beginner:";
			// 
			// lblScore2
			// 
			this.lblScore2.Location = new System.Drawing.Point(16, 48);
			this.lblScore2.Name = "lblScore2";
			this.lblScore2.Size = new System.Drawing.Size(72, 20);
			this.lblScore2.TabIndex = 5;
			this.lblScore2.Text = "Intermediate:";
			// 
			// lblScore3
			// 
			this.lblScore3.Location = new System.Drawing.Point(16, 80);
			this.lblScore3.Name = "lblScore3";
			this.lblScore3.Size = new System.Drawing.Size(56, 20);
			this.lblScore3.TabIndex = 4;
			this.lblScore3.Text = "Expert:";
			// 
			// HighScore1
			// 
			this.HighScore1.Location = new System.Drawing.Point(96, 16);
			this.HighScore1.Name = "HighScore1";
			this.HighScore1.Size = new System.Drawing.Size(64, 20);
			this.HighScore1.TabIndex = 9;
			this.HighScore1.Click += new System.EventHandler(this.HighScore1_Click);
			// 
			// HighScore2
			// 
			this.HighScore2.Location = new System.Drawing.Point(96, 48);
			this.HighScore2.Name = "HighScore2";
			this.HighScore2.Size = new System.Drawing.Size(64, 20);
			this.HighScore2.TabIndex = 8;
			// 
			// HighScore3
			// 
			this.HighScore3.Location = new System.Drawing.Point(96, 80);
			this.HighScore3.Name = "HighScore3";
			this.HighScore3.Size = new System.Drawing.Size(64, 20);
			this.HighScore3.TabIndex = 7;
			// 
			// HighName1
			// 
			this.HighName1.Location = new System.Drawing.Point(176, 16);
			this.HighName1.Name = "HighName1";
			this.HighName1.Size = new System.Drawing.Size(104, 20);
			this.HighName1.TabIndex = 12;
			// 
			// HighName2
			// 
			this.HighName2.Location = new System.Drawing.Point(176, 48);
			this.HighName2.Name = "HighName2";
			this.HighName2.Size = new System.Drawing.Size(104, 20);
			this.HighName2.TabIndex = 11;
			// 
			// HighName3
			// 
			this.HighName3.Location = new System.Drawing.Point(176, 80);
			this.HighName3.Name = "HighName3";
			this.HighName3.Size = new System.Drawing.Size(104, 20);
			this.HighName3.TabIndex = 10;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(176, 104);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(72, 32);
			this.btnOK.TabIndex = 13;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(48, 104);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(72, 32);
			this.btnReset.TabIndex = 14;
			this.btnReset.Text = "Reset Scores";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// txtName1
			// 
			this.txtName1.Location = new System.Drawing.Point(176, 16);
			this.txtName1.Name = "txtName1";
			this.txtName1.Size = new System.Drawing.Size(104, 20);
			this.txtName1.TabIndex = 15;
			this.txtName1.Text = "";
			this.txtName1.Visible = false;
			// 
			// txtName2
			// 
			this.txtName2.Location = new System.Drawing.Point(176, 48);
			this.txtName2.Name = "txtName2";
			this.txtName2.Size = new System.Drawing.Size(104, 20);
			this.txtName2.TabIndex = 16;
			this.txtName2.Text = "";
			this.txtName2.Visible = false;
			// 
			// txtName3
			// 
			this.txtName3.Location = new System.Drawing.Point(176, 80);
			this.txtName3.Name = "txtName3";
			this.txtName3.Size = new System.Drawing.Size(104, 20);
			this.txtName3.TabIndex = 17;
			this.txtName3.Text = "";
			this.txtName3.Visible = false;
			// 
			// frmHighScores
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(306, 144);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnReset,
																		  this.btnOK,
																		  this.HighName1,
																		  this.HighName2,
																		  this.HighName3,
																		  this.HighScore1,
																		  this.HighScore2,
																		  this.HighScore3,
																		  this.lblScore1,
																		  this.lblScore2,
																		  this.lblScore3,
																		  this.txtName1,
																		  this.txtName2,
																		  this.txtName3});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmHighScores";
			this.Text = "HighScores";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.HighScores_Load);
			this.Activated += new System.EventHandler(this.frmHighScores_Activated);
			this.ResumeLayout(false);

		}
		#endregion

		private void HighScores_Load(object sender, System.EventArgs e)
		{
		}

		public void HighScores(string [] scores, string [] names)
		{
			HighScore1.Text = scores[0];
			HighScore2.Text = scores[1];
			HighScore3.Text = scores[2];

			HighName1.Text = names[0];
			HighName2.Text = names[1];
			HighName3.Text = names[2];
		}

		public bool IsReset()
		{
			return reset;
		}

		public void SetScore(int diff)
		{
			if (diff == 0)
			{
				lbl = HighName1;
				txt = txtName1;
			}
			else if (diff == 1)
			{
				lbl = HighName2;
				txt = txtName2;
			}
			else
			{
				lbl = HighName3;
				txt = txtName3;
			}

			txt.Visible = true;
			lbl.Visible = false;

			scoreFlag = true;
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			reset = true;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (scoreFlag == true)
			{
				newName = txt.Text;
				txt.Visible = false;
				lbl.Text = newName;
				lbl.Visible = true;
				scoreFlag = false;
			}
			
			DialogResult = DialogResult.OK;
		}

		private void HighScore1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void frmHighScores_Activated(object sender, System.EventArgs e)
		{
			if (scoreFlag)
				txt.Focus();
		
		}

	}
}
