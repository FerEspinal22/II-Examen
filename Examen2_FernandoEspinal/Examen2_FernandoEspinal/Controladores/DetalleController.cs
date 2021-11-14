using Examen2_FernandoEspinal.Modelos.DAO;
using Examen2_FernandoEspinal.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2_FernandoEspinal.Controladores
{
    public class DetalleController
    {
        DetalleView vista;
        TicketDAO ticketDAO = new TicketDAO();

        public DetalleController(DetalleView view)
        {
            vista = view;
            vista.Load += new EventHandler(Load);
            vista.AceptarButton.Click += new EventHandler(Aceptar);
        }

        private void Aceptar(object sender, EventArgs e)
        {
            vista.Close();
        }

        private void Load(object sender, EventArgs e)
        {
            ListarTickets();
        }

        private void ListarTickets()
        {
            vista.DetalleDataGridView.DataSource = ticketDAO.GetTicket();
        }
    }
}
