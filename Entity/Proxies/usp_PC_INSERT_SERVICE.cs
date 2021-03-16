using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Entity.Proxies
{


    public abstract class usp_PC_INSERT_SERVICE
    {


        public static int usp_PC_INSERT(
			string beneficiario,
			string oggetto,
			string matricola,
			string note,
			System.Data.SqlClient.SqlTransaction trx		//
		)
		{
            //
            SqlCommand cmd = new SqlCommand();
            if (null == trx)
            {
				cmd.Connection =
					DbLayer.ConnectionManager.connectWithCustomSingleXpath(
						"ProxyGeneratorConnections/strings",// compulsory xpath
						"dotazioni2021"
					);
            }
            else
            {
                cmd.Connection = trx.Connection;
                cmd.Transaction = trx;
            }            
            if( null==cmd.Connection)
                return -1;// no conn
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_PC_INSERT";
            //
			int writingSucceeded = -1;// init to error:no_connection.
			//
			//
            System.Data.SqlClient.SqlParameter parbeneficiario = new SqlParameter();
            parbeneficiario.Direction = ParameterDirection.Input;
            parbeneficiario.DbType = DbType.String;
            parbeneficiario.ParameterName = "@beneficiario";
			cmd.Parameters.Add( parbeneficiario);// add to command
			if( null!=beneficiario && ""!=beneficiario )
			{
				parbeneficiario.Value = beneficiario;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			}
			else
			{
				parbeneficiario.Value = System.DBNull.Value;
			}
			//
            System.Data.SqlClient.SqlParameter paroggetto = new SqlParameter();
            paroggetto.Direction = ParameterDirection.Input;
            paroggetto.DbType = DbType.String;
            paroggetto.ParameterName = "@oggetto";
			cmd.Parameters.Add( paroggetto);// add to command
			if( null!=oggetto && ""!=oggetto )
			{
				paroggetto.Value = oggetto;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			}
			else
			{
				paroggetto.Value = System.DBNull.Value;
			}
			//
            System.Data.SqlClient.SqlParameter parmatricola = new SqlParameter();
            parmatricola.Direction = ParameterDirection.Input;
            parmatricola.DbType = DbType.String;
            parmatricola.ParameterName = "@matricola";
			cmd.Parameters.Add( parmatricola);// add to command
			if( null!=matricola && ""!=matricola )
			{
				parmatricola.Value = matricola;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			}
			else
			{
				parmatricola.Value = System.DBNull.Value;
			}
			//
            System.Data.SqlClient.SqlParameter parnote = new SqlParameter();
            parnote.Direction = ParameterDirection.Input;
            parnote.DbType = DbType.String;
            parnote.ParameterName = "@note";
			cmd.Parameters.Add( parnote);// add to command
			if( null!=note && ""!=note )
			{
				parnote.Value = note;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			}
			else
			{
				parnote.Value = System.DBNull.Value;
			}

            //
            try
            {
				//
                int rowsWritten =
                    cmd.ExecuteNonQuery();
                //
                if (1 <= rowsWritten )
                    writingSucceeded = 0;// rows written ok
                else
                    writingSucceeded = 4;// errore logico senza exception
				//
				//
            }
            catch (Exception ex)
            {
				//
				//
				/// <returns>
				/// -1  no connection
				/// 0   ok
				/// 1   sqlException chiave duplicata
				/// 2   sqlException diversa da chiave duplicata
				/// 3   eccezione NON sql
				/// 4   errore logico senza Exception
				/// ...
				/// >4  altre eccezioni TODO:dettagliare in fututo
				/// 
				/// </returns>
                //
                //---------------------exception nature discrimination----------------------
                writingSucceeded =
                    LoggingToolsContainerNamespace.LoggingToolsContainer.DecideAndLog(
                        ex,
                        "eccezione in DataAccess::usp_PC_INSERT_SERVICE : " + ex.Message,
						0 // verbosity
                );
                //
            }// end catch
            finally
            {
				if( null == trx)
				{
					if (null != cmd.Connection)
						if (System.Data.ConnectionState.Open == cmd.Connection.State)
							cmd.Connection.Close();
                }// else preserve transaction
            }
            // ready
            return writingSucceeded;// writing result is an integer.
        }// end service


    }// end class
}// end namespace
