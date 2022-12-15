using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VolkovTransportApp
{
    public partial class TransportMapControl : UserControl
    {
        public TransportMapControl()
        {
            InitializeComponent();
            // Двойная буферизация
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Нарисовать карту
            DrawMap(e.Graphics, ClientRectangle);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            // Перерисовать карту
            Invalidate();
        }

        protected void DrawMap(Graphics g, Rectangle bound)
        {
            // заполнение фона
            g.FillRectangle(Brushes.White, bound);
            // Текст
            string text = "Карта транспортных средств";
            // Вывод текста
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            RectangleF textRect = new RectangleF(
                bound.X, bound.Y, bound.Width, bound.Height);
            g.DrawString(text, Font, Brushes.Black,
                textRect, format);
        }
    }
}
