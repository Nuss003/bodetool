namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtK = new System.Windows.Forms.TextBox();
            this.txtPoli = new System.Windows.Forms.TextBox();
            this.txtZeri = new System.Windows.Forms.TextBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtM = new System.Windows.Forms.TextBox();
            this.txtTau = new System.Windows.Forms.TextBox();
            this.btnCalcola = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtZPpositivi = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkK = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "K (dB):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Poli:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Zeri:";
            // 
            // txtK
            // 
            this.txtK.Location = new System.Drawing.Point(62, 55);
            this.txtK.Name = "txtK";
            this.txtK.Size = new System.Drawing.Size(39, 20);
            this.txtK.TabIndex = 5;
            this.txtK.Text = "20";
            // 
            // txtPoli
            // 
            this.txtPoli.Location = new System.Drawing.Point(62, 79);
            this.txtPoli.Name = "txtPoli";
            this.txtPoli.Size = new System.Drawing.Size(39, 20);
            this.txtPoli.TabIndex = 6;
            this.txtPoli.Text = "1; 5";
            // 
            // txtZeri
            // 
            this.txtZeri.Location = new System.Drawing.Point(62, 105);
            this.txtZeri.Name = "txtZeri";
            this.txtZeri.Size = new System.Drawing.Size(39, 20);
            this.txtZeri.TabIndex = 7;
            this.txtZeri.Text = "10";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Attenuatrice",
            "Anticipatrice"});
            this.cmbTipo.Location = new System.Drawing.Point(11, 207);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(102, 21);
            this.cmbTipo.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "M:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tau:";
            // 
            // txtM
            // 
            this.txtM.Location = new System.Drawing.Point(62, 255);
            this.txtM.Name = "txtM";
            this.txtM.Size = new System.Drawing.Size(39, 20);
            this.txtM.TabIndex = 11;
            this.txtM.Text = "8";
            // 
            // txtTau
            // 
            this.txtTau.Location = new System.Drawing.Point(62, 279);
            this.txtTau.Name = "txtTau";
            this.txtTau.Size = new System.Drawing.Size(39, 20);
            this.txtTau.TabIndex = 12;
            this.txtTau.Text = "10";
            // 
            // btnCalcola
            // 
            this.btnCalcola.Location = new System.Drawing.Point(25, 368);
            this.btnCalcola.Name = "btnCalcola";
            this.btnCalcola.Size = new System.Drawing.Size(69, 27);
            this.btnCalcola.TabIndex = 13;
            this.btnCalcola.Text = "Calcola";
            this.btnCalcola.UseVisualStyleBackColor = true;
            this.btnCalcola.Click += new System.EventHandler(this.btnCalcola_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 316);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "x min:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "zeri/poli a p.r.positiva:";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(62, 317);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(39, 20);
            this.txtMin.TabIndex = 17;
            this.txtMin.Text = "0,001";
            // 
            // txtZPpositivi
            // 
            this.txtZPpositivi.Location = new System.Drawing.Point(26, 155);
            this.txtZPpositivi.Name = "txtZPpositivi";
            this.txtZPpositivi.Size = new System.Drawing.Size(75, 20);
            this.txtZPpositivi.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 466);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Blu: Grafico originale";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 493);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Verde: Rete corretrice";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 521);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Rosso: Grafico finale";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 27);
            this.button1.TabIndex = 24;
            this.button1.Text = "Salva";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkK);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtZPpositivi);
            this.groupBox1.Controls.Add(this.txtMin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnCalcola);
            this.groupBox1.Controls.Add(this.txtTau);
            this.groupBox1.Controls.Add(this.txtM);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbTipo);
            this.groupBox1.Controls.Add(this.txtZeri);
            this.groupBox1.Controls.Add(this.txtPoli);
            this.groupBox1.Controls.Add(this.txtK);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(784, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 748);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // checkK
            // 
            this.checkK.AutoSize = true;
            this.checkK.Location = new System.Drawing.Point(26, 24);
            this.checkK.Name = "checkK";
            this.checkK.Size = new System.Drawing.Size(84, 17);
            this.checkK.TabIndex = 26;
            this.checkK.Text = "k lineare < 0";
            this.checkK.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Tipo di rete:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pic2);
            this.groupBox2.Controls.Add(this.pic1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 748);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            // 
            // pic2
            // 
            this.pic2.BackColor = System.Drawing.Color.White;
            this.pic2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pic2.Location = new System.Drawing.Point(3, 367);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(778, 378);
            this.pic2.TabIndex = 21;
            this.pic2.TabStop = false;
            // 
            // pic1
            // 
            this.pic1.BackColor = System.Drawing.Color.White;
            this.pic1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pic1.Location = new System.Drawing.Point(3, 16);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(778, 378);
            this.pic1.TabIndex = 2;
            this.pic1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 748);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "BodeTool Version 1.4";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtK;
        private System.Windows.Forms.TextBox txtPoli;
        private System.Windows.Forms.TextBox txtZeri;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtM;
        private System.Windows.Forms.TextBox txtTau;
        private System.Windows.Forms.Button btnCalcola;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtZPpositivi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.CheckBox checkK;
    }
}

