namespace MetaphysicsIndustries.Amethyst
{
    partial class ConverterTypeSelectionForm
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
            this._inputSelectButton = new System.Windows.Forms.Button();
            this._outputSelectButton = new System.Windows.Forms.Button();
            this._inputTypeNameTextBox = new System.Windows.Forms.TextBox();
            this._outputTypeNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _inputSelectButton
            // 
            this._inputSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._inputSelectButton.Location = new System.Drawing.Point(205, 23);
            this._inputSelectButton.Name = "_inputSelectButton";
            this._inputSelectButton.Size = new System.Drawing.Size(75, 23);
            this._inputSelectButton.TabIndex = 0;
            this._inputSelectButton.Text = "Select...";
            this._inputSelectButton.UseVisualStyleBackColor = true;
            this._inputSelectButton.Click += new System.EventHandler(this._inputSelectButton_Click);
            // 
            // _outputSelectButton
            // 
            this._outputSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._outputSelectButton.Location = new System.Drawing.Point(205, 66);
            this._outputSelectButton.Name = "_outputSelectButton";
            this._outputSelectButton.Size = new System.Drawing.Size(75, 23);
            this._outputSelectButton.TabIndex = 1;
            this._outputSelectButton.Text = "Select...";
            this._outputSelectButton.UseVisualStyleBackColor = true;
            this._outputSelectButton.Click += new System.EventHandler(this._outputSelectButton_Click);
            // 
            // _inputTypeNameTextBox
            // 
            this._inputTypeNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._inputTypeNameTextBox.Location = new System.Drawing.Point(15, 25);
            this._inputTypeNameTextBox.Name = "_inputTypeNameTextBox";
            this._inputTypeNameTextBox.ReadOnly = true;
            this._inputTypeNameTextBox.Size = new System.Drawing.Size(184, 20);
            this._inputTypeNameTextBox.TabIndex = 2;
            // 
            // _outputTypeNameTextBox
            // 
            this._outputTypeNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._outputTypeNameTextBox.Location = new System.Drawing.Point(15, 68);
            this._outputTypeNameTextBox.Name = "_outputTypeNameTextBox";
            this._outputTypeNameTextBox.ReadOnly = true;
            this._outputTypeNameTextBox.Size = new System.Drawing.Size(184, 20);
            this._outputTypeNameTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output";
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Enabled = false;
            this._okButton.Location = new System.Drawing.Point(124, 95);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 6;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(205, 95);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 7;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // ConverterTypeSelectionForm
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(292, 130);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._outputTypeNameTextBox);
            this.Controls.Add(this._inputTypeNameTextBox);
            this.Controls.Add(this._outputSelectButton);
            this.Controls.Add(this._inputSelectButton);
            this.Name = "ConverterTypeSelectionForm";
            this.Text = "Converter Types";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _inputSelectButton;
        private System.Windows.Forms.Button _outputSelectButton;
        private System.Windows.Forms.TextBox _inputTypeNameTextBox;
        private System.Windows.Forms.TextBox _outputTypeNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
    }
}