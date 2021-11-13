using Examen2_FernandoEspinal.Controladores;
using System.Windows.Forms;

namespace Examen2_FernandoEspinal.Vistas
{
    public partial class ClientesView : Form
    {
        public ClientesView()
        {
            InitializeComponent();
            ClienteController controlador = new ClienteController(this);
        }
    }
}
