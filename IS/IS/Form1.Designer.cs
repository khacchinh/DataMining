﻿namespace IS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtOpenFile = new System.Windows.Forms.TextBox();
            this.opneFile = new System.Windows.Forms.Button();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.txtK = new System.Windows.Forms.TextBox();
            this.lvData = new System.Windows.Forms.ListView();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTest = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblClass = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblIns = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOpenFile
            // 
            this.txtOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpenFile.Location = new System.Drawing.Point(15, 15);
            this.txtOpenFile.Multiline = true;
            this.txtOpenFile.Name = "txtOpenFile";
            this.txtOpenFile.Size = new System.Drawing.Size(383, 40);
            this.txtOpenFile.TabIndex = 0;
            // 
            // opneFile
            // 
            this.opneFile.BackColor = System.Drawing.Color.Transparent;
            this.opneFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("opneFile.BackgroundImage")));
            this.opneFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.opneFile.FlatAppearance.BorderSize = 0;
            this.opneFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.opneFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opneFile.Location = new System.Drawing.Point(421, 15);
            this.opneFile.Name = "opneFile";
            this.opneFile.Size = new System.Drawing.Size(51, 40);
            this.opneFile.TabIndex = 1;
            this.opneFile.UseVisualStyleBackColor = false;
            this.opneFile.Click += new System.EventHandler(this.opneFile_Click);
            // 
            // txtTest
            // 
            this.txtTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTest.Location = new System.Drawing.Point(15, 62);
            this.txtTest.Multiline = true;
            this.txtTest.Name = "txtTest";
            this.txtTest.Size = new System.Drawing.Size(459, 36);
            this.txtTest.TabIndex = 2;
            this.txtTest.Text = "Insert data for test here!!";
            this.txtTest.Focus();
            this.txtTest.Enter += txtTest_Enter;
            
            // 
            // txtK
            // 
            this.txtK.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtK.Location = new System.Drawing.Point(148, 106);
            this.txtK.Multiline = true;
            this.txtK.Name = "txtK";
            this.txtK.Size = new System.Drawing.Size(59, 36);
            this.txtK.TabIndex = 3;
            // 
            // lvData
            // 
            this.lvData.Location = new System.Drawing.Point(16, 60);
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(495, 288);
            this.lvData.TabIndex = 4;
            this.lvData.UseCompatibleStateImageBehavior = false;
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(418, 7);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(93, 39);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTest);
            this.panel1.Controls.Add(this.lblResult);
            this.panel1.Controls.Add(this.listView2);
            this.panel1.Location = new System.Drawing.Point(544, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 552);
            this.panel1.TabIndex = 7;
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTest.Location = new System.Drawing.Point(16, 58);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(0, 27);
            this.lblTest.TabIndex = 7;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(16, 15);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(156, 27);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Class of test is:";
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(3, 158);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(423, 391);
            this.listView2.TabIndex = 6;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblClass);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtOpenFile);
            this.panel2.Controls.Add(this.txtTest);
            this.panel2.Controls.Add(this.opneFile);
            this.panel2.Controls.Add(this.txtK);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(526, 195);
            this.panel2.TabIndex = 8;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(16, 158);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(111, 29);
            this.lblClass.TabIndex = 5;
            this.lblClass.Text = "Classes: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Choose K:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblIns);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lvData);
            this.panel3.Controls.Add(this.btnStart);
            this.panel3.Location = new System.Drawing.Point(12, 213);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(526, 351);
            this.panel3.TabIndex = 9;
            // 
            // lblIns
            // 
            this.lblIns.AutoSize = true;
            this.lblIns.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIns.Location = new System.Drawing.Point(72, 24);
            this.lblIns.Name = "lblIns";
            this.lblIns.Size = new System.Drawing.Size(85, 22);
            this.lblIns.TabIndex = 6;
            this.lblIns.Text = "Instance: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Data - ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 576);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        void txtTest_Enter(object sender, System.EventArgs e)
        {
            this.txtTest.Text = "";
        }

        

        #endregion

        private System.Windows.Forms.TextBox txtOpenFile;
        private System.Windows.Forms.Button opneFile;
        private System.Windows.Forms.TextBox txtTest;
        private System.Windows.Forms.TextBox txtK;
        private System.Windows.Forms.ListView lvData;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblIns;
    }
}

