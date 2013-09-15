using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace WebApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Courses c = null;
            
            string respstring = string.Empty;
            var client = HttpClientFactory.Create();
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //client.BaseAddress = new Uri(@"http://cvm-dev2013-pbr/MvcWebApi/api");
            /*
            var task = client.GetAsync("http://cvm-dev2013-pbr/MvcWebApi/api/course").ContinueWith(async(taskresp) => 
                {
                   var resp = taskresp.Result;
                   respstring = await resp.Content.ReadAsStringAsync();
                   
                   //readtask.Wait();
                   //respstring = readtask.Result;
                });
            task.Wait();
             */

            var task = client.GetAsync("http://cvm-dev2013-pbr/MvcWebApi/api/course").ContinueWith((t) => Show(t));
            Console.WriteLine("Console continues while fetching courses");

            
            //Console.WriteLine(respstring);
            
            Console.ReadLine();
        }


        static void Show(Task<HttpResponseMessage> tr)
        {
            var resp = tr.Result;
            var rt = resp.Content.ReadAsStringAsync();
            rt.Wait();
            string output = rt.Result;

            Console.WriteLine(output);
        }

        static void ShowCourses(Task<HttpResponseMessage> tr)
        {
            Courses c = null;
            var resp = tr.Result;
            var rt = resp.Content.ReadAsAsync<Courses>();
            rt.Wait();
            c = rt.Result;
            Console.WriteLine(c.courses.Count < Course >() +" courses found");

            
        }
    }

    public class ShowResults
    {
      
    }
}
