using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace CapaVisual
{
    public partial class CrearUsuario : Form
    {
        public CrearUsuario()
        {
            InitializeComponent();
        }

        private void BotonCrear_Click(object sender, EventArgs e)
        {
            UsuarioControlador.Alta(TextBoxNombre.Text, TextBoxPassoword.Text);
            MessageBox.Show("Usuario Creado");

        }
    }
}
