namespace AZV3._0
{
    partial class Arbeitszeit
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
            this.KommenZeitTB = new System.Windows.Forms.MaskedTextBox();
            this.lbkommen = new System.Windows.Forms.Label();
            this.lbgehen = new System.Windows.Forms.Label();
            this.gehenZeitTB = new System.Windows.Forms.MaskedTextBox();
            this.btExit = new System.Windows.Forms.Button();
            this.btGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbVAZ = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // KommenZeitTB
            // 
            this.KommenZeitTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KommenZeitTB.Location = new System.Drawing.Point(45, 41);
            this.KommenZeitTB.Mask = "0:00";
            this.KommenZeitTB.Name = "KommenZeitTB";
            this.KommenZeitTB.Size = new System.Drawing.Size(65, 30);
            this.KommenZeitTB.TabIndex = 1;
            this.KommenZeitTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KommenZeitTB_KeyDown);
            // 
            // lbkommen
            // 
            this.lbkommen.AutoSize = true;
            this.lbkommen.Location = new System.Drawing.Point(42, 18);
            this.lbkommen.Name = "lbkommen";
            this.lbkommen.Size = new System.Drawing.Size(63, 17);
            this.lbkommen.TabIndex = 4;
            this.lbkommen.Text = "Kommen";
            // 
            // lbgehen
            // 
            this.lbgehen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbgehen.AutoSize = true;
            this.lbgehen.Location = new System.Drawing.Point(177, 18);
            this.lbgehen.Name = "lbgehen";
            this.lbgehen.Size = new System.Drawing.Size(51, 17);
            this.lbgehen.TabIndex = 5;
            this.lbgehen.Text = "Gehen";
            // 
            // gehenZeitTB
            // 
            this.gehenZeitTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gehenZeitTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gehenZeitTB.Location = new System.Drawing.Point(180, 41);
            this.gehenZeitTB.Mask = "90:00";
            this.gehenZeitTB.Name = "gehenZeitTB";
            this.gehenZeitTB.Size = new System.Drawing.Size(65, 30);
            this.gehenZeitTB.TabIndex = 6;
            this.gehenZeitTB.TabStop = false;
            this.gehenZeitTB.ValidatingType = typeof(System.DateTime);
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.Location = new System.Drawing.Point(12, 157);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(253, 44);
            this.btExit.TabIndex = 3;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btGo
            // 
            this.btGo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btGo.Location = new System.Drawing.Point(12, 107);
            this.btGo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.btGo.Name = "btGo";
            this.btGo.Size = new System.Drawing.Size(253, 44);
            this.btGo.TabIndex = 2;
            this.btGo.Text = "GO!";
            this.btGo.UseVisualStyleBackColor = true;
            this.btGo.Click += new System.EventHandler(this.btGo_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Verbleibende AZ:";
            // 
            // lbVAZ
            // 
            this.lbVAZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbVAZ.AutoSize = true;
            this.lbVAZ.Location = new System.Drawing.Point(146, 84);
            this.lbVAZ.Name = "lbVAZ";
            this.lbVAZ.Size = new System.Drawing.Size(0, 17);
            this.lbVAZ.TabIndex = 8;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 207);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(253, 23);
            this.progressBar.TabIndex = 9;
            // 
            // Arbeitszeit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 241);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lbVAZ);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btGo);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.gehenZeitTB);
            this.Controls.Add(this.lbgehen);
            this.Controls.Add(this.lbkommen);
            this.Controls.Add(this.KommenZeitTB);
            this.Name = "Arbeitszeit";
            this.Text = "Arbeitszeit";
            this.Load += new System.EventHandler(this.Arbeitszeit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox KommenZeitTB;
        private System.Windows.Forms.Label lbkommen;
        private System.Windows.Forms.Label lbgehen;
        private System.Windows.Forms.MaskedTextBox gehenZeitTB;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbVAZ;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

