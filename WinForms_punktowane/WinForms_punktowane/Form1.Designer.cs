
namespace WinForms_punktowane
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BlockText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DELETE = new System.Windows.Forms.Button();
            this.START = new System.Windows.Forms.Button();
            this.STOP = new System.Windows.Forms.Button();
            this.LINK = new System.Windows.Forms.Button();
            this.BD = new System.Windows.Forms.Button();
            this.BO = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1574, 1129);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1177, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.40437F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.59563F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 207F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(394, 1123);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plik";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 142);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(376, 46);
            this.button3.TabIndex = 2;
            this.button3.Text = "Wczytaj Schemat";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(376, 46);
            this.button2.TabIndex = 1;
            this.button2.Text = "Zapisz Schemat";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(376, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Nowy Schemat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BlockText);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.DELETE);
            this.groupBox2.Controls.Add(this.START);
            this.groupBox2.Controls.Add(this.STOP);
            this.groupBox2.Controls.Add(this.LINK);
            this.groupBox2.Controls.Add(this.BD);
            this.groupBox2.Controls.Add(this.BO);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 704);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edycja";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // BlockText
            // 
            this.BlockText.Enabled = false;
            this.BlockText.Location = new System.Drawing.Point(6, 315);
            this.BlockText.Multiline = true;
            this.BlockText.Name = "BlockText";
            this.BlockText.Size = new System.Drawing.Size(372, 383);
            this.BlockText.TabIndex = 8;
            this.BlockText.TextChanged += new System.EventHandler(this.BlockText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tekst zaznaczonego bloku:";
            // 
            // DELETE
            // 
            this.DELETE.Location = new System.Drawing.Point(258, 154);
            this.DELETE.Name = "DELETE";
            this.DELETE.Size = new System.Drawing.Size(120, 110);
            this.DELETE.TabIndex = 5;
            this.DELETE.UseVisualStyleBackColor = true;
            this.DELETE.Click += new System.EventHandler(this.DELETE_Click);
            // 
            // START
            // 
            this.START.Location = new System.Drawing.Point(6, 38);
            this.START.Name = "START";
            this.START.Size = new System.Drawing.Size(120, 110);
            this.START.TabIndex = 4;
            this.START.UseVisualStyleBackColor = true;
            this.START.Click += new System.EventHandler(this.START_Click);
            // 
            // STOP
            // 
            this.STOP.Location = new System.Drawing.Point(6, 154);
            this.STOP.Name = "STOP";
            this.STOP.Size = new System.Drawing.Size(120, 110);
            this.STOP.TabIndex = 3;
            this.STOP.UseVisualStyleBackColor = true;
            this.STOP.Click += new System.EventHandler(this.STOP_Click);
            // 
            // LINK
            // 
            this.LINK.Location = new System.Drawing.Point(258, 38);
            this.LINK.Name = "LINK";
            this.LINK.Size = new System.Drawing.Size(120, 110);
            this.LINK.TabIndex = 2;
            this.LINK.UseVisualStyleBackColor = true;
            this.LINK.Click += new System.EventHandler(this.LINK_Click);
            // 
            // BD
            // 
            this.BD.Location = new System.Drawing.Point(132, 154);
            this.BD.Name = "BD";
            this.BD.Size = new System.Drawing.Size(120, 110);
            this.BD.TabIndex = 1;
            this.BD.UseVisualStyleBackColor = true;
            this.BD.Click += new System.EventHandler(this.BD_Click);
            // 
            // BO
            // 
            this.BO.Location = new System.Drawing.Point(132, 38);
            this.BO.Name = "BO";
            this.BO.Size = new System.Drawing.Size(120, 110);
            this.BO.TabIndex = 0;
            this.BO.UseVisualStyleBackColor = true;
            this.BO.Click += new System.EventHandler(this.BO_Click);
            this.BO.Paint += new System.Windows.Forms.PaintEventHandler(this.BO_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 918);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(388, 202);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Język";
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(6, 90);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(376, 46);
            this.button7.TabIndex = 1;
            this.button7.Text = "Angielski";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(6, 38);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(376, 46);
            this.button6.TabIndex = 0;
            this.button6.Text = "Polski";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.Canvas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1168, 1123);
            this.panel1.TabIndex = 1;
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(8, 8);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(3000, 3000);
            this.Canvas.TabIndex = 2;
            this.Canvas.TabStop = false;
            this.Canvas.Click += new System.EventHandler(this.Canvas_Click);
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown_1);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 1129);
            this.Controls.Add(this.tableLayoutPanel1);
            this.IsMdiContainer = true;
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form";
            this.Load += new System.EventHandler(this.Form_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BD;
        private System.Windows.Forms.Button BO;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.Button LINK;
        private System.Windows.Forms.Button DELETE;
        private System.Windows.Forms.Button START;
        private System.Windows.Forms.Button STOP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BlockText;
    }
}

