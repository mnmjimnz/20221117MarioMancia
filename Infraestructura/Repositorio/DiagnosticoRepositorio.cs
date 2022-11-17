using _20221117MarioMancia.Core.DTOs;
using _20221117MarioMancia.Core.Interface;
using _20221117MarioMancia.Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace _20221117MarioMancia.Infraestructura.Repositorio
{
    public class DiagnosticoRepositorio : IDiagnostico
    {
        public int Insertar(DiagnosticoDTO _diag)
        {
            string consulta = "Insert_diagnostico";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_cita", _diag.id_cita_diag);
            comando.Parameters.AddWithValue("@diagnostico", _diag.diagnostico);
            return ComunDB.EjecutarComando(comando);
        }

        public int Modificar(DiagnosticoDTO _diag)
        {
            string consulta = "Update_diagnostico";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_cita", _diag.id_cita_diag);
            comando.Parameters.AddWithValue("@id_diagnostico", _diag.id_diagnostico);
            comando.Parameters.AddWithValue("@diagnostico", _diag.diagnostico);
            return ComunDB.EjecutarComando(comando);
        }
        public int Eliminar(int idDiagnostico)
        {
            string consulta = "Delete_diagnostico";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_diagnostico", idDiagnostico);
            return ComunDB.EjecutarComando(comando);
        }
        public List<DiagnosticoDTO> Listar()
        {
            string Consulta = "SelectAll_diagnostico";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = Consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<DiagnosticoDTO> _lista = new List<DiagnosticoDTO>();

            while (reader.Read())
            {
                DiagnosticoDTO _diag = new DiagnosticoDTO();
                _diag.id_diagnostico = reader.GetInt32(0);
                _diag.id_cita_diag = reader.GetInt32(1);
                _diag.diagnostico = reader.GetString(2);
                _lista.Add(_diag);
            }

            return _lista;
        }
        public List<DiagnosticoDTO> BuscarPorCita(int idCita)
        {
            string Consulta = "SelectOne_byCita";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = Consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_cita", idCita);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<DiagnosticoDTO> _lista = new List<DiagnosticoDTO>();

            while (reader.Read())
            {
                DiagnosticoDTO _diag = new DiagnosticoDTO();
                _diag.id_diagnostico = reader.GetInt32(0);
                _diag.id_cita_diag = reader.GetInt32(1);
                _diag.diagnostico = reader.GetString(2);
                _lista.Add(_diag);
            }

            return _lista;
        }
        public DiagnosticoDTO Buscar(int idCita)
        {
            string Consulta = "SelectOne_byCita";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = Consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_cita", idCita);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            DiagnosticoDTO _diag = new DiagnosticoDTO();
            while (reader.Read())
            {
                _diag.id_diagnostico = reader.GetInt32(0);
                _diag.id_cita_diag = reader.GetInt32(1);
                _diag.diagnostico = reader.GetString(2);
            }

            return _diag;
        }
    }
}
