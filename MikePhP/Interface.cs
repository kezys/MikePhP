using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text.Json;
using System.Windows.Forms;

namespace MikePhP
{
    public partial class Interface : Form
    {
        private Point initialMousePos;
        private Panel tabelaSelecionada;
        private List<Panel> tabelas = new List<Panel>();
        private DataGridViewRow origem = null;
        private DataGridViewRow destino = null;
        private Ajuda janelaAjuda = null;
        private Dictionary<(DataGridViewCell, DataGridViewCell), (Panel from, Panel to)> relacoes = new Dictionary<(DataGridViewCell, DataGridViewCell), (Panel from, Panel to)>();
        private const int resizeAreaSize = 10;



        public Interface()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            pnlDrag.Dock = DockStyle.Top;
            btnClose.Dock = DockStyle.Right;
            btnMax.Dock = DockStyle.Right;
            btnMin.Dock = DockStyle.Right;
            this.MinimumSize = new Size(500, 600);
            this.FormBorderStyle = FormBorderStyle.None;


        }

        protected override void WndProc(ref Message m)
        {
            const int HTLEFT = 10;
            const int HTRIGHT = 11;
            const int HTTOP = 12;
            const int HTTOPLEFT = 13;
            const int HTTOPRIGHT = 14;
            const int HTBOTTOM = 15;
            const int HTBOTTOMLEFT = 16;
            const int HTBOTTOMRIGHT = 17;
            const int WM_NCHITTEST = 0x84;

            const int resizeAreaSize = 10;

            if (m.Msg == WM_NCHITTEST)
            {
                Point cursor = PointToClient(Cursor.Position);

                if (cursor.X <= resizeAreaSize)
                {
                    if (cursor.Y <= resizeAreaSize)
                        m.Result = (IntPtr)HTTOPLEFT;
                    else if (cursor.Y >= ClientSize.Height - resizeAreaSize)
                        m.Result = (IntPtr)HTBOTTOMLEFT;
                    else
                        m.Result = (IntPtr)HTLEFT;
                    return;
                }
                else if (cursor.X >= ClientSize.Width - resizeAreaSize)
                {
                    if (cursor.Y <= resizeAreaSize)
                        m.Result = (IntPtr)HTTOPRIGHT;
                    else if (cursor.Y >= ClientSize.Height - resizeAreaSize)
                        m.Result = (IntPtr)HTBOTTOMRIGHT;
                    else
                        m.Result = (IntPtr)HTRIGHT;
                    return;
                }
                else if (cursor.Y <= resizeAreaSize)
                {
                    m.Result = (IntPtr)HTTOP;
                    return;
                }
                else if (cursor.Y >= ClientSize.Height - resizeAreaSize)
                {
                    m.Result = (IntPtr)HTBOTTOM;
                    return;
                }
            }

            base.WndProc(ref m);
        }

