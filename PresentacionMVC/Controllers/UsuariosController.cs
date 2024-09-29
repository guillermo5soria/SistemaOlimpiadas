using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LogicaDatos.Repositorios;
using LogicaNegocio.EntidadesDominio;
using LogicaAplicacion.ICU;
using DTO.Objetos;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using ExcepcionesPropias;

namespace PresentacionMVC.Controllers
{
    public class UsuariosController : Controller
    {
        public IAltaUsuario CUAlta { get; set; }
        public IListadoUsuarios CUListado { get; set; }
        public IListadoRoles CUListadoRoles { get; set; }
        public ILoginUsuario CULoginUsuario { get; set; }


        public UsuariosController(IAltaUsuario cuAlta, IListadoUsuarios cuListado, IListadoRoles cuListadoRoles, ILoginUsuario cULoginUsuario)
        {
            CUAlta = cuAlta;
            CUListado = cuListado;
            CUListadoRoles = cuListadoRoles;
            CULoginUsuario = cULoginUsuario;    
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            string rol = HttpContext.Session.GetString("rol");
            if (!string.IsNullOrEmpty(rol) && rol == "Administrador")
            {
                IEnumerable<ListadoUsuariosDTO> dtos = CUListado.ObtenerListado();
                return View(dtos);
            }

            return RedirectToAction(nameof(Login));
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            string rol = HttpContext.Session.GetString("rol");
            if (!string.IsNullOrEmpty(rol) && rol == "Administrador")
            {
                Models.AltaUsuarioViewModel vm = new Models.AltaUsuarioViewModel();
                vm.DTO = new AltaUsuarioDTO();
                vm.Roles = CUListadoRoles.ObtenerListado();
                return View(vm);
            }

            return RedirectToAction(nameof(Login));

        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AltaUsuarioViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CUAlta.Alta(vm.DTO);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Revise los datos ingresados";
                }
            }
            catch (UsuarioInvalidoException ex)
            {
                //COMO ES UNA EXCEPCIÓN PROPIA, PUEDO MOSTRAR EL MENSAJE DE LA
                //EXEPCIÓN AL USUARIO, PORQUE ES UN MENSAJE GENERADO POR MÍ
                ViewBag.Error = ex.Message;
            }
            catch (Exception ex)
            {
                //COMO NO ES UNA EXCEPCIÓN PROPIA
                //DEBERÍAMOS LOGUEAR ESTE ERROR Y LUEGO GENERAR UN MENSAJE PARA EL USUARIO
                //QUE NO SEA EL MESSAGE DE LA EXCEPTION
                ViewBag.Error = "Ocurrió un error, no se pudo realizar el alta";
            }

            vm.Roles = CUListadoRoles.ObtenerListado();
            return View(vm);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Usuarios/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUsuarioDTO usu)
        {
            try
            {
                ListadoUsuariosDTO logueado = CULoginUsuario.Login(usu.Email, usu.Contrasenia);
                HttpContext.Session.SetString("rol", logueado.Rol);

                if (logueado.Rol == "Administrador")
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Index), "Roles");
                }
            }
            catch (UsuarioInvalidoException ex)
            {
                ViewBag.Error = ex.Message;
            }
            catch (Exception)
            {
                ViewBag.Error = "Ocurrió un error. Inténtelo de nuevo más tarde.";
            }

            return View(usu);
        }
    }
}
