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
    public class Sender: ISender //Denne klasse er ikke implementeret til resten af systemet
    {
        private readonly string _iPAdress;
        private BlockingCollection<double[]> _arrayQueue;

        public Sender(string iPAdress, BlockingCollection<double[]> aq)
        {
            _iPAdress = iPAdress;
            _arrayQueue = aq;
        }

        public void Send()
        {
            double[] timeFlowAndFullTime;
            while (true)
            {
                try
                {
                    timeFlowAndFullTime = _arrayQueue.Take();

                    TcpClient client = new TcpClient(_iPAdress, 13000);

                    NetworkStream stream = client.GetStream();
                    StreamWriter writer = new StreamWriter(stream);

                    string arrayTimeFlowAndFullTime = String.Join(",", timeFlowAndFullTime);

                    writer.WriteLine(arrayTimeFlowAndFullTime);
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
