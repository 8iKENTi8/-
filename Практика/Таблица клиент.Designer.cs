﻿namespace Практика
{
    partial class Таблица_клиент
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
            this.табКлиент1 = new Практика.ТабКлиент();
            this.SuspendLayout();
            // 
            // табКлиент1
            // 
            this.табКлиент1.Location = new System.Drawing.Point(23, 86);
            this.табКлиент1.Name = "табКлиент1";
            this.табКлиент1.Size = new System.Drawing.Size(754, 450);
            this.табКлиент1.TabIndex = 0;
            // 
            // Таблица_клиент
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.табКлиент1);
            this.Name = "Таблица_клиент";
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "Таблица_клиент";
            this.ResumeLayout(false);

        }

        #endregion

        private ТабКлиент табКлиент1;
    }
}