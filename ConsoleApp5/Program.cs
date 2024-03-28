using System.Net;

using HttpListener listener = new HttpListener();

listener.Prefixes.Add("http://127.0.0.1:27001/");
listener.Prefixes.Add("http://127.0.0.1:27002/");
listener.Prefixes.Add("http://localhost:27003/");

listener.Start();

while (true)
{
    var context = listener.GetContext();

    _ = Task.Run(() =>
    {
        HttpListenerRequest? request = context.Request;

        HttpListenerResponse? response = context.Response;
        response.ContentType = "text/html";
        response.Headers.Add("Content-Type", "text/html");
        response.Headers.Add("Server", "Step");
        response.Headers.Add("Date", DateTime.Now.ToString());

        var url = request.RawUrl;
        Console.WriteLine(url);
        if (url == "/")
        {
            response.StatusCode = 200;


            // Data Content
            using var writer = new StreamWriter(response.OutputStream);

            var index = File.ReadAllText("MyWebSites/index.html");
            writer.Write(index);
        }
        else
        {

            var urls = url?.Split('/').ToList();


            if (urls[1] == "MyWebSites")
            {
                if (urls[2] == "index" || urls[2] == "index.html")
                {
                    response.StatusCode = 200;


                    // Data Content
                    using var writer = new StreamWriter(response.OutputStream);

                    var index = File.ReadAllText("MyWebSites/index.html");
                    writer.Write(index);
                }
                else if (urls[2] == "contact" || urls[2] == "contact.html")
                {
                    response.StatusCode = 200;


                    // Data Content
                    using var writer = new StreamWriter(response.OutputStream);

                    var index = File.ReadAllText("MyWebSites/contact.html");
                    writer.Write(index);
                }

                else if (urls[2] == "gallery" || urls[2] == "gallery.html")
                {
                    response.StatusCode = 200;


                    // Data Content
                    using var writer = new StreamWriter(response.OutputStream);

                    var index = File.ReadAllText("MyWebSites/gallery.html");
                    writer.Write(index);
                }

                else if (urls[2] == "about" || urls[2] == "about.html")
                {
                    response.StatusCode = 200;

                    // Data Content
                    using var writer = new StreamWriter(response.OutputStream);

                    var index = File.ReadAllText("MyWebSites/about.html");
                    writer.Write(index);
                }
                else
                {
                    response.StatusCode = 404;
                    // Data Content
                    using var writer = new StreamWriter(response.OutputStream);

                    var index = File.ReadAllText("MyWebSites/404.html");
                    writer.Write(index);
                }
            }
            else
            {
                response.StatusCode = 404;
                // Data Content
                using var writer = new StreamWriter(response.OutputStream);

                var index = File.ReadAllText("MyWebSites/404.html");
                writer.Write(index);
            }
        }
    });

}
