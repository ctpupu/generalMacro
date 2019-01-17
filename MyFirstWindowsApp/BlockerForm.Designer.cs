namespace GeneralMacro
{
    partial class BlockerForm
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
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbMsg
            // 
            this.tbMsg.BackColor = System.Drawing.SystemColors.Control;
            this.tbMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMsg.ForeColor = System.Drawing.Color.Red;
            this.tbMsg.Location = new System.Drawing.Point(12, 12);
            this.tbMsg.Multiline = true;
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.ReadOnly = true;
            this.tbMsg.Size = new System.Drawing.Size(502, 209);
            this.tbMsg.TabIndex = 1;
            this.tbMsg.Text = "Message";
            this.tbMsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BlockerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 233);
            this.Controls.Add(this.tbMsg);
            this.Name = "BlockerForm";
            this.Text = "Action Required!";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMsg;
    }
}