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
    public class DoctorRepositorio : IDoctor
    {

        public int Insertar(DoctorDTO _doctor)
        {
            string consulta = "Insert_doctor";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", _doctor.nombre);
            comando.Parameters.AddWithValue("@especialidad", _doctor.especialidad);
            comando.Parameters.AddWithValue("@disponible", _doctor.diponible);
            comando.Parameters.AddWithValue("@id_clinica", _doctor.id_clinica);
            return ComunDB.EjecutarComando(comando);
        }

        public int Modificar(DoctorDTO _doctor)
        {
            string consulta = "Update_doctor";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", _doctor.nombre);
            comando.Parameters.AddWithValue("@especialidad", _doctor.especialidad);
            comando.Parameters.AddWithValue("@disponible", _doctor.diponible);
            comando.Parameters.AddWithValue("@id_clinica", _doctor.id_clinica);
            comando.Parameters.AddWithValue("@id_doctor", _doctor.id_doctor);
            return ComunDB.EjecutarComando(comando);
        }
        public int Eliminar(int idDoctor)
        {
            string consulta = "Delete_doctor";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_doctor", idDoctor);
            return ComunDB.EjecutarComando(comando);
        }
        public List<DoctorDTO> Listar()
        {
            string Consulta = "SelectAll_doctor";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = Consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<DoctorDTO> _lista = new List<DoctorDTO>();

            while (reader.Read())
            {
                DoctorDTO _doctor = new DoctorDTO();
                _doctor.id_doctor = reader.GetInt32(0);
                _doctor.nombre = reader.GetString(1);
                _doctor.especialidad = reader.GetString(2);
                _doctor.diponible = reader.GetInt32(3);
                _doctor.id_clinica = reader.GetInt32(4);
                _lista.Add(_doctor);
            }

            return _lista;
        }
        public DoctorDTO Buscar(int idDcotor)
        {
            string Consulta = "SelectOne_doctor";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = Consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_doctor", idDcotor);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            DoctorDTO _doctor = new DoctorDTO();
            while (reader.Read())
            {
                _doctor.id_doctor = reader.GetInt32(0);
                _doctor.nombre = reader.GetString(1);
                _doctor.especialidad = reader.GetString(2);
                _doctor.diponible = reader.GetInt32(3);
                _doctor.id_clinica = reader.GetInt32(4);
            }

            return _doctor;
        }
    }
}
