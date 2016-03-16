namespace Peon.Forms
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
            System.Windows.Forms.Label labelGeocodeAddress;
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeocode = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelGeocode = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxGeocodeAddress = new System.Windows.Forms.TextBox();
            this.buttonGeocodeDecode = new System.Windows.Forms.Button();
            this.propertyGridGeocode = new System.Windows.Forms.PropertyGrid();
            this.tabPageMap = new System.Windows.Forms.TabPage();
            this.pictureBoxMap = new System.Windows.Forms.PictureBox();
            this.backgroundWorkerGeocode = new System.ComponentModel.BackgroundWorker();
            this.splitContainerMap = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanelMap = new System.Windows.Forms.TableLayoutPanel();
            this.buttonGenerateMap = new System.Windows.Forms.Button();
            this.propertyGridMap = new System.Windows.Forms.PropertyGrid();
            labelGeocodeAddress = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPageGeocode.SuspendLayout();
            this.tableLayoutPanelGeocode.SuspendLayout();
            this.tabPageMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMap)).BeginInit();
            this.splitContainerMap.Panel1.SuspendLayout();
            this.splitContainerMap.Panel2.SuspendLayout();
            this.splitContainerMap.SuspendLayout();
            this.tableLayoutPanelMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelGeocodeAddress
            // 
            labelGeocodeAddress.Anchor = System.Windows.Forms.AnchorStyles.Right;
            labelGeocodeAddress.AutoSize = true;
            labelGeocodeAddress.Location = new System.Drawing.Point(3, 6);
            labelGeocodeAddress.Name = "labelGeocodeAddress";
            labelGeocodeAddress.Size = new System.Drawing.Size(45, 13);
            labelGeocodeAddress.TabIndex = 0;
            labelGeocodeAddress.Text = "Address";
            // 
            // menuStrip
            // 
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(595, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageGeocode);
            this.tabControl.Controls.Add(this.tabPageMap);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(595, 572);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageGeocode
            // 
            this.tabPageGeocode.Controls.Add(this.tableLayoutPanelGeocode);
            this.tabPageGeocode.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeocode.Name = "tabPageGeocode";
            this.tabPageGeocode.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeocode.Size = new System.Drawing.Size(587, 546);
            this.tabPageGeocode.TabIndex = 0;
            this.tabPageGeocode.Text = "Geocode";
            this.tabPageGeocode.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelGeocode
            // 
            this.tableLayoutPanelGeocode.ColumnCount = 2;
            this.tableLayoutPanelGeocode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelGeocode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGeocode.Controls.Add(labelGeocodeAddress, 0, 0);
            this.tableLayoutPanelGeocode.Controls.Add(this.textBoxGeocodeAddress, 1, 0);
            this.tableLayoutPanelGeocode.Controls.Add(this.buttonGeocodeDecode, 1, 1);
            this.tableLayoutPanelGeocode.Controls.Add(this.propertyGridGeocode, 0, 2);
            this.tableLayoutPanelGeocode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGeocode.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelGeocode.Name = "tableLayoutPanelGeocode";
            this.tableLayoutPanelGeocode.RowCount = 3;
            this.tableLayoutPanelGeocode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeocode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelGeocode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGeocode.Size = new System.Drawing.Size(581, 540);
            this.tableLayoutPanelGeocode.TabIndex = 0;
            // 
            // textBoxGeocodeAddress
            // 
            this.textBoxGeocodeAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGeocodeAddress.Location = new System.Drawing.Point(54, 3);
            this.textBoxGeocodeAddress.Name = "textBoxGeocodeAddress";
            this.textBoxGeocodeAddress.Size = new System.Drawing.Size(524, 20);
            this.textBoxGeocodeAddress.TabIndex = 1;
            this.textBoxGeocodeAddress.Text = "LE29HU";
            // 
            // buttonGeocodeDecode
            // 
            this.buttonGeocodeDecode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonGeocodeDecode.Location = new System.Drawing.Point(503, 29);
            this.buttonGeocodeDecode.Name = "buttonGeocodeDecode";
            this.buttonGeocodeDecode.Size = new System.Drawing.Size(75, 23);
            this.buttonGeocodeDecode.TabIndex = 2;
            this.buttonGeocodeDecode.Text = "Decode";
            this.buttonGeocodeDecode.UseVisualStyleBackColor = true;
            this.buttonGeocodeDecode.Click += new System.EventHandler(this.buttonGeocodeDecode_Click);
            // 
            // propertyGridGeocode
            // 
            this.tableLayoutPanelGeocode.SetColumnSpan(this.propertyGridGeocode, 2);
            this.propertyGridGeocode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridGeocode.Location = new System.Drawing.Point(3, 58);
            this.propertyGridGeocode.Name = "propertyGridGeocode";
            this.propertyGridGeocode.Size = new System.Drawing.Size(575, 479);
            this.propertyGridGeocode.TabIndex = 3;
            // 
            // tabPageMap
            // 
            this.tabPageMap.Controls.Add(this.splitContainerMap);
            this.tabPageMap.Location = new System.Drawing.Point(4, 22);
            this.tabPageMap.Name = "tabPageMap";
            this.tabPageMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMap.Size = new System.Drawing.Size(587, 546);
            this.tabPageMap.TabIndex = 1;
            this.tabPageMap.Text = "Map";
            this.tabPageMap.UseVisualStyleBackColor = true;
            // 
            // pictureBoxMap
            // 
            this.pictureBoxMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMap.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMap.Name = "pictureBoxMap";
            this.pictureBoxMap.Size = new System.Drawing.Size(379, 540);
            this.pictureBoxMap.TabIndex = 0;
            this.pictureBoxMap.TabStop = false;
            this.pictureBoxMap.SizeChanged += new System.EventHandler(this.pictureBoxMap_SizeChanged);
            // 
            // backgroundWorkerGeocode
            // 
            this.backgroundWorkerGeocode.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerGeocode_DoWork);
            this.backgroundWorkerGeocode.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerGeocode_RunWorkerCompleted);
            // 
            // splitContainerMap
            // 
            this.splitContainerMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMap.Location = new System.Drawing.Point(3, 3);
            this.splitContainerMap.Name = "splitContainerMap";
            // 
            // splitContainerMap.Panel1
            // 
            this.splitContainerMap.Panel1.Controls.Add(this.pictureBoxMap);
            // 
            // splitContainerMap.Panel2
            // 
            this.splitContainerMap.Panel2.Controls.Add(this.tableLayoutPanelMap);
            this.splitContainerMap.Size = new System.Drawing.Size(581, 540);
            this.splitContainerMap.SplitterDistance = 379;
            this.splitContainerMap.TabIndex = 1;
            // 
            // tableLayoutPanelMap
            // 
            this.tableLayoutPanelMap.ColumnCount = 1;
            this.tableLayoutPanelMap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMap.Controls.Add(this.buttonGenerateMap, 0, 1);
            this.tableLayoutPanelMap.Controls.Add(this.propertyGridMap, 0, 0);
            this.tableLayoutPanelMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMap.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMap.Name = "tableLayoutPanelMap";
            this.tableLayoutPanelMap.RowCount = 2;
            this.tableLayoutPanelMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMap.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMap.Size = new System.Drawing.Size(198, 540);
            this.tableLayoutPanelMap.TabIndex = 0;
            // 
            // buttonGenerateMap
            // 
            this.buttonGenerateMap.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonGenerateMap.Location = new System.Drawing.Point(120, 514);
            this.buttonGenerateMap.Name = "buttonGenerateMap";
            this.buttonGenerateMap.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerateMap.TabIndex = 0;
            this.buttonGenerateMap.Text = "Generate";
            this.buttonGenerateMap.UseVisualStyleBackColor = true;
            this.buttonGenerateMap.Click += new System.EventHandler(this.buttonGenerateMap_Click);
            // 
            // propertyGridMap
            // 
            this.propertyGridMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridMap.Location = new System.Drawing.Point(3, 3);
            this.propertyGridMap.Name = "propertyGridMap";
            this.propertyGridMap.Size = new System.Drawing.Size(192, 505);
            this.propertyGridMap.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 596);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Peon Dev Test";
            this.tabControl.ResumeLayout(false);
            this.tabPageGeocode.ResumeLayout(false);
            this.tableLayoutPanelGeocode.ResumeLayout(false);
            this.tableLayoutPanelGeocode.PerformLayout();
            this.tabPageMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).EndInit();
            this.splitContainerMap.Panel1.ResumeLayout(false);
            this.splitContainerMap.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMap)).EndInit();
            this.splitContainerMap.ResumeLayout(false);
            this.tableLayoutPanelMap.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageGeocode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGeocode;
        private System.Windows.Forms.TextBox textBoxGeocodeAddress;
        private System.Windows.Forms.Button buttonGeocodeDecode;
        private System.Windows.Forms.PropertyGrid propertyGridGeocode;
        private System.ComponentModel.BackgroundWorker backgroundWorkerGeocode;
        private System.Windows.Forms.TabPage tabPageMap;
        private System.Windows.Forms.PictureBox pictureBoxMap;
        private System.Windows.Forms.SplitContainer splitContainerMap;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMap;
        private System.Windows.Forms.Button buttonGenerateMap;
        private System.Windows.Forms.PropertyGrid propertyGridMap;
    }
}

