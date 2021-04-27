using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NEGOCIO;
using DOMINIO;

namespace POKEDEX
{
    public partial class Form1 : Form
    {
        private List<Pokemon> ListaPokemons;
        public Form1()
        {
            InitializeComponent();
        }
        private void RecargarImg(string img)
        {
            try
            {
                pbxImagen.Load(img);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }
        private void CargarGrilla()
        {
            PokemonNegocio pokemonNegocio = new PokemonNegocio();
            try
            {
                ListaPokemons = pokemonNegocio.Listar();
                dgvTabla.DataSource = ListaPokemons;

                dgvTabla.Columns["Ficha"].Visible = false;
                dgvTabla.Columns["Descripcion"].Visible = false;
                dgvTabla.Columns["UrlImagen"].Visible = false;
                dgvTabla.Columns["Evolucion"].Visible = false;

                RecargarImg(ListaPokemons[0].UrlImagen);
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

        private void DgvTabla_MouseClick(object sender, MouseEventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvTabla.CurrentRow.DataBoundItem;
            RecargarImg(seleccionado.UrlImagen);

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregarPokemon agregarPokemon = new FrmAgregarPokemon();
            agregarPokemon.ShowDialog();
        }
    }
}
