using ForbExpress.DAL.Repositories.CorrespondenceRepository;
using ForbExpress.Models.ViewModels.CorrespondenceViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ForbExpress.Controllers
{
    public class CorrespondenceController : Controller
    {
        private ICorrespondenceRepository CorrespondenceRepository { get; }
        public CorrespondenceController(ICorrespondenceRepository correspondenceRepository)
        {
            CorrespondenceRepository = correspondenceRepository;
        }

        public IActionResult Summary(int pageNumber = 1, int pageCapacity = 15)
        {
            return View(new CorrespondenceViewModel
            {
                Correspondence = CorrespondenceRepository.GetAllCorrespondence()
            });
        }

        public IActionResult CorrespondenceDetails(int letterId)
        {
            return PartialView();
        }
    }
}