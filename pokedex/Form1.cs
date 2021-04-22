using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokedex
{
    public partial class Pokedex : Form
    {
        private List<Pokemon> listaPokemons;
        public Pokedex()
        {
            InitializeComponent();
        }

        private void Pokedex_Load(object sender, EventArgs e)
        {
            PokemonNegocio pokemonNegocio = new PokemonNegocio();
            //agregar dos pokemons


            try
            {
                listaPokemons = pokemonNegocio.Listar2();
            dgvTabla.DataSource = listaPokemons;
            RecargarImg(listaPokemons[0].UrlImagen);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void RecargarImg(string img)
        {
            pbxImg.Load(img);
        }

        private void DgvTabla_MouseClick(object sender, MouseEventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvTabla.CurrentRow.DataBoundItem;
            RecargarImg(seleccionado.UrlImagen);
        }
    }
}
