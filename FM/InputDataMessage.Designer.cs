namespace FM
{
    partial class InputDataMessage
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
            this.labelQusetionText = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelQusetionText
            // 
            this.labelQusetionText.AutoSize = true;
            this.labelQusetionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelQusetionText.Location = new System.Drawing.Point(97, 104);
            this.labelQusetionText.Name = "labelQusetionText";
            this.labelQusetionText.Size = new System.Drawing.Size(128, 29);
            this.labelQusetionText.TabIndex = 0;
            this.labelQusetionText.Text = "Question?";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(124, 195);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(323, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1_KeyPress);
            // 
            // InputDataMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 363);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelQusetionText);
            this.Name = "InputDataMessage";
            this.Text = "InputData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQusetionText;
        private System.Windows.Forms.TextBox textBox1;
    }
}