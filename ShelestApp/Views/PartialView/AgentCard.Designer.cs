namespace ShelestApp.Views.PartialView
{
    partial class AgentCard
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.titleTypeLbl = new System.Windows.Forms.Label();
            this.salesQtyLbl = new System.Windows.Forms.Label();
            this.phoneLbl = new System.Windows.Forms.Label();
            this.priorityLbl = new System.Windows.Forms.Label();
            this.discountLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = global::ShelestApp.Properties.Resources.picture;
            this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(192, 170);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // titleTypeLbl
            // 
            this.titleTypeLbl.AutoSize = true;
            this.titleTypeLbl.Font = new System.Drawing.Font("Monotype Corsiva", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.titleTypeLbl.Location = new System.Drawing.Point(201, 21);
            this.titleTypeLbl.Name = "titleTypeLbl";
            this.titleTypeLbl.Size = new System.Drawing.Size(357, 36);
            this.titleTypeLbl.TabIndex = 1;
            this.titleTypeLbl.Text = "Тип | Наименование агента";
            // 
            // salesQtyLbl
            // 
            this.salesQtyLbl.AutoSize = true;
            this.salesQtyLbl.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.salesQtyLbl.Location = new System.Drawing.Point(201, 57);
            this.salesQtyLbl.Name = "salesQtyLbl";
            this.salesQtyLbl.Size = new System.Drawing.Size(184, 33);
            this.salesQtyLbl.TabIndex = 1;
            this.salesQtyLbl.Text = "10 продаж за год";
            // 
            // phoneLbl
            // 
            this.phoneLbl.AutoSize = true;
            this.phoneLbl.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phoneLbl.Location = new System.Drawing.Point(201, 90);
            this.phoneLbl.Name = "phoneLbl";
            this.phoneLbl.Size = new System.Drawing.Size(185, 33);
            this.phoneLbl.TabIndex = 1;
            this.phoneLbl.Text = "+7 111 111 11 11";
            // 
            // priorityLbl
            // 
            this.priorityLbl.AutoSize = true;
            this.priorityLbl.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priorityLbl.Location = new System.Drawing.Point(200, 119);
            this.priorityLbl.Name = "priorityLbl";
            this.priorityLbl.Size = new System.Drawing.Size(232, 33);
            this.priorityLbl.TabIndex = 1;
            this.priorityLbl.Text = "Приоритетность: 10";
            // 
            // discountLbl
            // 
            this.discountLbl.AutoSize = true;
            this.discountLbl.Font = new System.Drawing.Font("Monotype Corsiva", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.discountLbl.Location = new System.Drawing.Point(974, 21);
            this.discountLbl.Name = "discountLbl";
            this.discountLbl.Size = new System.Drawing.Size(61, 36);
            this.discountLbl.TabIndex = 1;
            this.discountLbl.Text = "10%";
            // 
            // AgentCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.discountLbl);
            this.Controls.Add(this.priorityLbl);
            this.Controls.Add(this.phoneLbl);
            this.Controls.Add(this.salesQtyLbl);
            this.Controls.Add(this.titleTypeLbl);
            this.Controls.Add(this.logoPictureBox);
            this.Name = "AgentCard";
            this.Size = new System.Drawing.Size(1051, 176);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label titleTypeLbl;
        private System.Windows.Forms.Label salesQtyLbl;
        private System.Windows.Forms.Label phoneLbl;
        private System.Windows.Forms.Label priorityLbl;
        private System.Windows.Forms.Label discountLbl;
    }
}
