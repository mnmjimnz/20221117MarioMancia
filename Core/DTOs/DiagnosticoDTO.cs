using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20221117MarioMancia.Core.DTOs
{
    public class DiagnosticoDTO
    {
        public int id_diagnostico { get; set; }
        public int id_cita_diag { get; set; }
        public string diagnostico { get; set; }
    }
}
