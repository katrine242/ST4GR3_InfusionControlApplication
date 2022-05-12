using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace ICA_DataAccessLayer.TCP
{
    public class Listener:IListener
    {
        private readonly string _iPAdress;

        public Listener(string iPAdress)
        {
            _iPAdress = iPAdress;
        }

        public void Listen()
        {
            string request;

            while (true)
            {
                try
                {
                    TcpClient client = new TcpClient(_iPAdress, 13001);

                    NetworkStream stream = client.GetStream();
                    StreamReader reader = new StreamReader(stream);

                    request = reader.ReadLine();

                    stream.Close();
                    client.Close();

                    Console.WriteLine(request);

                    if (request == "START")
                    {
                        //Her skal vi gøre det vi skal når vi starter. 
                    }
                    else if (request == "STOP")
                    {
                        //Her skal vi gøre det vi skal hvis pumpen stoppes
                    }
                    else if (request == "Pause")
                    {
                        //her skal vi gøre det hvis vi pauser
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
