using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace ProjetoCrudVarejo
{
    internal class ConexaoCliente
    {
        private static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["ProjetoCrudVarejoDb"].ConnectionString;

        public bool ExecutarComandos(string sql, params MySqlParameter[] parametros)
        {
            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (parametros != null && parametros.Length > 0)
                    {
                        cmd.Parameters.AddRange(parametros);
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar o comando no banco de dados.", ex);
            }
        }

        public DataTable ExecutarConsulta(string sql, params MySqlParameter[] parametros)
        {
            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                using (var cmd = new MySqlCommand(sql, conn))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    if (parametros != null && parametros.Length > 0)
                    {
                        cmd.Parameters.AddRange(parametros);
                    }

                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar a consulta no banco de dados.", ex);
            }
        }
    }
}
