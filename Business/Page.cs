using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business;
public class Page
{
    private readonly IConfiguration _configuration;
    public Page(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }



    public List<Page> GetPagesList()
    {
        List<Page> dataList = new();
        Database.Page dbPage = new(_configuration);
        foreach (DataRow itemRow in dbPage.GetPagesList().Rows)
        {
            Page page = new(_configuration)
            {
                Id = Convert.ToInt32(itemRow["ID"]),
                Name = itemRow["NAME"].ToString(),
                Content = itemRow["CONTENT"].ToString(),
                Date = Convert.ToDateTime(itemRow["DATE"]),
            };

            dataList.Add(page);
        }

        return dataList;
    }
}
