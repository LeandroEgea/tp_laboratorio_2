namespace MiCalculadora
{
    partial class Resultado
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
            this.lblResultadoLargo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblResultadoLargo
            // 
            this.lblResultadoLargo.AutoSize = true;
            this.lblResultadoLargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultadoLargo.Location = new System.Drawing.Point(12, 9);
            this.lblResultadoLargo.MaximumSize = new System.Drawing.Size(210, 0);
            this.lblResultadoLargo.Name = "lblResultadoLargo";
            this.lblResultadoLargo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblResultadoLargo.Size = new System.Drawing.Size(15, 16);
            this.lblResultadoLargo.TabIndex = 0;
            this.lblResultadoLargo.Text = "0";
            // 
            // Resultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 90);
            this.Controls.Add(this.lblResultadoLargo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Resultado";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resultado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResultadoLargo;
    }
}