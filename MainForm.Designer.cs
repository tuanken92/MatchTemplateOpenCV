
namespace MatchTemplateOpenCV
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
            this.lbFileSource = new System.Windows.Forms.Label();
            this.lbFileTemplate = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnLoadTemplate = new System.Windows.Forms.Button();
            this.btnLoadSource = new System.Windows.Forms.Button();
            this.listLog = new System.Windows.Forms.ListBox();
            this.cbbTemplateMatchModes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lbFileSource
            // 
            this.lbFileSource.AutoSize = true;
            this.lbFileSource.Location = new System.Drawing.Point(124, 27);
            this.lbFileSource.Name = "lbFileSource";
            this.lbFileSource.Size = new System.Drawing.Size(60, 13);
            this.lbFileSource.TabIndex = 1;
            this.lbFileSource.Text = "File Source";
            // 
            // lbFileTemplate
            // 
            this.lbFileTemplate.AutoSize = true;
            this.lbFileTemplate.Location = new System.Drawing.Point(124, 64);
            this.lbFileTemplate.Name = "lbFileTemplate";
            this.lbFileTemplate.Size = new System.Drawing.Size(70, 13);
            this.lbFileTemplate.TabIndex = 1;
            this.lbFileTemplate.Text = "File Template";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(423, 138);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(317, 303);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // btnTest
            // 
            this.btnTest.Image = global::MatchTemplateOpenCV.Properties.Resources.edit;
            this.btnTest.Location = new System.Drawing.Point(127, 92);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(101, 31);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test";
            this.btnTest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Image = global::MatchTemplateOpenCV.Properties.Resources.search;
            this.btnProcess.Location = new System.Drawing.Point(17, 92);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(101, 31);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Find Template";
            this.btnProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnLoadTemplate
            // 
            this.btnLoadTemplate.Image = global::MatchTemplateOpenCV.Properties.Resources.folder;
            this.btnLoadTemplate.Location = new System.Drawing.Point(17, 55);
            this.btnLoadTemplate.Name = "btnLoadTemplate";
            this.btnLoadTemplate.Size = new System.Drawing.Size(101, 31);
            this.btnLoadTemplate.TabIndex = 0;
            this.btnLoadTemplate.Text = "Template";
            this.btnLoadTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadTemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadTemplate.UseVisualStyleBackColor = true;
            this.btnLoadTemplate.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnLoadSource
            // 
            this.btnLoadSource.Image = global::MatchTemplateOpenCV.Properties.Resources.folder;
            this.btnLoadSource.Location = new System.Drawing.Point(17, 18);
            this.btnLoadSource.Name = "btnLoadSource";
            this.btnLoadSource.Size = new System.Drawing.Size(101, 31);
            this.btnLoadSource.TabIndex = 0;
            this.btnLoadSource.Text = "Source";
            this.btnLoadSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadSource.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadSource.UseVisualStyleBackColor = true;
            this.btnLoadSource.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // listLog
            // 
            this.listLog.FormattingEnabled = true;
            this.listLog.HorizontalScrollbar = true;
            this.listLog.Location = new System.Drawing.Point(17, 138);
            this.listLog.Name = "listLog";
            this.listLog.Size = new System.Drawing.Size(400, 303);
            this.listLog.TabIndex = 4;
            // 
            // cbbTemplateMatchModes
            // 
            this.cbbTemplateMatchModes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTemplateMatchModes.FormattingEnabled = true;
            this.cbbTemplateMatchModes.Location = new System.Drawing.Point(234, 95);
            this.cbbTemplateMatchModes.Name = "cbbTemplateMatchModes";
            this.cbbTemplateMatchModes.Size = new System.Drawing.Size(183, 24);
            this.cbbTemplateMatchModes.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 447);
            this.Controls.Add(this.cbbTemplateMatchModes);
            this.Controls.Add(this.listLog);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.lbFileTemplate);
            this.Controls.Add(this.lbFileSource);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnLoadTemplate);
            this.Controls.Add(this.btnLoadSource);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadSource;
        private System.Windows.Forms.Label lbFileSource;
        private System.Windows.Forms.Button btnLoadTemplate;
        private System.Windows.Forms.Label lbFileTemplate;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ListBox listLog;
        private System.Windows.Forms.ComboBox cbbTemplateMatchModes;
    }
}

