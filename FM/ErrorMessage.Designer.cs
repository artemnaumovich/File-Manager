namespace FM
{
    partial class ErrorMessage
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
            this.labelTextError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTextError
            // 
            this.labelTextError.AutoSize = true;
            this.labelTextError.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTextError.Location = new System.Drawing.Point(129, 56);
            this.labelTextError.Name = "labelTextError";
            this.labelTextError.Size = new System.Drawing.Size(60, 26);
            this.labelTextError.TabIndex = 0;
            this.labelTextError.Text = "Error";
            // 
            // ErrorMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 134);
            this.Controls.Add(this.labelTextError);
            this.Name = "ErrorMessage";
            this.Text = "ErrorMessage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTextError;
    }
}