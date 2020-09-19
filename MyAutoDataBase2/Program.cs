using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace MyAutoDataBase
{
    class Program
    {
        static void Main()
        {
            DbProviderFactories.RegisterFactory("provider", SqlClientFactory.Instance);
            var providerFactory = DbProviderFactories.GetFactory("provider");

            DataSet dataSet = new DataSet("myAutoDb");
            var dataAdapter = providerFactory.CreateDataAdapter();
            var connection = providerFactory.CreateConnection();
            var selectCommand = providerFactory.CreateCommand();

            connection.ConnectionString = @"Provider=1-PC\SQLEXPRESS;Data Source=1-PC\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=msdb";
            selectCommand.CommandText = "select * from Users";

            selectCommand.Connection = connection;
            dataAdapter.SelectCommand = selectCommand;

            var commandBuilder = providerFactory.CreateCommandBuilder();
            commandBuilder.DataAdapter = dataAdapter;

            DataTable usersTable = new DataTable("Users");

            DataColumn idColumn = new DataColumn
            {
                ColumnName = "Id",
                DataType = typeof(int),
                AllowDBNull = false,
                AutoIncrement = true,
                Unique = true
            };

            usersTable.Columns.Add(idColumn);
            usersTable.PrimaryKey = new DataColumn[] { idColumn };

            DataColumn loginColumn = new DataColumn
            {
                ColumnName = "Login",
                DataType = typeof(string),
                AllowDBNull = false,
                AutoIncrement = true,
                Unique = true,
                MaxLength = 20
            };

            usersTable.Columns.Add(loginColumn);

            DataColumn PasswordColumn = new DataColumn
            {
                ColumnName = "Password",
                DataType = typeof(string),
                AllowDBNull = false,
                AutoIncrement = true,
                Unique = true,
                MaxLength = 20
            };

            usersTable.Columns.Add(PasswordColumn);

            DataTable ticketTable = new DataTable("Ticket");
            ticketTable.Columns.Add(idColumn);
            ticketTable.PrimaryKey = new DataColumn[] { idColumn };

            DataColumn nameOfTicet = new DataColumn
            {
                ColumnName = "nameOfTicet",
                DataType = typeof(string),
                AllowDBNull = false,
                AutoIncrement = true,
                Unique = true,
                MaxLength = 20
            };

            ticketTable.Columns.Add(nameOfTicet);

            DataColumn type = new DataColumn
            {
                ColumnName = "typeOfTicket",
                DataType = typeof(string),
                AllowDBNull = false,
                AutoIncrement = true,
                Unique = true,
                MaxLength = 20
            };

            ticketTable.Columns.Add(type);

            dataAdapter.Fill(dataSet);
        }
    }
}

