using System.Windows.Forms;

namespace TinyTimer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.NotifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerDisplay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NotifyIcon1
            // 
            this.NotifyIcon1.Icon = this.Icon;
            this.NotifyIcon1.Text = "TinyTimer";
            this.NotifyIcon1.Visible = true;
            this.NotifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // timerDisplay
            // 
            this.timerDisplay.AutoSize = true;
            this.timerDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerDisplay.Location = new System.Drawing.Point(3, 3);
            this.timerDisplay.Margin = new System.Windows.Forms.Padding(3);
            this.timerDisplay.Name = "timerDisplay";
            this.timerDisplay.Size = new System.Drawing.Size(151, 39);
            this.timerDisplay.TabIndex = 1;
            this.timerDisplay.Text = "00:00:00";
            this.timerDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseDown);
            this.timerDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseMove);
            this.timerDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseUp);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(158, 46);
            this.ControlBox = false;
            this.Controls.Add(this.timerDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NotifyIcon NotifyIcon1;
        private Label timerDisplay;
    }
}

