using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Test.Benchmark;

namespace Locust.Test.Test
{
    class test_EF_retrive : BaseTest
    {
        public override string Title
        {
            get { return "EF"; }
            set { }
        }
        public override void Test()
        {
            var filmsEFmodel = new FilmsEFmodel();

            //var films = filmsEFmodel.FilmTBLs.OrderByDescending(x => x.FilmCode).Take(1).ToList();
            var films = filmsEFmodel.FilmTBLs.Where(x => x.FilmCode == 42690).ToList();
            System.Console.WriteLine(films.FirstOrDefault().FilmDesc);
        }
    }
}
    

