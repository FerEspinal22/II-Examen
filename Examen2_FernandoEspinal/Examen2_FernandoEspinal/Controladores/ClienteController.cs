using Examen2_FernandoEspinal.Modelos.DAO;
using Examen2_FernandoEspinal.Modelos.Entidades;
using Examen2_FernandoEspinal.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen2_FernandoEspinal.Controladores
{
    public class ClienteController
    {
        ClientesView vista;
        ClienteDAO clienteDAO = new ClienteDAO();
        Cliente cliente = new Cliente();
        string operacion = string.Empty;

        public ClienteController(ClientesView view)
        {
            vista = view;
            vista.NuevoButton.Click += new EventHandler(Nuevo);
            vista.GuardarButton.Click += new EventHandler(Guardar);
            vista.ModificarButton.Click += new EventHandler(Modificar);
            vista.Load += new EventHandler(Load);
            vista.EliminarButton.Click += new EventHandler(Eliminar);
            vista.CancelarButton.Click += new EventHandler(Cancelar);
        }

        private void Nuevo(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }

        private void Guardar(object sender, EventArgs e)
        {
            if (vista.IdentidadMaskedTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.IdentidadMaskedTextBox, "Ingrese una identidad");
                vista.IdentidadMaskedTextBox.Focus();
                return;
            }
            if (vista.NombreTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.NombreTextBox, "Ingrese un nombre");
                vista.NombreTextBox.Focus();
                return;
            }
            if (vista.EmailTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.EmailTextBox, "Ingrese un email");
                vista.EmailTextBox.Focus();
                return;
            }
            try
            {
                cliente.Identidad = vista.IdentidadMaskedTextBox.Text;
                cliente.Nombre = vista.NombreTextBox.Text;
                cliente.Email = vista.EmailTextBox.Text;

                if (operacion == "Nuevo")
                {
                    bool inserto = clienteDAO.InsertarNuevoCliente(cliente);
                    if (inserto)
                    {
                        DeshabilitarControles();
                        LimpiarControles();
                        MessageBox.Show("Cliente creado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarClientes();
                    }
                    else
                    {
                        MessageBox.Show("Cliente no se pudo insertar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (operacion == "Modificar")
                {
                    cliente.Id = Convert.ToInt32(vista.IdTextBox.Text);
                    bool modifico = clienteDAO.ActualizarCliente(cliente);
                    if (modifico)
                    {
                        DeshabilitarControles();
                        LimpiarControles();
                        MessageBox.Show("Cliente modificado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarClientes();
                    }
                    else
                    {
                        MessageBox.Show("Cliente no se pudo modificar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void Modificar(object sender, EventArgs e)
        {
            if (vista.ClientesDataGridView.SelectedRows.Count > 0)
            {
                operacion = "Modificar";
                HabilitarControles();

                vista.IdTextBox.Text = vista.ClientesDataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.IdentidadMaskedTextBox.Text = vista.ClientesDataGridView.CurrentRow.Cells["IDENTIDAD"].Value.ToString();
                vista.NombreTextBox.Text = vista.ClientesDataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
                vista.EmailTextBox.Text = vista.ClientesDataGridView.CurrentRow.Cells["EMAIL"].Value.ToString();
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
            if (vista.ClientesDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = clienteDAO.EliminarUsuario(Convert.ToInt32(vista.ClientesDataGridView.CurrentRow.Cells["ID"].Value));
                if (elimino)
                {
                    MessageBox.Show("Cliente eliminado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarClientes();
                }
                else
                {
                    MessageBox.Show("Cliente no se pudo eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void Cancelar(object sender, EventArgs e)
        {
            DeshabilitarControles();
            LimpiarControles();
            cliente = null;
        }

        private void ListarClientes()
        {
            vista.ClientesDataGridView.DataSource = clienteDAO.GetClientes();
        }

        #region HABILITAR, DESHABILITAR Y LIMPIAR CONTROLES
        private void HabilitarControles()
        {
            vista.IdentidadMaskedTextBox.Enabled = true;
            vista.NombreTextBox.Enabled = true;
            vista.EmailTextBox.Enabled = true;

            vista.GuardarButton.Enabled = true;
            vista.CancelarButton.Enabled = true;
            vista.ModificarButton.Enabled = false;
            vista.NuevoButton.Enabled = false;
        }

        private void DeshabilitarControles()
        {
            vista.IdentidadMaskedTextBox.Enabled = false;
            vista.NombreTextBox.Enabled = false;
            vista.EmailTextBox.Enabled = false;

            vista.GuardarButton.Enabled = false;
            vista.CancelarButton.Enabled = false;
            vista.ModificarButton.Enabled = true;
            vista.NuevoButton.Enabled = true;

        }

        private void LimpiarControles()
        {
            vista.IdTextBox.Clear();
            vista.IdentidadMaskedTextBox.Clear();
            vista.NombreTextBox.Clear();
            vista.EmailTextBox.Clear();
        }

        #endregion
    }
}
