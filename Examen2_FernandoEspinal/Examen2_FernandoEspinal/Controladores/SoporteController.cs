using Examen2_FernandoEspinal.Modelos.DAO;
using Examen2_FernandoEspinal.Modelos.Entidades;
using Examen2_FernandoEspinal.Vistas;
using System;
using System.Windows.Forms;

namespace Examen2_FernandoEspinal.Controladores
{
    public class SoporteController
    {
        SoporteView vista;
        Soporte soporte = new Soporte();
        SoporteDAO soporteDAO = new SoporteDAO();
        string operacion = string.Empty;

        public SoporteController(SoporteView view)
        {
            vista = view;
            vista.NuevoButton.Click += new EventHandler(Nuevo);
            vista.GuardarButton.Click += new EventHandler(Guardar);
            vista.ModificarButton.Click += new EventHandler(Modificar);
            vista.Load += new EventHandler(Load);
            vista.EliminarButton.Click += new EventHandler(Eliminar);
            vista.CancelarButton.Click += new EventHandler(Cancelar);
        }

        #region EVENT HANDLERS

        private void Nuevo(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";   
        }

        private void Guardar(object sender, EventArgs e)
        {
            if (vista.MarcaTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.MarcaTextBox, "Ingrese una marca");
                vista.MarcaTextBox.Focus();
                return;
            }
            if (vista.ModeloTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.ModeloTextBox, "Ingrese un modelo");
                vista.ModeloTextBox.Focus();
                return;
            }
            if (vista.TipoSoporteTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.TipoSoporteTextBox, "Ingrese el tipo de soporte que desea");
                vista.TipoSoporteTextBox.Focus();
                return;
            }
            try
            {
                soporte.Marca = vista.MarcaTextBox.Text;
                soporte.Modelo = vista.ModeloTextBox.Text;
                soporte.TipoSoporte = vista.TipoSoporteTextBox.Text;

                if (operacion == "Nuevo")
                {
                    bool inserto = soporteDAO.InsertarNuevoSoporte(soporte);
                    if (inserto)
                    {
                        DeshabilitarControles();
                        LimpiarControles();
                        MessageBox.Show("Creado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarClientes();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo crear", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (operacion == "Modificar")
                {
                    soporte.Id = Convert.ToInt32(vista.IDTextBox.Text);
                    bool modifico = soporteDAO.ActualizarSoporte(soporte);
                    if (modifico)
                    {
                        DeshabilitarControles();
                        LimpiarControles();
                        MessageBox.Show("Modificado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarClientes();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void Modificar(object sender, EventArgs e)
        {
            if (vista.SoporteDataGridView.SelectedRows.Count > 0)
            {
                operacion = "Modificar";
                HabilitarControles();

                vista.IDTextBox.Text = vista.SoporteDataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.MarcaTextBox.Text = vista.SoporteDataGridView.CurrentRow.Cells["MARCA"].Value.ToString();
                vista.ModeloTextBox.Text = vista.SoporteDataGridView.CurrentRow.Cells["MODELO"].Value.ToString();
                vista.TipoSoporteTextBox.Text = vista.SoporteDataGridView.CurrentRow.Cells["TIPOSOPORTE"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }

        private void Load(object sender, EventArgs e)
        {
            ListarClientes();
        }

        private void Eliminar(object sender, EventArgs e)
        {
            if (vista.SoporteDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = soporteDAO.EliminarSoporte(Convert.ToInt32(vista.SoporteDataGridView.CurrentRow.Cells["ID"].Value));
                if (elimino)
                {
                    MessageBox.Show("Eliminado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarClientes();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void Cancelar(object sender, EventArgs e)
        {
            DeshabilitarControles();
            LimpiarControles();
            soporte = null;
        }

        #endregion EVENT HANDLERS

        private void ListarClientes()
        {
            vista.SoporteDataGridView.DataSource = soporteDAO.GetSoporte();
        }

        #region HABILITAR, DESHABILITAR Y LIMPIAR CONTROLES
        private void HabilitarControles()
        {
            vista.MarcaTextBox.Enabled = true;
            vista.ModeloTextBox.Enabled = true;
            vista.TipoSoporteTextBox.Enabled = true;

            vista.GuardarButton.Enabled = true;
            vista.CancelarButton.Enabled = true;
            vista.ModificarButton.Enabled = false;
            vista.NuevoButton.Enabled = false;
        }

        private void DeshabilitarControles()
        {
            vista.MarcaTextBox.Enabled = true;
            vista.ModeloTextBox.Enabled = true;
            vista.TipoSoporteTextBox.Enabled = true;

            vista.GuardarButton.Enabled = false;
            vista.CancelarButton.Enabled = false;
            vista.ModificarButton.Enabled = true;
            vista.NuevoButton.Enabled = true;

        }

        private void LimpiarControles()
        {
            vista.IDTextBox.Clear(); 
            vista.MarcaTextBox.Clear();
            vista.ModeloTextBox.Clear();
            vista.TipoSoporteTextBox.Clear();
        }

        #endregion

    }
}
