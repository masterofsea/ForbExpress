using ForbExpress.DAL.Repositories.PartnersRepository;
using ForbExpress.Models.ViewModels.PartnersViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ForbExpress.Controllers
{
    public class PartnersController : Controller
    {
        private IPartnersRepository PartnersRepository { get; }

        public PartnersController(IPartnersRepository partnersRepository)
        {
            PartnersRepository = partnersRepository;
        }
        public IActionResult Summary(int pageNumber = 1, int pageCapacity = 15)
        {
            return View(new PartnersViewModel
            {
                Partners = PartnersRepository.GetAllPartners()
            });
        }


        public IActionResult PartnerDetails(int partnerId)
        {
            return PartialView();
        }
    }
}