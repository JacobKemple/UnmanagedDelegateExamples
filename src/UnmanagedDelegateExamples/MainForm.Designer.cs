namespace UnmanagedDelegateExamples
{
    partial class MainForm
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
            this.buttonInitialize = new System.Windows.Forms.Button();
            this.buttonStartUp = new System.Windows.Forms.Button();
            this.buttonShutDown = new System.Windows.Forms.Button();
            this.buttonGetLocationA = new System.Windows.Forms.Button();
            this.buttonGetLocationB = new System.Windows.Forms.Button();
            this.buttonIsValidA = new System.Windows.Forms.Button();
            this.buttonIsValidB = new System.Windows.Forms.Button();
            this.textBoxLocationA = new System.Windows.Forms.TextBox();
            this.textBoxLocationB = new System.Windows.Forms.TextBox();
            this.textBoxIsValidA = new System.Windows.Forms.TextBox();
            this.textBoxIsValidB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonInitialize
            // 
            this.buttonInitialize.Location = new System.Drawing.Point(13, 13);
            this.buttonInitialize.Name = "buttonInitialize";
            this.buttonInitialize.Size = new System.Drawing.Size(259, 23);
            this.buttonInitialize.TabIndex = 0;
            this.buttonInitialize.Text = "Initialize";
            this.buttonInitialize.UseVisualStyleBackColor = true;
            this.buttonInitialize.Click += new System.EventHandler(this.buttonInitialize_Click);
            // 
            // buttonStartUp
            // 
            this.buttonStartUp.Location = new System.Drawing.Point(13, 42);
            this.buttonStartUp.Name = "buttonStartUp";
            this.buttonStartUp.Size = new System.Drawing.Size(259, 23);
            this.buttonStartUp.TabIndex = 1;
            this.buttonStartUp.Text = "Start Up";
            this.buttonStartUp.UseVisualStyleBackColor = true;
            this.buttonStartUp.Click += new System.EventHandler(this.buttonStartUp_Click);
            // 
            // buttonShutDown
            // 
            this.buttonShutDown.Location = new System.Drawing.Point(13, 71);
            this.buttonShutDown.Name = "buttonShutDown";
            this.buttonShutDown.Size = new System.Drawing.Size(259, 23);
            this.buttonShutDown.TabIndex = 2;
            this.buttonShutDown.Text = "Shut down";
            this.buttonShutDown.UseVisualStyleBackColor = true;
            this.buttonShutDown.Click += new System.EventHandler(this.buttonShutDown_Click);
            // 
            // buttonGetLocationA
            // 
            this.buttonGetLocationA.Location = new System.Drawing.Point(13, 131);
            this.buttonGetLocationA.Name = "buttonGetLocationA";
            this.buttonGetLocationA.Size = new System.Drawing.Size(75, 23);
            this.buttonGetLocationA.TabIndex = 3;
            this.buttonGetLocationA.Text = "LocationA";
            this.buttonGetLocationA.UseVisualStyleBackColor = true;
            this.buttonGetLocationA.Click += new System.EventHandler(this.buttonGetLocationA_Click);
            // 
            // buttonGetLocationB
            // 
            this.buttonGetLocationB.Location = new System.Drawing.Point(13, 161);
            this.buttonGetLocationB.Name = "buttonGetLocationB";
            this.buttonGetLocationB.Size = new System.Drawing.Size(75, 23);
            this.buttonGetLocationB.TabIndex = 4;
            this.buttonGetLocationB.Text = "LocationB";
            this.buttonGetLocationB.UseVisualStyleBackColor = true;
            this.buttonGetLocationB.Click += new System.EventHandler(this.buttonGetLocationB_Click);
            // 
            // buttonIsValidA
            // 
            this.buttonIsValidA.Location = new System.Drawing.Point(13, 191);
            this.buttonIsValidA.Name = "buttonIsValidA";
            this.buttonIsValidA.Size = new System.Drawing.Size(75, 23);
            this.buttonIsValidA.TabIndex = 5;
            this.buttonIsValidA.Text = "IsValidA";
            this.buttonIsValidA.UseVisualStyleBackColor = true;
            this.buttonIsValidA.Click += new System.EventHandler(this.buttonIsValidA_Click);
            // 
            // buttonIsValidB
            // 
            this.buttonIsValidB.Location = new System.Drawing.Point(13, 221);
            this.buttonIsValidB.Name = "buttonIsValidB";
            this.buttonIsValidB.Size = new System.Drawing.Size(75, 23);
            this.buttonIsValidB.TabIndex = 6;
            this.buttonIsValidB.Text = "IsValidB";
            this.buttonIsValidB.UseVisualStyleBackColor = true;
            this.buttonIsValidB.Click += new System.EventHandler(this.buttonIsValidB_Click);
            // 
            // textBoxLocationA
            // 
            this.textBoxLocationA.Location = new System.Drawing.Point(95, 131);
            this.textBoxLocationA.Name = "textBoxLocationA";
            this.textBoxLocationA.Size = new System.Drawing.Size(177, 20);
            this.textBoxLocationA.TabIndex = 7;
            // 
            // textBoxLocationB
            // 
            this.textBoxLocationB.Location = new System.Drawing.Point(95, 163);
            this.textBoxLocationB.Name = "textBoxLocationB";
            this.textBoxLocationB.Size = new System.Drawing.Size(177, 20);
            this.textBoxLocationB.TabIndex = 8;
            // 
            // textBoxIsValidA
            // 
            this.textBoxIsValidA.Location = new System.Drawing.Point(95, 193);
            this.textBoxIsValidA.Name = "textBoxIsValidA";
            this.textBoxIsValidA.Size = new System.Drawing.Size(177, 20);
            this.textBoxIsValidA.TabIndex = 9;
            // 
            // textBoxIsValidB
            // 
            this.textBoxIsValidB.Location = new System.Drawing.Point(95, 221);
            this.textBoxIsValidB.Name = "textBoxIsValidB";
            this.textBoxIsValidB.Size = new System.Drawing.Size(177, 20);
            this.textBoxIsValidB.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBoxIsValidB);
            this.Controls.Add(this.textBoxIsValidA);
            this.Controls.Add(this.textBoxLocationB);
            this.Controls.Add(this.textBoxLocationA);
            this.Controls.Add(this.buttonIsValidB);
            this.Controls.Add(this.buttonIsValidA);
            this.Controls.Add(this.buttonGetLocationB);
            this.Controls.Add(this.buttonGetLocationA);
            this.Controls.Add(this.buttonShutDown);
            this.Controls.Add(this.buttonStartUp);
            this.Controls.Add(this.buttonInitialize);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonInitialize;
        private System.Windows.Forms.Button buttonStartUp;
        private System.Windows.Forms.Button buttonShutDown;
        private System.Windows.Forms.Button buttonGetLocationA;
        private System.Windows.Forms.Button buttonGetLocationB;
        private System.Windows.Forms.Button buttonIsValidA;
        private System.Windows.Forms.Button buttonIsValidB;
        private System.Windows.Forms.TextBox textBoxLocationA;
        private System.Windows.Forms.TextBox textBoxLocationB;
        private System.Windows.Forms.TextBox textBoxIsValidA;
        private System.Windows.Forms.TextBox textBoxIsValidB;
    }
}

