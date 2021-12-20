namespace FreeJPGToPDFConverter
{
    partial class ucJPGToPDFConverter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucJPGToPDFConverter));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDocumentSize = new System.Windows.Forms.ComboBox();
            this.cmbOrientation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMargin = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbImageAlignment = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // cmbDocumentSize
            // 
            this.cmbDocumentSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbDocumentSize, "cmbDocumentSize");
            this.cmbDocumentSize.FormattingEnabled = true;
            this.cmbDocumentSize.Name = "cmbDocumentSize";
            // 
            // cmbOrientation
            // 
            this.cmbOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbOrientation, "cmbOrientation");
            this.cmbOrientation.FormattingEnabled = true;
            this.cmbOrientation.Name = "cmbOrientation";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // cmbMargin
            // 
            this.cmbMargin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbMargin, "cmbMargin");
            this.cmbMargin.FormattingEnabled = true;
            this.cmbMargin.Name = "cmbMargin";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Name = "label3";
            // 
            // cmbImageAlignment
            // 
            this.cmbImageAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbImageAlignment, "cmbImageAlignment");
            this.cmbImageAlignment.FormattingEnabled = true;
            this.cmbImageAlignment.Name = "cmbImageAlignment";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Name = "label4";
            // 
            // ucJPGToPDFConverter
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmbImageAlignment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMargin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbOrientation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDocumentSize);
            this.Controls.Add(this.label1);
            this.Name = "ucJPGToPDFConverter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cmbDocumentSize;
        public System.Windows.Forms.ComboBox cmbOrientation;
        public System.Windows.Forms.ComboBox cmbMargin;
        public System.Windows.Forms.ComboBox cmbImageAlignment;
    }
}
