namespace SanGuo
{
    partial class ChangeColor
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
            this.label1 = new System.Windows.Forms.Label();
            this.colorHatch = new SanGuo.Controls.ColorHatch();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(31, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Look at me,I can change my color";
            // 
            // colorHatch
            // 
            this.colorHatch.HatchColor = System.Drawing.Color.Blue;
            this.colorHatch.Location = new System.Drawing.Point(515, 32);
            this.colorHatch.Name = "colorHatch";
            this.colorHatch.Size = new System.Drawing.Size(50, 205);
            this.colorHatch.TabIndex = 1;
            this.colorHatch.ColorChange += new SanGuo.Controls.ColorHatch.ColorChangeEventHandler(this.colorHatch_ColorChange);
            // 
            // ChangeColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 384);
            this.Controls.Add(this.colorHatch);
            this.Controls.Add(this.label1);
            this.Name = "ChangeColor";
            this.Text = "ChangeColor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Controls.ColorHatch colorHatch;
    }
}