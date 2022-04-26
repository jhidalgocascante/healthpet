using HealthPet.Models;
using System.Data.SqlClient;
using System.Data;


namespace HealthPet.Datos
{
    public class ServicioDatos
    {

        public List<ServicioModel> Listar()
        {

            var oLista = new List<ServicioModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listarServicios", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new ServicioModel()
                        {
                            CodServicio = Convert.ToInt32(dr["CodServicio"]),
                            NombreServicio = dr["NombreServicio"].ToString(),
                            DescripcionServicio = dr["DescripcionServicio"].ToString()
                        });

                    }
                }
            }
            return oLista;
        }

        //
        public ServicioModel Obtener(int CodServicio)
        {

            var oServicio = new ServicioModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtenerServicio", conexion);
                cmd.Parameters.AddWithValue("CodServicio", @CodServicio);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        oServicio.CodServicio = Convert.ToInt32(dr["CodServicio"]);
                        oServicio.NombreServicio = dr["NombreServicio"].ToString();
                        oServicio.DescripcionServicio = dr["DescripcionServicio"].ToString();

                    }
                }
            }
            return oServicio;
        }


        //Contacto
        public bool Guardar(ServicioModel oServicio)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_guardarServicio", conexion);

                    cmd.Parameters.AddWithValue("NombreServicio", oServicio.NombreServicio);
                    cmd.Parameters.AddWithValue("DescripcionServicio", oServicio.DescripcionServicio);
                    //cmd.Parameters.AddWithValue("Correo", ocontacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = true;
            }
            return rpta;
        }

        //Editar
        public bool Editar(ServicioModel oServicio)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_editarServicio", conexion);

                    cmd.Parameters.AddWithValue("CodServicio", oServicio.CodServicio);
                    cmd.Parameters.AddWithValue("NombreServicio", oServicio.NombreServicio);
                    cmd.Parameters.AddWithValue("DescripcionServicio", oServicio.DescripcionServicio);
                    //cmd.Parameters.AddWithValue("Correo", ocontacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = true;
            }
            return rpta;
        }


        //Borrar
        public bool Eliminar(int CodServicio)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminarServicio", conexion);

                    cmd.Parameters.AddWithValue("CodServicio", CodServicio);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = true;
            }
            return rpta;
        }



    }
}
