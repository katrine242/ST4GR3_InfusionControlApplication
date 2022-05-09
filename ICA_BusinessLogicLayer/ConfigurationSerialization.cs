using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DTO_Library;

namespace ICA_Model
{
   public class ConfigurationSerialization
   {
      public static Medicine LoadString(string path)
      {
         FileStream fs = new FileStream(path, FileMode.Open);
         XmlSerializer serializer = new XmlSerializer(typeof(Medicine));
         Medicine configuration = (Medicine)serializer.Deserialize(fs);
         return configuration;
      }
      public static void saveString(string path, Medicine config)
      {
         FileStream fs = new FileStream(path, FileMode.Create);
         XmlSerializer serializer = new XmlSerializer(typeof(Medicine));
         serializer.Serialize(fs, config);
         fs.Close();

      }
      public static void SaveList(string path, List<Medicine> configlist)
      {
         FileStream fs = new FileStream(path, FileMode.Create);
         XmlSerializer serializer = new XmlSerializer(typeof(List<Medicine>));
         serializer.Serialize(fs, configlist);
         fs.Close();
      }
      public static List<Medicine> LoadList(string path)
      {
         FileStream fs = new FileStream(path, FileMode.Open);
         XmlSerializer serializer = new XmlSerializer(typeof(List<Medicine>));
         List<Medicine> configurationlist = (List<Medicine>)serializer.Deserialize(fs);
         return configurationlist;
      }
   }
}
