namespace FileCompareTool
{
    partial class DifferenceListForm
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
            this.LB_DifferenceList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LB_DifferenceList
            // 
            this.LB_DifferenceList.FormattingEnabled = true;
            this.LB_DifferenceList.Location = new System.Drawing.Point(8, 31);
            this.LB_DifferenceList.Name = "LB_DifferenceList";
            this.LB_DifferenceList.Size = new System.Drawing.Size(814, 667);
            this.LB_DifferenceList.TabIndex = 0;
            // 
            // DifferenceListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 706);
            this.Controls.Add(this.LB_DifferenceList);
            this.Name = "DifferenceListForm";
            this.Text = "DifferenceListForm";
            this.Load += new System.EventHandler(this.DifferenceListForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LB_DifferenceList;
    }
}