using _20221117MarioMancia.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20221117MarioMancia.Core.Interface
{
    public interface IClinica
    {
        public int Insertar(ClinicaDTO _clinica);
        public int Modificar(ClinicaDTO _clinica);
        public int Eliminar(int idClinica);
        public List<ClinicaDTO> Listar();
        public ClinicaDTO Buscar(int idClinica);
    }
}
