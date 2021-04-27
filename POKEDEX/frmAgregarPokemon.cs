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

namespace POKEDEX
{
    public partial class FrmAgregarPokemon : Form
    {
        public FrmAgregarPokemon()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmAgregarPokemon_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();
            try
            {
                cbxTipo.DataSource = elementoNegocio.Listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void FrmAgregarPokemon_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("De verad querés salir? Perderás los datos", "Saliendo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                return;

            Dispose();

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Pokemon nuevo = new Pokemon();
            PokemonNegocio pokemonNegocio = new PokemonNegocio();

            try
            {
                nuevo.Nombre = tbxNombre.Text;
                nuevo.Descripcion = tbxDescripcion.Text;
                nuevo.Numero = (int)nudNumero.Value;
                nuevo.UrlImagen = tbxDescripcion.Text;
                nuevo.Tipo = (Elemento)cbxTipo.SelectedItem;

                pokemonNegocio.Agregar(nuevo);
                MessageBox.Show("Agregado!");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
