using System.Configuration;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class Conectabd
    {
        private readonly string _cadena = ConfigurationManager.ConnectionStrings["ConectaBdapartados"].ConnectionString;
        SqlConnection _sqlConnection;
        public SqlConnection OpenDb()
        {
            try
            {
                if (!(string.IsNullOrEmpty(_cadena)))
                {
                    _sqlConnection = new SqlConnection(_cadena);
                    _sqlConnection.Open();
                }
            }
            catch (SqlException ex)
            {
                ex.GetBaseException();
            }
            return _sqlConnection;
        }

        public void CloseDb()
        {
            try
            {
                if (_sqlConnection == null) return;
                _sqlConnection.Close();
                _sqlConnection = null;
            }
            catch (SqlException ex)
            {
                ex.GetBaseException();
            }
        }
    }
}