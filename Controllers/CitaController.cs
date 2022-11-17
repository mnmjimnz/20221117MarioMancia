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
    public class CitaController : Controller
    {
        private readonly ICita _cita;
        private readonly IDiagnostico _diag;
        public CitaController(ICita cita, IDiagnostico diag)
        {
            _cita = cita;
            _diag = diag;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Insertar(CitaDTO data)
        {
            try
            {
                _cita.Insertar(data);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
        public IActionResult Editar(CitaDTO data)
        {
            try
            {
                _cita.Modificar(data);
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
                _cita.Eliminar(data);
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
                var data = _cita.Listar();
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
                var data = _cita.Buscar(id);
                return Json(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
        public IActionResult BuscarDiagnostico(string obj)
        {
            try
            {
                var id = JsonConvert.DeserializeObject<int>(obj);
                var data = _diag.BuscarPorCita(id);
                return Json(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
    }
}
