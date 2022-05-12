using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.IO;
using System.Net.Sockets;
using DTO_Library;

namespace ICA_DataAccessLayer.TCP
{
    public class Sender: ISender
    {
        private readonly string _iPAdress;
        private readonly DTO_TimeFlow _dTOTimeFlow;

        public Sender(string iPAdress, DTO_TimeFlow dToTimeFlow)
        {
            _iPAdress = iPAdress;
            _dTOTimeFlow = dToTimeFlow;
        }

        public void Send()
        {
            double[] timeAndFlow = new double[2];
            while (true)
            {
                try
                {
                    timeAndFlow[0] = _dTOTimeFlow.Time;
                    timeAndFlow[1] = _dTOTimeFlow.Flow;

                    TcpClient client = new TcpClient(_iPAdress, 13000);

                    NetworkStream stream = client.GetStream();
                    StreamWriter writer = new StreamWriter(stream);

                    writer.WriteLine(timeAndFlow);
                    writer.Flush();
                    Console.WriteLine("Time and Flow sent.");

                    stream.Close();
                    client.Close();
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
