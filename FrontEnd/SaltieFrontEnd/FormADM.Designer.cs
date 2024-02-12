namespace SaltieFrontEnd
{
    partial class FormADM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormADM));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnADMcadastro = new System.Windows.Forms.Button();
            this.btnCadastroVinho = new System.Windows.Forms.Button();
            this.btnADMpedidos = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSair = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(682, 44);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnADMcadastro
            // 
            this.btnADMcadastro.BackColor = System.Drawing.Color.Firebrick;
            this.btnADMcadastro.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnADMcadastro.ForeColor = System.Drawing.Color.White;
            this.btnADMcadastro.Location = new System.Drawing.Point(501, 141);
            this.btnADMcadastro.Name = "btnADMcadastro";
            this.btnADMcadastro.Size = new System.Drawing.Size(163, 56);
            this.btnADMcadastro.TabIndex = 2;
            this.btnADMcadastro.Text = "GERENCIAR USUÁRIOS";
            this.btnADMcadastro.UseVisualStyleBackColor = false;
            this.btnADMcadastro.Click += new System.EventHandler(this.btnADMcadastro_Click);
            // 
            // btnCadastroVinho
            // 
            this.btnCadastroVinho.BackColor = System.Drawing.Color.Firebrick;
            this.btnCadastroVinho.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastroVinho.ForeColor = System.Drawing.Color.White;
            this.btnCadastroVinho.Location = new System.Drawing.Point(501, 203);
            this.btnCadastroVinho.Name = "btnCadastroVinho";
            this.btnCadastroVinho.Size = new System.Drawing.Size(163, 55);
            this.btnCadastroVinho.TabIndex = 3;
            this.btnCadastroVinho.Text = "GERENCIAR VINHOS";
            this.btnCadastroVinho.UseVisualStyleBackColor = false;
            this.btnCadastroVinho.Click += new System.EventHandler(this.btnCadastroVinho_Click);
            // 
            // btnADMpedidos
            // 
            this.btnADMpedidos.BackColor = System.Drawing.Color.Firebrick;
            this.btnADMpedidos.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnADMpedidos.ForeColor = System.Drawing.Color.White;
            this.btnADMpedidos.Location = new System.Drawing.Point(501, 264);
            this.btnADMpedidos.Name = "btnADMpedidos";
            this.btnADMpedidos.Size = new System.Drawing.Size(163, 52);
            this.btnADMpedidos.TabIndex = 4;
            this.btnADMpedidos.Text = "PEDIDOS";
            this.btnADMpedidos.UseVisualStyleBackColor = false;
            this.btnADMpedidos.Click += new System.EventHandler(this.btnADMpedidos_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 84);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(458, 306);
            this.flowLayoutPanel1.TabIndex = 5;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Firebrick;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(537, 351);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(134, 39);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "SAIR";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Rage Italic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(517, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 61);
            this.label3.TabIndex = 11;
            this.label3.Text = "Saltie";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(525, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Vinhos em atacado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(10, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 34);
            this.label1.TabIndex = 13;
            this.label1.Text = "VINHOS EM ESTOQUE:";
            // 
            // FormADM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(683, 402);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnADMpedidos);
            this.Controls.Add(this.btnCadastroVinho);
            this.Controls.Add(this.btnADMcadastro);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "FormADM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador";
            this.Load += new System.EventHandler(this.FormADM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnADMcadastro;
        private System.Windows.Forms.Button btnCadastroVinho;
        private System.Windows.Forms.Button btnADMpedidos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}