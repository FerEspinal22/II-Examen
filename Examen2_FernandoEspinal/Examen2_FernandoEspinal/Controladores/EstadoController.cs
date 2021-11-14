using Examen2_FernandoEspinal.Modelos.DAO;
using Examen2_FernandoEspinal.Modelos.Entidades;
using Examen2_FernandoEspinal.Vistas;
using System;
using System.Windows.Forms;

namespace Examen2_FernandoEspinal.Controladores
{
    public class EstadoController
    {
        EstadoView vista;
        Estados estado = new Estados();
        EstadoDAO estadoDAO = new EstadoDAO();
        string operacion = String.Empty;

        public EstadoController(EstadoView view)
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
            if (vista.EstadoTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.EstadoTextBox, "Ingrese un modelo");
                vista.EstadoTextBox.Focus();
                return;
            }

            if (vista.EstadoTextBox.Text != "Sin resolver" && vista.EstadoTextBox.Text != "Abierto" && vista.EstadoTextBox.Text != "En espera" && vista.EstadoTextBox.Text != "Cerrado")
            {
                MessageBox.Show("Los valores validos son: 'Abierto', 'En espera', 'Sin resolver', 'Cerrado'");
                vista.EstadoTextBox.Focus();
                return;
            }


            try
            {
                estado.Estado = vista.EstadoTextBox.Text;

                if (operacion == "Nuevo")
                {
                    bool inserto = estadoDAO.InsertarNuevoEstado(estado);
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
                    estado.Id = Convert.ToInt32(vista.IdTextBox.Text);
                    bool modifico = estadoDAO.ActualizarEstado(estado);
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
            if (vista.EstadoDataGridView.SelectedRows.Count > 0)
            {
                operacion = "Modificar";
                HabilitarControles();

                vista.IdTextBox.Text = vista.EstadoDataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.EstadoTextBox.Text = vista.EstadoDataGridView.CurrentRow.Cells["ESTADO"].Value.ToString();
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
            if (vista.EstadoDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = estadoDAO.EliminarSoporte(Convert.ToInt32(vista.EstadoDataGridView.CurrentRow.Cells["ID"].Value));

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
            estado = null;
        }

        #endregion

        private void ListarClientes()
        {
            vista.EstadoDataGridView.DataSource = estadoDAO.GetEstado();
        }

        #region HABILITAR, DESHABILITAR Y LIMPIAR CONTROLES
        private void HabilitarControles()
        {
            vista.IdTextBox.Enabled = true;
            vista.EstadoTextBox.Enabled = true;

            vista.GuardarButton.Enabled = true;
            vista.CancelarButton.Enabled = true;
            vista.ModificarButton.Enabled = false;
            vista.NuevoButton.Enabled = false;
        }

        private void DeshabilitarControles()
        {
            vista.IdTextBox.Enabled = true;
            vista.EstadoTextBox.Enabled = true;

            vista.GuardarButton.Enabled = false;
            vista.CancelarButton.Enabled = false;
            vista.ModificarButton.Enabled = true;
            vista.NuevoButton.Enabled = true;

        }

        private void LimpiarControles()
        {
            vista.IdTextBox.Clear();
            vista.EstadoTextBox.Clear();
        }

        #endregion
    }
}
