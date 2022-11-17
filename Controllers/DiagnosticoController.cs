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
    public class DiagnosticoController : Controller
    {
        private readonly IDiagnostico _diag;
        public DiagnosticoController(IDiagnostico diag)
        {
            _diag = diag;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Insertar(DiagnosticoDTO data)
        {
            try
            {
                _diag.Insertar(data);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
        public IActionResult Editar(DiagnosticoDTO data)
        {
            try
            {
                _diag.Modificar(data);
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
                _diag.Eliminar(data);
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
                var data = _diag.Listar();
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
                var data = _diag.Buscar(id);
                return Json(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }
    }
}
