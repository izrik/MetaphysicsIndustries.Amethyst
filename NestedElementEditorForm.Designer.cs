namespace MetaphysicsIndustries.Amethyst
{
    partial class NestedElementEditorForm
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
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._closeButton = new System.Windows.Forms.Button();
            this.amethystControl1 = new MetaphysicsIndustries.Amethyst.AmethystControl();
            this._heightTextBox = new System.Windows.Forms.TextBox();
            this._widthTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._nameTextBox.Location = new System.Drawing.Point(53, 12);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(351, 20);
            this._nameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // _closeButton
            // 
            this._closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._closeButton.Location = new System.Drawing.Point(329, 377);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(75, 23);
            this._closeButton.TabIndex = 2;
            this._closeButton.Text = "Close";
            this._closeButton.UseVisualStyleBackColor = true;
            this._closeButton.Click += new System.EventHandler(this._closeButton_Click);
            // 
            // amethystControl1
            // 
            this.amethystControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.amethystControl1.AutoScroll = true;
            this.amethystControl1.AutoScrollMinSize = new System.Drawing.Size(360, 360);
            this.amethystControl1.BackColor = System.Drawing.SystemColors.Window;
            this.amethystControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.amethystControl1.BoxCollisions = true;
            this.amethystControl1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amethystControl1.Location = new System.Drawing.Point(12, 38);
            this.amethystControl1.Name = "amethystControl1";
            this.amethystControl1.ShallRenderElements = true;
            this.amethystControl1.ShallRenderPaths = true;
            this.amethystControl1.ShowDebugInfo = false;
            this.amethystControl1.ShowPathArrows = true;
            this.amethystControl1.ShowPathJoints = false;
            this.amethystControl1.Size = new System.Drawing.Size(392, 333);
            this.amethystControl1.TabIndex = 3;
            // 
            // _heightTextBox
            // 
            this._heightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._heightTextBox.Location = new System.Drawing.Point(133, 379);
            this._heightTextBox.Name = "_heightTextBox";
            this._heightTextBox.Size = new System.Drawing.Size(66, 20);
            this._heightTextBox.TabIndex = 4;
            // 
            // _widthTextBox
            // 
            this._widthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._widthTextBox.Location = new System.Drawing.Point(36, 379);
            this._widthTextBox.Name = "_widthTextBox";
            this._widthTextBox.Size = new System.Drawing.Size(66, 20);
            this._widthTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "W";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "H";
            // 
            // NestedElementEditorForm
            // 
            this.AcceptButton = this._closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 412);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._widthTextBox);
            this.Controls.Add(this._heightTextBox);
            this.Controls.Add(this.amethystControl1);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._nameTextBox);
            this.Name = "NestedElementEditorForm";
            this.Text = "Nested Node Properties";
            this.Load += new System.EventHandler(this.NestedElementEditorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _closeButton;
        private AmethystControl amethystControl1;
        private System.Windows.Forms.TextBox _heightTextBox;
        private System.Windows.Forms.TextBox _widthTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}