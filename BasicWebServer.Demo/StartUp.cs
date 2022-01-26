using BasicWebServer.Demo.Controllers;
using BasicWebServer.Server;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System.Text;
using System.Web;

namespace BasicWebServer.Demo
{
    public class StartUp
    {

        public static async Task Main()
        {
            await new HttpServer(routes => routes
            .MapGet<HomeController>("/", c => c.Index())
            .MapGet<HomeController>("/Redirect", c => c.Redirect())
            .MapGet<HomeController>("/HTML", c => c.Html())
            .MapPost<HomeController>("/HTML", c => c.HtmlFormPost())
            .MapGet<HomeController>("/Content", c => c.Content())
            .MapPost<HomeController>("/Content", c => c.DownloadContent())
            .MapGet<HomeController>("/Cookies", c => c.Cookies())
            .MapGet<HomeController>("/Session", c => c.Session())
            .MapGet<UsersController>("/Login", c => c.Login())
            .MapPost<UsersController>("/Login", c => c.LogInUser())
            .MapGet<UsersController>("/Logout", c => c.Logout()))
            .Start();
        }

        //private static void GetUserDataAction(Request request, Response response)
        //{
        //    if (request.Session.ContainsKey(Session.SessionUserKey))
        //    {
        //        response.Body = "";
        //        response.Body += $"<h3>Currently logged-in user " +
        //            $"is with username '{Username}'</h3>";
        //    }
        //    else
        //    {
        //        response.Body = "";
        //        response.Body += "<h3>You should first log in " +
        //            "- <a href='/Login'>Login</a></h3>";
        //    }
        //}

        private static void AddFormDataAction(Request request, Response response)
        {
            response.Body = "";
            foreach (var (key, value) in request.Form)
            {
                response.Body += $"{key} - {value}";
                response.Body += Environment.NewLine;
            }
        }
    }
}