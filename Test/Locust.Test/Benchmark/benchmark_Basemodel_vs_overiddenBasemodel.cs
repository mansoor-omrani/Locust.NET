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
    class benchmark_Basemodel_vs_overiddenBasemodel : BaseBenchmark
    {

        private class Film1 : BaseModel
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


        private class Film2 : BaseModel
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
            protected override void SetProperty(SetPropertyArgs args)
            {
                switch (args.PropertyName)
                {
                    case "FilmCode":
                        FilmCode = SafeClrConvert.ToInt32(args.GivenValue);
                        break;
                    case "FilmDesc":
                        FilmDesc = SafeClrConvert.ToString(args.GivenValue);
                        break;
                    case "Iranian":
                        Iranian = SafeClrConvert.ToBoolean(args.GivenValue);
                        break;
                    case "Director":
                        Director = SafeClrConvert.ToString(args.GivenValue);
                        break;
                    case "Summary":
                        Summary = SafeClrConvert.ToString(args.GivenValue);
                        break;
                    case "ReleaseDate":
                        ReleaseDate = SafeClrConvert.ToString(args.GivenValue);
                        break;
                    case "RunningTime":
                        RunningTime = SafeClrConvert.ToString(args.GivenValue);
                        break;
                    case "Genre":
                        Genre = SafeClrConvert.ToString(args.GivenValue);
                        break;
                    case "Trailer":
                        Trailer = SafeClrConvert.ToString(args.GivenValue);
                        break;
                    case "Year":
                        Year = SafeClrConvert.ToString(args.GivenValue);
                        break;
                    case "Producer":
                        Producer = SafeClrConvert.ToString(args.GivenValue);
                        break;
                    case "Casting":
                        Casting = SafeClrConvert.ToString(args.GivenValue);
                        break;
                    case "Credits":
                        Credits = SafeClrConvert.ToString(args.GivenValue);
                        break;
                    case "Filmimage":
                        Filmimage = SafeClrConvert.ToString(args.GivenValue);
                        break;
                    case "Film_id":
                        Film_id = SafeClrConvert.ToInt32(args.GivenValue);
                        break;
                    case "Category_Id":
                        Category_Id = SafeClrConvert.ToInt32(args.GivenValue);
                        break;
                    case "date":
                        date = SafeClrConvert.ToDateTime(args.GivenValue);
                        break;
                    case "FilmHorizontalImage":
                        FilmHorizontalImage = SafeClrConvert.ToString(args.GivenValue);
                        break;
                    case "distribution":
                        distribution = SafeClrConvert.ToString(args.GivenValue);
                        break;
                    case "ShowSale":
                        ShowSale = SafeClrConvert.ToBoolean(args.GivenValue);
                        break;
                    case "Film_Field1":
                        Film_Field1 = SafeClrConvert.ToString(args.GivenValue);
                        break;
                    case "Film_Field2":
                        Film_Field2 = SafeClrConvert.ToString(args.GivenValue);
                        break;
                    case "Film_Order":
                        Film_Order = SafeClrConvert.ToInt32(args.GivenValue);
                        break;
                    case "Rating":
                        Rating = SafeClrConvert.ToInt32(args.GivenValue);
                        break;
                    case "Rating_Users":
                        Rating_Users = SafeClrConvert.ToInt32(args.GivenValue);
                        break;
                    case "Film_Field3":
                        Film_Field3 = SafeClrConvert.ToString(args.GivenValue);
                        break;
                }
            }
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
                    var result = new Film1();

                    result.Read(row);

                    return result;
                }, new { fid = 42690 });
            }
        }

        private class Test2 : BaseTest
        {
            public override string Title
            {
                get { return "Overidden_BaseModel"; }
                set { }
            }

            public override void Test()
            {
                var cmd = DA.DefaultDb.GetCommand("select * from dbo.FilmTbl where filmcode=@fid", sproc: false);
                var dbr = DA.DefaultDb.ExecuteReader(cmd, (row) =>
                {
                    var result = new Film2();

                    result.Read(row);

                    return result;
                }, new { fid = 42690 });
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

