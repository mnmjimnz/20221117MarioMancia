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
    public class CitaRepositorio : ICita
    {
        public int Insertar(CitaDTO _cita)
        {
            string consulta = "Insert_cita";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@direccion_paciente", _cita.direccion_paciente);
            comando.Parameters.AddWithValue("@dui_paciente", _cita.dui_paciente);
            comando.Parameters.AddWithValue("@fecha_cita", _cita.fecha_cita);
            comando.Parameters.AddWithValue("@hora_cita", _cita.hora_cita);
            comando.Parameters.AddWithValue("@id_doctor", _cita.id_doctor);
            comando.Parameters.AddWithValue("@nombre_paciente", _cita.nombre_paciente);
            comando.Parameters.AddWithValue("@telefono_paciente", _cita.telefono_paciente);
            comando.Parameters.AddWithValue("@id_clinica", _cita.id_clinica);
            return ComunDB.EjecutarComando(comando);
        }

        public int Modificar(CitaDTO _cita)
        {
            string consulta = "Update_cita";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@direccion_paciente", _cita.direccion_paciente);
            comando.Parameters.AddWithValue("@dui_paciente", _cita.dui_paciente);
            comando.Parameters.AddWithValue("@fecha_cita", _cita.fecha_cita);
            comando.Parameters.AddWithValue("@hora_cita", _cita.hora_cita);
            comando.Parameters.AddWithValue("@id_cita", _cita.id_cita);
            comando.Parameters.AddWithValue("@id_doctor", _cita.id_doctor);
            comando.Parameters.AddWithValue("@nombre_paciente", _cita.nombre_paciente);
            comando.Parameters.AddWithValue("@telefono_paciente", _cita.telefono_paciente);
            comando.Parameters.AddWithValue("@id_clinica", _cita.id_clinica);
            return ComunDB.EjecutarComando(comando);
        }
        public int Eliminar(int idCita)
        {
            string consulta = "Delete_cita";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_cita", idCita);
            return ComunDB.EjecutarComando(comando);
        }
        public List<CitaDTO> Listar()
        {
            string Consulta = "SelectAll_cita";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = Consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<CitaDTO> _lista = new List<CitaDTO>();

            while (reader.Read())
            {
                CitaDTO _cita = new CitaDTO();
                _cita.id_cita = reader.GetInt32(0);
                _cita.nombre_paciente= reader.GetString(1);
                _cita.direccion_paciente= reader.GetString(2);
                _cita.telefono_paciente= reader.GetString(3);
                _cita.dui_paciente= reader.GetString(4);
                _cita.fecha_cita= reader.GetString(5);
                _cita.hora_cita= reader.GetString(6);
                _cita.id_doctor= reader.GetInt32(7);
                _cita.id_clinica= reader.GetInt32(8);
                _lista.Add(_cita);
            }

            return _lista;
        }
        public CitaDTO Buscar(int idCita)
        {
            string Consulta = "SelectOne_cita";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = Consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_cita", idCita);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            CitaDTO _cita = new CitaDTO();
            while (reader.Read())
            {
                _cita.id_cita = reader.GetInt32(0);
                _cita.nombre_paciente = reader.GetString(1);
                _cita.direccion_paciente = reader.GetString(2);
                _cita.telefono_paciente = reader.GetString(3);
                _cita.dui_paciente = reader.GetString(4);
                _cita.fecha_cita = reader.GetString(5);
                _cita.hora_cita = reader.GetString(6);
                _cita.id_doctor = reader.GetInt32(7);
                _cita.id_clinica = reader.GetInt32(8);
            }

            return _cita;
        }
    }
}
