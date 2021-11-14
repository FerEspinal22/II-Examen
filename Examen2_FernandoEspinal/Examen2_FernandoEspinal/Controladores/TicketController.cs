using Examen2_FernandoEspinal.Modelos.DAO;
using Examen2_FernandoEspinal.Modelos.Entidades;
using Examen2_FernandoEspinal.Vistas;
using System;
using System.Windows.Forms;

namespace Examen2_FernandoEspinal.Controladores
{
    public class TicketController
    {
        TicketView vista;
        Ticket ticket = new Ticket();
        TicketDAO ticketDAO = new TicketDAO();
        string operacion = String.Empty;
        SoporteDAO soporteDAO = new SoporteDAO();
        EstadoDAO estadoDAO = new EstadoDAO();
        ClienteDAO clienteDAO = new ClienteDAO();

        public TicketController(TicketView view)
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
            ListarTiposSoporte();
            ListarEstados();
            ListarNombres();
            operacion = "Nuevo";
        }

        private void Guardar(object sender, EventArgs e)
        {

            ticket.Fecha = vista.FechaDateTimePicker.Value;
            ticket.Nombre = vista.NombreComboBox.Text;
            ticket.TipoSoporte = vista.TipoSoporteComboBox.Text;
            ticket.Estado = vista.EstadoComboBox.Text;

            if (operacion == "Nuevo")
            {
                bool inserto = ticketDAO.InsertarNuevoTicket(ticket);
                if (inserto)
                {
                    DeshabilitarControles();
                    LimpiarControles();
                    MessageBox.Show("Creado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarTickets();
                }
                else
                {
                    MessageBox.Show("No se pudo crear", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (operacion == "Modificar")
            {
                ticket.Id = Convert.ToInt32(vista.IdTextBox.Text);
                bool modifico = ticketDAO.ActualizarTicket(ticket);

                if (modifico)
                {
                    DeshabilitarControles();
                    LimpiarControles();
                    MessageBox.Show("Modificado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarTickets();
                }
                else
                {
                    MessageBox.Show("No se pudo modificar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Modificar(object sender, EventArgs e)
        {
            operacion = "Modificar";
            if (vista.TicketDataGridView.SelectedRows.Count > 0)
            {
                vista.IdTextBox.Text = vista.TicketDataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.FechaDateTimePicker.Text = vista.TicketDataGridView.CurrentRow.Cells["FECHA"].Value.ToString();

                HabilitarControles();
            }
        }

        private void Load(object sender, EventArgs e)
        {
            ListarTickets();
            ListarTiposSoporte();
            ListarEstados();
            ListarNombres();
        }

        private void Eliminar(object sender, EventArgs e)
        {
            if (vista.TicketDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = ticketDAO.EliminarTicket(Convert.ToInt32(vista.TicketDataGridView.CurrentRow.Cells["ID"].Value));
                if (elimino)
                {
                    MessageBox.Show("Cliente eliminado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarTickets();
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
            ticket = null;
        }

        #endregion

        #region LISTAS
        private void ListarTiposSoporte()
        {
            vista.TipoSoporteComboBox.DataSource = soporteDAO.GetSoporte();
            vista.TipoSoporteComboBox.DisplayMember = "SOPORTE";
            vista.TipoSoporteComboBox.ValueMember = "TIPOSOPORTE";
        }

        private void ListarEstados()
        {
            vista.EstadoComboBox.DataSource = estadoDAO.GetEstado();
            vista.EstadoComboBox.DisplayMember ="ESTADO";
            vista.EstadoComboBox.ValueMember = "ESTADO";
        }

        private void ListarNombres()
        {
            vista.NombreComboBox.DataSource = clienteDAO.GetClientes();
            vista.NombreComboBox.DisplayMember = "CLIENTE";
            vista.NombreComboBox.ValueMember = "NOMBRE";
        }

        private void ListarTickets()
        {
            vista.TicketDataGridView.DataSource = ticketDAO.GetTicket();
        }

        #endregion

        #region HABILITAR, DESHABILITAR Y LIMPIAR CONTROLES 
        private void HabilitarControles()
        {
            vista.IdTextBox.Enabled = true;
            vista.FechaDateTimePicker.Enabled = true;
            vista.NombreComboBox.Enabled = true;
            vista.TipoSoporteComboBox.Enabled = true;
            vista.EstadoComboBox.Enabled = true;

            vista.GuardarButton.Enabled = true;
            vista.CancelarButton.Enabled = true;
            vista.ModificarButton.Enabled = false;
            vista.NuevoButton.Enabled = false;
        }

        private void DeshabilitarControles()
        {
            vista.IdTextBox.Enabled = true;
            vista.FechaDateTimePicker.Enabled = true;
            vista.NombreComboBox.Enabled = true;
            vista.TipoSoporteComboBox.Enabled = true;
            vista.EstadoComboBox.Enabled = true;

            vista.GuardarButton.Enabled = false;
            vista.CancelarButton.Enabled = false;
            vista.ModificarButton.Enabled = true;
            vista.NuevoButton.Enabled = true;

        }

        private void LimpiarControles()
        {
            vista.IdTextBox.Clear();
            vista.NombreComboBox.Enabled = true;
            vista.TipoSoporteComboBox.Enabled = true;
            vista.EstadoComboBox.Enabled = true;
        }

        #endregion
    }
}
