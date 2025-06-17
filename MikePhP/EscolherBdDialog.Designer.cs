namespace MikePhP
{
    partial class EscolherBdDialog
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
            txtNomeBanco = new TextBox();
            label1 = new Label();
            rbtnMySQL = new RadioButton();
            rbtnSQLServer = new RadioButton();
            btnOk = new Button();
            SuspendLayout();
            // 
            // txtNomeBanco
            // 
            txtNomeBanco.Location = new Point(101, 37);
            txtNomeBanco.Name = "txtNomeBanco";
            txtNomeBanco.Size = new Size(209, 31);
            txtNomeBanco.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(101, 9);
            label1.Name = "label1";
            label1.Size = new Size(209, 25);
            label1.TabIndex = 1;
            label1.Text = "Nome da Base de Dados";
            // 
            // rbtnMySQL
            // 
            rbtnMySQL.AutoSize = true;
            rbtnMySQL.Location = new Point(101, 117);
            rbtnMySQL.Name = "rbtnMySQL";
            rbtnMySQL.Size = new Size(94, 29);
            rbtnMySQL.TabIndex = 2;
            rbtnMySQL.TabStop = true;
            rbtnMySQL.Text = "MySQL";
            rbtnMySQL.UseVisualStyleBackColor = true;
            // 
            // rbtnSQLServer
            // 
            rbtnSQLServer.AutoSize = true;
            rbtnSQLServer.Location = new Point(194, 117);
            rbtnSQLServer.Name = "rbtnSQLServer";
            rbtnSQLServer.Size = new Size(123, 29);
            rbtnSQLServer.TabIndex = 3;
            rbtnSQLServer.TabStop = true;
            rbtnSQLServer.Text = "SQL Server";
            rbtnSQLServer.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(143, 188);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(112, 34);
            btnOk.TabIndex = 4;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // EscolherBdDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 233);
            Controls.Add(btnOk);
            Controls.Add(rbtnSQLServer);
            Controls.Add(rbtnMySQL);
            Controls.Add(label1);
            Controls.Add(txtNomeBanco);
            Name = "EscolherBdDialog";
            Text = "Escolher Base de Dados";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNomeBanco;
        private Label label1;
        private RadioButton rbtnMySQL;
        private RadioButton rbtnSQLServer;
        private Button btnOk;
    }
}
