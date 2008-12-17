namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    partial class ConstructorInvokeForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._assemblyComboBox = new System.Windows.Forms.ComboBox();
            this._constructorComboBox = new System.Windows.Forms.ComboBox();
            this._typeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Constructor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Assembly";
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(205, 94);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 12;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(124, 94);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 11;
            this._okButton.Text = "Ok";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _assemblyComboBox
            // 
            this._assemblyComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._assemblyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._assemblyComboBox.FormattingEnabled = true;
            this._assemblyComboBox.Location = new System.Drawing.Point(79, 13);
            this._assemblyComboBox.Name = "_assemblyComboBox";
            this._assemblyComboBox.Size = new System.Drawing.Size(201, 21);
            this._assemblyComboBox.TabIndex = 10;
            this._assemblyComboBox.SelectedIndexChanged += new System.EventHandler(this._assemblyComboBox_SelectedIndexChanged);
            // 
            // _constructorComboBox
            // 
            this._constructorComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._constructorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._constructorComboBox.FormattingEnabled = true;
            this._constructorComboBox.Location = new System.Drawing.Point(79, 67);
            this._constructorComboBox.Name = "_constructorComboBox";
            this._constructorComboBox.Size = new System.Drawing.Size(201, 21);
            this._constructorComboBox.TabIndex = 9;
            this._constructorComboBox.SelectedIndexChanged += new System.EventHandler(this._constructorComboBox_SelectedIndexChanged);
            // 
            // _typeComboBox
            // 
            this._typeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._typeComboBox.FormattingEnabled = true;
            this._typeComboBox.Location = new System.Drawing.Point(79, 40);
            this._typeComboBox.Name = "_typeComboBox";
            this._typeComboBox.Size = new System.Drawing.Size(201, 21);
            this._typeComboBox.TabIndex = 8;
            this._typeComboBox.SelectedIndexChanged += new System.EventHandler(this._typeComboBox_SelectedIndexChanged);
            // 
            // ConstructorInvokeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 129);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._assemblyComboBox);
            this.Controls.Add(this._constructorComboBox);
            this.Controls.Add(this._typeComboBox);
            this.MinimumSize = new System.Drawing.Size(300, 156);
            this.Name = "ConstructorInvokeForm";
            this.Text = "ConstructorInvokeForm";
            this.Load += new System.EventHandler(this.ConstructorInvokeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.ComboBox _assemblyComboBox;
        private System.Windows.Forms.ComboBox _constructorComboBox;
        private System.Windows.Forms.ComboBox _typeComboBox;

    }
}