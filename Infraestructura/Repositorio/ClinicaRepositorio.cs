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
    public class ClinicaRepositorio : IClinica
    {
        public int Insertar(ClinicaDTO _clinica)
        {
            string consulta = "Insert_clinica";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", _clinica.nombre);
            comando.Parameters.AddWithValue("@direccion", _clinica.direccion );
            comando.Parameters.AddWithValue("@telefono", _clinica.telefono);
            return ComunDB.EjecutarComando(comando);
        }

        public int Modificar(ClinicaDTO _clinica)
        {
            string consulta = "Update_clinica";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", _clinica.nombre);
            comando.Parameters.AddWithValue("@direccion", _clinica.direccion);
            comando.Parameters.AddWithValue("@telefono", _clinica.telefono);
            comando.Parameters.AddWithValue("@id_clinica", _clinica.id_clinica);
            return ComunDB.EjecutarComando(comando);
        }
        public int Eliminar(int idClinica)
        {
            string consulta = "Delete_clinica";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_clinica", idClinica);
            return ComunDB.EjecutarComando(comando);
        }
        public List<ClinicaDTO> Listar()
        {
            string Consulta = "SelectAll_clinica";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = Consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<ClinicaDTO> _lista = new List<ClinicaDTO>();

            while (reader.Read())
            {
                ClinicaDTO _clinica = new ClinicaDTO();
                _clinica.id_clinica = reader.GetInt32(0);
                _clinica.nombre= reader.GetString(1);
                _clinica.direccion= reader.GetString(2);
                _clinica.telefono = reader.GetString(3);
                _lista.Add(_clinica);
            }

            return _lista;
        }
        public ClinicaDTO Buscar(int idClinica)
        {
            string Consulta = "SelectOne_clinica";
            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = Consulta;
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_clinica", idClinica);
            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            ClinicaDTO _clinica = new ClinicaDTO();
            while (reader.Read())
            {
                _clinica.id_clinica = reader.GetInt32(0);
                _clinica.nombre = reader.GetString(1);
                _clinica.direccion = reader.GetString(2);
                _clinica.telefono = reader.GetString(3);
            }

            return _clinica;
        }
    }
}
