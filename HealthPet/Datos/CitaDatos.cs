using HealthPet.Models;
using System.Data.SqlClient;
using System.Data;

namespace HealthPet.Datos
{
    public class CitaDatos
    {

        public List<CitaModel> Listar()
        {

            var oLista = new List<CitaModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listarCita", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new CitaModel()
                        {
                            CodCita = Convert.ToInt32(dr["CodCita"]),
                            CodServicio = Convert.ToInt32(dr["CodServicio"]),
                            NombreServicio = dr["NombreServicio"].ToString(),
                            FechaCita = dr["FechaCita"].ToString(),
                            HoraCita = dr["HoraCita"].ToString(),
                            NombreDueno = dr["NombreDueno"].ToString(),
                            ApellidoDueno = dr["ApellidoDueno"].ToString(),
                            TipoPaciente = dr["TipoPaciente"].ToString(),
                            RazaPaciente = dr["RazaPaciente"].ToString()
                        });

                    }
                }
            }
            return oLista;
        }

        //
        public CitaModel Obtener(int CodCita)
        {

            var oCita = new CitaModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtenerCita", conexion);
                cmd.Parameters.AddWithValue("CodCita", @CodCita);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        oCita.CodCita = Convert.ToInt32(dr["CodCita"]);
                        oCita.CodServicio = Convert.ToInt32(dr["CodServicio"]);
                        oCita.DetalleCita = dr["DetalleCita"].ToString();
                        oCita.FechaCita = dr["FechaCita"].ToString();
                        oCita.HoraCita = dr["HoraCita"].ToString();
                        oCita.CedulaDueno = dr["CedulaDueno"].ToString();
                        oCita.NombreDueno = dr["NombreDueno"].ToString();
                        oCita.ApellidoDueno = dr["ApellidoDueno"].ToString();
                        oCita.TelefonoDueno = dr["TelefonoDueno"].ToString();
                        oCita.CorreoDueno = dr["CorreoDueno"].ToString();
                        oCita.TipoPaciente = dr["TipoPaciente"].ToString();
                        oCita.NombrePaciente = dr["NombrePaciente"].ToString();
                        oCita.EdadPaciente = dr["EdadPaciente"].ToString();
                        oCita.RazaPaciente = dr["RazaPaciente"].ToString();

                    }
                }
            }
            return oCita;
        }


        //Contacto
        public bool Guardar(CitaModel oCita)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_guardarCita", conexion);

                    cmd.Parameters.AddWithValue("DetalleCita", oCita.DetalleCita);
                    cmd.Parameters.AddWithValue("CodServicio", oCita.CodServicio);
                    cmd.Parameters.AddWithValue("FechaCita", oCita.FechaCita);
                    cmd.Parameters.AddWithValue("HoraCita", oCita.HoraCita);
                    //
                    cmd.Parameters.AddWithValue("CedulaDueno", oCita.CedulaDueno);
                    cmd.Parameters.AddWithValue("NombreDueno", oCita.NombreDueno);
                    cmd.Parameters.AddWithValue("ApellidoDueno", oCita.ApellidoDueno);
                    cmd.Parameters.AddWithValue("TelefonoDueno", oCita.TelefonoDueno);
                    cmd.Parameters.AddWithValue("CorreoDueno", oCita.CorreoDueno);
                    //
                    cmd.Parameters.AddWithValue("TipoPaciente", oCita.TipoPaciente);
                    cmd.Parameters.AddWithValue("NombrePaciente", oCita.NombrePaciente);
                    cmd.Parameters.AddWithValue("EdadPaciente", oCita.EdadPaciente);
                    cmd.Parameters.AddWithValue("RazaPaciente", oCita.RazaPaciente);


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
        public bool Editar(CitaModel oCita)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_editarCita", conexion);

                    cmd.Parameters.AddWithValue("CodCita", oCita.CodCita);
                    cmd.Parameters.AddWithValue("DetalleCita", oCita.DetalleCita);
                    cmd.Parameters.AddWithValue("CodServicio", oCita.CodServicio);
                    cmd.Parameters.AddWithValue("FechaCita", oCita.FechaCita);
                    cmd.Parameters.AddWithValue("HoraCita", oCita.HoraCita);
                    //
                    cmd.Parameters.AddWithValue("CedulaDueno", oCita.CedulaDueno);
                    cmd.Parameters.AddWithValue("NombreDueno", oCita.NombreDueno);
                    cmd.Parameters.AddWithValue("ApellidoDueno", oCita.ApellidoDueno);
                    cmd.Parameters.AddWithValue("TelefonoDueno", oCita.TelefonoDueno);
                    cmd.Parameters.AddWithValue("CorreoDueno", oCita.CorreoDueno);
                    //
                    cmd.Parameters.AddWithValue("TipoPaciente", oCita.TipoPaciente);
                    cmd.Parameters.AddWithValue("NombrePaciente", oCita.NombrePaciente);
                    cmd.Parameters.AddWithValue("EdadPaciente", oCita.EdadPaciente);
                    cmd.Parameters.AddWithValue("RazaPaciente", oCita.RazaPaciente);


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
        public bool Eliminar(int CodCita)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminarCita", conexion);

                    cmd.Parameters.AddWithValue("CodCita", CodCita);
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

        //nuevo




    }
}
