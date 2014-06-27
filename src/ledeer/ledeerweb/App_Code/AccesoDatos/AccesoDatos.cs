using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;

/// <summary>
/// Clase en la que se definen los métodos que acceden 
/// a la base de datos DBLEDEER
/// </summary>

namespace DataAccess
{
    public class AccesoDatos
    {

        //Funciones que llaman a los procedimientos almacenados
        protected static String CadenaConexion = "";
        public AccesoDatos()
        {
        }


        static AccesoDatos()
        {
            CadenaConexion = ConfigurationManager.AppSettings["Conecta"];
        }


        protected SqlConnection getConexion()
        {
            SqlConnection Con = new SqlConnection(CadenaConexion);
            return Con;
        }


        //Métodos para agregar parametros
        //Recibe nombre del atributo, el tipo de datos del atributo

        private SqlParameter SqlParametro(string nombre, string valor)
        {
            SqlParameter _parametro = new SqlParameter();
            _parametro.ParameterName = nombre;
            _parametro.SqlDbType = SqlDbType.VarChar;
            _parametro.Direction = ParameterDirection.Input;
            _parametro.Value = valor;
            return _parametro;
        }

        private SqlParameter SqlParametro(string nombre, int valor)
        {
            SqlParameter _parametro = new SqlParameter();
            _parametro.ParameterName = nombre;
            _parametro.SqlDbType = SqlDbType.Int;

            if (nombre.CompareTo("@Existe") == 0)
                _parametro.Direction = ParameterDirection.Output;
            else
                _parametro.Direction = ParameterDirection.Input;
            _parametro.Value = valor;
            return _parametro;
        }

        private SqlParameter SqlParametro(string nombre, DateTime valor)
        {
            SqlParameter _parametro = new SqlParameter();
            _parametro.ParameterName = nombre;
            _parametro.SqlDbType = SqlDbType.DateTime;
            _parametro.Direction = ParameterDirection.Input;
            _parametro.Value = valor;
            return _parametro;
        }


        //Métodos que llaman a los procedimientos almacenados
        /**
               Agregar un nueva arena
        **/
        //regresa 0 si es insertado
        public int AddArena(string name)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AddArena", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            /*
             AtrName - nombre de la arena
             Existe
             */

            comando.Parameters.Add(SqlParametro("@AtrName", name));

            SqlParameter Existe = new SqlParameter("@Existe", DbType.Int32);
            Existe.Direction = ParameterDirection.Output;
            Existe.Value = 0;
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //regresa 0 si es insertado
        public int AddObject(string name, string val)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AddObject", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            /*
             AtrName - nombre del objeto
             * AtrVal - valor del objeto
             Existe
             */

            comando.Parameters.Add(SqlParametro("@AtrName", name));
            comando.Parameters.Add(SqlParametro("@AtrVal", val));

            SqlParameter Existe = new SqlParameter("@Existe", DbType.Int32);
            Existe.Direction = ParameterDirection.Output;
            Existe.Value = 0;
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }



        //Métodos que llaman a los procedimientos almacenados
        /**
               Agregar un nueva acción
        **/
        //regresa 0 si es insertado
        public int AddAction(string name)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AddAction", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            /*
             AtrName - nombre de la arena
             Existe
             */

            comando.Parameters.Add(SqlParametro("@AtrName", name));

