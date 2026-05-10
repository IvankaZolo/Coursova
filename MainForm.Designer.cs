namespace Coursova
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mazePictureBox = new PictureBox();
            btnCreate = new Button();
            btnGenerate = new Button();
            btnClear = new Button();
            btnAStarManhattan = new Button();
            btnDijkstra = new Button();
            btnAStarEuclid = new Button();
            btnPause = new Button();
            textBox1 = new TextBox();
            txtRows = new TextBox();
            txtCols = new TextBox();
            txtDensity = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblAlgorithm = new Label();
            lblVisited = new Label();
            lblPathLength = new Label();
            lblTime = new Label();
            animationTimer = new System.Windows.Forms.Timer(components);
            btnSave = new Button();
            rbWall = new RadioButton();
            rbStart = new RadioButton();
            rbFinish = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)mazePictureBox).BeginInit();
            SuspendLayout();
            // 
            // mazePictureBox
            // 
            mazePictureBox.Location = new Point(23, 64);
            mazePictureBox.Name = "mazePictureBox";
            mazePictureBox.Size = new Size(650, 650);
            mazePictureBox.TabIndex = 0;
            mazePictureBox.TabStop = false;
            mazePictureBox.Paint += mazePictureBox_Paint;
            mazePictureBox.MouseDown += mazePictureBox_MouseDown;
            mazePictureBox.MouseMove += mazePictureBox_MouseMove;
            mazePictureBox.MouseUp += mazePictureBox_MouseUp;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(708, 112);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(210, 45);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "Створити";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(708, 214);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(210, 45);
            btnGenerate.TabIndex = 2;
            btnGenerate.Text = "Згенерувати";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(708, 265);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(210, 45);
            btnClear.TabIndex = 3;
            btnClear.Text = "Очистити";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnAStarManhattan
            // 
            btnAStarManhattan.Location = new Point(708, 396);
            btnAStarManhattan.Name = "btnAStarManhattan";
            btnAStarManhattan.Size = new Size(210, 45);
            btnAStarManhattan.TabIndex = 4;
            btnAStarManhattan.Text = "А* Манхеттен";
            btnAStarManhattan.UseVisualStyleBackColor = true;
            btnAStarManhattan.Click += btnAStarManhattan_Click;
            // 
            // btnDijkstra
            // 
            btnDijkstra.Location = new Point(708, 345);
            btnDijkstra.Name = "btnDijkstra";
            btnDijkstra.Size = new Size(210, 45);
            btnDijkstra.TabIndex = 5;
            btnDijkstra.Text = "Дейкстра";
            btnDijkstra.UseVisualStyleBackColor = true;
            btnDijkstra.Click += btnDijkstra_Click;
            // 
            // btnAStarEuclid
            // 
            btnAStarEuclid.Location = new Point(708, 447);
            btnAStarEuclid.Name = "btnAStarEuclid";
            btnAStarEuclid.Size = new Size(210, 45);
            btnAStarEuclid.TabIndex = 6;
            btnAStarEuclid.Text = "А* Евклід";
            btnAStarEuclid.UseVisualStyleBackColor = true;
            btnAStarEuclid.Click += btnAStarEuclid_Click;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(708, 498);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(210, 45);
            btnPause.TabIndex = 7;
            btnPause.Text = "Пауза";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(708, 64);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(0, 27);
            textBox1.TabIndex = 8;
            // 
            // txtRows
            // 
            txtRows.Location = new Point(869, 36);
            txtRows.Name = "txtRows";
            txtRows.Size = new Size(64, 27);
            txtRows.TabIndex = 9;
            // 
            // txtCols
            // 
            txtCols.Location = new Point(869, 75);
            txtCols.Name = "txtCols";
            txtCols.Size = new Size(64, 27);
            txtCols.TabIndex = 10;
            // 
            // txtDensity
            // 
            txtDensity.Location = new Point(869, 181);
            txtDensity.Name = "txtDensity";
            txtDensity.Size = new Size(64, 27);
            txtDensity.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(708, 43);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 12;
            label1.Text = "Рядки (10-100):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(708, 82);
            label2.Name = "label2";
            label2.Size = new Size(126, 20);
            label2.TabIndex = 13;
            label2.Text = "Стовпці (10-100):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(696, 184);
            label3.Name = "label3";
            label3.Size = new Size(167, 20);
            label3.TabIndex = 14;
            label3.Text = "Щільність стін (1-60%):";
            // 
            // lblAlgorithm
            // 
            lblAlgorithm.AutoSize = true;
            lblAlgorithm.Location = new Point(696, 560);
            lblAlgorithm.Name = "lblAlgorithm";
            lblAlgorithm.Size = new Size(80, 20);
            lblAlgorithm.TabIndex = 15;
            lblAlgorithm.Text = "Алгоритм:";
            // 
            // lblVisited
            // 
            lblVisited.AutoSize = true;
            lblVisited.Location = new Point(696, 589);
            lblVisited.Name = "lblVisited";
            lblVisited.Size = new Size(160, 20);
            lblVisited.TabIndex = 16;
            lblVisited.Text = "Переглянуто вершин:";
            // 
            // lblPathLength
            // 
            lblPathLength.AutoSize = true;
            lblPathLength.Location = new Point(696, 619);
            lblPathLength.Name = "lblPathLength";
            lblPathLength.Size = new Size(122, 20);
            lblPathLength.TabIndex = 17;
            lblPathLength.Text = "Довжина шляху:";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(696, 649);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(117, 20);
            lblTime.TabIndex = 18;
            lblTime.Text = "Час виконання:";
            // 
            // animationTimer
            // 
            animationTimer.Interval = 50;
            animationTimer.Tick += animationTimer_Tick;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(733, 683);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(164, 29);
            btnSave.TabIndex = 19;
            btnSave.Text = "Зберегти результати";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // rbWall
            // 
            rbWall.AutoSize = true;
            rbWall.Location = new Point(23, 25);
            rbWall.Name = "rbWall";
            rbWall.Size = new Size(66, 24);
            rbWall.TabIndex = 20;
            rbWall.TabStop = true;
            rbWall.Text = "Стіна";
            rbWall.UseVisualStyleBackColor = true;
            // 
            // rbStart
            // 
            rbStart.AutoSize = true;
            rbStart.Location = new Point(125, 25);
            rbStart.Name = "rbStart";
            rbStart.Size = new Size(68, 24);
            rbStart.TabIndex = 21;
            rbStart.TabStop = true;
            rbStart.Text = "Старт";
            rbStart.UseVisualStyleBackColor = true;
            // 
            // rbFinish
            // 
            rbFinish.AutoSize = true;
            rbFinish.Location = new Point(223, 25);
            rbFinish.Name = "rbFinish";
            rbFinish.Size = new Size(70, 24);
            rbFinish.TabIndex = 22;
            rbFinish.TabStop = true;
            rbFinish.Text = "Фініш";
            rbFinish.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 736);
            Controls.Add(rbFinish);
            Controls.Add(rbStart);
            Controls.Add(rbWall);
            Controls.Add(btnSave);
            Controls.Add(lblTime);
            Controls.Add(lblPathLength);
            Controls.Add(lblVisited);
            Controls.Add(lblAlgorithm);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDensity);
            Controls.Add(txtCols);
            Controls.Add(txtRows);
            Controls.Add(textBox1);
            Controls.Add(btnPause);
            Controls.Add(btnAStarEuclid);
            Controls.Add(btnDijkstra);
            Controls.Add(btnAStarManhattan);
            Controls.Add(btnClear);
            Controls.Add(btnGenerate);
            Controls.Add(btnCreate);
            Controls.Add(mazePictureBox);
            Name = "MainForm";
            Text = "Пошук шляху в лабіринті";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)mazePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox mazePictureBox;
        private Button btnCreate;
        private Button btnGenerate;
        private Button btnClear;
        private Button btnAStarManhattan;
        private Button btnDijkstra;
        private Button btnAStarEuclid;
        private Button btnPause;
        private TextBox textBox1;
        private TextBox txtRows;
        private TextBox txtCols;
        private TextBox txtDensity;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblAlgorithm;
        private Label lblVisited;
        private Label lblPathLength;
        private Label lblTime;
        private System.Windows.Forms.Timer animationTimer;
        private Button btnSave;
        private RadioButton rbWall;
        private RadioButton rbStart;
        private RadioButton rbFinish;
    }
}
