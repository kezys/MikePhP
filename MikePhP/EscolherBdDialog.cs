using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MikePhP
{
    public partial class EscolherBdDialog : Form
    {
        public string NomeBanco { get; private set; }
        public string BancoEscolhido { get; private set; }

        public EscolherBdDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomeBanco.Text))
            {
                MessageBox.Show("Por favor, insira o nome da base de dados.");
                return;
            }

            NomeBanco = txtNomeBanco.Text;

            if (rbtnMySQL.Checked)
            {
                BancoEscolhido = "MySQL";
            }
            else if (rbtnSQLServer.Checked)
            {
                BancoEscolhido = "SQL Server";
            }
            else
            {
                MessageBox.Show("Por favor, escolha o banco de dados.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