            SqlParameter Existe = new SqlParameter("@Existe", DbType.Int32);
            Existe.Direction = ParameterDirection.Output;
            Existe.Value = 0;
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }



        //AddActor '<actor>' 
        //regresa 0 si es insertado
        public int AddActor(string name)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AddActor", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add(SqlParametro("@AtrName", name));
            SqlParameter Existe = new SqlParameter("@Existe", DbType.Int32);
            Existe.Direction = ParameterDirection.Output;
            Existe.Value = 0;
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;

        }


        //Métodos que llaman a los procedimientos almacenados
        /**
               Agregar rol actancial
        **/
        //regresa 0 si es insertado
        public int AddRoleAct(string name)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AddRoleActancial", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            /*
             AtrName - nombre de la arena
             Existe
             */

            comando.Parameters.Add(SqlParametro("@AtrName", name));

            SqlParameter Existe = new SqlParameter("@Existe", DbType.Int32);
            Existe.Direction = ParameterDirection.Output;
            Existe.Value = 0;
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //regresa 0 si es insertado
        //AddActionRoleActancial <nameaction>,<nameroleact>, existo
        //Agregar rol actancial a una funcionalidad de la arena

        public int AddRoleActToAction(string namearena, string nameaction, string nameroleact)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AddArenaActionRoleActancial", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // name
            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameAction", nameaction));
            comando.Parameters.Add(SqlParametro("@AtrNameRoleAct", nameroleact));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }

        //regresa 0 si es insertado
        //Agregar objeto a una funcionalidad de la arena

        public int AddObjectToArena(string namearena, string nameobject)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AddArenaObject", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // name
            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameObject", nameobject));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //regresa 0 si es insertado
        //AddActionToArena
        //agregar acción a una arena
        public int AddActionToArena(string namearena, string nameaction)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AddArenaAction", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // name,acción
            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameAction", nameaction));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }

        //regresa 0 si es insertado
        //Arenas
        public int AddRoleActToAction(string nameaction, string nameroleact)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AddActionRoleActancial", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // name acción, role actancial
            comando.Parameters.Add(SqlParametro("@AtrNameAction", nameaction));
            comando.Parameters.Add(SqlParametro("@AtrNameRoleAct", nameroleact));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //--Add agregar actor a una acción '<name>'
        //regresa 0 si es insertado
        public int AddActorToArena(string namearena, string nameactor)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AddArenaActor", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // name

            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameActor", nameactor));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //regresa 0 si es insertado
        //AddScenarioToAction agregar escenario a una acción de la arena
        public int AddScenarioToAction(string namearena, string nameaction, string namescenario, string description)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AddArenaActionScenario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // name arena, name action, name escenario, description
            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameAction", nameaction));
            comando.Parameters.Add(SqlParametro("@AtrNameScenario", namescenario));
            comando.Parameters.Add(SqlParametro("@AtrDescription", description));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //regresa 0 si es insertado
        //AddRoleToActor agregar role a una actor
        public int AddRoleToActor(string namearena, string nameactor, string namerole)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AddArenaActorRole", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // name arena, acotr, rol
            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameActor", nameactor));
            comando.Parameters.Add(SqlParametro("@AtrNameRole", namerole));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //regresa 0 si es insertado
        //AddRoleToArena agregar role a una arena
        public int AddRoleToArena(string namearena, string namerole)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AddArenaRole", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // name arena, role
            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameRole", namerole));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }

        //regresa 0 si es insertado
        //AddRoleActancialToArena agregar role actancial a una arena
        public int AddRoleActToArena(string namearena, string nameroleact)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AddArenaRoleActancial", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // name arena, role
            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameRoleAct", nameroleact));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }
        //regresa 0 si es insertado
        //AddRole agregar role
        public int AddRole(string namerole)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AddRole", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // role
            comando.Parameters.Add(SqlParametro("@AtrName", namerole));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }




        //regresa 0 si es insertado
        //AddProcess agregar proceso a un scenario
        public int AddProcessToScenario(string nameprocess)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AddScenarioProcess", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nameprocess
            comando.Parameters.Add(SqlParametro("@AtrNameProcess", nameprocess));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //regresa 0 si es insertado
        //AddType agregar type a un scenario
        public int AddTypeToScenario(string nametype)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AddScenarioType", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nametype
            comando.Parameters.Add(SqlParametro("@AtrNameType", nametype));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //regresa 0 si es insertado
        //AddProcess agregar sentencia un scenario
        public int AddSentenceToScenario(string namearena,string namescenario, string namesentence, string nametype, string nameprocess)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AddScenarioSentence", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            //namearena,  namescenario, nameentence, nametype,nameprocess
            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameScenario", namescenario));
            comando.Parameters.Add(SqlParametro("@AtrNameSentence", namesentence));
            comando.Parameters.Add(SqlParametro("@AtrNameType", nametype));
            comando.Parameters.Add(SqlParametro("@AtrNameProcess", nameprocess));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }





        //Llamadas a los procedimientos de eliminar

        //eliminar acción parametros: idAction
        //regresa 0 si se eliminó satisfactoriamente
        public int DelAction(int idaction)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelIdAction", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // IdAction , variable de retorno

            comando.Parameters.Add(SqlParametro("@IdAction", idaction));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }



        //eliminar acción parametros: idobj
        //regresa 0 si se eliminó satisfactoriamente
        public int DelObject(int idobj)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelIdObject", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // IdAction , variable de retorno

            comando.Parameters.Add(SqlParametro("@IdObj", idobj));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //eliminar acción parametros: AtrName
        //regresa 0 si se eliminó satisfactoriamente
        public int DelObject(string nameobj)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelObject", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // IdAction , variable de retorno

            comando.Parameters.Add(SqlParametro("@AtrName", nameobj));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //eliminar acción parametros: nombre de la acción
        //regresa 0 si se eliminó satisfactoriamente
        public int DelAction(string nameaction)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelAction", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // IdAction , variable de retorno

            comando.Parameters.Add(SqlParametro("@AtrName", nameaction));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }

        //eliminar objeto parametros: idObj, idArena
        //regresa 0 si se eliminó satisfactoriamente
        public int DelObjectOfArena(int namearena, int nameobj)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelIdArenaObject", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // IdAction , variable de retorno

            comando.Parameters.Add(SqlParametro("@IdArena", namearena));
            comando.Parameters.Add(SqlParametro("@IdObj", nameobj));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //eliminar objeto parametros: AtrNameObject, AtrNameArena
        //regresa 0 si se eliminó satisfactoriamente
        public int DelObjectOfArena(string namearena, string nameobj)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelArenaObject", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameObject", nameobj));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }




        //eliminar acción parametros: idRoleAct
        //regresa 0 si se eliminó satisfactoriamente
        public int DelRoleActOfAction(int nameaction, int nameroleact)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelIdActionRoleActancial", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // IdAction , variable de retorno

            comando.Parameters.Add(SqlParametro("@IdAction", nameaction));
            comando.Parameters.Add(SqlParametro("@IdRoleAct", nameroleact));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }

        //eliminar acción parametros: idRoleAct
        //regresa 0 si se eliminó satisfactoriamente
        public int DelRoleActOfAction(string nameaction, string nameroleact)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelActionRoleActancial", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // IdAction , variable de retorno

            comando.Parameters.Add(SqlParametro("@AtrNameAction", nameaction));
            comando.Parameters.Add(SqlParametro("@AtrNameRoleAct", nameroleact));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //eliminar acción parametros: accion y escenario
        //regresa 0 si se eliminó satisfactoriamente
        /*public int DelScenarioOfAction(string namearena, string nameaction, string namescenario)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelActionScenario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // IdAction , variable de retorno

            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameAction", nameaction));
            comando.Parameters.Add(SqlParametro("@AtrNameScenario", namescenario));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }*/

        //eliminar acción parametros: accion y escenario
        //regresa 0 si se eliminó satisfactoriamente
        public int DelScenarioOfAction(int nameaction, int namescenario)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelIdActionScenario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // IdAction , variable de retorno

            comando.Parameters.Add(SqlParametro("@IdAction", nameaction));
            comando.Parameters.Add(SqlParametro("@IdScenario", namescenario));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }

        //eliminar acción parametros: actor
        //regresa 0 si se eliminó satisfactoriamente
        public int DelActor(string nameactor)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelActor", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // IdAction , variable de retorno

            comando.Parameters.Add(SqlParametro("@AtrName", nameactor));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //eliminar acción parametros: actor
        //regresa 0 si se eliminó satisfactoriamente
        public int DelActor(int nameactor)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelIdActor", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // IdAction , variable de retorno

            comando.Parameters.Add(SqlParametro("@IdActor", nameactor));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }



        //eliminar arena parametros: arena
        //regresa 0 si se eliminó satisfactoriamente
        public int DelArena(string namearena)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelArena", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena , variable de retorno

            comando.Parameters.Add(SqlParametro("@AtrName", namearena));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //eliminar arena parametros: arena
        //regresa 0 si se eliminó satisfactoriamente
        public int DelArena(int namearena)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelIdArena", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena , variable de retorno

            comando.Parameters.Add(SqlParametro("@IdArena", namearena));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //eliminar acción de arena parametros: arena, acción
        //regresa 0 si se eliminó satisfactoriamente
        public int DelActionOfArena(string namearena, string nameaction)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelArenaAction", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameAction", nameaction));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //eliminar acción de arena parametros: arena, acción
        //regresa 0 si se eliminó satisfactoriamente
        public int DelActionOfArena(int namearena, int nameaction)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelIdArenaAction", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@IdArena", namearena));
            comando.Parameters.Add(SqlParametro("@IdAction", nameaction));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }




        //eliminar roles act de arena parametros: arena, acción, role act
        //regresa 0 si se eliminó satisfactoriamente
        public int DelRolesActOfAction(string namearena, string nameaction)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelArenaActionRoleAct", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@AtrArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrAction", nameaction));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //eliminar acción de arena parametros: arena, acción
        //regresa 0 si se eliminó satisfactoriamente
        public int DelRolesActOfAction(int namearena, int nameaction)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelIdArenaActionRoleAct", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@IdArena", namearena));
            comando.Parameters.Add(SqlParametro("@IdAction", nameaction));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }



        //regresa 0 si se eliminó satisfactoriamente
        public int DelActorOfArena(int namearena, int nameactor)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelIdArenaActor", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@IdArena", namearena));
            comando.Parameters.Add(SqlParametro("@IdActor", nameactor));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }

        //regresa 0 si se eliminó satisfactoriamente
        public int DelActorOfArena(string namearena, string nameactor)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelArenaActor", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameActor", nameactor));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //eliminar escenario
        //regresa 0 si se eliminó satisfactoriamente
        public int DelScenarioOfAction(string namearena, string nameaction, string namescenario)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelArenaActionScenario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameAction", nameaction));
            comando.Parameters.Add(SqlParametro("@AtrNameScenario", namescenario));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }

        //eliminar escenario
        //regresa 0 si se eliminó satisfactoriamente
        public int DelScenarioOfAction(int namearena, int nameaction, int namescenario)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelIdArenaActionScenario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@IdArena", namearena));
            comando.Parameters.Add(SqlParametro("@IdAction", nameaction));
            comando.Parameters.Add(SqlParametro("@IdScenario", namescenario));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //eliminar escenario
        //regresa 0 si se eliminó satisfactoriamente
        public int DelRoleOfActor(string namearena, string nameactor)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelArenaActorRole", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameActor", nameactor));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }

        //eliminar escenario
        //regresa 0 si se eliminó satisfactoriamente
        public int DelRoleOfActor(int namearena, int nameactor)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelIdArenaActorRole", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@IdArena", namearena));
            comando.Parameters.Add(SqlParametro("@IdActor", nameactor));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }



        //eliminar escenario
        //regresa 0 si se eliminó satisfactoriamente
        public int DelRoleOfArena(string namearena, string namerole)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelArenaRole", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameRole", namerole));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }

        //regresa 0 si se eliminó satisfactoriamente
        public int DelRoleActOfArena(string namearena, string nameroleact)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelArenaRoleActancial", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameRoleAct", nameroleact));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }

        //Mostrar roles arena
        public DataSet GetRolesOfArena(string namearena)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetArenaRoles", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@AtrName", namearena));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTRolesArena");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Mostrar roles actanciales de la arena
        public DataSet GetRolesActOfArena(string namearena)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetArenaRolesActancial", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@AtrName", namearena));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTRolesActArena");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        //eliminar escenario
        //regresa 0 si se eliminó satisfactoriamente
        public int DelRoleOfArena(int namearena, int namerole)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelIdArenaRole", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@IdArena", namearena));
            comando.Parameters.Add(SqlParametro("@IdRole", namerole));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }



        //eliminar role
        //regresa 0 si se eliminó satisfactoriamente
        public int DelRole(string namerole)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelRole", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@AtrName", namerole));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }



        //eliminar role
        //regresa 0 si se eliminó satisfactoriamente
        public int DelRole(int namerole)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelIdRole", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@IdRole", namerole));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }



        //eliminar role atancial
        //regresa 0 si se eliminó satisfactoriamente
        public int DelRoleActancial(string namerole)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelRoleActancial", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@AtrName", namerole));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //eliminar role atancial
        //regresa 0 si se eliminó satisfactoriamente
        public int DelRoleActancial(int namerole)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelIdRoleActancial", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@IdRoleAct", namerole));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //eliminar proceso del escenario
        //regresa 0 si se eliminó satisfactoriamente
        public int DelProcessOfScenario(string nameprocess)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelScenarioProcess", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@AtrName", nameprocess));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //eliminar proceso del escenario
        //regresa 0 si se eliminó satisfactoriamente
        public int DelProcessOfScenario(int nameprocess)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelIdScenarioProcess", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@IdProcess", nameprocess));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //eliminar tipo de sentencias
        //regresa 0 si se eliminó satisfactoriamente
        public int DelTypeOfScenario(string nametype)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelScenarioType", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("AtrName", nametype));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }

        //eliminar tipo de sentencias
        //regresa 0 si se eliminó satisfactoriamente
        public int DelTypeOfScenario(int nametype)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelIdScenarioType", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("IdType", nametype));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //eliminar sentencias
        //regresa 0 si se eliminó satisfactoriamente
        public int DelSentenceOfScenario(string namescenario, int namesentence)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelScenarioSentence", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@AtrNameScenario", namescenario));
            comando.Parameters.Add(SqlParametro("@IdSentence", namesentence));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }


        //eliminar sentencias
        //regresa 0 si se eliminó satisfactoriamente
        public int DelSentenceOfScenario(int namescenario, int namesentence)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("DelIdScenarioSentence", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // nombre arena ,acción variable de retorno

            comando.Parameters.Add(SqlParametro("@IdScenario", namescenario));
            comando.Parameters.Add(SqlParametro("@IdSentence", namesentence));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;
        }

        //--EliminarUsuario 'servkey',0;





        //Mostrar roles actanciales
        public DataSet GetRoleActancialOfAction(string nameaction)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetActionRoleActancial", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // IdTema

            comando.Parameters.Add(SqlParametro("@AtrNameAction", nameaction));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTRoleActancial");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Mostrar roles actions
        public DataSet GetActions()
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetActions", conexion);
            comando.CommandType = CommandType.StoredProcedure;


            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTActions");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Mostrar objetos
        public DataSet GetObjects()
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetObjects", conexion);
            comando.CommandType = CommandType.StoredProcedure;


            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTObjects");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Mostrar objetos de una arena
        public DataSet GetObjectsOfArena(string namearena)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetArenaObjects", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // AtrName - nombre de la arena

            comando.Parameters.Add(SqlParametro("@AtrName", namearena));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTObjects");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Mostrarescenariode una acción
        public DataSet GetScenarioOfAction(string nameaction)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetActionScenarios", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // IdTema

            comando.Parameters.Add(SqlParametro("@AtrName", nameaction));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTScenario");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }



        //Mostrarescenariode una acción
        public DataSet GetActors()
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetActors", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTActors");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        //Mostrar rol actancial una acción
        public DataSet GetRoleActancialOfAction(string namearena, string nameaction)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetArenaActionRoleAct", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            // IdTema

            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameAction", nameaction));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTRoleActancial");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Mostrar acciones de una arena
        public DataSet GetActionsOfArena(string namearena)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetArenaActions", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@AtrName", namearena));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTActions");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Mostrar escenario de una acción
        public DataSet GetScenarioOfAction(string namearena, string nameaction)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetArenaActionScenario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameAction", nameaction));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTScenario");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Mostrar escenario 
        public DataSet GetDataScenarioOfAction(string namearena, string nameaction, string namescenario)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetArenaActionScenarioData", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameAction", nameaction));
            comando.Parameters.Add(SqlParametro("@AtrNameScenario", namescenario));
            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTDataScenario");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Mostrar acciones con rol actancial
        public DataSet GetActionRoleActOfArena(string namearena)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetArenaActionsRolesAct", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTActionRoleAct");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }




        //Mostrar rol de un actor en una arena
        public DataSet GetActorRoleOfArena(string namearena, string nameactor)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetArenaActorRole", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameActor", nameactor));
            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTActorRole");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }




        //Mostrar actores de una arena
        public DataSet GetActorsOfArena(string namearena)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetArenaActors", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@AtrName", namearena));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTActorRole");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }




        //Mostrar actores con roles arena
        public DataSet GetActorsRolesOfArena(string namearena)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetArenaActorsRoles", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTActorRole");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Mostrar role de actor arena
        public DataSet GetRoleOfActor(string namearena, string nameactor)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetArenaActorRole", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameActor", nameactor));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTRoleActorArena");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        //GetArenas
        //Mostrar arenas
        public DataSet GetArenas()
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetArenas", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTArenas");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        //Mostrar arena con llave o id
        public DataSet GetArena(int id)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetArena", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            comando.Parameters.Add(SqlParametro("@IdArena", id));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTArena");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Mostrar arena con llave o id
        public DataSet GetArenaId(string namearena)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetIdArena1", conexion);
            comando.CommandType = CommandType.StoredProcedure;

