using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Entity.Proxies
{


    public abstract class usp_genericaAuto_INSERT_SERVICE
    {


        public static int usp_genericaAuto_INSERT(
			string Vettura,
			System.DateTime data,
			Int32 km,
			string intervento,
			double litri,
			double euro,
			double gasolio_euro_litro,
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
            cmd.CommandText = "usp_genericaAuto_INSERT";
            //
			int writingSucceeded = -1;// init to error:no_connection.
			//
			//
            System.Data.SqlClient.SqlParameter parVettura = new SqlParameter();
            parVettura.Direction = ParameterDirection.Input;
            parVettura.DbType = DbType.String;
            parVettura.ParameterName = "@Vettura";
			cmd.Parameters.Add( parVettura);// add to command
			if( null!=Vettura && ""!=Vettura )
			{
				parVettura.Value = Vettura;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			}
			else
			{
				parVettura.Value = System.DBNull.Value;
			}
			//
            System.Data.SqlClient.SqlParameter pardata = new SqlParameter();
            pardata.Direction = ParameterDirection.Input;
            pardata.DbType = DbType.DateTime;
            pardata.ParameterName = "@data";
			cmd.Parameters.Add( pardata);// add to command
			if( System.DateTime.MinValue<data )
			{
				pardata.Value = data;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			}
			else
			{
				pardata.Value = System.DBNull.Value;
			}
			//
            System.Data.SqlClient.SqlParameter parkm = new SqlParameter();
            parkm.Direction = ParameterDirection.Input;
            parkm.DbType = DbType.Int32;
            parkm.ParameterName = "@km";
			cmd.Parameters.Add( parkm);// add to command
			if( 0<km )
			{
				parkm.Value = km;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			}
			else
			{
				parkm.Value = System.DBNull.Value;
			}
			//
            System.Data.SqlClient.SqlParameter parintervento = new SqlParameter();
            parintervento.Direction = ParameterDirection.Input;
            parintervento.DbType = DbType.String;
            parintervento.ParameterName = "@intervento";
			cmd.Parameters.Add( parintervento);// add to command
			if( null!=intervento && ""!=intervento )
			{
				parintervento.Value = intervento;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			}
			else
			{
				parintervento.Value = System.DBNull.Value;
			}
			//
            System.Data.SqlClient.SqlParameter parlitri = new SqlParameter();
            parlitri.Direction = ParameterDirection.Input;
            parlitri.DbType = DbType.Double;
            parlitri.ParameterName = "@litri";
			cmd.Parameters.Add( parlitri);// add to command
			if(  !double.IsNaN(litri)  && !double.IsInfinity(litri) )
			{
				parlitri.Value = litri;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			}
			else
			{
				parlitri.Value = System.DBNull.Value;
			}
			//
            System.Data.SqlClient.SqlParameter pareuro = new SqlParameter();
            pareuro.Direction = ParameterDirection.Input;
            pareuro.DbType = DbType.Double;
            pareuro.ParameterName = "@euro";
			cmd.Parameters.Add( pareuro);// add to command
			if(  !double.IsNaN(euro)  && !double.IsInfinity(euro) )
			{
				pareuro.Value = euro;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			}
			else
			{
				pareuro.Value = System.DBNull.Value;
			}
			//
            System.Data.SqlClient.SqlParameter pargasolio_euro_litro = new SqlParameter();
            pargasolio_euro_litro.Direction = ParameterDirection.Input;
            pargasolio_euro_litro.DbType = DbType.Double;
            pargasolio_euro_litro.ParameterName = "@gasolio_euro_litro";
			cmd.Parameters.Add( pargasolio_euro_litro);// add to command
			if(  !double.IsNaN(gasolio_euro_litro)  && !double.IsInfinity(gasolio_euro_litro) )
			{
				pargasolio_euro_litro.Value = gasolio_euro_litro;// checks ok -> ProxyParemeter value assigned to the SqlParameter.
			}
			else
			{
				pargasolio_euro_litro.Value = System.DBNull.Value;
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
                        "eccezione in DataAccess::usp_genericaAuto_INSERT_SERVICE : " + ex.Message,
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
