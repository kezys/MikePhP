namespace MikePhP
{
    partial class Interface
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Button btnAdicionarTabela;
        private Button btnConcluirModelo;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interface));
            btnAdicionarTabela = new Button();
            btnConcluirModelo = new Button();
            textBoxNomeTabela = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            btnAjuda = new Button();
            panel1 = new Panel();
            panel3 = new Panel();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel4 = new Panel();
            panel2 = new Panel();
            pictureBox5 = new PictureBox();
            pnlDrag = new Panel();
            btnClose = new Button();
            btnMax = new Button();
            btnMin = new Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            pnlDrag.SuspendLayout();
            SuspendLayout();
            // 
            // btnAdicionarTabela
            // 
            btnAdicionarTabela.Cursor = Cursors.Hand;
            btnAdicionarTabela.Dock = DockStyle.Top;
            btnAdicionarTabela.FlatAppearance.BorderSize = 0;
            btnAdicionarTabela.FlatStyle = FlatStyle.Flat;
            btnAdicionarTabela.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnAdicionarTabela.ForeColor = Color.White;
            btnAdicionarTabela.Location = new Point(0, 100);
            btnAdicionarTabela.Margin = new Padding(2);
            btnAdicionarTabela.Name = "btnAdicionarTabela";
            btnAdicionarTabela.Size = new Size(175, 43);
            btnAdicionarTabela.TabIndex = 0;
            btnAdicionarTabela.Text = "Adicionar Tabela";
            btnAdicionarTabela.UseVisualStyleBackColor = false;
            btnAdicionarTabela.Click += btnAdicionarTabela_Click;
            // 
            // btnConcluirModelo
            // 
            btnConcluirModelo.Cursor = Cursors.Hand;
            btnConcluirModelo.Dock = DockStyle.Top;
            btnConcluirModelo.FlatAppearance.BorderSize = 0;
            btnConcluirModelo.FlatStyle = FlatStyle.Flat;
            btnConcluirModelo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnConcluirModelo.ForeColor = Color.White;
            btnConcluirModelo.Location = new Point(0, 143);
            btnConcluirModelo.Margin = new Padding(2);
            btnConcluirModelo.Name = "btnConcluirModelo";
            btnConcluirModelo.Size = new Size(175, 41);
            btnConcluirModelo.TabIndex = 1;
            btnConcluirModelo.Text = " Concluir Modelo";
            btnConcluirModelo.UseVisualStyleBackColor = false;
            btnConcluirModelo.Click += btnConcluirModelo_Click;
            // 
            // textBoxNomeTabela
            // 
            textBoxNomeTabela.Location = new Point(14, 47);
            textBoxNomeTabela.Margin = new Padding(2);
            textBoxNomeTabela.Name = "textBoxNomeTabela";
            textBoxNomeTabela.Size = new Size(147, 23);
            textBoxNomeTabela.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(38, 16);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 3;
            label1.Text = "Nome da Tabela";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(0, 184);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(175, 37);
            button1.TabIndex = 4;
            button1.Text = "Importar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(0, 221);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(175, 39);
            button2.TabIndex = 5;
            button2.Text = "Exportar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnAjuda
            // 
            btnAjuda.Cursor = Cursors.Hand;
            btnAjuda.Dock = DockStyle.Bottom;
            btnAjuda.FlatAppearance.BorderSize = 0;
            btnAjuda.FlatStyle = FlatStyle.Flat;
            btnAjuda.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            btnAjuda.ForeColor = Color.White;
            btnAjuda.Location = new Point(0, 423);
            btnAjuda.Margin = new Padding(2);
            btnAjuda.Name = "btnAjuda";
            btnAjuda.Size = new Size(175, 43);
            btnAjuda.TabIndex = 6;
            btnAjuda.Text = "Ajuda";
            btnAjuda.UseVisualStyleBackColor = false;
            btnAjuda.Click += btnAjuda_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(175, 566);
            panel1.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(31, 30, 68);
            panel3.Controls.Add(pictureBox4);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(btnAjuda);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(btnConcluirModelo);
            panel3.Controls.Add(btnAdicionarTabela);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 100);
            panel3.Name = "panel3";
            panel3.Size = new Size(175, 466);
            panel3.TabIndex = 5;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(9, 226);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(25, 26);
            pictureBox4.TabIndex = 11;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(6, 189);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(25, 26);
            pictureBox3.TabIndex = 10;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(6, 148);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25, 26);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(6, 109);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(26, 29);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(31, 30, 68);
            panel4.Controls.Add(textBoxNomeTabela);
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(175, 100);
            panel4.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(31, 30, 68);
            panel2.Controls.Add(pictureBox5);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(175, 100);
            panel2.TabIndex = 4;
            // 
            // pictureBox5
            // 
            pictureBox5.Dock = DockStyle.Fill;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(0, 0);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(175, 100);
            pictureBox5.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox5.TabIndex = 0;
            pictureBox5.TabStop = false;
            // 
            // pnlDrag
            // 
            pnlDrag.BackColor = Color.FromArgb(31, 30, 68);
            pnlDrag.Controls.Add(btnMin);
            pnlDrag.Controls.Add(btnMax);
            pnlDrag.Controls.Add(btnClose);
            pnlDrag.Dock = DockStyle.Top;
            pnlDrag.Location = new Point(175, 0);
            pnlDrag.Name = "pnlDrag";
            pnlDrag.Size = new Size(860, 38);
            pnlDrag.TabIndex = 0;
            pnlDrag.MouseDown += pnlDrag_MouseDown;
            // 
            // btnClose
            // 
            btnClose.Cursor = Cursors.Hand;
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.Location = new Point(823, 0);
            btnClose.Margin = new Padding(2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(37, 38);
            btnClose.TabIndex = 12;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click_1;
            // 
            // btnMax
            // 
            btnMax.Cursor = Cursors.Hand;
            btnMax.Dock = DockStyle.Right;
            btnMax.FlatAppearance.BorderSize = 0;
            btnMax.FlatStyle = FlatStyle.Flat;
            btnMax.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnMax.ForeColor = Color.White;
            btnMax.Image = (Image)resources.GetObject("btnMax.Image");
            btnMax.Location = new Point(786, 0);
            btnMax.Margin = new Padding(2);
            btnMax.Name = "btnMax";
            btnMax.Size = new Size(37, 38);
            btnMax.TabIndex = 13;
            btnMax.UseVisualStyleBackColor = false;
            btnMax.Click += btnMax_Click_1;
            // 
            // btnMin
            // 
            btnMin.Cursor = Cursors.Hand;
            btnMin.Dock = DockStyle.Right;
            btnMin.FlatAppearance.BorderSize = 0;
            btnMin.FlatStyle = FlatStyle.Flat;
            btnMin.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnMin.ForeColor = Color.White;
            btnMin.Image = (Image)resources.GetObject("btnMin.Image");
            btnMin.Location = new Point(749, 0);
            btnMin.Margin = new Padding(2);
            btnMin.Name = "btnMin";
            btnMin.Size = new Size(37, 38);
            btnMin.TabIndex = 14;
            btnMin.UseVisualStyleBackColor = false;
            btnMin.Click += btnMin_Click_1;
            // 
            // Interface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(1035, 566);
            Controls.Add(pnlDrag);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "Interface";
            Text = "MikePhP";
            Load += Interface_Load_1;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            pnlDrag.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBoxNomeTabela;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button btnAjuda;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Panel panel4;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox5;
        private Panel pnlDrag;
        private Button btnMin;
        private Button btnMax;
        private Button btnClose;
    }
}
