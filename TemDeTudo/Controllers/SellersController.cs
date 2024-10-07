using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemDeTudo.Data;
using TemDeTudo.Models;
using TemDeTudo.Models.ViewModels;

namespace TemDeTudo.Controllers
{
    public class SellersController: Controller
    {
        private readonly TemDeTudoContext _context;

        public SellersController(TemDeTudoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           //List<Seller> sellers = _context.Seller.ToList();
            var sellers = _context.Seller.Include("Department").ToList();
            return View(sellers);
        }
        public IActionResult Create() {
            // Instanciar um SellerFormViewModel
            // Essa instancia vai ter 2 propriedades 1 vendedor 1 lista de departamentos
            SellerFormViewModel viewModel = new SellerFormViewModel();
            viewModel.Departments = _context.Department.ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Seller seller)
        {
            //testa se foi passado um vendedor
            if(seller == null)
            {
                return NotFound();
            }

            //seller.Department = _context.Department.FirstOrDefault();
            //seller.DepartmentId = seller.Department.ID

            //adicionar o objeto vendedor ao banco
            _context.Add(seller);
            //salvar as alterações na base de dados
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
