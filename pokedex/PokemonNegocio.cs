using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace pokedex
{
    class PokemonNegocio
    {
        public List<Pokemon> Listar()
        {
            List<Pokemon> lista = new List<Pokemon>(); 
            SqlConnection conexion = new SqlConnection(); // donde me voy a conectar
            SqlCommand comando = new SqlCommand(); // que es lo que voy a hacer
            SqlDataReader lector; // qué voy a traer
            try
            {
                conexion.ConnectionString = "data source=LAJAVIL\\SQLEXPRESS; initial catalog=pokedex; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select numero, nombre, descripcion, urlImagen from pokemons";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Pokemon poaux = new Pokemon
                    {
                        Numero = (int)lector["Numero"],
                        Nombre = (string)lector["Nombre"],
                        Descripcion = (string)lector["Descripcion"],
                        UrlImagen = (string)lector["UrlImagen"]
                    };

                    lista.Add(poaux);


                }

                

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Pokemon> Listar2()
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection(); // donde me voy a conectar
            SqlCommand comando = new SqlCommand(); // que es lo que voy a hacer
            SqlDataReader lector; // qué voy a traer
            try
            {
                conexion.ConnectionString = "data source=LAJAVIL\\SQLEXPRESS; initial catalog=pokedex; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select p.numero, p.nombre, p.descripcion, p.urlImagen, t.descripcion tipo, d.descripcion debilidad from pokemons as p, elementos t, elementos as d where p.idTipo=t.id and p.idDebilidad=d.id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Pokemon poaux = new Pokemon
                    {
                        Numero = (int)lector["Numero"],
                        Nombre = (string)lector["Nombre"],
                        Descripcion = (string)lector["Descripcion"],
                        UrlImagen = (string)lector["UrlImagen"],
                        Tipo = new Elemento((string)lector["Tipo"]),
                        Debilidad = new Elemento((string)lector["Debilidad"])
                    };

                    lista.Add(poaux);


                }



                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        //select p.numero, p.nombre, p.descripcion, p.urlImagen, p.descripcion from pokemons as p, elementos t, elementos as d where p.idTipo= t.id and p.idDebilidad= d.id
    }
}
