using System;
using System.Collections.Generic;
using Entidades_Compartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaPasaPor
    {
        //singleton
        private static PersistenciaPasaPor _instancia = null;
        private PersistenciaPasaPor() { }
        public static PersistenciaPasaPor GetInstance()
        {
            if (_instancia == null)
                _instancia = new PersistenciaPasaPor();

            return _instancia;
        }//fin singleton
        internal void AltaPPViaje(PasaPor Ter, int unV, SqlTransaction _pTransaccion)
        {
            SqlCommand oComando = new SqlCommand("AltaPasaPordeViaje", _pTransaccion.Connection);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CodigoTer", Ter.Ter.Codigo);//Corrección: pasamos el codigo de terminal, no la terminal como objeto
            oComando.Parameters.AddWithValue("@CodigoVia", unV);
            oComando.Parameters.AddWithValue("@Orden", Ter.Orden);
            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(_ParmRetorno);
            try
            {
                oComando.Transaction = _pTransaccion;
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("La terminal debe existir");
                else if (oAfectados == -2)
                    throw new Exception("El viaje debe existir");
                else if (oAfectados == -3)
                    throw new Exception("Esta terminal ya fue asociada a este viaje");
                else if (oAfectados == -4)
                    throw new Exception("No pueden haber 2 terminales con el mismo N° de orden");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal List<PasaPor> ListTerViaje(int unV)
        {
            int _orden;
            string _codTer;
            PasaPor _ter = null;
            List<PasaPor> _lista = new List<PasaPor>();

            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("ListadoTerminalesdeunViaje", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            SqlParameter _codigo = new SqlParameter("@Codigo", unV);
            oComando.Parameters.Add(_codigo);
            

            SqlDataReader oReader;
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        _orden = (int)oReader["Orden"];
                        _codTer = (string)oReader["CodigoTer"];
                        Terminal _terminal = null;
                        _terminal = PersistenciaInternacional.GetInstance().BuscarTI(_codTer);//Corrección: voy a necesitar un proc que busque sin importar el registro sin embargo la linea de tiempo muere 
                        //en persistencia poque necesito ese buscar para mapear las dependencias pero no me interesa que nadie mas la vea.
                        if (_terminal == null)
                        {
                            _terminal = PersistenciaNacional.GetInstance().BuscarTN(_codTer);//Corrección: lo mismo
                        }
                        _ter = new PasaPor(_orden, _terminal);
                        _lista.Add(_ter);
                    }
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
            return _lista;
        }
    }
}