        private void btnAdicionarTabela_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNomeTabela.Text))
            {
                MessageBox.Show("Preencha um Nome para a Tabela!");
                return;
            }
            else
            {
                var todosPainéis = this.Controls.OfType<Panel>();

                foreach (Panel tabela in todosPainéis)
                {
                    if (textBoxNomeTabela.Text == tabela.Tag?.ToString())
                    {
                        MessageBox.Show("Já existe um tabela com esse nome!");
                        return;
                    }
                }

                AdicionarTabela(textBoxNomeTabela.Text);
            }
        }

        private void AdicionarTabela(string nomeTabela)
        {
         
            Panel tabelaPanel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(120, 100),
                Tag = nomeTabela,
                BackColor = Color.White,
                Size = new Size(larguraPainel, alturaInicial)
            };

            Label tabelaLabel = new Label
            {
                Text = nomeTabela,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 30,
                BackColor = Color.FromArgb(31, 30, 68),
            };

            DataGridView dgv = new DataGridView
            {
                Location = new Point(0, tabelaLabel.Height),
                Width = larguraPainel,
                Height = alturaInicial - tabelaLabel.Height,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                ScrollBars = ScrollBars.None,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            };

            dgv.Columns.Add("ColunaNome", "Nome");
            dgv.Columns.Add("ColunaTipo", "Tipo");

            DataGridViewCheckBoxColumn autoIncrementColumn = new DataGridViewCheckBoxColumn
            {
                Name = "AutoIncrement",
                HeaderText = "Auto Increment",
                FalseValue = false,
                TrueValue = true
            };
            dgv.Columns.Add(autoIncrementColumn);

            DataGridViewCheckBoxColumn primaryKeyColumn = new DataGridViewCheckBoxColumn
            {
                Name = "PrimaryKey",
                HeaderText = "Primary Key",
                FalseValue = false,
                TrueValue = true
            };
            dgv.Columns.Add(primaryKeyColumn);

            tabelaPanel.Controls.Add(dgv);
            tabelaPanel.Controls.Add(tabelaLabel);

            tabelaLabel.MouseDown += (s, e) => OnTabelaPanelMouseDown(s, e, tabelaPanel);
            tabelaLabel.MouseMove += (s, e) => OnTabelaPanelMouseMove(s, e, tabelaPanel);
            tabelaLabel.MouseUp += (s, e) => OnTabelaPanelMouseUp(s, e, tabelaPanel);

            tabelaPanel.MouseDoubleClick += (s, ev) => AdicionarLinhaTabela(dgv, tabelaPanel, tabelaLabel);
            dgv.MouseDoubleClick += (s, ev) => AdicionarLinhaTabela(dgv, tabelaPanel, tabelaLabel);

            dgv.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hitTest = dgv.HitTest(e.X, e.Y);
                    if (hitTest.RowIndex >= 0)
                    {
                        var result = MessageBox.Show("Deseja eliminar esta linha?", "Eliminar", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            dgv.Rows.RemoveAt(hitTest.RowIndex);

                            int alturaLinhas = dgv.Rows.Count * dgv.RowTemplate.Height;
                            int alturaTotal = dgv.ColumnHeadersHeight + alturaLinhas;
                            dgv.Height = alturaTotal;
                            Panel tabelaPanel = (Panel)dgv.Parent;
                            Label tabelaLabel = tabelaPanel.Controls[1] as Label;
                            tabelaPanel.Height = alturaTotal + tabelaLabel.Height;
                        }
                    }
                }
            };


            dgv.KeyDown += (s, e) =>
            {
                if (e.Control && e.KeyCode == Keys.R)
                {
                    if (dgv.SelectedCells.Count > 0)
                    {
                        var rowIndex = dgv.SelectedCells[0].RowIndex;
                        var selectedRow = dgv.Rows[rowIndex];

                        if (origem == null)
                        {
                            origem = selectedRow;
                            MessageBox.Show("Agora clique Enter na row que deseja fazer a relação!");
                        }
                        else
                        {
                            destino = selectedRow;
                            MessageBox.Show("Relação feita entre " + origem.Cells[0].Value.ToString() + " e " + destino.Cells[0].Value.ToString());

                            var origemPainel = (Panel)origem.DataGridView.Parent;
                            var destinoPainel = (Panel)destino.DataGridView.Parent;

                            if (origemPainel != destinoPainel)
                            {
                                relacoes[(origem.Cells[0], destino.Cells[0])] = (origemPainel, destinoPainel);
                                this.Invalidate();
                                origem = null;
                                destino = null;
                            }
                        }
                    }
                }
            };

            tabelaLabel.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    var result = MessageBox.Show("Deseja eliminar esta tabela?", "Eliminar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        this.Controls.Remove(tabelaPanel);
                    }
                }
            };

            tabelas.Add(tabelaPanel);

            this.Controls.Add(tabelaPanel);
        }
            int larguraPainel = 605;
            int alturaInicial = 100;

        private void AdicionarLinhaTabela(DataGridView dgv, Panel tabelaPanel, Label tabelaLabel)
        {
            if (dgv.Rows.Count == 0)
                dgv.Rows.Add("id_" + tabelaLabel.Text, "int", true, true);
            else
                dgv.Rows.Add("Nova_Linha", "varchar", false, false);

            int alturaLinhas = dgv.Rows.Count * dgv.RowTemplate.Height;
            int alturaTotal = dgv.ColumnHeadersHeight + alturaLinhas;

            dgv.Height = alturaTotal;
            tabelaPanel.Height = alturaTotal + tabelaLabel.Height;
        }

        private void OnTabelaPanelMouseDown(object sender, MouseEventArgs e, Panel tabelaPanel)
        {
            initialMousePos = e.Location;
            tabelaSelecionada = tabelaPanel;
        }

        private void OnTabelaPanelMouseMove(object sender, MouseEventArgs e, Panel tabelaPanel)
        {
            if (e.Button == MouseButtons.Left && tabelaSelecionada == tabelaPanel)
            {
                tabelaPanel.Left += e.X - initialMousePos.X;
                tabelaPanel.Top += e.Y - initialMousePos.Y;
                this.Invalidate();
            }
        }

        private void OnTabelaPanelMouseUp(object sender, MouseEventArgs e, Panel tabelaPanel)
        {
            tabelaSelecionada = null;

        }

        private void ObterDadosDasTabelas(string bancoDeDadosEscolhido, string nomeBaseDeDados)
        {
            var todosPainéis = this.Controls.OfType<Panel>();
            List<string> comandosSQL = new List<string>();
            List<string> foreignKeyCommands = new List<string>();

            if (bancoDeDadosEscolhido == "MySQL")
            {
                comandosSQL.Add($"CREATE DATABASE {nomeBaseDeDados};");
                comandosSQL.Add($"USE {nomeBaseDeDados};");
            }
            else if (bancoDeDadosEscolhido == "SQL Server")
            {
                comandosSQL.Add($"CREATE DATABASE {nomeBaseDeDados};");
                comandosSQL.Add("GO");
                comandosSQL.Add($"USE {nomeBaseDeDados};");
                comandosSQL.Add("GO");
            }

            foreach (Panel tabela in todosPainéis)
            {
                if (!tabela.Controls.OfType<DataGridView>().Any())
                    continue;

                Label tituloLabel = tabela.Controls.OfType<Label>().FirstOrDefault();
                string titulo = tituloLabel?.Text ?? "Sem_Nome";

                DataGridView dgv = tabela.Controls.OfType<DataGridView>().FirstOrDefault();
                if (dgv != null)
                {
                    string createTableSQL = $"CREATE TABLE {titulo} (";
                    List<string> primaryKeyColumns = new List<string>();

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            var nome = row.Cells[0].Value?.ToString() ?? "";
                            var tipo = row.Cells[1].Value?.ToString() ?? "";
                            bool isAutoIncrement = (bool)(row.Cells[2].Value ?? false);
                            bool isPrimaryKey = (bool)(row.Cells[3].Value ?? false);

                            if (isAutoIncrement && tipo.ToLower() != "int")
                            {
                                MessageBox.Show($"Erro: AUTO_INCREMENT só pode ser usado em colunas do tipo 'int' ({nome} não é int).");
                                return;
                            }

                            string columnDefinition = $"{nome} {tipo}";

                            if (isAutoIncrement)
                                columnDefinition += bancoDeDadosEscolhido == "MySQL" ? " AUTO_INCREMENT" : " IDENTITY";

                            if (isPrimaryKey)
                                primaryKeyColumns.Add(nome);

                            createTableSQL += columnDefinition + ", ";
                        }
                    }

                    if (primaryKeyColumns.Count > 0)
                    {
                        string pkLine = $"PRIMARY KEY ({string.Join(", ", primaryKeyColumns)})";
                        createTableSQL += pkLine + ", ";
                    }

                    if (createTableSQL.EndsWith(", "))
                        createTableSQL = createTableSQL.Substring(0, createTableSQL.Length - 2);

                    createTableSQL += ");";

                    comandosSQL.Add(createTableSQL);
                    if (bancoDeDadosEscolhido == "SQL Server")
                        comandosSQL.Add("GO");

                    foreach (var relacao in relacoes)
                    {
                        if (relacao.Value.from == tabela)
                        {
                            var origemColuna = relacao.Key.Item1;
                            var destinoColuna = relacao.Key.Item2;

                            var origemNome = origemColuna.Value?.ToString() ?? "";
                            var destinoNome = destinoColuna.Value?.ToString() ?? "";

                            string destinoTabela = relacao.Value.to.Controls.OfType<Label>().FirstOrDefault()?.Text ?? "TabelaDestino";

                            string foreignKeySQL = $"ALTER TABLE {titulo} " +
                                                   $"ADD CONSTRAINT FK_{titulo}_{origemNome}_{destinoNome} " +
                                                   $"FOREIGN KEY ({origemNome}) REFERENCES {destinoTabela} ({destinoNome}) ON DELETE CASCADE;";

                            foreignKeyCommands.Add(foreignKeySQL);
                            if (bancoDeDadosEscolhido == "SQL Server")
                                foreignKeyCommands.Add("GO");
                        }
                    }
                }
            }

            comandosSQL.AddRange(foreignKeyCommands);

            string comandosFinais = string.Join("\n", comandosSQL);
            Clipboard.SetText(comandosFinais);

            MessageBox.Show("Comandos SQL copiados para o clipboard:\n" + comandosFinais);
        }

        private void btnConcluirModelo_Click(object sender, EventArgs e)
        {
            EscolherBdDialog escolherBancoDialog = new EscolherBdDialog();

            if (escolherBancoDialog.ShowDialog() == DialogResult.OK)
            {
                string nomeBanco = escolherBancoDialog.NomeBanco;
                string bancoDeDadosEscolhido = escolherBancoDialog.BancoEscolhido;

                ObterDadosDasTabelas(bancoDeDadosEscolhido, nomeBanco);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            var pen = new Pen(Color.Black, 2);

            foreach (var relacao in relacoes)
            {
                var origemCell = relacao.Key.Item1;
                var destinoCell = relacao.Key.Item2;

                var origemPanel = relacao.Value.Item1;
                var destinoPanel = relacao.Value.Item2;

                var origemPoint = origemPanel.Location;
                var destinoPoint = destinoPanel.Location;

                origemPoint.X += origemPanel.Width;
                origemPoint.Y += origemCell.DataGridView.GetCellDisplayRectangle(origemCell.ColumnIndex, origemCell.RowIndex, true).Top + origemCell.DataGridView.Location.Y + 10;

                destinoPoint.Y += destinoCell.DataGridView.GetCellDisplayRectangle(destinoCell.ColumnIndex, destinoCell.RowIndex, true).Top + destinoCell.DataGridView.Location.Y + 10;

                var middleX = (origemPoint.X + destinoPoint.X) / 2;

                g.DrawLine(pen, origemPoint, new Point(middleX, origemPoint.Y));
                g.DrawLine(pen, new Point(middleX, origemPoint.Y), new Point(middleX, destinoPoint.Y));
                g.DrawLine(pen, new Point(middleX, destinoPoint.Y), destinoPoint);
            }
        }

        private void ImportarTabelas(string caminhoFicheiro)
        {
            if (tabelas.Count >0)
            {
                var resultado = MessageBox.Show( "Já existem tabelas desenhadas. Deseja apagá-las e importar novas?", "Confirmar Importação", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (resultado == DialogResult.No)
            {
                return;
            }
            foreach (var painel in tabelas)
            {
                this.Controls.Remove(painel); // remove do formulário
                painel.Dispose();             // liberta os recursos
            }

            tabelas.Clear(); // limpa a lista
            relacoes.Clear();
            }

            if (!File.Exists(caminhoFicheiro))
            {
                MessageBox.Show("Ficheiro não encontrado.");
                return;
            }

            string json = File.ReadAllText(caminhoFicheiro);
            var dadosImport = JsonSerializer.Deserialize<ImportData>(json);

            foreach (var tabela in dadosImport.tabelas)
            {
                AdicionarTabela(tabela.nome);
                Panel painel = tabelas.Last();
                painel.Location = new Point(tabela.posicao.x, tabela.posicao.y);

                var dgv = painel.Controls.OfType<DataGridView>().First();

                foreach (var coluna in tabela.colunas)
                {
                    dgv.Rows.Add(coluna.nome, coluna.tipo, coluna.autoIncrement, coluna.primaryKey);
                }

                int alturaLinhas = dgv.Rows.Count * dgv.RowTemplate.Height;
                int alturaTotal = dgv.ColumnHeadersHeight + alturaLinhas;

                dgv.Height = alturaTotal;
                painel.Height = alturaTotal + alturaLinhas;
            }

            foreach (var rel in dadosImport.relacoes)
            {
                var origemPainel = tabelas.First(t => t.Tag.ToString() == rel.origem.tabela);
                var destinoPainel = tabelas.First(t => t.Tag.ToString() == rel.destino.tabela);

                var origemDgv = origemPainel.Controls.OfType<DataGridView>().First();
                var destinoDgv = destinoPainel.Controls.OfType<DataGridView>().First();

                var origemCell = origemDgv.Rows
                    .Cast<DataGridViewRow>()
                    .First(r => r.Cells[0].Value?.ToString() == rel.origem.coluna)
                    .Cells[0];

                var destinoCell = destinoDgv.Rows
                    .Cast<DataGridViewRow>()
                    .First(r => r.Cells[0].Value?.ToString() == rel.destino.coluna)
                    .Cells[0];

                relacoes[(origemCell, destinoCell)] = (origemPainel, destinoPainel);
            }

            Invalidate();
            MessageBox.Show("Importação concluída.");
        }

        private void ExportarTabelas(string caminhoFicheiro)
        {

            var dadosExport = new
            {
                tabelas = tabelas.Select(p => new
                {
                    nome = p.Tag.ToString(),
                    posicao = new { x = p.Left, y = p.Top },
                    colunas = ((DataGridView)p.Controls.OfType<DataGridView>().First()).Rows
                        .Cast<DataGridViewRow>()
                        .Where(r => !r.IsNewRow)
                        .Select(r => new
                        {
                            nome = r.Cells[0].Value?.ToString(),
                            tipo = r.Cells[1].Value?.ToString(),
                            autoIncrement = Convert.ToBoolean(r.Cells[2].Value ?? false),
                            primaryKey = Convert.ToBoolean(r.Cells[3].Value ?? false)
                        }).ToList()
                }),
                relacoes = relacoes.Select(r => new
                {
                    origem = new
                    {
                        tabela = r.Value.from.Tag.ToString(),
                        coluna = r.Key.Item1.Value?.ToString()
                    },
                    destino = new
                    {
                        tabela = r.Value.to.Tag.ToString(),
                        coluna = r.Key.Item2.Value?.ToString()
                    }
                }).ToList()
            };

            var json = JsonSerializer.Serialize(dadosExport, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminhoFicheiro, json);
            MessageBox.Show("Exportação concluída.");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "JSON files (*.json)|*.json";
            if (open.ShowDialog() == DialogResult.OK)
            {
                ImportarTabelas(open.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "JSON files (*.json)|*.json";
            if (save.ShowDialog() == DialogResult.OK)
            {
                ExportarTabelas(save.FileName);
            }
        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            if (janelaAjuda == null || janelaAjuda.IsDisposed)
            {
                janelaAjuda = new Ajuda();
                janelaAjuda.Show();
            }
            else
            {
                MessageBox.Show("A janela de ajuda já está aberta.");
                janelaAjuda.BringToFront();
            }
        }

        //Drag 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);

        private void pnlDrag_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMax_Click_1(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMin_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Interface_Load_1(object sender, EventArgs e)
        {

        }
    }

    public class ImportData
    {
        public List<TabelaDTO> tabelas { get; set; }
        public List<RelacaoDTO> relacoes { get; set; }
    }

    public class TabelaDTO
    {
        public string nome { get; set; }
        public PosicaoDTO posicao { get; set; }
        public List<ColunaDTO> colunas { get; set; }
    }

    public class PosicaoDTO
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class ColunaDTO
    {
        public string nome { get; set; }
        public string tipo { get; set; }
        public bool autoIncrement { get; set; }
        public bool primaryKey { get; set; }
    }

    public class RelacaoDTO
    {
        public ReferenciaDTO origem { get; set; }
        public ReferenciaDTO destino { get; set; }
    }

    public class ReferenciaDTO
    {
        public string tabela { get; set; }
        public string coluna { get; set; }

    }
}