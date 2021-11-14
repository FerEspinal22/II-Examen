
namespace Examen2_FernandoEspinal.Vistas
{
    partial class SoporteView
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.MarcaTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ModeloTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TipoSoporteTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SoporteDataGridView = new System.Windows.Forms.DataGridView();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.EliminarButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.ModificarButton = new System.Windows.Forms.Button();
            this.NuevoButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SoporteDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(187, 31);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.ReadOnly = true;
            this.IDTextBox.Size = new System.Drawing.Size(100, 22);
            this.IDTextBox.TabIndex = 1;
            // 
            // MarcaTextBox
            // 
            this.MarcaTextBox.Location = new System.Drawing.Point(187, 84);
            this.MarcaTextBox.Name = "MarcaTextBox";
            this.MarcaTextBox.Size = new System.Drawing.Size(145, 22);
            this.MarcaTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Marca del dispositivo:";
            // 
            // ModeloTextBox
            // 
            this.ModeloTextBox.Location = new System.Drawing.Point(187, 137);
            this.ModeloTextBox.Name = "ModeloTextBox";
            this.ModeloTextBox.Size = new System.Drawing.Size(145, 22);
            this.ModeloTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Modelo del dispositivo:";
            // 
            // TipoSoporteTextBox
            // 
            this.TipoSoporteTextBox.Location = new System.Drawing.Point(187, 190);
            this.TipoSoporteTextBox.Name = "TipoSoporteTextBox";
            this.TipoSoporteTextBox.Size = new System.Drawing.Size(145, 22);
            this.TipoSoporteTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tipo de soporte:";
            // 
            // SoporteDataGridView
            // 
            this.SoporteDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SoporteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SoporteDataGridView.Location = new System.Drawing.Point(12, 288);
            this.SoporteDataGridView.Name = "SoporteDataGridView";
            this.SoporteDataGridView.RowHeadersWidth = 51;
            this.SoporteDataGridView.RowTemplate.Height = 24;
            this.SoporteDataGridView.Size = new System.Drawing.Size(776, 150);
            this.SoporteDataGridView.TabIndex = 8;
            // 
            // CancelarButton
            // 
            this.CancelarButton.Enabled = false;
            this.CancelarButton.Location = new System.Drawing.Point(573, 233);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(101, 33);
            this.CancelarButton.TabIndex = 40;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            // 
            // EliminarButton
            // 
            this.EliminarButton.Location = new System.Drawing.Point(459, 233);
            this.EliminarButton.Name = "EliminarButton";
            this.EliminarButton.Size = new System.Drawing.Size(101, 33);
            this.EliminarButton.TabIndex = 39;
            this.EliminarButton.Text = "Eliminar";
            this.EliminarButton.UseVisualStyleBackColor = true;
            // 
            // GuardarButton
            // 
            this.GuardarButton.Enabled = false;
            this.GuardarButton.Location = new System.Drawing.Point(345, 233);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(101, 33);
            this.GuardarButton.TabIndex = 38;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            // 
            // ModificarButton
            // 
            this.ModificarButton.Location = new System.Drawing.Point(231, 233);
            this.ModificarButton.Name = "ModificarButton";
            this.ModificarButton.Size = new System.Drawing.Size(101, 33);
            this.ModificarButton.TabIndex = 37;
            this.ModificarButton.Text = "Modificar";
            this.ModificarButton.UseVisualStyleBackColor = true;
            // 
            // NuevoButton
            // 
            this.NuevoButton.Location = new System.Drawing.Point(117, 233);
            this.NuevoButton.Name = "NuevoButton";
            this.NuevoButton.Size = new System.Drawing.Size(101, 33);
            this.NuevoButton.TabIndex = 36;
            this.NuevoButton.Text = "Nuevo";
            this.NuevoButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SoporteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.EliminarButton);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.ModificarButton);
            this.Controls.Add(this.NuevoButton);
            this.Controls.Add(this.SoporteDataGridView);
            this.Controls.Add(this.TipoSoporteTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ModeloTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MarcaTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.label1);
            this.Name = "SoporteView";
            this.Text = "Soporte";
            ((System.ComponentModel.ISupportInitialize)(this.SoporteDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox IDTextBox;
        public System.Windows.Forms.TextBox MarcaTextBox;
        public System.Windows.Forms.TextBox ModeloTextBox;
        public System.Windows.Forms.TextBox TipoSoporteTextBox;
        public System.Windows.Forms.DataGridView SoporteDataGridView;
        public System.Windows.Forms.Button CancelarButton;
        public System.Windows.Forms.Button EliminarButton;
        public System.Windows.Forms.Button GuardarButton;
        public System.Windows.Forms.Button ModificarButton;
        public System.Windows.Forms.Button NuevoButton;
        public System.Windows.Forms.ErrorProvider errorProvider1;
    }
}