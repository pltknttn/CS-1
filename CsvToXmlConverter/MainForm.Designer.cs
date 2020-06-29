namespace CsvToXmlConverter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelCSV = new System.Windows.Forms.Panel();
            this.groupBoxCSV = new System.Windows.Forms.GroupBox();
            this.tbInfoCSV = new System.Windows.Forms.TextBox();
            this.panelFileCSV = new System.Windows.Forms.Panel();
            this.buttonOpenFileCsv = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileCsv = new System.Windows.Forms.TextBox();
            this.cbCSV = new System.Windows.Forms.CheckBox();
            this.panelXML = new System.Windows.Forms.Panel();
            this.groupBoxXML = new System.Windows.Forms.GroupBox();
            this.tbInfoXML = new System.Windows.Forms.TextBox();
            this.panelFileXML = new System.Windows.Forms.Panel();
            this.buttonOpenFileXml = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFileXml = new System.Windows.Forms.TextBox();
            this.cbXML = new System.Windows.Forms.CheckBox();
            this.panelConvert = new System.Windows.Forms.Panel();
            this.buttonConvertCsvToXml = new System.Windows.Forms.Button();
            this.buttonConvertXmlToCsv = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelCSV.SuspendLayout();
            this.groupBoxCSV.SuspendLayout();
            this.panelFileCSV.SuspendLayout();
            this.panelXML.SuspendLayout();
            this.groupBoxXML.SuspendLayout();
            this.panelFileXML.SuspendLayout();
            this.panelConvert.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelCSV, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelXML, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelConvert, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(967, 597);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelCSV
            // 
            this.panelCSV.Controls.Add(this.groupBoxCSV);
            this.panelCSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCSV.Location = new System.Drawing.Point(3, 3);
            this.panelCSV.Name = "panelCSV";
            this.panelCSV.Size = new System.Drawing.Size(452, 591);
            this.panelCSV.TabIndex = 0;
            // 
            // groupBoxCSV
            // 
            this.groupBoxCSV.Controls.Add(this.tbInfoCSV);
            this.groupBoxCSV.Controls.Add(this.panelFileCSV);
            this.groupBoxCSV.Controls.Add(this.cbCSV);
            this.groupBoxCSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCSV.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCSV.Name = "groupBoxCSV";
            this.groupBoxCSV.Size = new System.Drawing.Size(452, 591);
            this.groupBoxCSV.TabIndex = 0;
            this.groupBoxCSV.TabStop = false;
            // 
            // tbInfoCSV
            // 
            this.tbInfoCSV.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbInfoCSV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInfoCSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInfoCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbInfoCSV.Location = new System.Drawing.Point(3, 90);
            this.tbInfoCSV.Multiline = true;
            this.tbInfoCSV.Name = "tbInfoCSV";
            this.tbInfoCSV.ReadOnly = true;
            this.tbInfoCSV.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbInfoCSV.Size = new System.Drawing.Size(446, 498);
            this.tbInfoCSV.TabIndex = 3;
            this.tbInfoCSV.Text = "Результаты";
            // 
            // panelFileCSV
            // 
            this.panelFileCSV.Controls.Add(this.buttonOpenFileCsv);
            this.panelFileCSV.Controls.Add(this.label1);
            this.panelFileCSV.Controls.Add(this.tbFileCsv);
            this.panelFileCSV.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFileCSV.Location = new System.Drawing.Point(3, 36);
            this.panelFileCSV.Name = "panelFileCSV";
            this.panelFileCSV.Size = new System.Drawing.Size(446, 54);
            this.panelFileCSV.TabIndex = 6;
            // 
            // buttonOpenFileCsv
            // 
            this.buttonOpenFileCsv.Image = global::CsvToXmlConverter.Properties.Resources.OpenFile;
            this.buttonOpenFileCsv.Location = new System.Drawing.Point(398, 21);
            this.buttonOpenFileCsv.Name = "buttonOpenFileCsv";
            this.buttonOpenFileCsv.Size = new System.Drawing.Size(38, 22);
            this.buttonOpenFileCsv.TabIndex = 2;
            this.buttonOpenFileCsv.UseVisualStyleBackColor = true;
            this.buttonOpenFileCsv.Click += new System.EventHandler(this.buttonOpenFileCsv_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Источник";
            // 
            // tbFileCsv
            // 
            this.tbFileCsv.Location = new System.Drawing.Point(6, 22);
            this.tbFileCsv.Name = "tbFileCsv";
            this.tbFileCsv.Size = new System.Drawing.Size(393, 20);
            this.tbFileCsv.TabIndex = 0;
            this.tbFileCsv.TextChanged += new System.EventHandler(this.tbFileCsv_TextChanged);
            // 
            // cbCSV
            // 
            this.cbCSV.AutoSize = true;
            this.cbCSV.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbCSV.Location = new System.Drawing.Point(3, 16);
            this.cbCSV.Name = "cbCSV";
            this.cbCSV.Size = new System.Drawing.Size(446, 20);
            this.cbCSV.TabIndex = 5;
            this.cbCSV.Text = "CSV";
            this.cbCSV.UseVisualStyleBackColor = true;
            this.cbCSV.CheckedChanged += new System.EventHandler(this.cbCSV_CheckedChanged);
            // 
            // panelXML
            // 
            this.panelXML.Controls.Add(this.groupBoxXML);
            this.panelXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelXML.Location = new System.Drawing.Point(511, 3);
            this.panelXML.Name = "panelXML";
            this.panelXML.Size = new System.Drawing.Size(453, 591);
            this.panelXML.TabIndex = 1;
            // 
            // groupBoxXML
            // 
            this.groupBoxXML.Controls.Add(this.tbInfoXML);
            this.groupBoxXML.Controls.Add(this.panelFileXML);
            this.groupBoxXML.Controls.Add(this.cbXML);
            this.groupBoxXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxXML.Location = new System.Drawing.Point(0, 0);
            this.groupBoxXML.Name = "groupBoxXML";
            this.groupBoxXML.Size = new System.Drawing.Size(453, 591);
            this.groupBoxXML.TabIndex = 0;
            this.groupBoxXML.TabStop = false;
            // 
            // tbInfoXML
            // 
            this.tbInfoXML.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbInfoXML.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInfoXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInfoXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbInfoXML.Location = new System.Drawing.Point(3, 90);
            this.tbInfoXML.Multiline = true;
            this.tbInfoXML.Name = "tbInfoXML";
            this.tbInfoXML.ReadOnly = true;
            this.tbInfoXML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbInfoXML.Size = new System.Drawing.Size(447, 498);
            this.tbInfoXML.TabIndex = 3;
            this.tbInfoXML.Text = "Результаты";
            // 
            // panelFileXML
            // 
            this.panelFileXML.Controls.Add(this.buttonOpenFileXml);
            this.panelFileXML.Controls.Add(this.label2);
            this.panelFileXML.Controls.Add(this.tbFileXml);
            this.panelFileXML.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFileXML.Location = new System.Drawing.Point(3, 36);
            this.panelFileXML.Name = "panelFileXML";
            this.panelFileXML.Size = new System.Drawing.Size(447, 54);
            this.panelFileXML.TabIndex = 5;
            // 
            // buttonOpenFileXml
            // 
            this.buttonOpenFileXml.Image = global::CsvToXmlConverter.Properties.Resources.OpenFile;
            this.buttonOpenFileXml.Location = new System.Drawing.Point(399, 22);
            this.buttonOpenFileXml.Name = "buttonOpenFileXml";
            this.buttonOpenFileXml.Size = new System.Drawing.Size(38, 22);
            this.buttonOpenFileXml.TabIndex = 5;
            this.buttonOpenFileXml.UseVisualStyleBackColor = true;
            this.buttonOpenFileXml.Click += new System.EventHandler(this.buttonOpenFileXml_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Источник";
            // 
            // tbFileXml
            // 
            this.tbFileXml.Location = new System.Drawing.Point(7, 23);
            this.tbFileXml.Name = "tbFileXml";
            this.tbFileXml.Size = new System.Drawing.Size(393, 20);
            this.tbFileXml.TabIndex = 3;
            this.tbFileXml.TextChanged += new System.EventHandler(this.tbFileXml_TextChanged);
            // 
            // cbXML
            // 
            this.cbXML.AutoSize = true;
            this.cbXML.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbXML.Location = new System.Drawing.Point(3, 16);
            this.cbXML.Name = "cbXML";
            this.cbXML.Size = new System.Drawing.Size(447, 20);
            this.cbXML.TabIndex = 4;
            this.cbXML.Text = "XML";
            this.cbXML.UseVisualStyleBackColor = true;
            this.cbXML.CheckedChanged += new System.EventHandler(this.cbXML_CheckedChanged);
            // 
            // panelConvert
            // 
            this.panelConvert.Controls.Add(this.buttonConvertCsvToXml);
            this.panelConvert.Controls.Add(this.buttonConvertXmlToCsv);
            this.panelConvert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConvert.Location = new System.Drawing.Point(461, 3);
            this.panelConvert.Name = "panelConvert";
            this.panelConvert.Size = new System.Drawing.Size(44, 591);
            this.panelConvert.TabIndex = 3;
            // 
            // buttonConvertCsvToXml
            // 
            this.buttonConvertCsvToXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConvertCsvToXml.Location = new System.Drawing.Point(3, 199);
            this.buttonConvertCsvToXml.Name = "buttonConvertCsvToXml";
            this.buttonConvertCsvToXml.Size = new System.Drawing.Size(38, 42);
            this.buttonConvertCsvToXml.TabIndex = 1;
            this.buttonConvertCsvToXml.Text = "=>";
            this.buttonConvertCsvToXml.UseVisualStyleBackColor = true;
            this.buttonConvertCsvToXml.Click += new System.EventHandler(this.buttonConvertCsvToXml_Click);
            // 
            // buttonConvertXmlToCsv
            // 
            this.buttonConvertXmlToCsv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConvertXmlToCsv.Location = new System.Drawing.Point(3, 151);
            this.buttonConvertXmlToCsv.Name = "buttonConvertXmlToCsv";
            this.buttonConvertXmlToCsv.Size = new System.Drawing.Size(38, 42);
            this.buttonConvertXmlToCsv.TabIndex = 0;
            this.buttonConvertXmlToCsv.Text = "<=";
            this.buttonConvertXmlToCsv.UseVisualStyleBackColor = true;
            this.buttonConvertXmlToCsv.Click += new System.EventHandler(this.buttonConvertXmlToCsv_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 597);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конвертер CSV <-> XML";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelCSV.ResumeLayout(false);
            this.groupBoxCSV.ResumeLayout(false);
            this.groupBoxCSV.PerformLayout();
            this.panelFileCSV.ResumeLayout(false);
            this.panelFileCSV.PerformLayout();
            this.panelXML.ResumeLayout(false);
            this.groupBoxXML.ResumeLayout(false);
            this.groupBoxXML.PerformLayout();
            this.panelFileXML.ResumeLayout(false);
            this.panelFileXML.PerformLayout();
            this.panelConvert.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelCSV;
        private System.Windows.Forms.GroupBox groupBoxCSV;
        private System.Windows.Forms.Panel panelXML;
        private System.Windows.Forms.GroupBox groupBoxXML;
        private System.Windows.Forms.TextBox tbInfoCSV;
        private System.Windows.Forms.Panel panelFileCSV;
        private System.Windows.Forms.Button buttonOpenFileCsv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileCsv;
        private System.Windows.Forms.CheckBox cbCSV;
        private System.Windows.Forms.TextBox tbInfoXML;
        private System.Windows.Forms.Panel panelFileXML;
        private System.Windows.Forms.CheckBox cbXML;
        private System.Windows.Forms.Panel panelConvert;
        private System.Windows.Forms.Button buttonConvertCsvToXml;
        private System.Windows.Forms.Button buttonConvertXmlToCsv;
        private System.Windows.Forms.Button buttonOpenFileXml;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFileXml;
    }
}

