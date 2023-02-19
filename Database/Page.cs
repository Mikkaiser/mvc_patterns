using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Database;
public class Page
{
    private readonly IConfiguration _configuration;

    public Page(IConfiguration _configuration)
    {
        this._configuration = _configuration;
    }
    private string GetDatabaseConnection()
    {
        return _configuration.GetConnectionString("SqlServerConnectionString");
    }

    public DataTable GetPagesList()
    {
        SqlConnection sqlConnection = new(GetDatabaseConnection());
    }
}
