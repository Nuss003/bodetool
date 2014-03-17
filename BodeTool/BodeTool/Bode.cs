using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Bode /* Oggetto in grado di disegnare diagrammi di Bode */
    {
        private float k; /* Guadagno statico */
        private List<float> zeri;
        private List<float> poli;
        private List<float> zeripolipositivi; //Lista dei poli e degli zeri che sono a parte reale positiva, quindi in fase si comporteranno in maniera inversa
        private int width; //Lunghezza del grafico
        private int height; //Altezza del grafico
        private int origine_y; //Riferimento in pixel della posizione dell'asse 0 (di default a metà altezza)
        private int origine_x; //Riferimento in pixel della posizione di 10^0
        private float xmin; //potenza di 10 da cui deve partire il grafico
        private int[] divisioni_decade; //Contiene il numero di pixel che mi servono per suddividere la decade
        private Bitmap graficofinito; //Immagine bitmap su cui disegnerò il grafico e che poi ritornerò
        private bool disegna_griglia; //Specifica se disegnare prima la griglia e poi sopra il grafico
        private bool k_lineare_negativo;

        public Bode(float k, bool k_lineare_negativo, List<float> zeri, List<float> poli, List<float> zeripolipositivi, int width, int height, float xmin)
        {   //Inizializzazione
            this.k = k;
            this.k_lineare_negativo = k_lineare_negativo;
            this.zeri = zeri;
            this.poli = poli;
            this.zeripolipositivi = zeripolipositivi;
            this.width = width;
            this.height = height;
            this.xmin = xmin;
            this.origine_y = height / 2;
            this.divisioni_decade = new int[] { 0, 34, 56, 69, 78, 85, 90, 94, 97 };
            this.graficofinito = new Bitmap(width, height);
            this.disegna_griglia = true;
            this.origine_x = ContaDecadi(xmin) * 100; //Mi salvo la posizione di 10^0 in pixel
        }

        /* Conta quante decadi di differenza ci sono tra la decade passata come parametro e 10^0 */
        private int ContaDecadi(float decade)
        {
            if (decade < 1f)
                return 1 + ContaDecadi((float)Math.Round(decade * 10, 6));
            else if (decade > 1f)
                return -1 + ContaDecadi((float)Math.Round(decade / 10, 6));
            return 0;
        }

        /* Metodo che disegna la griglia per fare il grafico */
        /* Se modulo = true allora segna sulle ordinate i decibel, se = false segna i gradi */
        private void DisegnaGriglia(Graphics grafico, bool modulo)
        {
            Font font = new Font("Arial", 8);
            Brush brush = new SolidBrush(Color.Black);
            Pen pen_black = new Pen(Color.Black);
            Pen pen_gray = new Pen(Color.Gray);
            Pen pen_lightgray = new Pen(Color.LightGray);
            float passo;
            //Metto lo sfondo bianco
            grafico.Clear(Color.White);
            //Traccio l'asse dell'origine
            grafico.DrawLine(pen_black, new Point(0, this.origine_y), new Point(this.width, this.origine_y));
            grafico.DrawString("0", font, brush, 2, this.origine_y);
            //Traccio gli altri assi paralleli all'origine
            int y2 = this.origine_y - 40;
            for (int y = this.origine_y + 40; y < this.height; y += 40) //Salto di 40 in 40 (40 pixel mi rappresentano 20 dB o 45 gradi)
            {
                //Calcolo il passo, cioè mi servirà a determinare la spaziatura tra le linee
                if (modulo == true)
                    passo = -0.5f; //passo per il modulo
                else
                    passo = -1.125f; //passo per la fase

                //Disegno dall'origine verso il basso
                grafico.DrawLine(pen_gray, new Point(0, y), new Point(this.width, y));
                grafico.DrawString(((y - this.origine_y) * passo).ToString(), font, brush, 2, y);
                //Disegno dall'origine verso l'alto
                grafico.DrawLine(pen_gray, new Point(0, y2), new Point(this.width, y2));
                grafico.DrawString(((y2 - this.origine_y) * passo).ToString(), font, brush, 2, y2);
                y2 -= 40;
            }
            
            //Traccio le decadi
            float decade = this.xmin;
            int distanza;
            for (int x = 0; x < this.width; x += 100) //Ogni decade è rappresentata da 100 pixel
            {
                //Suddivido le decadi
                for (int i = 1; i < 9; i++)
                {
                    distanza = x + this.divisioni_decade[i];
                    grafico.DrawLine(pen_lightgray, new Point(distanza, 0), new Point(distanza, this.height));
                }

                //Disegno le decadi
                grafico.DrawLine(pen_gray, new Point(x, 0), new Point(x, this.height));
                grafico.DrawString((decade).ToString(), font, brush, x, 2);
                decade = (float)Math.Round(decade * 10, 5); //Incremento la decade
            }

            //Aggiungo scritta in basso a destra per indicare se si tratta del grafico del modulo o della fase
            String nome = "Modulo";
            if (modulo == false)
                nome = "Fase";
            grafico.DrawString(nome, new Font("Arial", 12), new SolidBrush(Color.Maroon), this.width - 60, this.height - 20);
        }

        public Bitmap GraficoModulo()
        {
            return GraficoModulo(Color.Blue);
        }

        public Bitmap GraficoModulo(Color colore)
        {
            return Grafico(colore, true);
        }

        /* Metodo che disegna il grafico o del modulo (se uguale true) o altrimenti della fase */
        private Bitmap Grafico(Color colore, bool modulo)
        {
            float decadi;
            Graphics grafico = Graphics.FromImage(this.graficofinito);
            Pen pen = new Pen(colore);

            //Inizializzo il grafico
            if (this.disegna_griglia == true)
                DisegnaGriglia(grafico, modulo);
            //Analizzo posizione di partenza e inclinazione iniziali
            int partenza = 0; //Determino il punto di partenza
            int inclinazione = 0; //Determino l'inclinazione di partenza
            if (modulo == true) //Se devo disegnare il modulo aggiorno l'inclinazione di partenza guardando i poli/zeri nell'origine
            {   //Considerare che il punto in alto a sinistra del grafico è (0, 0) in pixel
                inclinazione += 40 * NumeroOccorrenze(0, this.poli); //incremento di 40 pixel per ogni polo nell'origine, cioè il grafico scenderà di 20 dB per ogni polo
                inclinazione -= 40 * NumeroOccorrenze(0, this.zeri); //decremento di 40 pixel cioè il grafico salirà di 20 dB
            }
            else //Se devo disegnare la fase aggiorno il punto di partenza
            {
                partenza += 80 * NumeroOccorrenze(0, this.poli); //incremento di 80 pixel per ogni polo, quindi il punto di partenza si abbasserà di 90° per ogni polo
                partenza -= 80 * NumeroOccorrenze(0, this.zeri); //decremento di 80 pixel, quindi il punto di partenza si alzerà di 90°
                if (this.k_lineare_negativo == true) //Se k lineare è < 0 ho uno sfasamento di 180°
                       partenza -= 160; //incremento di 180°, tanto sommare o sottrarre di 180° è la stessa cosa, per vedere meglio il grafico mi conviene sommare
            }
            //Metto tutti i poli e gli zeri in un'unica lista che poi ordino, in modo da vedere chi incontro man mano che traccio il grafico
            List<float> polizeri = new List<float>(poli);
            polizeri.AddRange(zeri); //unisco le liste
            polizeri.Sort(); //Ordinamento naturale, per funzionare, mi aspetto che i poli/zeri siano stati presi in modulo
            //In base ai calcoli fatti prima stabilisco il punto di partenza
            int tmp;
            if (modulo == true) //Se devo fare il grafico del modulo tengo conto che a 10^0 mi trovo ad altezza k
                tmp = (int)((this.origine_y - (this.k * 2)) - ((this.origine_x / 100) * inclinazione));
            else
                tmp = this.origine_y+partenza;
            Point posizione_corrente = new Point(0, tmp);
            Point posizione_finale = new Point();
            float polozero_precedente = 0;
            //Inizio a ciclare la lista di poli/zeri per tracciare il grafico
            foreach (float polozero in polizeri)
            {
                if (polozero != 0f) //Se il polo/zero non è nell'origine
                {
                    if (polozero < this.xmin)
                    { //Se il mio polo o zero si trova prima dell'inizio del grafico
                        grafico.Clear(Color.White); //Cancello il grafico e ci metto uno sfondo bianco
                        grafico.DrawString("Errore: polo o zero posizionato prima dell'inizio del grafico", new Font("Arial", 8), new SolidBrush(Color.Black), 5, 5); //Stampo scritta di errore
                        grafico.Save(); //Salvo
                        return this.graficofinito; //e ritorno
                    }
                    //Traccio il grafico
                    posizione_finale.X = GetPixel(polozero); //Mi ricavo la posizione in pixel del polo/zero
                    decadi = ((float)(posizione_finale.X - posizione_corrente.X) / 100); //Mi ricavo le decadi di distanza dal punto in cui mi trovo
                    posizione_finale.Y = posizione_corrente.Y + (int)Math.Round(inclinazione * decadi); //Mi calcolo l'altezza in pixel tenendo conto dell'inclinazione rispetto le decadi percorse
                    grafico.DrawLine(pen, posizione_corrente, posizione_finale); //Disegno la linea
                    posizione_corrente = posizione_finale; //Aggiorno la posizione corrente

                    //Mi calcolo l'inclinazione che dovrà avere la prossima linea
                    if ((this.poli.Contains(polozero)) && (!(this.zeri.Contains(polozero))))//se il polo/zero corrente è un polo
                        inclinazione += 40; //Aggiungo 40 pixel, cioè l'inclinazione scende di ulteriori 20 dB/45°
                    else if ((this.zeri.Contains(polozero)) && (!(this.poli.Contains(polozero)))) //Altrimenti se è uno zero
                        inclinazione -= 40; //Decremento di 40 pixel, cioè salgo di 20dB/45°
                    else //Altrimenti se ho un polo (o più) sovrapposto ad uno zero (o più)
                        if (polozero_precedente != polozero) //Se non l'ho già contati
                        {   //Conto la somma totale dei contributi
                            inclinazione = inclinazione + 40 * (NumeroOccorrenze(polozero, this.poli) - NumeroOccorrenze(polozero, this.zeri));
                            polozero_precedente = polozero; //e dico di non contarli più
                        }
                }
            }
            //Faccio l'ultimo tratto finale
            posizione_finale.X = this.width;
            decadi = ((float)(posizione_finale.X - posizione_corrente.X) / 100);
            posizione_finale.Y = posizione_corrente.Y + (int)Math.Round(inclinazione * decadi);
            grafico.DrawLine(pen, posizione_corrente, posizione_finale);
            grafico.Save();
            return this.graficofinito;
        }

        
        public Bitmap GraficoFase()
        {
            return GraficoFase(Color.Blue);
        }

        public Bitmap GraficoFase(Color colore)
        {
            List<float> new_poli = new List<float>();
            List<float> new_zeri = new List<float>();
            bool invertito;
            //Sdoppio i poli
            foreach (float polo in this.poli)
            {
                invertito = this.zeripolipositivi.Contains(polo); //Verifico se il polo corrente si comporta come uno zero
                if (polo == 0f) //Verifico se è nell'origine
                    if (invertito)
                        new_zeri.Add(polo);
                    else
                        new_poli.Add(polo);
                else //Se non è nell'origine lo sdoppio
                {
                    float polo1, polo2;
                    polo1 = (float)Math.Round(polo / 10, 6);
                    polo2 = (float)Math.Round(polo * 10, 6);
                    if (invertito)
                    {
                        float t = polo1;
                        polo1 = polo2;
                        polo2 = t;
                    }
                    new_poli.Add(polo1);
                    new_zeri.Add(polo2);
                }

            }
            //Sdoppio gli zeri in maniera analoga ai poli
            foreach (float zero in this.zeri)
            {
                invertito = this.zeripolipositivi.Contains(zero);
                if (zero == 0f)
                    if (invertito)
                        new_poli.Add(zero);
                    else
                        new_zeri.Add(zero);
                else
                {
                    float zero1, zero2;
                    zero1 = (float)Math.Round(zero / 10, 6);
                    zero2 = (float)Math.Round(zero * 10, 6);
                    if (invertito)
                    {
                        float t = zero1;
                        zero1 = zero2;
                        zero2 = t;
                    }
                    new_zeri.Add(zero1);
                    new_poli.Add(zero2);
                }
            }

            //Modifico la lista di poli e zeri dell'oggetto
            this.poli = new_poli;
            this.zeri = new_zeri;

            return Grafico(colore, false);
        }

        /* Ritorna quante volte è contenuto il numero n nella lista */
        private int NumeroOccorrenze(float n, List<float> lista)
        {
            int risultato = 0;
            foreach (float num in lista)
            {
                if (num == n)
                    risultato++;
            }
            return risultato;
        }

        /* Ritorna il valore in pixel del polo/zero passati come parametro formale.
         * C'è una perdita di precisione, poichè può individuare la posizione del polo/zero solo se si trova
         * in punti pre-determinati, cioè su una decade o su una suddivisione della decade, se non è così
         * approssima la sua posizione alla posizione nota più vicina. */
        private int GetPixel(float polozero)
        {
            float i = this.xmin; //Contatore delle decadi
            int decade = 0;
            while (true) { //Ciclo le decadi
                if (i > polozero) //Se l'inizio della decade è maggiore del polo/zero..
                {
                    decade -= 100; //Poichè trovo una decade più grande, mi sposto una decade prima perchè è lì che il polo/zero dev'essere contenuto
                    int polozero_standard = GetFormatoStandard(polozero);
                    if (polozero_standard == 1)
                        return decade;
                    else
                        return decade + this.divisioni_decade[polozero_standard-1];
                }
                i = (float)Math.Round(i * 10, 5); //Incremento il contatore delle decadi
                decade += 100;
            }
        }

        //Dato un polo o zero, lo scala fino ad ottenerlo copreso tra 1 e 10 (la considero la forma standard)
        private int GetFormatoStandard(float polozero)
        { 
            if ((polozero >= 1) && (polozero <= 9))
                return (int)Math.Round(polozero);
            else if (polozero < 1)
                return GetFormatoStandard((float)Math.Round(polozero * 10, 6));
            else
                return GetFormatoStandard((float)Math.Round(polozero / 10, 6));
        }

        public void SetImgPerGrafico(Bitmap bitmap)
        {
            this.graficofinito = bitmap;
            this.disegna_griglia = false;
        }

        public void ResetGrafico()
        {
            this.graficofinito = new Bitmap(this.width, this.height);
            this.disegna_griglia = true;
        }

    }
}
