using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Entity.Proxies
{


    public abstract class usp_prova456_INSERT_SERVICE
    {


        public static int usp_prova456_INSERT(
			double un_razionale,
			Int64 un_intero,//---######################## manually modified from Int32 to Int64 ###########################à
			System.DateTime una_data_senzaOra,
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
            cmd.CommandText = "usp_prova456_INSERT";
            //
			int writingSucceeded = -1;// init to error:no_connection.
			//
			//
            System.Data.SqlClient.SqlParameter parun_razionale = new SqlParameter();
            parun_razionale.Direction = ParameterDirection.Input;
            parun_razionale.DbType = DbType.Double;
            parun_razionale.ParameterName = "@un_razionale";
			cmd.Parameters.Add( parun_razionale);// add to command
			if( ! double.IsNaN( un_razionale) 
                && ! double.IsInfinity( un_razionale)  ) 
			{
				parun_razionale.Value = un_razionale;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			}
			else
			{
				parun_razionale.Value = System.DBNull.Value;
			}
			//
            System.Data.SqlClient.SqlParameter parun_intero = new SqlParameter();
            parun_intero.Direction = ParameterDirection.Input;
            parun_intero.DbType = DbType.Int64;//---ddecide Int size 16,32,...
            parun_intero.ParameterName = "@un_intero";
			cmd.Parameters.Add( parun_intero);// add to command
            if (Int64.MinValue < un_intero//########################################---NB. manually modified!---------########################################################
                && Int64.MaxValue > un_intero)
            {
                parun_intero.Value = un_intero;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
            }
            else
            {
                parun_intero.Value = System.DBNull.Value;
            }
			//
            System.Data.SqlClient.SqlParameter paruna_data_senzaOra = new SqlParameter();
            paruna_data_senzaOra.Direction = ParameterDirection.Input;
            paruna_data_senzaOra.DbType = DbType.DateTime;
            paruna_data_senzaOra.ParameterName = "@una_data_senzaOra";
			cmd.Parameters.Add( paruna_data_senzaOra);// add to command
            if (new System.DateTime(2000, 01, 01) < una_data_senzaOra//########################################---NB. manually modified!---------#######################################
                && System.DateTime.Today > una_data_senzaOra)
            {
                paruna_data_senzaOra.Value = una_data_senzaOra;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
            }
            else
            {
                paruna_data_senzaOra.Value = System.DBNull.Value;
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
                        "eccezione in DataAccess::usp_prova456_INSERT_SERVICE : " + ex.Message,
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
