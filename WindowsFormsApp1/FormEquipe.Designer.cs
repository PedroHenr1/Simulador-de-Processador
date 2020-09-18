namespace WindowsFormsApp1
{
    partial class FormEquipe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEquipe));
            this.pedroNome = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.painelNome = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pedroNome
            // 
            this.pedroNome.BackColor = System.Drawing.Color.Transparent;
            this.pedroNome.FlatAppearance.BorderSize = 0;
            this.pedroNome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pedroNome.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pedroNome.ForeColor = System.Drawing.SystemColors.Window;
            this.pedroNome.Location = new System.Drawing.Point(38, 89);
            this.pedroNome.Name = "pedroNome";
            this.pedroNome.Size = new System.Drawing.Size(225, 76);
            this.pedroNome.TabIndex = 1;
            this.pedroNome.Text = "Pedro Henrique";
            this.pedroNome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pedroNome.UseVisualStyleBackColor = false;
            this.pedroNome.MouseEnter += new System.EventHandler(this.pedroNome_MouseEnter);
            this.pedroNome.MouseLeave += new System.EventHandler(this.pedroNome_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(39, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "EQUIPE";
            // 
            // painelNome
            // 
            this.painelNome.BackColor = System.Drawing.Color.Gold;
            this.painelNome.Location = new System.Drawing.Point(2, 89);
            this.painelNome.Name = "painelNome";
            this.painelNome.Size = new System.Drawing.Size(42, 76);
            this.painelNome.TabIndex = 3;
            // 
            // FormEquipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(266, 263);
            this.Controls.Add(this.painelNome);
            this.Controls.Add(this.pedroNome);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(282, 302);
            this.MinimumSize = new System.Drawing.Size(282, 302);
            this.Name = "FormEquipe";
            this.Text = "Grupo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pedroNome;
        private System.Windows.Forms.Panel painelNome;
    }
}