using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DTO_Library;

namespace ICA_BusinessLogicLayer
{
   public class ConfigurationSerialization
   {
      
      public static void SaveList(string path, List<Medicine_config> configlist)
      {
         FileStream fs = new FileStream(path, FileMode.Create);
         XmlSerializer serializer = new XmlSerializer(typeof(List<Medicine>));
         serializer.Serialize(fs, configlist);
         fs.Close();
      }
      public static List<Medicine_config> LoadList(string path)
      {
         FileStream fs = new FileStream(path, FileMode.Open);
         XmlSerializer serializer = new XmlSerializer(typeof(List<Medicine_config>));
         List<Medicine_config> configurationlist = (List<Medicine_config>)serializer.Deserialize(fs);
         return configurationlist;
      }
   }
}
