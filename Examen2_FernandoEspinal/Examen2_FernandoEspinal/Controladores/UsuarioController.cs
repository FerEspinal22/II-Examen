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

    public class UsuarioController
    {
        UsuariosView vista;
        string operacion = string.Empty;
        UsuarioDAO userDAO = new UsuarioDAO();
        Usuario user = new Usuario();

        public UsuarioController(UsuariosView view)
        {
            vista = view;
            vista.NuevoButton.Click += new EventHandler(Nuevo);
            vista.GuardarButton.Click += new EventHandler(Guardar);
            vista.Load += new EventHandler(Load);
            vista.ModificarButton.Click += new EventHandler(Modificar);
            vista.EliminarButton.Click += new EventHandler(Eliminar);
        }

        private void Nuevo(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }

        private void Guardar(object sender, EventArgs e)
        {
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

            if (vista.ClaveTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.ClaveTextBox, "Ingrese una clave");
                vista.ClaveTextBox.Focus();
                return;
            }

            user.Nombre = vista.NombreTextBox.Text;
            user.Email = vista.EmailTextBox.Text;
            user.Clave = vista.ClaveTextBox.Text;
            user.EsAdministrador = vista.EsAdministradorCheckBox.Checked;

            if (operacion == "Nuevo")
            {
                bool inserto = userDAO.InsertarNuevoUsuario(user);

                if (inserto)
                {
                    DeshabilitarControles();
                    LimpiarControles();
                    MessageBox.Show("Usuario creado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarUsuarios();
                }
                else
                {
                    MessageBox.Show("Usuario no creado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (operacion == "Modificar")
            {
                user.Id = Convert.ToInt32(vista.IdTextBox.Text);
                bool modifico = userDAO.ActualizarUsuario(user);

                if (modifico)
                {
                    DeshabilitarControles();
                    LimpiarControles();
                    MessageBox.Show("Usuario modificado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarUsuarios();
                }
                else
                {
                    MessageBox.Show("Usuario no modificado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void Modificar(object sender, EventArgs e)
        {
            operacion = "Modificar";
            if (vista.UsuariosDataGridView.SelectedRows.Count > 0)
            {
                vista.IdTextBox.Text = vista.UsuariosDataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.NombreTextBox.Text = vista.UsuariosDataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
                vista.EmailTextBox.Text = vista.UsuariosDataGridView.CurrentRow.Cells["EMAIL"].Value.ToString();
                vista.EsAdministradorCheckBox.Checked = Convert.ToBoolean(vista.UsuariosDataGridView.CurrentRow.Cells["ESADMINISTRADOR"].Value);

                HabilitarControles();
            }
        }

        private void Eliminar(object sender, EventArgs e)
        {
            if (vista.UsuariosDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = userDAO.EliminarUsuario(Convert.ToInt32(vista.UsuariosDataGridView.CurrentRow.Cells[0].Value.ToString()));

                if (elimino)
                {
                    DeshabilitarControles();
                    LimpiarControles();
                    MessageBox.Show("Usuario eliminado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarUsuarios();
                }
            }
        }

        public void ListarUsuarios()
        {
            vista.UsuariosDataGridView.DataSource = userDAO.GetUsuarios();
        }

        #region HABILITAR, DESHABILITAR Y LIMPIAR CONTROLES
        private void LimpiarControles()
        {
            vista.IdTextBox.Clear();
            vista.NombreTextBox.Clear();
            vista.EmailTextBox.Clear();
            vista.ClaveTextBox.Clear();
            vista.EsAdministradorCheckBox.Enabled = false;
        }
        private void HabilitarControles()
        {
            vista.IdTextBox.Enabled = true;
            vista.NombreTextBox.Enabled = true;
            vista.EmailTextBox.Enabled = true;
            vista.ClaveTextBox.Enabled = true;
            vista.EsAdministradorCheckBox.Enabled = true;

            vista.GuardarButton.Enabled = true;
            vista.CancelarButton.Enabled = true;
            vista.ModificarButton.Enabled = false;
            vista.NuevoButton.Enabled = false;
        }

        private void DeshabilitarControles()
        {
            vista.IdTextBox.Enabled = false;
            vista.NombreTextBox.Enabled = false;
            vista.EmailTextBox.Enabled = false;
            vista.ClaveTextBox.Enabled = false;
            vista.EsAdministradorCheckBox.Enabled = false;

            vista.GuardarButton.Enabled = false;
            vista.CancelarButton.Enabled = false;
            vista.ModificarButton.Enabled = true;
            vista.NuevoButton.Enabled = true;
        }

        #endregion
    }
}
