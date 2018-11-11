using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Conversion;
using Locust.Db;
using Locust.Model;

namespace Locust.Test.Benchmark
{

    class benchmark_basemodel_vs_ado: BaseBenchmark
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
        
        private class Test1 : BaseTest
        {
            public override string Title
            {
                get { return "BaseModel"; }
                set { }
            }

            public override void Test()
            {
                var cmd = DA.DefaultDb.GetCommand("select * from dbo.FilmTbl where filmcode=@fid", sproc: false);
                var dbr = DA.DefaultDb.ExecuteReader(cmd, (row) =>
                {
                    var result = new Film();

                    result.Read(row);

                    return result;
                }, new { fid = 42690 });
            }
        }

        private class Test2 : BaseTest
        {
            public override string Title
            {
                get { return "ADO"; }
                set { }
            }

            public override void Test()
            {
                var connstr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
                var conn = new SqlConnection(connstr);
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("select * from dbo.FilmTbl where filmcode=42690", conn))
                    using (SqlDataReader reader = command.ExecuteReader())
                    { while (reader.Read())
                        {
                            var f = new Film();
                            f.FilmCode = SafeClrConvert.ToInt32(reader["FilmCode"]);
                            f.FilmDesc = SafeClrConvert.ToString(reader["FilmDesc"]);
                            f.Iranian = SafeClrConvert.ToBoolean(reader["Iranian"]);
                            f.Director = SafeClrConvert.ToString(reader["Director"]);
                            f.Summary = SafeClrConvert.ToString(reader["Summary"]);
                            f.ReleaseDate = SafeClrConvert.ToString(reader["ReleaseDate"]);
                            f.RunningTime = SafeClrConvert.ToString(reader["RunningTime"]);
                            f.Genre = SafeClrConvert.ToString(reader["Genre"]);
                            f.Trailer = SafeClrConvert.ToString(reader["Trailer"]);
                            f.Year = SafeClrConvert.ToString(reader["Year"]);
                            f.Producer = SafeClrConvert.ToString(reader["Producer"]);
                            f.Casting = SafeClrConvert.ToString(reader["Casting"]);
                            f.Credits = SafeClrConvert.ToString(reader["Credits"]);
                            f.Filmimage = SafeClrConvert.ToString(reader["Filmimage"]);
                            f.Film_id = SafeClrConvert.ToInt32(reader["Film_id"]);
                            f.Category_Id = SafeClrConvert.ToInt32(reader["Category_Id"]);
                            f.date = SafeClrConvert.ToDateTime(reader["date"]);
                            f.FilmHorizontalImage = SafeClrConvert.ToString(reader["FilmHorizontalImage"]);
                            f.distribution = SafeClrConvert.ToString(reader["distribution"]);
                            f.ShowSale = SafeClrConvert.ToBoolean(reader["ShowSale"]);
                            f.Film_Field1 = SafeClrConvert.ToString(reader["Film_Field1"]);
                            f.Film_Field2 = SafeClrConvert.ToString(reader["Film_Field2"]);
                            f.Film_Order = SafeClrConvert.ToInt32(reader["Film_Order"]);
                            f.Rating = SafeClrConvert.ToInt32(reader["Rating"]);
                            f.Rating_Users = SafeClrConvert.ToInt32(reader["Rating_Users"]);
                            f.Film_Field3 = SafeClrConvert.ToString(reader["Film_Field3"]);
                        }
                        reader.Close();
                    }
                    conn.Close();                   
                }
                catch(Exception e)
                {
                    System.Console.WriteLine(e);
                }
            }
        }

        public override void Run()
        {
            const int repeatCount = 10;
            const int stressCount = 10;

            test1 = new Test1();
            test2 = new Test2();

            base.Run(repeatCount, stressCount);
        }
    }
}
