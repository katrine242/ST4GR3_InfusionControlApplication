using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA_BusinessLogicLayer.Exception
{
   public class InvalidMedicineNameConflictException : System.Exception
   {
      public string MedicineName { get; set; }

      public InvalidMedicineNameConflictException(string medicineName)
      {
         MedicineName = medicineName;
      }
   }
}
