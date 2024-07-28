namespace CartrigeAltstar.Nomenclatura.History
{
    partial class ListHistoryForms
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
            this.dgHistory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgHistory
            // 
            this.dgHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHistory.Location = new System.Drawing.Point(39, 25);
            this.dgHistory.Name = "dgHistory";
            this.dgHistory.RowHeadersWidth = 51;
            this.dgHistory.RowTemplate.Height = 24;
            this.dgHistory.Size = new System.Drawing.Size(1012, 484);
            this.dgHistory.TabIndex = 0;
            // 
            // ListHistoryForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 627);
            this.Controls.Add(this.dgHistory);
            this.Name = "ListHistoryForms";
            this.Text = "ListHistoryForms";
            ((System.ComponentModel.ISupportInitialize)(this.dgHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgHistory;
    }
}