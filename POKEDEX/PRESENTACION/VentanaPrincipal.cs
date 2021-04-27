using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DOMINIO;
using NEGOCIO;

namespace PRESENTACION
{
    public partial class VentanaPrincipal : Form
    {
        private List<Pokemon> listaPokemons;

        public VentanaPrincipal()
        {
            InitializeComponent();
        }
        private void RecargarImg(string img)
        {
            pbxPokemon.Load(img);
        }
        private void CargarGrilla()
        {
            PokemonNegocio pokemonNegocio = new PokemonNegocio();

            try
            {
                listaPokemons = pokemonNegocio.Listar();
                dgvPokemons.DataSource = listaPokemons;

                //Oculto Columnas de la grilla.
                //Puedo poner el indice de la columna o el nombre de la propiedad.
                dgvPokemons.Columns["Ficha"].Visible = false;
                dgvPokemons.Columns["Descripcion"].Visible = false;
                dgvPokemons.Columns["UrlImagen"].Visible = false;
                dgvPokemons.Columns["Evolucion"].Visible = false;

                RecargarImg(listaPokemons[0].UrlImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void dgvPokemons_MouseClick(object sender, MouseEventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            RecargarImg(seleccionado.UrlImagen);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarPokemon agregar = new frmAgregarPokemon();
            agregar.ShowDialog();
            CargarGrilla();
        }
    }
}
