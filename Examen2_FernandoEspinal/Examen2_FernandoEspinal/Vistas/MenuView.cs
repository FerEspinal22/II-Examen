using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Examen2_FernandoEspinal.Vistas
{
    public partial class MenuView : Syncfusion.Windows.Forms.Office2010Form
    {
        public MenuView()
        {
            InitializeComponent();
        }

        UsuariosView vistaUsuarios;
        ClientesView vistaClientes;
        SoporteView vistaSoporte;
        EstadoView vistaEstados;
        TicketView vistaTicket;
        DetalleView vistaDetalle;

        private void UsuariosToolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaUsuarios == null)
            {
                vistaUsuarios = new UsuariosView();
                vistaUsuarios.MdiParent = this;
                vistaUsuarios.FormClosed += VistaUsuarios_FormClosed; 
                vistaUsuarios.Show();
            }
            else
            {
                vistaUsuarios.Activate();
            }
        }

        private void VistaUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaUsuarios = null;
        }

        private void ClientesToolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaClientes == null)
            {
                vistaClientes = new ClientesView();
                vistaClientes.MdiParent = this;
                vistaClientes.FormClosed += VistaClientes_FormClosed;
                vistaClientes.Show();
            }
            else
            {
                vistaClientes.Activate();
            }
        }

        private void VistaClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaClientes = null;
        }

        private void SoporteToolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaSoporte == null)
            {
                vistaSoporte = new SoporteView();
                vistaSoporte.MdiParent = this;
                vistaSoporte.FormClosed += VistaSoporte_FormClosed; ;
                vistaSoporte.Show();
            }
            else
            {
                vistaClientes.Activate();
            }
        }

        private void VistaSoporte_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaSoporte = null;
        }

        private void EstadoToolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaEstados == null)
            {
                vistaEstados = new EstadoView();
                vistaEstados.MdiParent = this;
                vistaEstados.FormClosed += VistaEstados_FormClosed;
                vistaEstados.Show();
            }
            else
            {
                vistaClientes.Activate();
            }
        }

        private void VistaEstados_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaEstados = null;
        }

        private void TicketToolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaTicket == null)
            {
                vistaTicket = new TicketView();
                vistaTicket.MdiParent = this;
                vistaTicket.FormClosed += VistaTicket_FormClosed; ;
                vistaTicket.Show();
            }
            else
            {
                vistaTicket.Activate();
            }
        }

        private void VistaTicket_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaTicket = null;
        }

        private void DetalleToolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaDetalle == null)
            {
                vistaDetalle = new DetalleView();
                vistaDetalle.MdiParent = this;
                vistaDetalle.FormClosed += VistaDetalle_FormClosed; 
                vistaDetalle.Show();
            }
            else
            {
                vistaDetalle.Activate();
            }
        }

        private void VistaDetalle_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaDetalle = null;
        }
    }
}
