using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Db;
using Locust.Model;

namespace Locust.Test.Test
{

    class test_basemodel_query: BaseTest
    {
        private class Film : BaseModel
        {
            public int FilmCode { get; set; }
            public string FilmDesc { get; set; }

            public bool? Iranian { get; set; }

            public string Director { get; set; }

            public string Summary { get; set; }

            public string ReleaseDate { get; set; }

            public string RunningTime { get; set; }


            public string Genre { get; set; }

            public string Trailer { get; set; }

            public string Year { get; set; }

            public string Producer { get; set; }

            public string Casting { get; set; }

            public string Credits { get; set; }

            public string Filmimage { get; set; }

            public long Film_id { get; set; }

            public int? Category_Id { get; set; }

            public DateTime date { get; set; }

            public string FilmHorizontalImage { get; set; }

            public string distribution { get; set; }

            public bool? ShowSale { get; set; }

            public string Film_Field1 { get; set; }

            public string Film_Field2 { get; set; }

            public int? Film_Order { get; set; }

            public double? Rating { get; set; }

            public int? Rating_Users { get; set; }

            public string Film_Field3 { get; set; }

        }

            public override string Title
            {
                get { return "BaseModel"; }
                set { }
            }

            public override void Test()
            {
                var cmd = DA.DefaultDb.GetCommand("select * from dbo.FilmTbl where filmcode =42690", sproc: false);
                var dbr = DA.DefaultDb.ExecuteReader(cmd, (row) =>
                    {
                        var result = new Film();

                        result.Read(row);
                        System.Console.WriteLine(JsonConvert.SerializeObject(result));
                        return result;

                    }, new { });
            }
        }
    
}

