using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;

namespace GetHtmlCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string server;
            Console.WriteLine("Site adresini giriniz: ");
            server = Console.ReadLine();

            Console.WriteLine("------------------\nSite Kodları\n------------------");
            TcpClient client = new TcpClient(server, 80);
            StreamReader sr = new StreamReader(client.GetStream());
            StreamWriter sw = new StreamWriter(client.GetStream());

            try
            {
                sw.WriteLine("GET / HTTP/1.0\n\n");
                sw.Flush();

                string data = sr.ReadLine();
                while (data != null)
                {
                    Console.WriteLine(data);
                    data = sr.ReadLine();
                }
                client.Close();
            }
            catch
            {
            }
            Console.ReadLine();
        }
    }
}
