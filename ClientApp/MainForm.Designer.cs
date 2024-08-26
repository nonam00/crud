namespace ClientApp
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
            listBox = new ListBox();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonAdd = new Button();
            SuspendLayout();
            // 
            // listBox
            // 
            listBox.Font = new Font("Segoe UI", 16F);
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 30;
            listBox.Location = new Point(12, 12);
            listBox.Name = "listBox";
            listBox.Size = new Size(336, 394);
            listBox.TabIndex = 0;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(421, 104);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(108, 38);
            buttonUpdate.TabIndex = 1;
            buttonUpdate.Text = "Update info";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(421, 157);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(108, 35);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Delete employee";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(421, 51);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(108, 37);
            buttonAdd.TabIndex = 3;
            buttonAdd.Text = "Add employee";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonAdd);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(listBox);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonAdd;
    }
}