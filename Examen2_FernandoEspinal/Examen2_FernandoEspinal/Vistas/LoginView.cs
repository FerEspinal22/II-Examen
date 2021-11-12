using Examen2_FernandoEspinal.Controladores;
using System.Windows.Forms;

namespace Examen2_FernandoEspinal.Vistas
{
    public partial class LoginView : Form
    {
        public LoginView()
        {
            InitializeComponent();
            LoginController controlador = new LoginController(this);
        }
    }
}