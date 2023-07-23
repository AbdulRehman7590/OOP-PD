
namespace _1st_App_Desktop
{
    partial class MyForm
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
            this.value = new System.Windows.Forms.Label();
            this.value2 = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            this.v1 = new System.Windows.Forms.TextBox();
            this.v2 = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.Subtract = new System.Windows.Forms.Button();
            this.Multiply = new System.Windows.Forms.Button();
            this.Division = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // value
            // 
            this.value.AutoSize = true;
            this.value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.value.Location = new System.Drawing.Point(50, 48);
            this.value.Name = "value";
            this.value.Size = new System.Drawing.Size(115, 20);
            this.value.TabIndex = 0;
            this.value.Text = "Enter 1st value";
            // 
            // value2
            // 
            this.value2.AutoSize = true;
            this.value2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.value2.Location = new System.Drawing.Point(50, 115);
            this.value2.Name = "value2";
            this.value2.Size = new System.Drawing.Size(120, 20);
            this.value2.TabIndex = 1;
            this.value2.Text = "Enter 2nd value";
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.Location = new System.Drawing.Point(49, 199);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(77, 25);
            this.resultLabel.TabIndex = 2;
            this.resultLabel.Text = "Result :";
            // 
            // v1
            // 
            this.v1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.v1.Location = new System.Drawing.Point(54, 72);
            this.v1.Name = "v1";
            this.v1.Size = new System.Drawing.Size(145, 26);
            this.v1.TabIndex = 3;
            this.v1.Text = "0";
            // 
            // v2
            // 
            this.v2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.v2.Location = new System.Drawing.Point(54, 138);
            this.v2.Name = "v2";
            this.v2.Size = new System.Drawing.Size(146, 26);
            this.v2.TabIndex = 4;
            this.v2.Text = "0";
            this.v2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.Location = new System.Drawing.Point(246, 65);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 44);
            this.Add.TabIndex = 5;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Subtract
            // 
            this.Subtract.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Subtract.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subtract.Location = new System.Drawing.Point(349, 65);
            this.Subtract.Name = "Subtract";
            this.Subtract.Size = new System.Drawing.Size(75, 44);
            this.Subtract.TabIndex = 6;
            this.Subtract.Text = "Subtract";
            this.Subtract.UseVisualStyleBackColor = false;
            this.Subtract.Click += new System.EventHandler(this.Subtract_Click);
            // 
            // Multiply
            // 
            this.Multiply.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Multiply.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Multiply.Location = new System.Drawing.Point(246, 130);
            this.Multiply.Name = "Multiply";
            this.Multiply.Size = new System.Drawing.Size(75, 44);
            this.Multiply.TabIndex = 7;
            this.Multiply.Text = "Multiply";
            this.Multiply.UseVisualStyleBackColor = false;
            this.Multiply.Click += new System.EventHandler(this.Multiply_Click);
            // 
            // Division
            // 
            this.Division.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Division.Location = new System.Drawing.Point(349, 130);
            this.Division.Name = "Division";
            this.Division.Size = new System.Drawing.Size(75, 44);
            this.Division.TabIndex = 8;
            this.Division.Text = "Divide";
            this.Division.UseVisualStyleBackColor = true;
            this.Division.Click += new System.EventHandler(this.Division_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Division);
            this.Controls.Add(this.Multiply);
            this.Controls.Add(this.Subtract);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.v2);
            this.Controls.Add(this.v1);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.value2);
            this.Controls.Add(this.value);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label value;
        private System.Windows.Forms.Label value2;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.TextBox v1;
        private System.Windows.Forms.TextBox v2;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Subtract;
        private System.Windows.Forms.Button Multiply;
        private System.Windows.Forms.Button Division;
    }
}