//            int retorno = (int)sqlHelper.ExecuteScalar(Singleton.Instance.POSConnectionString, "NombreStoredProcedure", new object[] { parametro1, parametro2 });

            //pasar parametros
            comando.Parameters.Add(SqlParametro("@AtrName", namearena));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTArena");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Mostrar arena con llave o id
        public DataSet GetScenarioId(string namearena,string namescenario)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetIdScenario1", conexion);
            comando.CommandType = CommandType.StoredProcedure;


            //pasar parametros
            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrNameScenario", namescenario));
            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTScenario");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        //Mostrar role con llave o id
        public DataSet GetRoleId(string namerole)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetIdRole1", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            comando.Parameters.Add(SqlParametro("@AtrName", namerole));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTArena");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Mostrar scenarios de la arena
        public DataSet GetScenariosOfArena(string namearena)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetArenaScenarios", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            comando.Parameters.Add(SqlParametro("@AtrName", namearena));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTArena");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Mostrar procesos de escenario
        public DataSet GetProcessOfSentece()
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetProcessSentence", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTProcess");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Mostrar Roles
        public DataSet GetRoles()
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetRoles", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTRoles");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Mostrar Roles Actanciales
        public DataSet GetRolesActancial()
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetRolesActancial", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTRolesAct");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }



        //Mostrar sentencias of escenario
        public DataSet GetSentencesOfScenario(string namearena,string namescenario)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetScenarioSentences", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            comando.Parameters.Add(SqlParametro("@AtrNameArena", namearena));
            comando.Parameters.Add(SqlParametro("@AtrName", namescenario));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTScenario");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }




        //Mostrar sentencias que existen en un escenario
        public DataSet GetTypeOfSentence()
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GetTypeSentence", conexion);
            comando.CommandType = CommandType.StoredProcedure;


            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTTypeSentence");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }





        //Modificar action
        //regresa distinto de 0 si es modificado correctamente
        public int updateAction(int idaction, string nameaction)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("updateAction", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@IdAction", idaction));
            comando.Parameters.Add(SqlParametro("@AtrNameActionUpdate", nameaction));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }



        //Modificar objeto
        //regresa distinto de 0 si es modificado correctamente
        public int updateObject(int idobj, string nameobjU, string valU)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("updateObject", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@IdObj", idobj));
            comando.Parameters.Add(SqlParametro("@AtrNameObjUpdate", nameobjU));
            comando.Parameters.Add(SqlParametro("@AtrNameValUpdate", valU));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }




        //Modificar actor
        //regresa distinto de 0 si es modificado correctamente
        public int updateActor(int idactor, string nameactor)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("updateActor", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@IdActor", idactor));
            comando.Parameters.Add(SqlParametro("@AtrNameActorUpdate", nameactor));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }



        //Modificar arena
        //regresa distinto de 0 si es modificado correctamente
        public int updateArena(int idarena, string namearena)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("updateArena", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@IdArena", idarena));
            comando.Parameters.Add(SqlParametro("@AtrNameArenaUpdate", namearena));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }



        //Modificar role
        //regresa distinto de 0 si es modificado correctamente
        public int updateRole(int idrole, string namerole)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("updateRole", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@IdRole", idrole));
            comando.Parameters.Add(SqlParametro("@AtrNameRoleUpdate", namerole));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }

        //Modificar role actancial
        //regresa distinto de 0 si es modificado correctamente
        public int updateRoleActancial(int idroleact, string nameroleact)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("updateRoleActancial", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@IdRoleAct", idroleact));
            comando.Parameters.Add(SqlParametro("@AtrNameRoleActUpdate", nameroleact));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }



        //Modificar scenario
        //regresa distinto de 0 si es modificado correctamente
        public int updateScenario(int idscenario, string namescenario, string namedescription)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("updateScenario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@IdScenario", idscenario));
            comando.Parameters.Add(SqlParametro("@AtrNameScenarioUpdate", namescenario));
            comando.Parameters.Add(SqlParametro("@AtrNameDescriptionUpdate", namedescription));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }



        //Modificar sentencia
        //regresa distinto de 0 si es modificado correctamente
        public int updateSentence(int idsentence, string namesentence)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("updateSentence", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@IdSentence", idsentence));
            comando.Parameters.Add(SqlParametro("@AtrNameSentenceUpdate", namesentence));

            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }

        //Modificar process de una sentencia
        //regresa distinto de 0 si es modificado correctamente
        public int updateProcessOfScentence(int idsentence, string nameprocess)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("updateSentenceProcess", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@IdSentence", idsentence));
            comando.Parameters.Add(SqlParametro("@AtrNameProcessUpdate", nameprocess));

            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }


        //Modificar types de una sentencia
        //regresa distinto de 0 si es modificado correctamente
        public int updateTypeOfScentence(int idsentence, string nametype)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("updateSentenceType", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@IdSentence", idsentence));
            comando.Parameters.Add(SqlParametro("@AtrNameTypeUpdate", nametype));

            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }




        //ModificarUsuario 'mjl1208','Equipo desarrollo', 'equipo@hot.com', '123456',2,0 ;
        public int ModificarUsuario(string usuario, string nombre, string email, string password)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("ModificarUsuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros
            //ModificarUsuario 'mjl1208','Equipo desarrollo', 'equipo@hot.com', '123456',2,0 ;

            comando.Parameters.Add(SqlParametro("@AtrUsuario", usuario));
            comando.Parameters.Add(SqlParametro("@AtrNombre", nombre));
            comando.Parameters.Add(SqlParametro("@AtrEmail", email));
            comando.Parameters.Add(SqlParametro("@AtrPassword", password));
            comando.Parameters.Add(SqlParametro("@IdNivelUsuario", 2));
            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;

        }


        public int SolicitarUnirse(string usuario, int idgrupo, DateTime fecha)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("SolicitarUnirse", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@AtrUsuario", usuario));
            comando.Parameters.Add(SqlParametro("@IdGrupos", idgrupo));
            comando.Parameters.Add(SqlParametro("@AtrFecha", fecha));

            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;

        }

        public int UnirseGrupo(string usuario, int idgrupo)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("UnirseGrupo", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@AtrUsuario", usuario));
            comando.Parameters.Add(SqlParametro("@IdGrupos", idgrupo));

            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;

        }



        public int EnviarMensajeUsuario(string titulo, string mensaje,
            string usuarioO, string usuarioD)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("EnviarMensajeUsuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@AtrTitulo", titulo));
            comando.Parameters.Add(SqlParametro("@AtrMensaje", mensaje));
            comando.Parameters.Add(SqlParametro("@AtrUsuarioO", usuarioO));
            comando.Parameters.Add(SqlParametro("@AtrUsuarioD", usuarioD));
            comando.Parameters.Add(SqlParametro("@AtrFecha", DateTime.Now));

            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;

        }


        public int AgregarEventoGrupo(string nombre, int idgrupo, DateTime fecha)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AgregarEventoGrupo", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@Nombre", nombre));
            comando.Parameters.Add(SqlParametro("@IdGrupos", idgrupo));
            comando.Parameters.Add(SqlParametro("@Fecha", fecha));

            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;

        }


        public int AgregarEventoUsuario(string nombre, string usuario, DateTime fecha)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("AgregarEventoUsuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@Nombre", nombre));
            comando.Parameters.Add(SqlParametro("@Usuario", usuario));
            comando.Parameters.Add(SqlParametro("@Fecha", fecha));


            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;

        }



        public int EnviarDocumentoGrupo(string nombre,
            string usuario, int idgrupo)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("EnviarDocumentoGrupo", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@Nombre", nombre));
            comando.Parameters.Add(SqlParametro("@Usuario", usuario));
            comando.Parameters.Add(SqlParametro("@IdGrupos", idgrupo));
            comando.Parameters.Add(SqlParametro("@Fecha", DateTime.Now));

            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;

        }

        public int EnviarDocumentoUsuario(string nombre,
            string usuarioD, string usuarioO)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("EnviarDocumentoUsuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@Nombre", nombre));
            comando.Parameters.Add(SqlParametro("@UsuarioD", usuarioD));
            comando.Parameters.Add(SqlParametro("@UsuarioO", usuarioO));
            comando.Parameters.Add(SqlParametro("@Fecha", DateTime.Now));

            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;

        }

        public DataSet MostrarDocumentosUsuario(string idusuario)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("MostrarDocumentosUsuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add(SqlParametro("@AtrUsuario", idusuario));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTUsuarios");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet MostrarEventosUsuario(string idusuario)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("MostrarEventosUsuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add(SqlParametro("@AtrUsuario", idusuario));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTUsuarios");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        public DataSet MostrarEventosGrupo(int idgrupo)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("MostrarEventosGrupo", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add(SqlParametro("@IdGrupos", idgrupo));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTUsuarios");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public DataSet MostrarDocumentosGrupos(int idgrupo)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("MostrarDocumentosGrupo", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add(SqlParametro("@IdGrupos", idgrupo));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTUsuarios");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        //EliminarEvento 1,0
        public int EliminarEventoGrupo(int idagendas)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("EliminarEventoGrupo", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@IdAgendas", idagendas));

            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;

        }

        public int EliminarEventoUsuario(int idagendas)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("EliminarEventoUsuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@IdAgendas", idagendas));

            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;

        }

        //EliminarSolicitud 1,0
        public int EliminarSolicitud(int idmensaje)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("EliminarSolicitud", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@IdMensajes", idmensaje));

            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;

        }


        public int EliminarMensajeUsuario(int idmensaje)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("EliminarMensajeUsuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@IdMensajes", idmensaje));

            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;

        }


        public int VerificarGrupo(int idgrupo, string usuario)
        {
            int resultado = 0;
            SqlConnection conexion = getConexion();

            SqlCommand comando = new SqlCommand("VerificarGrupo", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //pasar parametros

            comando.Parameters.Add(SqlParametro("@AtrUsuario", usuario));
            comando.Parameters.Add(SqlParametro("@IdGrupos", idgrupo));

            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;

        }


        //Se muestran los grupos en los que estan unido el usuario
        public DataSet GruposUsuario(string idusuario)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("GruposUsuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add(SqlParametro("@AtrUsuario", idusuario));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTUsuarios");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        //Se muestran los mensajes de un usuario
        public DataSet MostrarMensajesUsuario(string idusuario)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("MostrarMensajesUsuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add(SqlParametro("@AtrUsuario", idusuario));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTUsuarios");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }




        //Se muestran los mensajes de un usuario
        public DataSet MostrarMensajesSolicitudes(string idusuario)
        {
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("MostrarMensajesSolicitudes", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add(SqlParametro("@AtrUsuario", idusuario));

            //preparar el dataset
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = comando;
            DataSet Datos = new DataSet();
            try
            {
                conexion.Open();
                Adaptador.Fill(Datos, "DTUsuarios");
                return Datos;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        //ValidarUsuario 'Administrador','vgfm186'
        public int AuthenticarUsuario(string usuario, string password)
        {
            int resultado = -1;
            SqlConnection conexion = getConexion();
            SqlCommand comando = new SqlCommand("AuthenticarUsuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            //parametros
            comando.Parameters.Add(SqlParametro("@AtrUsuario", usuario));
            comando.Parameters.Add(SqlParametro("@AtrPassword", password));


            SqlParameter Existe = SqlParametro("@Existe", 0);
            comando.Parameters.Add(Existe);

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                resultado = (int)Existe.Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                conexion.Close();
            }
            return resultado;

        }
    }

}