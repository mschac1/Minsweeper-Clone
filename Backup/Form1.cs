using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;


namespace WindowsApplication1
{
	[Serializable]
	public class frmMinesweeper : System.Windows.Forms.Form, ISerializable
	{
		#region variables

		// The two dimensional arrays of form buttons and the labels behind them
		private System.Windows.Forms.Button [ , ] btnGrid;
		private System.Windows.Forms.Label [ , ] lblGrid;

		// An array of menu items, one for each difficulty level and one for Custom
		private System.Windows.Forms.MenuItem [] menuDiff;


		// Constants
		const int minHeight = 9;
		const int minWidth = 9;
		const int minMines = 10;

		const int maxHeight = 24;
		const int maxWidth = 30;

		// By Difficulty
		int [] diffHeight = {9, 16, 16};
		int [] diffWidth = {9, 16, 30};
		int [] diffMines = {10, 40, 99};

		// Defaults
		int currHeight = 9;
		int currWidth =  9;
		int currMines =  10;

		int diff = 0;

		string [] highScore = {"999", "999", "999"};
		string [] highName = {"Anonymous", "Anonymous", "Anonymous"};

		// The number of non-bomb buttons remaining
		int squaresLeft;

		// Whether a button has been clicked
		bool firstClick = true;

		bool gameOver = false;

		// Whether question marks are used when flagging
		bool Qmarks = true;

		// Describes whether the from has been registrered as minimized
		bool minimized = false;

		// Flags used for the right/left click
		bool rClickFlg = false;
		bool lClickFlg = false;

		// TODO: Remove Hovering
		int colHover;
		int rowHover;

		int time = 0;

		// Because making ttons takes to long, move them off to the right DIST pixels
		// when they're clicked
		const int DIST = 1000;

        // List of colors for the label numbers
		System.Drawing.Color [] numColor;

		// The random number generator
		System.Random rnd = new System.Random();

		//VS variables 

		private System.Windows.Forms.Button btnTemplate;
		private System.Windows.Forms.Label lblTemplate;
		private System.Windows.Forms.Button flag;
		private System.Windows.Forms.Label noBomb;
		private System.Windows.Forms.Label activeBomb;
		private System.Windows.Forms.Label bomb;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuNew;
		private System.Windows.Forms.MenuItem menuBeginner;
		private System.Windows.Forms.MenuItem menuIntermediate;
		private System.Windows.Forms.MenuItem menuExpert;
		private System.Windows.Forms.MenuItem menuCustom;
		private System.Windows.Forms.MenuItem menuMarks;
		private System.Windows.Forms.MenuItem menuBestTimes;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.Timer tmrScore;
		private System.Windows.Forms.PictureBox toolBar;
		private System.Windows.Forms.Label lblFlags;
		private System.Windows.Forms.Label lblTime;
		private System.Windows.Forms.Button btnNewGame;
		private System.Windows.Forms.Timer tmrMin;
		private System.ComponentModel.IContainer components;


		#endregion
		 
		public frmMinesweeper(SerializationInfo info, StreamingContext context)
		{
			// Deserializes the game (load the saved information)
			diff = info.GetInt32("diff");
			
			currMines = info.GetInt32("currMines");
			currWidth = info.GetInt32("currWidth");
			currHeight = info.GetInt32("currHeight");
			Qmarks = info.GetBoolean("Qmarks");

			highScore = (string []) info.GetValue("HighScores", highScore.GetType());
			highName = (string []) info.GetValue("HighNames", highName.GetType());
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			// Serialize the game (save it).
			info.AddValue("diff", diff);
			info.AddValue("currMines", currMines);
			info.AddValue("currWidth", currWidth);
			info.AddValue("currHeight", currHeight);
			info.AddValue("Qmarks", Qmarks);
			info.AddValue("HighScores", highScore);
			info.AddValue("HighNames", highName);
		}

