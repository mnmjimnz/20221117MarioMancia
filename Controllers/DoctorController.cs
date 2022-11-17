using _20221117MarioMancia.Core.DTOs;
using _20221117MarioMancia.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20221117MarioMancia.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctor _doctor;
        public DoctorController(IDoctor doctor)
        {
            _doctor = doctor;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Insertar(DoctorDTO data)
        {
            try
            {
                _doctor.Insertar(data);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
        public IActionResult Editar(DoctorDTO data)
        {
            try
            {
                _doctor.Modificar(data);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
        public IActionResult Eliminar(string obj)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<int>(obj);
                _doctor.Eliminar(data);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
        public IActionResult ObtenerTodo()
        {
            try
            {
                var data = _doctor.Listar();
                return Json(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
        public IActionResult Buscar(string obj)
        {
            try
            {
                var id = JsonConvert.DeserializeObject<int>(obj);
                var data = _doctor.Buscar(id);
                return Json(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
    }
}
