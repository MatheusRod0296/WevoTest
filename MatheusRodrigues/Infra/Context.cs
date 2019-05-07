using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Infra
{
    /// <summary>
    /// classe controla a abertura e fechamanto das conexão com o bd
    /// </summary>
    public class Context: IDisposable
    {
     
        public SqlConnection Connection { get; }

        protected readonly ConnectionString _connection;


        public Context(IOptions<ConnectionString> connection)
        {
           
            Connection = new SqlConnection(connection.Value.Connection);
            Connection.Open();
        }



        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
            {
                Connection.Dispose();
            }
        }
    }
}
