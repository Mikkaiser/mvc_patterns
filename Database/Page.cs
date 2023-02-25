using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Database;
public class Page
{
    private readonly IConfiguration _configuration;
    public Page(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private string GetDatabaseConnection()
    {
        var conn = _configuration.GetConnectionString("SqlServerConnectionString");
        return conn;
    }

    public DataTable GetPagesList()
    {
        SqlConnection sqlConnection = new(GetDatabaseConnection());

        string queryString = "SELECT * FROM PAGES";
        SqlCommand command = new(queryString, sqlConnection);
        command.Connection.Open();

        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = command;

        DataTable table = new DataTable();
        adapter.Fill(table);
        return table;
    }
}