		public frmMinesweeper()
		{
			// Designer Form Components
			InitializeComponent();

			// My Manually added components
			InitializeMyComponents();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMinesweeper));
			this.btnTemplate = new System.Windows.Forms.Button();
			this.lblTemplate = new System.Windows.Forms.Label();
			this.flag = new System.Windows.Forms.Button();
			this.bomb = new System.Windows.Forms.Label();
			this.noBomb = new System.Windows.Forms.Label();
			this.activeBomb = new System.Windows.Forms.Label();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuNew = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuBeginner = new System.Windows.Forms.MenuItem();
			this.menuIntermediate = new System.Windows.Forms.MenuItem();
			this.menuExpert = new System.Windows.Forms.MenuItem();
			this.menuCustom = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuMarks = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuBestTimes = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuExit = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.tmrScore = new System.Windows.Forms.Timer(this.components);
			this.toolBar = new System.Windows.Forms.PictureBox();
			this.lblFlags = new System.Windows.Forms.Label();
			this.lblTime = new System.Windows.Forms.Label();
			this.btnNewGame = new System.Windows.Forms.Button();
			this.tmrMin = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// btnTemplate
			// 
			this.btnTemplate.BackColor = System.Drawing.Color.LightGray;
			this.btnTemplate.Font = new System.Drawing.Font("Courier New", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnTemplate.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnTemplate.Location = new System.Drawing.Point(24, 56);
			this.btnTemplate.Name = "btnTemplate";
			this.btnTemplate.Size = new System.Drawing.Size(16, 16);
			this.btnTemplate.TabIndex = 0;
			this.btnTemplate.Text = "?";
			this.btnTemplate.Visible = false;
			this.btnTemplate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnTemplate_MouseUp);
			this.btnTemplate.MouseEnter += new System.EventHandler(this.btnTemplate_MouseEnter);
			this.btnTemplate.MouseLeave += new System.EventHandler(this.btnTemplate_MouseLeave);
			this.btnTemplate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTemplate_MouseDown);
			// 
			// lblTemplate
			// 
			this.lblTemplate.BackColor = System.Drawing.Color.Silver;
			this.lblTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTemplate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTemplate.ForeColor = System.Drawing.Color.Blue;
			this.lblTemplate.Location = new System.Drawing.Point(0, 56);
			this.lblTemplate.Name = "lblTemplate";
			this.lblTemplate.Size = new System.Drawing.Size(16, 16);
			this.lblTemplate.TabIndex = 1;
			this.lblTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblTemplate.Visible = false;
			// 
			// flag
			// 
			this.flag.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.flag.ForeColor = System.Drawing.SystemColors.ControlText;
			this.flag.Image = ((System.Drawing.Bitmap)(resources.GetObject("flag.Image")));
			this.flag.Location = new System.Drawing.Point(24, 80);
			this.flag.Name = "flag";
			this.flag.Size = new System.Drawing.Size(16, 16);
			this.flag.TabIndex = 2;
			this.flag.Visible = false;
			// 
			// bomb
			// 
			this.bomb.BackColor = System.Drawing.Color.Silver;
			this.bomb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.bomb.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bomb.ForeColor = System.Drawing.Color.Blue;
			this.bomb.Image = ((System.Drawing.Bitmap)(resources.GetObject("bomb.Image")));
			this.bomb.Location = new System.Drawing.Point(0, 80);
			this.bomb.Name = "bomb";
			this.bomb.Size = new System.Drawing.Size(16, 16);
			this.bomb.TabIndex = 3;
			this.bomb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.bomb.Visible = false;
			// 
			// noBomb
			// 
			this.noBomb.BackColor = System.Drawing.Color.Silver;
			this.noBomb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.noBomb.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.noBomb.ForeColor = System.Drawing.Color.Blue;
			this.noBomb.Image = ((System.Drawing.Bitmap)(resources.GetObject("noBomb.Image")));
			this.noBomb.Location = new System.Drawing.Point(48, 80);
			this.noBomb.Name = "noBomb";
			this.noBomb.Size = new System.Drawing.Size(16, 16);
			this.noBomb.TabIndex = 4;
			this.noBomb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.noBomb.Visible = false;
			// 
			// activeBomb
			// 
			this.activeBomb.BackColor = System.Drawing.Color.Silver;
			this.activeBomb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.activeBomb.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.activeBomb.ForeColor = System.Drawing.Color.Blue;
			this.activeBomb.Image = ((System.Drawing.Bitmap)(resources.GetObject("activeBomb.Image")));
			this.activeBomb.Location = new System.Drawing.Point(48, 56);
			this.activeBomb.Name = "activeBomb";
			this.activeBomb.Size = new System.Drawing.Size(16, 16);
			this.activeBomb.TabIndex = 5;
			this.activeBomb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.activeBomb.Visible = false;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuNew,
																					  this.menuItem13,
																					  this.menuBeginner,
																					  this.menuIntermediate,
																					  this.menuExpert,
																					  this.menuCustom,
																					  this.menuItem14,
																					  this.menuMarks,
																					  this.menuItem10,
																					  this.menuItem15,
																					  this.menuBestTimes,
																					  this.menuItem16,
																					  this.menuExit});
			this.menuItem1.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
			this.menuItem1.Text = "&Game";
			// 
			// menuNew
			// 
			this.menuNew.Index = 0;
			this.menuNew.Shortcut = System.Windows.Forms.Shortcut.F2;
			this.menuNew.Text = "&New";
			this.menuNew.Click += new System.EventHandler(this.menuNew_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 1;
			this.menuItem13.Text = "-";
			// 
			// menuBeginner
			// 
			this.menuBeginner.Checked = true;
			this.menuBeginner.Index = 2;
			this.menuBeginner.Text = "&Beginner";
			this.menuBeginner.Click += new System.EventHandler(this.menuBeginner_Click);
			// 
			// menuIntermediate
			// 
			this.menuIntermediate.Index = 3;
			this.menuIntermediate.Text = "&Intermediate";
			this.menuIntermediate.Click += new System.EventHandler(this.menuIntermediate_Click);
			// 
			// menuExpert
			// 
			this.menuExpert.Index = 4;
			this.menuExpert.Text = "&Expert";
			this.menuExpert.Click += new System.EventHandler(this.menuExpert_Click);
			// 
			// menuCustom
			// 
			this.menuCustom.Index = 5;
			this.menuCustom.Text = "&Custom...";
			this.menuCustom.Click += new System.EventHandler(this.menuCustom_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 6;
			this.menuItem14.Text = "-";
			// 
			// menuMarks
			// 
			this.menuMarks.Checked = true;
			this.menuMarks.Index = 7;
			this.menuMarks.Text = "&Marks (?)";
			this.menuMarks.Click += new System.EventHandler(this.menuMarks_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 8;
			this.menuItem10.Text = "Sound";
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 9;
			this.menuItem15.Text = "-";
			// 
			// menuBestTimes
			// 
			this.menuBestTimes.Index = 10;
			this.menuBestTimes.Text = "&Best Times";
			this.menuBestTimes.Click += new System.EventHandler(this.menuBestTimes_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 11;
			this.menuItem16.Text = "-";
			// 
			// menuExit
			// 
			this.menuExit.Index = 12;
			this.menuExit.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.menuExit.Text = "E&xit";
			this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "&Help";
			// 
			// tmrScore
			// 
			this.tmrScore.Interval = 1000;
			this.tmrScore.Tick += new System.EventHandler(this.tmrScore_Tick);
			// 
			// toolBar
			// 
			this.toolBar.BackColor = System.Drawing.Color.LightGray;
			this.toolBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.toolBar.Name = "toolBar";
			this.toolBar.Size = new System.Drawing.Size(208, 40);
			this.toolBar.TabIndex = 7;
			this.toolBar.TabStop = false;
			// 
			// lblFlags
			// 
			this.lblFlags.BackColor = System.Drawing.SystemColors.ControlText;
			this.lblFlags.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFlags.ForeColor = System.Drawing.Color.Red;
			this.lblFlags.Location = new System.Drawing.Point(8, 8);
			this.lblFlags.Name = "lblFlags";
			this.lblFlags.Size = new System.Drawing.Size(40, 24);
			this.lblFlags.TabIndex = 8;
			this.lblFlags.Text = "0";
			this.lblFlags.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTime
			// 
			this.lblTime.BackColor = System.Drawing.SystemColors.ControlText;
			this.lblTime.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTime.ForeColor = System.Drawing.Color.Red;
			this.lblTime.Location = new System.Drawing.Point(160, 8);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(40, 24);
			this.lblTime.TabIndex = 9;
			this.lblTime.Text = "0";
			this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnNewGame
			// 
			this.btnNewGame.BackColor = System.Drawing.Color.Silver;
			this.btnNewGame.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnNewGame.Image")));
			this.btnNewGame.Location = new System.Drawing.Point(96, 8);
			this.btnNewGame.Name = "btnNewGame";
			this.btnNewGame.Size = new System.Drawing.Size(24, 24);
			this.btnNewGame.TabIndex = 10;
			this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
			// 
			// tmrMin
			// 
			this.tmrMin.Enabled = true;
			this.tmrMin.Interval = 1;
			this.tmrMin.Tick += new System.EventHandler(this.tmrMin_Tick);
			// 
			// frmMinesweeper
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(210, 195);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnNewGame,
																		  this.lblTime,
																		  this.lblFlags,
																		  this.toolBar,
																		  this.activeBomb,
																		  this.noBomb,
																		  this.flag,
																		  this.bomb,
																		  this.btnTemplate,
																		  this.lblTemplate});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "frmMinesweeper";
			this.Text = "Minesweeper";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMinesweeper_KeyDown);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMinesweeper_Closing);
			this.Load += new System.EventHandler(this.frmMinesweeper_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void InitializeMyComponents()
		{
			btnGrid = new System.Windows.Forms.Button [maxWidth, maxHeight];
			lblGrid = new System.Windows.Forms.Label [maxWidth, maxHeight];

			for (int i = 0; i < maxWidth; i++)
			{
				for (int j = 0; j < maxHeight;j++)
				{
					btnGrid[i, j] = new System.Windows.Forms.Button();
					lblGrid[i, j] = new System.Windows.Forms.Label();

					btnGrid[i, j].BackColor = btnTemplate.BackColor;
					btnGrid[i, j].Font = btnTemplate.Font;
					btnGrid[i, j].Location = new System.Drawing.Point(i * btnTemplate.Width, j * btnTemplate.Height + toolBar.Height);
					btnGrid[i, j].Name = i.ToString() + "_" + j.ToString();
					btnGrid[i, j].Size = new System.Drawing.Size(btnTemplate.Width, btnTemplate.Height);
					btnGrid[i, j].TabStop = false;
					btnGrid[i, j].Visible = true;
					btnGrid[i, j].MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTemplate_MouseDown);
					btnGrid[i, j].MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnTemplate_MouseUp);
					btnGrid[i, j].MouseEnter += new System.EventHandler(this.btnTemplate_MouseEnter);
					btnGrid[i, j].MouseLeave += new System.EventHandler(this.btnTemplate_MouseLeave);
					// TODO:Remove Hovers
					Controls.AddRange(new System.Windows.Forms.Control[] {btnGrid[i, j]});

					lblGrid[i, j].BackColor = lblTemplate.BackColor;
					lblGrid[i, j].BorderStyle = lblTemplate.BorderStyle;
					lblGrid[i, j].Font = lblTemplate.Font;
					lblGrid[i, j].ForeColor = lblTemplate.BackColor;
					lblGrid[i, j].Location = new System.Drawing.Point(i * btnTemplate.Width, j * btnTemplate.Height + toolBar.Height);
					lblGrid[i, j].Name = i.ToString() + "_" + j.ToString();
					lblGrid[i, j].Size = new System.Drawing.Size(btnTemplate.Width, btnTemplate.Height);
					lblGrid[i, j].TabStop = false;
					lblGrid[i, j].Tag = "";
					lblGrid[i, j].Text = "0";
					lblGrid[i, j].Visible = true;
					lblGrid[i, j].MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTemplate_MouseDown);
					lblGrid[i, j].MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTemplate_MouseUp);
					lblGrid[i, j].MouseEnter += new System.EventHandler(this.lblTemplate_MouseEnter);
					lblGrid[i, j].MouseLeave += new System.EventHandler(this.btnTemplate_MouseLeave);
					Controls.AddRange(new System.Windows.Forms.Control[] {lblGrid[i, j]});

				}
			}

			// Alias the menu array to the actual level menus
			menuDiff = new System.Windows.Forms.MenuItem[4];
			menuDiff[0] = menuBeginner;
			menuDiff[1] = menuIntermediate;
			menuDiff[2] = menuExpert;
			menuDiff[3] = menuCustom;

			// The colors for the label numbers
			numColor = new System.Drawing.Color[9];
			numColor[0] = lblTemplate.BackColor;
			numColor[1] = System.Drawing.Color.Blue;
			numColor[2] = System.Drawing.Color.Green;
			numColor[3] = System.Drawing.Color.Red;
			numColor[4] = System.Drawing.Color.DarkBlue;
			numColor[5] = System.Drawing.Color.Brown;
			numColor[6] = System.Drawing.Color.Cyan;
			numColor[7] = System.Drawing.Color.Black;
			numColor[8] = System.Drawing.Color.Gray;
		}

		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMinesweeper());
		}
		private void newGame()
		{
			// reset flags
			firstClick = true;
			gameOver = false;

			// restart time
			time = 0;
			tmrScore.Enabled = false;

			// Reset the number of remaining squares
			squaresLeft = currWidth * currHeight - currMines;

			lblFlags.Text = currMines.ToString();
			lblTime.Text = "0";

			// Check correct menu
			for (int i = 0; i < 4; i++)
				menuDiff[i].Checked = false;
			menuDiff[diff].Checked = true;

			menuMarks.Checked = Qmarks;

			// Reset buttons and labels
			for (int i = 0; i < currWidth; i++)
			{
				for (int j = 0; j < currHeight; j++)
				{

					btnGrid[i, j].Image = null;
					btnGrid[i, j].Text = "";
					if (btnGrid[i, j].Left >= DIST)
						btnGrid[i, j].Left -= DIST;

					lblGrid[i, j].ForeColor = lblTemplate.BackColor;
					lblGrid[i, j].Image = null;
					lblGrid[i, j].Tag = "";
					lblGrid[i, j].Text = "0";
				}
			}

			// Setup the form and the toolbar		
			// Include the width and length of the form borders in it's height and width
			Height = btnGrid[0, currHeight - 1].Top + btnTemplate.Height + 52;
			Width = btnGrid[currWidth - 1, 0].Left + btnTemplate.Width + 6;
			toolBar.Width = Width - 6;
			lblTime.Left = Width - 54;
			btnNewGame.Left = toolBar.Left + (toolBar.Width - btnNewGame.Width) / 2;

		}

		private void frmMinesweeper_Load(object sender, System.EventArgs e)
		{
			if (File.Exists("minedat"))
			{

		        BinaryFormatter bformatter = new BinaryFormatter();
				Stream stream = File.Open("minedat", FileMode.Open);
				frmMinesweeper frmTemp = (frmMinesweeper) bformatter.Deserialize(stream);
				stream.Close();
				this.currHeight = frmTemp.currHeight;
				this.currWidth = frmTemp.currWidth;
				this.currMines = frmTemp.currMines;
				this.Qmarks = frmTemp.Qmarks;
				this.diff = frmTemp.diff;
				this.highScore = frmTemp.highScore;
				this.highName = frmTemp.highName;
			}

			newGame();
		}


		private void btnTemplate_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (gameOver == true)
				return;

			// The button and it's co-ordinates
			System.Windows.Forms.Button btn = ((System.Windows.Forms.Button) sender); 
			int uScore = btn.Name.IndexOf("_");
			int col = System.Int32.Parse(btn.Name.Substring(0, uScore));
			int row = System.Int32.Parse(btn.Name.Substring(uScore + 1));

			// Allow MouseEnter to be reset before the click is releases
			btn.Capture = false;

			if (e.Button == MouseButtons.Left)
			{
				lClickFlg = true;
			}

			#region MouseRight
			if (e.Button == MouseButtons.Right)
			{
				// This should not happen
				if (btnGrid[col, row].Left >= DIST)
					return;

				rClickFlg = true;

				// If both mouse buttons are clicked...
				if (lClickFlg == rClickFlg == true)
				{
					LR_Click(sender);
					return;
				}

				// Otherwise... place/clear a flag/'?'
				if (btn.Text.Equals("?"))
					btn.Text = "";
				else if(btn.Image == null)
				{
					btn.Image = flag.Image;
					lblFlags.Text = (System.Int32.Parse(lblFlags.Text) - 1).ToString();
				}
				else
				{
					btn.Image = null;
					lblFlags.Text = (System.Int32.Parse(lblFlags.Text) + 1).ToString();

					if (Qmarks)
						btn.Text = "?";
				}

			}
			#endregion

		
		}

		
		private void menuExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void menuMarks_Click(object sender, System.EventArgs e)
		{
			menuMarks.Checked = !menuMarks.Checked;
			Qmarks = !Qmarks;
		}

		private void menuNew_Click(object sender, System.EventArgs e)
		{
			newGame();
		}

		private void menuBeginner_Click(object sender, System.EventArgs e)
		{
			diff = 0;
			menuClick();
		}

		private void menuIntermediate_Click(object sender, System.EventArgs e)
		{
			diff = 1;
			menuClick();
		}

		private void menuExpert_Click(object sender, System.EventArgs e)
		{
			diff = 2;
			menuClick();
		}

		private void btnTemplate_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (gameOver == true)
				return;

			if (lClickFlg == rClickFlg == true)
			{
				LR_Click(sender);
			}

			else if (e.Button == MouseButtons.Left)
			{
				if (colHover == -1)
				{
//					MessageBox.Show("Error");

					System.Windows.Forms.Button btn = ((System.Windows.Forms.Button) sender); 

					int uScore = btn.Name.IndexOf("_");
					int col = System.Int32.Parse(btn.Name.Substring(0, uScore));
					int row = System.Int32.Parse(btn.Name.Substring(uScore + 1));
					LeftClick(col, row);
				}
				else
					LeftClick(colHover, rowHover);
			}

			lClickFlg = false;
			rClickFlg = false;

		}
		private void LeftClick(int col, int row)
		{

			if (btnGrid[col, row].Image == flag.Image || btnGrid[col, row].Text == "?" || btnGrid[col, row].Left >= DIST)
				return;

			if (btnGrid[col, row].Left >= DIST)
				Text = btnGrid[col, row].Left.ToString();

			btnGrid[col, row].Left += DIST;

			#region First Click

			if (firstClick == true)
			{
				// Protect Surrounding squares from bombs
				for (int i = -1; i <= 1; i++)
					for (int j = -1; j <= 1; j++)
						if (col + i >= 0 && col + i < currWidth && row + j >= 0 && row + j < currHeight)
							lblGrid[col + i, row + j].Tag = "0";
 
				// Place bombs
				int rWidth, rHeight;
				for (int m = 0; m < currMines; m++)
				{
					/*EDIT*/
					rWidth = rnd.Next(0, currWidth);
					rHeight = rnd.Next(0, currHeight);
					if (!lblGrid[rWidth, rHeight].Tag.Equals("0") && !lblGrid[rWidth, rHeight].Tag.Equals("B") )
					{
						lblGrid[rWidth, rHeight].Image = bomb.Image;
						lblGrid[rWidth, rHeight].Tag = "B";
						lblGrid[rWidth, rHeight].ForeColor = numColor[0];
						for (int i = -1; i <= 1; i++)
							for (int j = -1; j <= 1; j++)
								if (rWidth + i >= 0 && rWidth + i < currWidth && rHeight + j >= 0 && rHeight + j < currHeight)
									lblGrid[rWidth + i, rHeight + j].Text = (System.Int32.Parse(lblGrid[rWidth + i, rHeight + j].Text) + 1).ToString();
					}
					else
						m--;

					tmrScore.Enabled = true;

				}

				// Show numbers in color
				for (int i = 0; i < currWidth; i++)
					for (int j = 0; j < currHeight; j++)
					{
						//						if (!lblGrid[i, j].Text.Equals("0"))
						//							lblGrid[i, j].BorderStyle = bomb.BorderStyle;

						if (lblGrid[i, j].Tag.Equals("B"))
							lblGrid[i, j].Text = "";
						else
							lblGrid[i, j].ForeColor = numColor[System.Int32.Parse(lblGrid[i,j].Text)];

					}

				firstClick = false;
			}
			#endregion

			if (lblGrid[col, row].Image == bomb.Image)
			{
				lblGrid[col, row].Image = activeBomb.Image;
				GameLost();
			}

			else
			{
				squaresLeft--;
				if (squaresLeft == 0)
					GameWon();
			}


			if (lblGrid[col, row].Text.Equals("0"))
				for (int i = col - 1; i <= col + 1; i++)
					for (int j = row - 1; j <= row + 1; j++)
						if (i >= 0 && i < currWidth && j >= 0 &&j < currHeight)
							/**/							if (btnGrid[i, j].Left <= DIST)
																LeftClick(i, j);


		}

		private void menuCustom_Click(object sender, System.EventArgs e)
		{
			frmCustom customDialog = new frmCustom();

			customDialog.gridHeight = currHeight;
			customDialog.gridWidtht = currWidth;
			customDialog.Mines = currMines;

			DialogResult status = customDialog.ShowDialog();

			if (status == DialogResult.OK)
			{
				diff = 3;

				currHeight = customDialog.gridHeight;
				if (currHeight < minHeight)
					currHeight = minHeight;
				if (currHeight > maxHeight)
					currHeight = maxHeight;

				currWidth = customDialog.gridWidtht;
				if (currWidth < minWidth)
					currWidth = minWidth;
				if (currWidth > maxWidth)
					currWidth = maxWidth;

				currMines = customDialog.Mines;
				if (currMines < minMines)
					currMines = minMines;
				if (currMines > (currHeight - 1) * (currWidth - 1))
					currMines = (currHeight - 1) * (currWidth - 1);

				newGame();
			}
		}

		private void GameLost()
		{
			tmrScore.Enabled = false;
			gameOver = true;

			for (int i = 0; i < currWidth; i++)
			{
				for (int j = 0; j < currHeight; j++)
				{
					if (lblGrid[i, j].Image == bomb.Image && btnGrid[i, j].Image == null)
						btnGrid[i, j].Left += DIST;
					else if (lblGrid[i, j].Image == null && btnGrid[i, j].Image == flag.Image)
					{
						lblGrid[i, j].Image = noBomb.Image;
						lblGrid[i, j].Text = "";
						 btnGrid[i, j].Left += DIST;
					}
				}
			}
		}
		private void GameWon()
		{
			tmrScore.Enabled = false;
			gameOver = true;

			if (diff == 3)
				return;

			if (time < Int32.Parse(highScore[diff]))
			{
				frmHighScores scoresDialog = new frmHighScores();
				scoresDialog.btnReset.Enabled = false;

				highScore[diff] = time.ToString();
				scoresDialog.HighScores(highScore, highName);
				scoresDialog.SetScore(diff);
				scoresDialog.ShowDialog();
				highName[diff] = scoresDialog.newName;
				scoresDialog.btnReset.Enabled = true;

				// Save Game
				Stream stream = File.Open("minedat", FileMode.Create);
				BinaryFormatter bformatter = new BinaryFormatter();
				bformatter.Serialize(stream, this);
				stream.Close();

			}

		}

		private void frmMinesweeper_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		}

		private void tmrScore_Tick(object sender, System.EventArgs e)
		{
			time++;
			lblTime.Text = time.ToString();
		}

		private void menuBestTimes_Click(object sender, System.EventArgs e)
		{
			frmHighScores scoresDialog = new frmHighScores();
			scoresDialog.HighScores(highScore, highName);
			scoresDialog.ShowDialog();
			if (scoresDialog.IsReset())
			{
				highScore = new string[] {"999", "999", "999"};
				highName = new string [] {"Anonymous", "Anonymous", "Anonymous"};

			}

		}

		private void btnNewGame_Click(object sender, System.EventArgs e)
		{
			newGame();
		}

		private void frmMinesweeper_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{

			Stream stream = File.Open("minedat", FileMode.Create);
			BinaryFormatter bformatter = new BinaryFormatter();
			bformatter.Serialize(stream, this);
			stream.Close();
		}

		private void menuClick()
		{
			currHeight = diffHeight[diff];
			currWidth = diffWidth[diff];
			currMines = diffMines[diff];

			newGame();

		}

		private void tmrMin_Tick(object sender, System.EventArgs e)
		{
			if (this.WindowState == System.Windows.Forms.FormWindowState.Minimized && minimized == false && tmrScore.Enabled == true)
			{
				tmrScore.Enabled = false;
				minimized = true;
			}
			else if(this.WindowState != System.Windows.Forms.FormWindowState.Minimized && minimized == true)
			{
				tmrScore.Enabled = true;
				minimized = false;
			}
		}

		private void btnTemplate_MouseEnter(object sender, System.EventArgs e)
		{
			System.Windows.Forms.Button btn = ((System.Windows.Forms.Button) sender); 

			int uScore = btn.Name.IndexOf("_");
			colHover = System.Int32.Parse(btn.Name.Substring(0, uScore));
			rowHover = System.Int32.Parse(btn.Name.Substring(uScore + 1));
			// Text = colHover.ToString() + " " + rowHover.ToString();
		}

		private void btnTemplate_MouseLeave(object sender, System.EventArgs e)
		{
			colHover = rowHover = -1;
			// Text = colHover.ToString() + " " + rowHover.ToString();

		
		}
		public void LR_Click(object sender)
		{
			if (sender.GetType() == btnTemplate.GetType())
				return;

			System.Windows.Forms.Label lbl = ((System.Windows.Forms.Label) sender); 

			int uScore = lbl.Name.IndexOf("_");
			int col = System.Int32.Parse(lbl.Name.Substring(0, uScore));
			int row = System.Int32.Parse(lbl.Name.Substring(uScore + 1));

			int rank = System.Int32.Parse(lbl.Text);

			for (int i = col - 1; i <= col + 1; i++)
				for (int j = row - 1; j <= row + 1; j++)
					if (i >= 0 && i < currWidth && j >= 0 &&j < currHeight)
						if (btnGrid[i, j].Image == flag.Image)
							rank--;
			if (rank == 0)
			{
				for (int i = col - 1; i <= col + 1; i++)
					for (int j = row - 1; j <= row + 1; j++)
						if (i >= 0 && i < currWidth && j >= 0 &&j < currHeight)
							LeftClick(i, j);
			}

		}

		private void lblTemplate_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (gameOver == true)
				return;

			System.Windows.Forms.Label lbl = ((System.Windows.Forms.Label) sender); 

			lbl.Capture = false;

			if (e.Button == MouseButtons.Left)
				lClickFlg = true;

			else if (e.Button == MouseButtons.Right)
				rClickFlg = true;
		}
		private void lblTemplate_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (gameOver == true)
				return;

			if (lClickFlg == rClickFlg == true)
				LR_Click(sender);

			lClickFlg = false;
			rClickFlg = false;

		}

		private void lblTemplate_MouseEnter(object sender, System.EventArgs e)
		{
			System.Windows.Forms.Label lbl = ((System.Windows.Forms.Label) sender); 

			int uScore = lbl.Name.IndexOf("_");
			colHover = System.Int32.Parse(lbl.Name.Substring(0, uScore));
			rowHover = System.Int32.Parse(lbl.Name.Substring(uScore + 1));
			// Text = colHover.ToString() + " " + rowHover.ToString();
		}


	}
}
