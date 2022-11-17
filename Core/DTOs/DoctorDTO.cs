using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20221117MarioMancia.Core.DTOs
{
    public class DoctorDTO
    {
        public int id_doctor { get; set; }
        public string nombre { get; set; }
        public string especialidad { get; set; }
        public int diponible { get; set; }
        public int id_clinica { get; set; }
    }
}
