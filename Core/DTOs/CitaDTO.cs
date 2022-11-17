using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20221117MarioMancia.Core.DTOs
{
    public class CitaDTO
    {
        public int id_cita { get; set; }
        public string nombre_paciente { get; set; }
        public string direccion_paciente { get; set; }
        public string telefono_paciente { get; set; }
        public string dui_paciente { get; set; }
        public string fecha_cita { get; set; }
        public string hora_cita { get; set; }
        public int id_doctor { get; set; }
        public int id_clinica { get; set; }
    }
}
