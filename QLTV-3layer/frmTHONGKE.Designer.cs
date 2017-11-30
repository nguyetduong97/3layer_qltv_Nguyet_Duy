namespace QLTV_3layer
{
    partial class frmTHONGKE
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
            this.cRPTHONGKE = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRPTHONGKE
            // 
            this.cRPTHONGKE.ActiveViewIndex = -1;
            this.cRPTHONGKE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRPTHONGKE.Cursor = System.Windows.Forms.Cursors.Default;
            this.cRPTHONGKE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRPTHONGKE.Location = new System.Drawing.Point(0, 0);
            this.cRPTHONGKE.Name = "cRPTHONGKE";
            this.cRPTHONGKE.Size = new System.Drawing.Size(807, 372);
            this.cRPTHONGKE.TabIndex = 0;
            this.cRPTHONGKE.Load += new System.EventHandler(this.cRPTHONGKE_Load);
            // 
            // frmTHONGKE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 372);
            this.Controls.Add(this.cRPTHONGKE);
            this.Name = "frmTHONGKE";
            this.Text = "frmTHONGKE";
            this.Load += new System.EventHandler(this.frmTHONGKE_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRPTHONGKE;
    }
}