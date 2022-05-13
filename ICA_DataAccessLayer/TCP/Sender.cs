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
        private readonly DTO_InfusionPlan _dTOInfusionPlan;

        public Sender(string iPAdress, DTO_TimeFlow dToTimeFlow, DTO_InfusionPlan dToInfusionPlan)
        {
            _iPAdress = iPAdress;
            _dTOTimeFlow = dToTimeFlow;
            _dTOInfusionPlan = dToInfusionPlan;
        }

        public void Send()
        {
            double[] timeAndFlowAndFullTime = new double[3];
            while (true)
            {
                try
                {
                    timeAndFlowAndFullTime[0] = _dTOTimeFlow.Time;
                    timeAndFlowAndFullTime[1] = _dTOTimeFlow.Flow;
                    timeAndFlowAndFullTime[2] = _dTOInfusionPlan.Fulltime;

                    TcpClient client = new TcpClient(_iPAdress, 13000);

                    NetworkStream stream = client.GetStream();
                    StreamWriter writer = new StreamWriter(stream);

                    writer.WriteLine(timeAndFlowAndFullTime);
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
