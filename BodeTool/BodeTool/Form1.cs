using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        private Bitmap imgGraficoBaseModulo;
        private Bitmap imgGraficoBaseFase;
        private bool riduci;

        public Form1()
        {
            InitializeComponent();
            /* Adatto le dimensioni del form allo schermo */
            this.Width = (int)Math.Round(Screen.PrimaryScreen.Bounds.Width * 0.712);
            this.Height = (int)Math.Round(Screen.PrimaryScreen.Bounds.Height * 0.794);
            int larghezza_picture = (int)Math.Round(Screen.PrimaryScreen.Bounds.Width * 0.6078);
            int altezza_picture = (int)Math.Round(Screen.PrimaryScreen.Bounds.Height * 0.3591);
            this.pic1.Width = larghezza_picture;
            this.pic1.Height = altezza_picture;
            this.pic2.Width = larghezza_picture;
            this.pic2.Height = altezza_picture;
            this.riduci = false;
        }

        private void btnCalcola_Click(object sender, EventArgs e)
        {
            List<float> zeri = new List<float>();
            List<float> poli = new List<float>();
            List<float> zeripolipositivi = new List<float>();
            if ((txtK.Text.Equals("")) || (txtMin.Text.Equals("")))
            {
                MessageBox.Show("k e x di inizio grafico, sono campi obbligatori!");
                return;
            }

            //Carico gli zeri
            txtZeri.Text = txtZeri.Text.Replace('.', ',');
            List<String> tmp = txtZeri.Text.Split(';').ToList<String>();
            foreach (String numero in tmp)
            {
                if (!(numero.Equals("")))
                {
                    zeri.Add(float.Parse(numero));
                }
            }
            //Carico i poli
            txtPoli.Text = txtPoli.Text.Replace('.', ',');
            tmp = txtPoli.Text.Split(';').ToList<String>();
            foreach (String numero in tmp)
            {
                if (!(numero.Equals("")))
                {
                    poli.Add(float.Parse(numero));
                }
            }

            //Carico gli zeri e i poli a parte reale positiva
            txtZPpositivi.Text = txtZPpositivi.Text.Replace('.', ',');
            tmp = txtZPpositivi.Text.Split(';').ToList<String>();
            foreach (String numero in tmp)
            {
                if (!(numero.Equals("")))
                    zeripolipositivi.Add(float.Parse(numero));
            }

            //Disegno bode normale
            txtMin.Text = txtMin.Text.Replace('.', ',');
            float k = float.Parse(txtK.Text);
            float xmin = float.Parse(txtMin.Text);
            Bode bode = new Bode(k, checkK.Checked, zeri, poli, zeripolipositivi, pic1.Width, pic1.Height, xmin);
            this.imgGraficoBaseModulo = bode.GraficoModulo();
            bode.ResetGrafico();
            this.imgGraficoBaseFase = bode.GraficoFase();
            pic1.Image = this.imgGraficoBaseModulo;
            pic2.Image = this.imgGraficoBaseFase;
            if ((txtM.Text.Equals("")) || (txtTau.Text.Equals("")) || (txtTau.Text.Equals("0")))
                return;
            txtM.Text = txtM.Text.Replace('.', ',');
            txtTau.Text = txtTau.Text.Replace('.', ',');
            float tau = float.Parse(txtTau.Text);
            List<float> zero = new List<float>();
            zero.Add((float)Math.Round(1 / tau, 4)); //Calcolo zero anticipatrice
            List<float> polo = new List<float>();
            polo.Add((float)Math.Round(float.Parse(txtM.Text) / tau, 4)); //Calcolo polo anticipatrice
            if (cmbTipo.Text.Equals("Anticipatrice"))
            {   //Disegno anticipatrice
                ApplicaCorrettrice(zero, polo, zeri, poli, zeripolipositivi, k, xmin);
            }
            else if (cmbTipo.Text.Equals("Attenuatrice"))
            {   //Disegno attenuatrice
                ApplicaCorrettrice(polo, zero, zeri, poli, zeripolipositivi, k, xmin);
                //Per ottenere l'attenuatrice inverto il polo e lo zero dell'anticipatrice
            }

        }

        private void ApplicaCorrettrice(List<float> zero, List<float> polo, List<float> zeri, List<float> poli, List<float> zeripolipositivi, float k, float xmin)
        {
            Bode correttrice = new Bode(0, false, zero, polo, new List<float>(), pic1.Width, pic1.Height, xmin);
            correttrice.SetImgPerGrafico(this.imgGraficoBaseModulo);
            this.imgGraficoBaseModulo = correttrice.GraficoModulo(Color.Green);
            pic1.Image = this.imgGraficoBaseModulo;
            correttrice.SetImgPerGrafico(this.imgGraficoBaseFase);
            this.imgGraficoBaseFase = correttrice.GraficoFase(Color.Green);
            pic2.Image = imgGraficoBaseFase;
            //Applico anticipatrice/correttrice
            poli.Add(polo[0]); //Aggiungo il primo (ovvero l'unico) elemento della lista polo alla lista poli
            zeri.Add(zero[0]); //Faccio la medesima cosa
            correttrice = new Bode(k, checkK.Checked, zeri, poli, zeripolipositivi, pic1.Width, pic1.Height, xmin);
            correttrice.SetImgPerGrafico(this.imgGraficoBaseModulo);
            pic1.Image = correttrice.GraficoModulo(Color.Red);
            correttrice.SetImgPerGrafico(this.imgGraficoBaseFase);
            pic2.Image = correttrice.GraficoFase(Color.Red);
        }

        /* Salvataggio immagini */
        private void button1_Click(object sender, EventArgs e)
        {
            pic1.Image.Save(Application.StartupPath + "\\Modulo.jpg", ImageFormat.Jpeg);
            pic2.Image.Save(Application.StartupPath + "\\Fase.jpg", ImageFormat.Jpeg);
            MessageBox.Show("Immagini salvate nella stessa cartella del programma");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {   //Ridimensiono le picturebox se la finestra viene massimizzata
            //Sapendo che per un monitor con 1024 pixel di altezza devo alzarle di 90 pixel
            //Faccio una proporzione per determinare di quanto alzare le picturebox
           int pixel = (int)Math.Round(Screen.PrimaryScreen.Bounds.Height * 0.08789); //0.08789 = 90/1024

            if ((this.riduci==false) && (this.WindowState.Equals(FormWindowState.Maximized)))
            {
                pic1.Height += pixel;
                pic2.Height += pixel;
                this.riduci = true;
            }
            else if ((this.riduci==true) && (this.WindowState.Equals(FormWindowState.Normal)))
            {
                pic1.Height -= pixel;
                pic2.Height -= pixel;
                this.riduci = false;
            }
        }
    }
}
