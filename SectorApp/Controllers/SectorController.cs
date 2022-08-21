using Microsoft.AspNetCore.Mvc;
using SectorApp.Models;
using System.Diagnostics;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SectorApp.Models.Sector;
using SectorApp.Providers;
using SectorApp.Services;

namespace SectorApp.Controllers
{
    [Authorize]
    public class SectorController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ISectorUserService _sectorUserService;
        private readonly IUpdateSectorViewModelProvider _updateSectorViewModelProvider;

        public SectorController(UserManager<IdentityUser> userManager,
            ISectorUserService sectorUserService,
            IUpdateSectorViewModelProvider updateSectorViewModelProvider)
        {
            _sectorUserService = sectorUserService;
            _updateSectorViewModelProvider = updateSectorViewModelProvider;
            _userManager = userManager;
        }
        
        [HttpGet]
        public IActionResult Update()
        {
            var userId = _userManager.GetUserId(User);
            var model = _updateSectorViewModelProvider.Provide(userId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UpdateSectorViewModel updateModel)
        {
            var model = _updateSectorViewModelProvider.ProvideFrom(updateModel);
            var validationResult = new UpdateSectorViewModelValidator().Validate(model);
            validationResult.AddToModelState(ModelState, null);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var userId = _userManager.GetUserId(User);
            _sectorUserService.Update(userId, model);

            ViewData.Add("SectorUpdateSuccess", "Sector information has been updated");
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
