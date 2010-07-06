namespace MetaphysicsIndustries.Amethyst
{
    partial class ScriptElementEditorForm
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
            this._sourcetextBox1 = new System.Windows.Forms.TextBox();
            this._nametextBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._okbutton1 = new System.Windows.Forms.Button();
            this._cancelbutton2 = new System.Windows.Forms.Button();
            this._connectionslistBox1 = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._addInputbutton1 = new System.Windows.Forms.Button();
            this._addOutputbutton2 = new System.Windows.Forms.Button();
            this._deleteConnectionbutton3 = new System.Windows.Forms.Button();
            this._addUsingbutton1 = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _sourcetextBox1
            // 
            this._sourcetextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._sourcetextBox1.Location = new System.Drawing.Point(0, 0);
            this._sourcetextBox1.Multiline = true;
            this._sourcetextBox1.Name = "_sourcetextBox1";
            this._sourcetextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._sourcetextBox1.Size = new System.Drawing.Size(480, 202);
            this._sourcetextBox1.TabIndex = 0;
            // 
            // _nametextBox2
            // 
            this._nametextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._nametextBox2.Location = new System.Drawing.Point(53, 12);
            this._nametextBox2.Name = "_nametextBox2";
            this._nametextBox2.Size = new System.Drawing.Size(439, 20);
            this._nametextBox2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // _okbutton1
            // 
            this._okbutton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okbutton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okbutton1.Location = new System.Drawing.Point(336, 330);
            this._okbutton1.Name = "_okbutton1";
            this._okbutton1.Size = new System.Drawing.Size(75, 23);
            this._okbutton1.TabIndex = 3;
            this._okbutton1.Text = "OK";
            this._okbutton1.UseVisualStyleBackColor = true;
            this._okbutton1.Click += new System.EventHandler(this._okbutton1_Click);
            // 
            // _cancelbutton2
            // 
            this._cancelbutton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelbutton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelbutton2.Location = new System.Drawing.Point(417, 330);
            this._cancelbutton2.Name = "_cancelbutton2";
            this._cancelbutton2.Size = new System.Drawing.Size(75, 23);
            this._cancelbutton2.TabIndex = 4;
            this._cancelbutton2.Text = "Cancel";
            this._cancelbutton2.UseVisualStyleBackColor = true;
            this._cancelbutton2.Click += new System.EventHandler(this._cancelbutton2_Click);
            // 
            // _connectionslistBox1
            // 
            this._connectionslistBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._connectionslistBox1.FormattingEnabled = true;
            this._connectionslistBox1.Location = new System.Drawing.Point(0, 0);
            this._connectionslistBox1.Name = "_connectionslistBox1";
            this._connectionslistBox1.Size = new System.Drawing.Size(480, 80);
            this._connectionslistBox1.TabIndex = 5;
            this._connectionslistBox1.SelectedIndexChanged += new System.EventHandler(this._connectionslistBox1_SelectedIndexChanged);
            this._connectionslistBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._connectionslistBox1_MouseDoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(12, 38);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._connectionslistBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._sourcetextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(480, 286);
            this.splitContainer1.SplitterDistance = 80;
            this.splitContainer1.TabIndex = 6;
            // 
            // _addInputbutton1
            // 
            this._addInputbutton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._addInputbutton1.Location = new System.Drawing.Point(12, 330);
            this._addInputbutton1.Name = "_addInputbutton1";
            this._addInputbutton1.Size = new System.Drawing.Size(75, 23);
            this._addInputbutton1.TabIndex = 7;
            this._addInputbutton1.Text = "Add Input";
            this._addInputbutton1.UseVisualStyleBackColor = true;
            this._addInputbutton1.Click += new System.EventHandler(this._addInputbutton1_Click);
            // 
            // _addOutputbutton2
            // 
            this._addOutputbutton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._addOutputbutton2.Location = new System.Drawing.Point(93, 330);
            this._addOutputbutton2.Name = "_addOutputbutton2";
            this._addOutputbutton2.Size = new System.Drawing.Size(75, 23);
            this._addOutputbutton2.TabIndex = 8;
            this._addOutputbutton2.Text = "Add Output";
            this._addOutputbutton2.UseVisualStyleBackColor = true;
            this._addOutputbutton2.Click += new System.EventHandler(this._addOutputbutton2_Click);
            // 
            // _deleteConnectionbutton3
            // 
            this._deleteConnectionbutton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._deleteConnectionbutton3.Enabled = false;
            this._deleteConnectionbutton3.Location = new System.Drawing.Point(255, 330);
            this._deleteConnectionbutton3.Name = "_deleteConnectionbutton3";
            this._deleteConnectionbutton3.Size = new System.Drawing.Size(75, 23);
            this._deleteConnectionbutton3.TabIndex = 9;
            this._deleteConnectionbutton3.Text = "Delete";
            this._deleteConnectionbutton3.UseVisualStyleBackColor = true;
            this._deleteConnectionbutton3.Click += new System.EventHandler(this._deleteConnectionbutton3_Click);
            // 
            // _addUsingbutton1
            // 
            this._addUsingbutton1.Location = new System.Drawing.Point(174, 330);
            this._addUsingbutton1.Name = "_addUsingbutton1";
            this._addUsingbutton1.Size = new System.Drawing.Size(75, 23);
            this._addUsingbutton1.TabIndex = 10;
            this._addUsingbutton1.Text = "Add Using";
            this._addUsingbutton1.UseVisualStyleBackColor = true;
            this._addUsingbutton1.Click += new System.EventHandler(this._addUsingbutton1_Click);
            // 
            // ScriptElementEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 365);
            this.Controls.Add(this._addUsingbutton1);
            this.Controls.Add(this._deleteConnectionbutton3);
            this.Controls.Add(this._addOutputbutton2);
            this.Controls.Add(this._addInputbutton1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this._cancelbutton2);
            this.Controls.Add(this._okbutton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._nametextBox2);
            this.MinimumSize = new System.Drawing.Size(512, 281);
            this.Name = "ScriptElementEditorForm";
            this.Text = "ScriptElementEditorForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _sourcetextBox1;
        private System.Windows.Forms.TextBox _nametextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _okbutton1;
        private System.Windows.Forms.Button _cancelbutton2;
        private System.Windows.Forms.ListBox _connectionslistBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button _addInputbutton1;
        private System.Windows.Forms.Button _addOutputbutton2;
        private System.Windows.Forms.Button _deleteConnectionbutton3;
        private System.Windows.Forms.Button _addUsingbutton1;
    }
}