using System;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MikePhP
{
    public partial class Ajuda : Form
    {
        // Constantes e funções nativas do Windows
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Ajuda()
        {
            InitializeComponent();

            // Retira a borda da janela
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            panel1.Width = 2;
            panel1.Height = 450;
            panel1.BackColor = Color.Black;
        }


        private void Ajuda_Load(object sender, EventArgs e)
        {
            int raio = 20;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, raio, raio, 180, 90);
            path.AddArc(Width - raio, 0, raio, raio, 270, 90);
            path.AddArc(Width - raio, Height - raio, raio, raio, 0, 90);
            path.AddArc(0, Height - raio, raio, raio, 90, 90);
            path.CloseFigure();
            Region = new Region(path);
        }

        private void painelPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
