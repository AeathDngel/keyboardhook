namespace KeyboardHook
{
    partial class Form2
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
            this.btnMouseControl = new System.Windows.Forms.Button();
            this.txtKeys = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnMouseControl
            // 
            this.btnMouseControl.Location = new System.Drawing.Point(479, 383);
            this.btnMouseControl.Name = "btnMouseControl";
            this.btnMouseControl.Size = new System.Drawing.Size(109, 105);
            this.btnMouseControl.TabIndex = 0;
            this.btnMouseControl.Text = "Allow Mouse Control with Arrow Keys";
            this.btnMouseControl.UseVisualStyleBackColor = true;
            this.btnMouseControl.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtKeys
            // 
            this.txtKeys.Location = new System.Drawing.Point(12, 12);
            this.txtKeys.Multiline = true;
            this.txtKeys.Name = "txtKeys";
            this.txtKeys.Size = new System.Drawing.Size(576, 365);
            this.txtKeys.TabIndex = 1;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.txtKeys);
            this.Controls.Add(this.btnMouseControl);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMouseControl;
        private System.Windows.Forms.TextBox txtKeys;
    }
}