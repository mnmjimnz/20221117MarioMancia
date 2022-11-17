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
    public class ClinicaController : Controller
    {
        private readonly IClinica _clinica;
        public ClinicaController(IClinica clinica)
        {
            _clinica = clinica;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Insertar(ClinicaDTO data)
        {
            try
            {
                _clinica.Insertar(data);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
        public IActionResult Editar(ClinicaDTO data)
        {
            try
            {
                _clinica.Modificar(data);
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
                _clinica.Eliminar(data);
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
                var data  = _clinica.Listar();
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
                var data = _clinica.Buscar(id);
                return Json(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
    }
}
