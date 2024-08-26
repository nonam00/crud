namespace ClientApp
{
    partial class EmployeeForm
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
            textBoxName = new TextBox();
            textBoxAge = new TextBox();
            buttonAction = new Button();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Font = new Font("Segoe UI", 16F);
            textBoxName.Location = new Point(237, 112);
            textBoxName.Name = "textBoxName";
            textBoxName.PlaceholderText = "Name";
            textBoxName.Size = new Size(311, 36);
            textBoxName.TabIndex = 0;
            // 
            // textBoxAge
            // 
            textBoxAge.Font = new Font("Segoe UI", 16F);
            textBoxAge.Location = new Point(237, 189);
            textBoxAge.Name = "textBoxAge";
            textBoxAge.PlaceholderText = "Age";
            textBoxAge.Size = new Size(311, 36);
            textBoxAge.TabIndex = 1;
            // 
            // buttonAction
            // 
            buttonAction.Location = new Point(305, 284);
            buttonAction.Name = "buttonAction";
            buttonAction.Size = new Size(158, 36);
            buttonAction.TabIndex = 2;
            buttonAction.Text = "button1";
            buttonAction.UseVisualStyleBackColor = true;
            buttonAction.Click += buttonAction_Click;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonAction);
            Controls.Add(textBoxAge);
            Controls.Add(textBoxName);
            Name = "EmployeeForm";
            Text = "AddForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private TextBox textBoxAge;
        private Button buttonAction;
    }
}