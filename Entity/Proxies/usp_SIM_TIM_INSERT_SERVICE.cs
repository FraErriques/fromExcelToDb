using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Entity.Proxies
{


    public abstract class usp_SIM_TIM_INSERT_SERVICE
    {


        public static int usp_SIM_TIM_INSERT(
			string beneficiario,
			string servizio,
			string numero,
			string PIN,
			string PUK,
			string ICCID,
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
						"Tim2021"
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
            cmd.CommandText = "usp_SIM_TIM_INSERT";
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
            System.Data.SqlClient.SqlParameter parservizio = new SqlParameter();
            parservizio.Direction = ParameterDirection.Input;
            parservizio.DbType = DbType.String;
            parservizio.ParameterName = "@servizio";
			cmd.Parameters.Add( parservizio);// add to command
			if( null!=servizio && ""!=servizio )
			{
				parservizio.Value = servizio;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			}
			else
			{
				parservizio.Value = System.DBNull.Value;
			}
			//
            System.Data.SqlClient.SqlParameter parnumero = new SqlParameter();
            parnumero.Direction = ParameterDirection.Input;
            parnumero.DbType = DbType.String;
            parnumero.ParameterName = "@numero";
			cmd.Parameters.Add( parnumero);// add to command
			if( null!=numero && ""!=numero )
			{
				parnumero.Value = numero;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			}
			else
			{
				parnumero.Value = System.DBNull.Value;
			}
			//
            System.Data.SqlClient.SqlParameter parPIN = new SqlParameter();
            parPIN.Direction = ParameterDirection.Input;
            parPIN.DbType = DbType.String;
            parPIN.ParameterName = "@PIN";
			cmd.Parameters.Add( parPIN);// add to command
			if( null!=PIN && ""!=PIN )
			{
				parPIN.Value = PIN;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			}
			else
			{
				parPIN.Value = System.DBNull.Value;
			}
			//
            System.Data.SqlClient.SqlParameter parPUK = new SqlParameter();
            parPUK.Direction = ParameterDirection.Input;
            parPUK.DbType = DbType.String;
            parPUK.ParameterName = "@PUK";
			cmd.Parameters.Add( parPUK);// add to command
			if( null!=PUK && ""!=PUK )
			{
				parPUK.Value = PUK;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			}
			else
			{
				parPUK.Value = System.DBNull.Value;
			}
			//
            System.Data.SqlClient.SqlParameter parICCID = new SqlParameter();
            parICCID.Direction = ParameterDirection.Input;
            parICCID.DbType = DbType.String;
            parICCID.ParameterName = "@ICCID";
			cmd.Parameters.Add( parICCID);// add to command
			if( null!=ICCID && ""!=ICCID )
			{
				parICCID.Value = ICCID;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			}
			else
			{
				parICCID.Value = System.DBNull.Value;
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
                        "eccezione in DataAccess::usp_riscontro8767_INSERT_SERVICE : " + ex.Message,
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
