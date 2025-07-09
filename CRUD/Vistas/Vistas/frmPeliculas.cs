using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelos;

namespace Vistas
{
    public partial class frmPeliculas : Form
    {
        public frmPeliculas()
        {
            InitializeComponent();
        }

        private void frmPeliculas_Load(object sender, EventArgs e)
        {
            MostrarPeliculas();
        }

        private void MostrarPeliculas()
        {
            dgvPeliculas.DataSource = null;
            dgvPeliculas.DataSource = Peliculas.CargarPeliculas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Peliculas p = new Peliculas();
            p.Nombre = txtNombre.Text;
            p.FechaLanzamiento = dtpFecha.Value;
            p.Director = txtDirector.Text;

            //se escribe p. para que los atributos de p sirvan de parametros en el método
            p.InsertarPeliculas();
            MostrarPeliculas();
        }
    }
}
