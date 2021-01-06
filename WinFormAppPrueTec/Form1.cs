using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormAppPrueTec
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void butComprimir_Click(object sender, EventArgs e)
        {
            string CadenaIni = string.Empty;
            string CadenaComprimida = string.Empty;

            lblMensaje.Text = "";

            if (txtCadena.Text.Length == 0)
            {
                lblMensaje.Text = "Debe ingresar una cadena de caracteres";
                return;
            }

            CadenaIni = txtCadena.Text.ToString();
            clNegocio.Cadenas obj = new clNegocio.Cadenas();
            CadenaComprimida = obj.ComprimirBasico(CadenaIni);

            if (CadenaComprimida.Length > 0)
            {
                lblMensaje.Text = "Compresion Correcta";
                txtResultado.Text = CadenaComprimida;
            }
            else
            {
                lblMensaje.Text = "No se pudo comprimir la cadena " + CadenaIni;
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
