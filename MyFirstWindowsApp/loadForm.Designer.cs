namespace GeneralMacro
{
    partial class loadForm
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
            this.lbData = new System.Windows.Forms.ListBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbData
            // 
            this.lbData.FormattingEnabled = true;
            this.lbData.Location = new System.Drawing.Point(23, 13);
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(193, 264);
            this.lbData.TabIndex = 0;
            this.lbData.SelectedValueChanged += new System.EventHandler(this.OnListChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Enabled = false;
            this.btnLoad.Location = new System.Drawing.Point(238, 13);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.OnLoadBtnClicked);
            // 
            // loadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 337);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lbData);
            this.Name = "loadForm";
            this.Text = "Load data";
            this.Load += new System.EventHandler(this.OnFormLoaded);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbData;
        private System.Windows.Forms.Button btnLoad;
    }
}