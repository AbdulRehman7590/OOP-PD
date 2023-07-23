
namespace Problem_02
{
    partial class Form1
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
            this.gv1 = new System.Windows.Forms.DataGridView();
            this.Del_btn = new System.Windows.Forms.Button();
            this.Search_btn = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            this.SuspendLayout();
            // 
            // gv1
            // 
            this.gv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv1.Location = new System.Drawing.Point(27, 95);
            this.gv1.Name = "gv1";
            this.gv1.Size = new System.Drawing.Size(460, 223);
            this.gv1.TabIndex = 0;
            // 
            // Del_btn
            // 
            this.Del_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Del_btn.Location = new System.Drawing.Point(27, 343);
            this.Del_btn.Name = "Del_btn";
            this.Del_btn.Size = new System.Drawing.Size(91, 42);
            this.Del_btn.TabIndex = 1;
            this.Del_btn.Text = "Delete";
            this.Del_btn.UseVisualStyleBackColor = false;
            this.Del_btn.Click += new System.EventHandler(this.Del_btn_Click);
            // 
            // Search_btn
            // 
            this.Search_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Search_btn.Location = new System.Drawing.Point(532, 220);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(91, 42);
            this.Search_btn.TabIndex = 2;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = false;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(532, 176);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(159, 20);
            this.txt1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Del_btn);
            this.Controls.Add(this.gv1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gv1;
        private System.Windows.Forms.Button Del_btn;
        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.TextBox txt1;
    }
}

