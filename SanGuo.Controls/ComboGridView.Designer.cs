namespace SanGuo.Controls
{
    partial class ComboGridView
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gvRoot = new System.Windows.Forms.DataGridView();
            this.cmbChild1 = new System.Windows.Forms.ComboBox();
            this.cmbRoot = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(537, 140);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.Visible = false;
            // 
            // gvRoot
            // 
            this.gvRoot.BackgroundColor = System.Drawing.Color.Silver;
            this.gvRoot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRoot.Dock = System.Windows.Forms.DockStyle.Top;
            this.gvRoot.Location = new System.Drawing.Point(0, 140);
            this.gvRoot.Name = "gvRoot";
            this.gvRoot.RowTemplate.Height = 23;
            this.gvRoot.Size = new System.Drawing.Size(537, 86);
            this.gvRoot.TabIndex = 2;
            // 
            // cmbChild1
            // 
            this.cmbChild1.FormattingEnabled = true;
            this.cmbChild1.Items.AddRange(new object[] {
            "",
            "Address.Street",
            "Office",
            "Address.Door"});
            this.cmbChild1.Location = new System.Drawing.Point(131, 3);
            this.cmbChild1.Name = "cmbChild1";
            this.cmbChild1.Size = new System.Drawing.Size(94, 20);
            this.cmbChild1.TabIndex = 6;
            this.cmbChild1.Visible = false;
            // 
            // cmbRoot
            // 
            this.cmbRoot.FormattingEnabled = true;
            this.cmbRoot.Items.AddRange(new object[] {
            "",
            "Address.Street",
            "Office",
            "Address.Door"});
            this.cmbRoot.Location = new System.Drawing.Point(26, 3);
            this.cmbRoot.Name = "cmbRoot";
            this.cmbRoot.Size = new System.Drawing.Size(99, 20);
            this.cmbRoot.TabIndex = 5;
            this.cmbRoot.SelectionChangeCommitted += new System.EventHandler(this.cmbRoot_SelectionChangeCommitted);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmbChild1);
            this.splitContainer1.Panel1.Controls.Add(this.cmbRoot);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gvRoot);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(537, 328);
            this.splitContainer1.SplitterDistance = 31;
            this.splitContainer1.TabIndex = 8;
            // 
            // ComboGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ComboGridView";
            this.Size = new System.Drawing.Size(537, 328);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRoot)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView gvRoot;
        private System.Windows.Forms.ComboBox cmbChild1;
        private System.Windows.Forms.ComboBox cmbRoot;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
