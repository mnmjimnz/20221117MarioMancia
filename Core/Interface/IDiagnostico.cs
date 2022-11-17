using _20221117MarioMancia.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20221117MarioMancia.Core.Interface
{
    public interface IDiagnostico
    {
        public int Insertar(DiagnosticoDTO _doctor);
        public int Modificar(DiagnosticoDTO _doctor);
        public int Eliminar(int idDoctor);
        public List<DiagnosticoDTO> Listar();
        public DiagnosticoDTO Buscar(int idDcotor);
        public List<DiagnosticoDTO> BuscarPorCita(int idCita);
    }
}
