using _20221117MarioMancia.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20221117MarioMancia.Core.Interface
{
    public interface ICita
    {
        public int Insertar(CitaDTO _doctor);
        public int Modificar(CitaDTO _doctor);
        public int Eliminar(int idDoctor);
        public List<CitaDTO> Listar();
        public CitaDTO Buscar(int idDcotor);
    }
}
