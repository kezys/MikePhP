using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MikePhP
{
    public partial class TooltipForm : Form
    {
        public TooltipForm(string texto)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(220, 110);
            SetRoundedRegion(30);

            Label label = new Label()
            {
                Text = texto,
                AutoSize = false,
                Size = new Size(200, 60),
                Location = new Point(15, 10)
            };

            Button btnNext = new Button()
            {
                Text = "Next",
                Location = new Point(30, 70),
                Size = new Size(80, 35)
            };

            Button btnClose = new Button()
            {
                Text = "X",
                Location = new Point(170, 70),
                Size = new Size(35, 35)
            };



            btnNext.Click += (s, e) => this.DialogResult = DialogResult.OK;
            btnClose.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.Controls.Add(label);
            this.Controls.Add(btnNext);
            this.Controls.Add(btnClose);
        }

        private void SetRoundedRegion(int radius)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            // Cria um retângulo arredondado
            int diameter = radius * 2;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90); // canto superior esquerdo
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90); // canto superior direito
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90); // canto inferior direito
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90); // canto inferior esquerdo
            path.CloseFigure();

            this.Region = new Region(path);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int topMargin = 45;

            int arrowWidth = 10;
            int arrowHeight = 20;

            int offsetX = 5;

            Point[] arrowPoints = new Point[]
            {
            new Point(0 + offsetX, topMargin + arrowHeight / 2),
            new Point(arrowWidth + offsetX, topMargin),
            new Point(arrowWidth + offsetX, topMargin + arrowHeight)
            };

            // Desenha sombra da seta (mais clara e deslocada)
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0)))
            {
                Point[] shadowPoints = arrowPoints.Select(p => new Point(p.X + 3, p.Y + 3)).ToArray();
                g.FillPolygon(shadowBrush, shadowPoints);
            }

            // Desenha o triângulo da seta a preto
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                g.FillPolygon(brush, arrowPoints);
            }

            // Desenha a borda da seta para mais definição
            using (Pen pen = new Pen(Color.DarkSlateGray, 2))
            {
                g.DrawPolygon(pen, arrowPoints);
            }
        }

    }
}
