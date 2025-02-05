using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProgettoGestioneRistoranti
{
    // Classe per il bottone personalizzato con ombra
    public class ShadowButton : Button
    {
        // Costruttore per abilitare l'ottimizzazione del rendering
        public ShadowButton()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        // Sovrascrive il metodo OnPaint per disegnare l'ombra e il bottone
        protected override void OnPaint(PaintEventArgs pevent)
        {
            // Disegna prima l'ombra
            using (GraphicsPath gp = new GraphicsPath())
            {
                // Aggiungi un rettangolo attorno al bottone
                gp.AddRectangle(new Rectangle(5, 5, this.Width - 10, this.Height - 10));

                // Disegna l'ombra con un leggero offset per farla apparire sotto il bottone
                DrawShadow(gp, 50, 10, pevent.Graphics);
            }

            // Ora disegna il bottone sopra l'ombra
            base.OnPaint(pevent); // Disegna il bottone (contenuto, come testo e bordo)
        }

        // Metodo per disegnare l'ombra
        private void DrawShadow(GraphicsPath gp, int intensity, int radius, Graphics g)
        {
            double alpha = 0;
            double astep = 0;
            double astepstep = (double)intensity / radius / (radius / 2D);

            // Ciclo per disegnare l'ombra con diversi spessori
            for (int thickness = radius; thickness > 0; thickness--)
            {
                using (Pen p = new Pen(Color.FromArgb((int)alpha, 0, 0, 0), thickness))
                {
                    p.LineJoin = LineJoin.Round;
                    g.DrawPath(p, gp); // Disegna il path (forma) con l'ombra
                }
                alpha += astep;
                alpha += astepstep;
            }
        }
    }

    public partial class Form3 : Form
    {
        // Costante per l'ombra del form
        private const int CS_DROPSHADOW = 0x00020000;

        public Form3()
        {
            InitializeComponent();

            // Crea il primo bottone personalizzato con ombra
            ShadowButton shadowButton1 = new ShadowButton
            {
                Size = new Size(200, 60), // Dimensioni del bottone
                Location = new Point(100, 100), // Posizione del bottone
                Text = "Bottone 1" // Testo del bottone
            };

            // Crea il secondo bottone personalizzato con ombra
            ShadowButton shadowButton2 = new ShadowButton
            {
                Size = new Size(200, 60), // Dimensioni del bottone
                Location = new Point(100, 200), // Posizione del bottone
                Text = "Bottone 2" // Testo del bottone
            };

            // Aggiungi i bottoni al form
            this.Controls.Add(shadowButton1);
            this.Controls.Add(shadowButton2);

            // Imposta lo stile per il ridisegno del form
            this.Refresh();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.Resize += Form3_Resize;
        }

        private void Form3_Resize(object sender, EventArgs e)
        {
            this.Invalidate(); // Rende necessario il ridisegno del form
        }

        // Metodo per impostare l'ombra sul form
        protected override CreateParams CreateParams
        {
            get
            {
                // Aggiungi la costante per l'ombra del form
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW; // Abilita l'ombra del form
                return cp;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Eventuali altre inizializzazioni
        }
    }
}
