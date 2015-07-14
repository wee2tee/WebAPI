namespace TestAPI
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
            this.btnTestGet = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnTestPost = new System.Windows.Forms.Button();
            this.btnTestPatch = new System.Windows.Forms.Button();
            this.btnTestDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestGet
            // 
            this.btnTestGet.Location = new System.Drawing.Point(16, 15);
            this.btnTestGet.Name = "btnTestGet";
            this.btnTestGet.Size = new System.Drawing.Size(90, 32);
            this.btnTestGet.TabIndex = 0;
            this.btnTestGet.Text = "Test GET";
            this.btnTestGet.UseVisualStyleBackColor = true;
            this.btnTestGet.Click += new System.EventHandler(this.btnTestGet_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 59);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(641, 436);
            this.txtResult.TabIndex = 1;
            // 
            // btnTestPost
            // 
            this.btnTestPost.Location = new System.Drawing.Point(112, 15);
            this.btnTestPost.Name = "btnTestPost";
            this.btnTestPost.Size = new System.Drawing.Size(90, 32);
            this.btnTestPost.TabIndex = 2;
            this.btnTestPost.Text = "Test POST";
            this.btnTestPost.UseVisualStyleBackColor = true;
            this.btnTestPost.Click += new System.EventHandler(this.btnTestPost_Click);
            // 
            // btnTestPatch
            // 
            this.btnTestPatch.Location = new System.Drawing.Point(208, 15);
            this.btnTestPatch.Name = "btnTestPatch";
            this.btnTestPatch.Size = new System.Drawing.Size(90, 32);
            this.btnTestPatch.TabIndex = 3;
            this.btnTestPatch.Text = "Test PATCH";
            this.btnTestPatch.UseVisualStyleBackColor = true;
            this.btnTestPatch.Click += new System.EventHandler(this.btnTestPatch_Click);
            // 
            // btnTestDelete
            // 
            this.btnTestDelete.Location = new System.Drawing.Point(304, 15);
            this.btnTestDelete.Name = "btnTestDelete";
            this.btnTestDelete.Size = new System.Drawing.Size(90, 32);
            this.btnTestDelete.TabIndex = 4;
            this.btnTestDelete.Text = "Test DELETE";
            this.btnTestDelete.UseVisualStyleBackColor = true;
            this.btnTestDelete.Click += new System.EventHandler(this.btnTestDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 507);
            this.Controls.Add(this.btnTestDelete);
            this.Controls.Add(this.btnTestPatch);
            this.Controls.Add(this.btnTestPost);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnTestGet);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestGet;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnTestPost;
        private System.Windows.Forms.Button btnTestPatch;
        private System.Windows.Forms.Button btnTestDelete;
    }
}

