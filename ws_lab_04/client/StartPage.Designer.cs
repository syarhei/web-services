namespace client {
    partial class StartPage {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.getSum = new System.Windows.Forms.Button();
            this.x = new System.Windows.Forms.TextBox();
            this.y = new System.Windows.Forms.TextBox();
            this.result = new System.Windows.Forms.TextBox();
            this.getSumByProxy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // getSum
            // 
            this.getSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.getSum.Location = new System.Drawing.Point(222, 32);
            this.getSum.Name = "getSum";
            this.getSum.Size = new System.Drawing.Size(148, 96);
            this.getSum.TabIndex = 0;
            this.getSum.Text = "ref";
            this.getSum.UseVisualStyleBackColor = true;
            this.getSum.Click += new System.EventHandler(this.getSum_Click);
            // 
            // x
            // 
            this.x.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.x.Location = new System.Drawing.Point(29, 32);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(155, 36);
            this.x.TabIndex = 1;
            // 
            // y
            // 
            this.y.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.y.Location = new System.Drawing.Point(29, 92);
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(155, 36);
            this.y.TabIndex = 2;
            // 
            // result
            // 
            this.result.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.result.Location = new System.Drawing.Point(562, 58);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(155, 36);
            this.result.TabIndex = 3;
            // 
            // getSumByProxy
            // 
            this.getSumByProxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.getSumByProxy.Location = new System.Drawing.Point(389, 32);
            this.getSumByProxy.Name = "getSumByProxy";
            this.getSumByProxy.Size = new System.Drawing.Size(148, 96);
            this.getSumByProxy.TabIndex = 4;
            this.getSumByProxy.Text = "proxy";
            this.getSumByProxy.UseVisualStyleBackColor = true;
            this.getSumByProxy.Click += new System.EventHandler(this.getSumByProxy_Click);
            // 
            // StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 152);
            this.Controls.Add(this.getSumByProxy);
            this.Controls.Add(this.result);
            this.Controls.Add(this.y);
            this.Controls.Add(this.x);
            this.Controls.Add(this.getSum);
            this.Name = "StartPage";
            this.Text = "Welcome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getSum;
        private System.Windows.Forms.TextBox x;
        private System.Windows.Forms.TextBox y;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Button getSumByProxy;
    }
}

