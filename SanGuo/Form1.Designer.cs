namespace SanGuo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSch = new System.Windows.Forms.Button();
            this.gvMain = new System.Windows.Forms.DataGridView();
            this.treeview1 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSch
            // 
            this.btnSch.Location = new System.Drawing.Point(211, 469);
            this.btnSch.Name = "btnSch";
            this.btnSch.Size = new System.Drawing.Size(75, 23);
            this.btnSch.TabIndex = 0;
            this.btnSch.Text = "查询";
            this.btnSch.UseVisualStyleBackColor = true;
            this.btnSch.Click += new System.EventHandler(this.btnSch_Click);
            // 
            // gvMain
            // 
            this.gvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMain.Location = new System.Drawing.Point(238, 47);
            this.gvMain.Name = "gvMain";
            this.gvMain.RowTemplate.Height = 23;
            this.gvMain.Size = new System.Drawing.Size(500, 416);
            this.gvMain.TabIndex = 1;
            // 
            // treeview1
            // 
            this.treeview1.Location = new System.Drawing.Point(12, 47);
            this.treeview1.Name = "treeview1";
            this.treeview1.Size = new System.Drawing.Size(220, 416);
            this.treeview1.TabIndex = 2;
            this.treeview1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeview1_AfterSelect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.treeview1);
            this.Controls.Add(this.gvMain);
            this.Controls.Add(this.btnSch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSch;
        private System.Windows.Forms.DataGridView gvMain;
        private System.Windows.Forms.TreeView treeview1;
    }
}

