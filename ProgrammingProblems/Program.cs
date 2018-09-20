using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ProgrammingProblems
{
    class Program
    {
        static void Main(string[] args)
        {

            Uri[] ValidExternalLinks = new Uri[] {
                                           new Uri("http://cscw.acm.org/2016/submit/workshops.php"),
                                           new Uri("http://motherboard.vice.com/read/what-makes-paris-look-like-paris-let-an-algorithm-tell-you"),
                                           new Uri("https://docs.angularjs.org/api/ng/directive/ngInit"),
                                           new Uri("http://blogs.msdn.com/b/webdev/archive/2013/07/03/understanding-owin-forms-authentication-in-mvc-5.aspx")
                                           };

            Uri[] InvalidExternalLinks = new Uri[] {
                                           new Uri("amqp://guest:guest@client1/development"),
                                           new Uri("tcp://localhost:5672"),
                                           new Uri("file:///E:/Resource/index.html"),
                                           };

            var data = File.ReadAllText(@".\data.json");
                //File.ReadAllText(@"E:\src\researchmeme\ResearchMeme\Branches\Main\Source\Repository.Tests\TestData\CalendarEventStory.json");
            
            var info = string.Format(data, "world");

            var n = 20;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var fact = Factorial.FindFactorial(n);
            watch.Stop();


            
            Console.WriteLine("{0}! = {1}", n, string.Join("", fact));
            Console.WriteLine("Total time = {0}", watch.ElapsedMilliseconds);
        }
    }
}
