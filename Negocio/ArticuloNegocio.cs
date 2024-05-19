using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using dominio;
using Negocio;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices.WindowsRuntime;
using static System.Net.WebRequestMethods;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                
                datos.setearConsulta("SELECT AR.Id, AR.Codigo, AR.Nombre, AR.Descripcion, MA.Descripcion as Marca, AR.Precio, CA.Descripcion as Categoria, \r\n(SELECT TOP 1 IM.ImagenUrl FROM IMAGENES IM WHERE AR.Id = IM.IdArticulo ORDER BY IM.Id ASC) as Imagen \r\nFROM ARTICULOS AR \r\nLEFT JOIN MARCAS MA on AR.IdMarca = MA.Id \r\nLEFT JOIN CATEGORIAS CA on AR.IdCategoria = CA.Id;");
                datos.ejecutarLectura();

                
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Cantidad = datos.Lector.GetInt32(0);
                   
                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    }
                    else
                    {
                        aux.Marca.Descripcion = "Unbranding";
                    }

                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["Categoria"] is DBNull))
                    {
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }
                    else
                    {
                        aux.Categoria.Descripcion = "Sin categoria";
                    }

                    aux.Precio = (float)datos.Lector.GetDecimal(5);

                    aux.Imagen = new Imagen();  
                    if (!(datos.Lector["imagen"] is DBNull))
                    {
                        aux.Imagen.ImagenURl = (string)datos.Lector["imagen"];
                    }
                    else
                    {
                        aux.Imagen.ImagenURl = "https://th.bing.com/th/id/OIP.F00dCf4bXxX0J-qEEf4qIQHaD6?rs=1&pid=ImgDetMain";
                    }

                    lista.Add(aux);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();    
            }
            return lista;
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@cod, @nom, @desc, @idMar, @idCat, @pre)");
                datos.setearParametro("@cod", nuevo.Codigo);
                datos.setearParametro("@nom", nuevo.Nombre);
                datos.setearParametro("@desc", nuevo.Descripcion);
                datos.setearParametro("@idMar", nuevo.Marca.Id);
                datos.setearParametro("@idCat", nuevo.Categoria.Id);
                datos.setearParametro("@pre", nuevo.Precio); 
                datos.ejecutarAccion();


                int i = UltimoID();
                Imagen img = new Imagen();
                img.IdArticulo = i;
                img.ImagenURl = nuevo.Imagen.ImagenURl;
                ImagenNegocio imagenNegocio = new ImagenNegocio();
                imagenNegocio.agregar(img);

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private int UltimoID()
        {
            int PK = 0;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                    datos.setearConsulta("select max(Id) as 'newid' from ARTICULOS");
                    datos.ejecutarLectura();
                    if (datos.Lector.Read())
            {
                        PK = (int)datos.Lector["newid"];
                        return PK;
            }
               else
               {
                    
                    return PK;
               }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();               
            }
        }

        public void modificar(Articulo modificar)
        {

        }

        public static void EliminarArticulo(int iD)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS WHERE Id = @id");
                datos.setearParametro("@id", iD);
                datos.ejecutarAccion();
                datos.cerrarConexion();
                EliminarImagen(iD);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void EliminarImagen(int iD)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("delete from IMAGENES WHERE IdArticulo = @id");
            datos.setearParametro("@id", iD);
            datos.ejecutarAccion();
        }

        public List<Articulo> filtrarBusqueda(string campo, string criterio, string busqueda)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT AR.Id, AR.Codigo, AR.Nombre, AR.Descripcion, MA.Descripcion as Marca, AR.Precio, CA.Descripcion as Categoria, ";
                consulta += "(SELECT TOP 1 IM.ImagenUrl FROM IMAGENES IM WHERE AR.Id = IM.IdArticulo ORDER BY IM.Id ASC) as Imagen ";
                consulta += "FROM ARTICULOS AR ";
                consulta += "LEFT JOIN MARCAS MA on AR.IdMarca = MA.Id ";
                consulta += "LEFT JOIN CATEGORIAS CA on AR.IdCategoria = CA.Id ";

                if (campo == "Codigo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "WHERE AR.Codigo like '" + busqueda + "%' ";
                            break;
                        case "Termina con":
                            consulta += "WHERE AR.Codigo like '%" + busqueda + "'";
                            break;
                        default:
                            consulta += "WHERE AR.Codigo like '%" + busqueda + "%'";
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "WHERE AR.Nombre like '" + busqueda + "%' ";
                            break;
                        case "Termina con":
                            consulta += "WHERE AR.Nombre like '%" + busqueda + "'";
                            break;
                        default:
                            consulta += "WHERE AR.Nombre like '%" + busqueda + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "WHERE AR.Descripcion like '" + busqueda + "%' ";
                            break;
                        case "Termina con":
                            consulta += "WHERE AR.Descripcion like '%" + busqueda + "'";
                            break;
                        default:
                            consulta += "WHERE AR.Descripcion like '%" + busqueda + "%'";
                            break;
                    }
                }
                consulta += ";";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();

                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    }
                    else
                    {
                        aux.Marca.Descripcion = "Unbranding";
                    }

                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["Categoria"] is DBNull))
                    {
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }
                    else
                    {
                        aux.Categoria.Descripcion = "Sin categoria";
                    }

                    aux.Precio = (float)datos.Lector.GetDecimal(5);

                    aux.Imagen = new Imagen();
                    if (!(datos.Lector["imagen"] is DBNull))
                    {
                        aux.Imagen.ImagenURl = (string)datos.Lector["imagen"];
                    }
                    else
                    {
                        aux.Imagen.ImagenURl = "https://th.bing.com/th/id/OIP.F00dCf4bXxX0J-qEEf4qIQHaD6?rs=1&pid=ImgDetMain";
                    }

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
