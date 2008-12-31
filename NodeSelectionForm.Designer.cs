namespace MetaphysicsIndustries.Amethyst
{
    partial class NodeSelectionForm
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
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._assemblyComboBox = new System.Windows.Forms.ComboBox();
            this._nodeList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(124, 238);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 0;
            this._okButton.Text = "Ok";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(205, 238);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _assemblyComboBox
            // 
            this._assemblyComboBox.FormattingEnabled = true;
            this._assemblyComboBox.Location = new System.Drawing.Point(12, 12);
            this._assemblyComboBox.Name = "_assemblyComboBox";
            this._assemblyComboBox.Size = new System.Drawing.Size(268, 21);
            this._assemblyComboBox.TabIndex = 2;
            this._assemblyComboBox.SelectedIndexChanged += new System.EventHandler(this._assemblyComboBox_SelectedIndexChanged);
            // 
            // _nodeList
            // 
            this._nodeList.FormattingEnabled = true;
            this._nodeList.Location = new System.Drawing.Point(12, 43);
            this._nodeList.Name = "_nodeList";
            this._nodeList.Size = new System.Drawing.Size(268, 186);
            this._nodeList.TabIndex = 3;
            // 
            // NodeSelectionForm
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this._nodeList);
            this.Controls.Add(this._assemblyComboBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Name = "NodeSelectionForm";
            this.Text = "NodeSelectionForm";
            this.Load += new System.EventHandler(this.NodeSelectionForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.ComboBox _assemblyComboBox;
        private System.Windows.Forms.ListBox _nodeList;
    }
}