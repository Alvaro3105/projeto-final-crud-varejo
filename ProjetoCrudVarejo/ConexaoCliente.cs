using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCrudVarejo
{
    internal class ConexaoCliente
    {
        MySqlConnection conn;

        public void ConectarBD()
        {
            try
            {
                conn = new MySqlConnection("Persist Security info = false; server = localhost; database = projetocrudvarejo; user=root; pwd=;");
                conn.Open();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool ExecutarComandos(string sql)
        {
            try
            {
                //Abrir conexão
                ConectarBD();
                //Preparar o comadno
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //Executar comando
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar o comando: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        public DataTable ExecutarConsulta(string sql)
        {
            try
            {
                ConectarBD();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar a consulta: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }

}
