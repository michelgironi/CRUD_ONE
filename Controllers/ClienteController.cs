using CRUD_ONE.DAL.Interface;
using CRUD_ONE.Models;
using CRUD_ONE.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using X.PagedList;
namespace CRUD_ONE.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteDAL _cliente;
        public ClienteController(IClienteDAL cliente)
        {
            _cliente = cliente;
        }
        public IActionResult Index(int? pagina)
        {
            int tamanhoPagina = 6;
            int numeroPagina = pagina ?? 1;
            //var listaClientes = _cliente.GetAllClientes().ToPagedList(numeroPagina, tamanhoPagina);
            var listaClientes = _cliente.GetAllClientes().Cast<Cliente>().ToPagedList(numeroPagina, tamanhoPagina);
            return View(listaClientes);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ICliente cliente = _cliente.GetCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _cliente.AddCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ICliente cliente = _cliente.GetCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _cliente.UpdateCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ICliente cliente = _cliente.GetCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            _cliente.DeleteCliente(id);
            return RedirectToAction("Index");
        }
    }
}
