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
        var conn = _configuration.GetConnectionString("SqlServerConnectionStringWithCredentials");
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

    public void Save(int id, string name, string content, DateTime date)
    {
        SqlConnection sqlConnection = new(GetDatabaseConnection());

        string queryString = $"INSERT INTO PAGES(NAME, DATE, CONTENT) VALUES ({name}, {date.ToString("yyyy-mm-dd hh:mm:ss")}, {content})";

        if (String.IsNullOrEmpty(id.ToString()))
        {
            queryString = $"UPDATE PAGES SET NAME='{name}', DATE='{date.ToString("yyyy-mm-dd hh:mm:ss")}', CONTENT='{content}' WHERE ID={id}";
        }

        SqlCommand command = new(queryString, sqlConnection);
        command.Connection.Open();
        command.ExecuteNonQuery();
    }
}
