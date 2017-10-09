using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Salaries.Data
{
	/// <summary>
	/// DbObject is the class from which all classes in the Data Services
	/// Tier inherit. The core functionality of establishing a connection
	/// with the database and executing simple stored procedures is also
	/// provided by this base class.
	/// </summary>
	public abstract class DbObject: IDisposable
	{
		private SqlConnection connection;
		private string connectionString;

		// If mananged and unmanaged resources have not been disposed of, the member is false, 
		// true otherwise.
		private bool disposed;

		#region Constructor
		/// <summary>
		/// A parameterized constructor, it allows us to take a connection
		/// string as a constructor argument, automatically instantiating
		/// a new connection.
		/// </summary>
		/// <param name="newConnectionString">Connection String to the associated database</param>
		protected DbObject( string connectionString )
		{
			this.connectionString = connectionString;
			connection = new SqlConnection( connectionString );
		}
		#endregion

		#region Properties
		/// <summary>
		/// Conexiunea la baza de date SqlServer.
		/// </summary>
		public SqlConnection Connection
		{
			set
			{
				connection = value;
			}
			get
			{
				return connection;
			}
		}	

		/// <summary>
		/// Protected property that exposes the connection string
		/// to inheriting classes. Read-Only.
		/// </summary>
		protected string ConnectionString
		{
			get 
			{
				return connectionString;
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Private routine allowed only by this base class, it automates the task
		/// of building a SqlCommand object designed to obtain a return value from
		/// the stored procedure.
		/// </summary>
		/// <param name="storedProcName">Name of the stored procedure in the DB, eg. sp_DoTask</param>
		/// <param name="parameters">Array of IDataParameter objects containing parameters to the stored proc</param>
		/// <returns>Newly instantiated SqlCommand instance</returns>
		private SqlCommand BuildIntCommand(string storedProcName, IDataParameter[] parameters)
		{
			SqlCommand command = BuildQueryCommand( storedProcName, parameters );			
			//Added: Ionel Popa
			command.CommandTimeout = 20 * 60;
			command.Parameters.Add( new SqlParameter ( "ReturnValue",
				SqlDbType.Int,
				4, /* Size */
				ParameterDirection.ReturnValue,
				false, /* is nullable */
				0, /* byte precision */
				0, /* byte scale */
				string.Empty,
				DataRowVersion.Default,
				null ));

			return command;
		}


		/// <summary>
		/// Builds a SqlCommand designed to return a SqlDataReader, and not
		/// an actual integer value.
		/// </summary>
		/// <param name="storedProcName">Name of the stored procedure</param>
		/// <param name="parameters">Array of IDataParameter objects</param>
		/// <returns></returns>
		private SqlCommand BuildQueryCommand(string storedProcName, IDataParameter[] parameters)
		{
			SqlCommand command = new SqlCommand( storedProcName, connection );
			command.CommandType = CommandType.StoredProcedure;
			//Added: Ionel Popa
			command.CommandTimeout = 20 * 60;

			foreach (SqlParameter parameter in parameters)
			{
				command.Parameters.Add( parameter );
			}

			return command;

		}

		/// <summary>
		/// Runs a stored procedure, can only be called by those classes deriving
		/// from this base. It returns an integer indicating the return value of the
		/// stored procedure, and also returns the value of the RowsAffected aspect
		/// of the stored procedure that is returned by the ExecuteNonQuery method.
		/// </summary>
		/// <param name="storedProcName">Name of the stored procedure</param>
		/// <param name="parameters">Array of IDataParameter objects</param>
		/// <param name="rowsAffected">Number of rows affected by the stored procedure.</param>
		/// <returns>An integer indicating return value of the stored procedure</returns>
		protected int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected )
		{
			int result;

			connection.Open();
			SqlCommand command = BuildIntCommand( storedProcName, parameters );
			rowsAffected = command.ExecuteNonQuery();
			result = (int)command.Parameters["ReturnValue"].Value;
			connection.Close();
			return result;
		}
		
		/// <summary>
		/// Will run a stored procedure, can only be called by those classes deriving
		/// from this base. It returns a SqlDataReader containing the result of the stored
		/// procedure.
		/// </summary>
		/// <param name="storedProcName">Name of the stored procedure</param>
		/// <param name="parameters">Array of parameters to be passed to the procedure</param>
		/// <returns>A newly instantiated SqlDataReader object</returns>
		protected SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters )
		{
			SqlDataReader returnReader;

			connection.Open();
			SqlCommand command = BuildQueryCommand( storedProcName, parameters );
			command.CommandType = CommandType.StoredProcedure;

			returnReader = command.ExecuteReader();
			connection.Close();
			return returnReader;
		}

		/// <summary>
		/// Creates a DataSet by running the stored procedure and placing the results
		/// of the query/proc into the given tablename.
		/// </summary>
		/// <param name="storedProcName"></param>
		/// <param name="parameters"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		protected DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName )
		{
			DataSet dataSet = new DataSet();
			dataSet.Locale = CultureInfo.InvariantCulture;
			connection.Open();
			SqlDataAdapter sqlDA = new SqlDataAdapter();
			sqlDA.SelectCommand = BuildQueryCommand( storedProcName, parameters );
			sqlDA.Fill( dataSet, tableName );
			connection.Close();

			return dataSet;
		}

		/// <summary>
		/// Takes an -existing- dataset and fills the given table name with the results
		/// of the stored procedure.
		/// </summary>
		/// <param name="storedProcName"></param>
		/// <param name="parameters"></param>
		/// <param name="dataSet"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		protected void RunProcedure(string storedProcName, IDataParameter[] parameters, DataSet dataSet, string tableName )
		{
			connection.Open();
			SqlDataAdapter sqlDA = new SqlDataAdapter();
			sqlDA.SelectCommand = BuildIntCommand( storedProcName, parameters );
			sqlDA.Fill( dataSet, tableName );
			connection.Close();			
		}

		static public SqlParameter AddInputParameter( string parameterName, SqlDbType parameterType, int parameterSize, object parameterValue)
		{
			SqlParameter param = new SqlParameter(parameterName, parameterType, parameterSize);
			param.Direction = ParameterDirection.Input;
			param.Value = parameterValue;

			return param;
		}

		static public SqlParameter AddOutputParameter( string parameterName, SqlDbType parameterType, int parameterSize)
		{
			SqlParameter param = new SqlParameter(parameterName, parameterType, parameterSize);
			param.Direction = ParameterDirection.Output;
			

			return param;
		}
		#endregion
		
		#region Destructor

		/// <summary>
		/// Destructor.
		/// </summary>
		~DbObject()
		{
			Dispose(false);
		}
		#endregion

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing,
		/// or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			// Dispose of the managed and unmanaged resources.
			Dispose(true);

			// Tell the GC that the Finalize process no longer needs
			// to be run for this object.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// If disposeManagedResources equals true, the method has been called directly
		/// or indirectly by a user's code. Managed and unmanaged resources can be disposed.
		/// If disposing equals false, the method has been called by the runtime from inside
		/// the finalizer and you should not reference other objects. 
		/// </summary>
		protected virtual void Dispose(bool disposeManagedResources)
		{
			// Process only if mananged and unmanaged resources have not been disposed of.
			if (!this.disposed)
			{
				if (disposeManagedResources)
				{
					// Dispose managed resources.
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
				
				this.disposed = true;
			}
		}
		#endregion
	}
}
