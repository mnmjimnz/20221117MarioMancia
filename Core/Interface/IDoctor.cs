using _20221117MarioMancia.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20221117MarioMancia.Core.Interface
{
    public interface IDoctor
    {
        public int Insertar(DoctorDTO _doctor);
        public int Modificar(DoctorDTO _doctor);
        public int Eliminar(int idDoctor);
        public List<DoctorDTO> Listar();
        public DoctorDTO Buscar(int idDcotor);
    }
}
