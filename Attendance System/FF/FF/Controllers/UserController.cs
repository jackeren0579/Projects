using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FF.Models;
using Microsoft.AspNetCore.Identity;

namespace FF.Controllers {
    [Authorize]
    public class UserController : Controller {
        private readonly ISubjectRepository subjectRepository;
        private readonly IProtocolRepository protocolRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UserController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> SignInMgr,
            ISubjectRepository subjectRepo, IProtocolRepository protocolRepo) {
            userManager = userMgr;
            signInManager = SignInMgr;
            subjectRepository = subjectRepo;
            protocolRepository = protocolRepo;
        }

        [HttpGet]
        public ViewResult Index() {
            var subjects = subjectRepository.Subjects;
            var protocols = protocolRepository.Protocols;

            var percentages = new Dictionary<int, double>();

            foreach (Subject subject in subjects) {
                double TimerTotal = 0, TimerPresent = 0, TimerProcent = 0;
                foreach (Protocol protocol in protocols.Where(p => p.SubjectID == subject.SubjectID)) {
                    TimerTotal += protocol.HoursTotal;
                    TimerPresent += protocol.HoursPresent;
                    TimerPresent += protocol.HoursVirtual;
                }
                TimerProcent = (TimerPresent / TimerTotal * 100);
                percentages.Add(subject.SubjectID, TimerProcent);   
            }

            return View(new ProtocolsListViewModel { Subjects = subjects, Protocols = protocols, AttendanceInPercentage = percentages });
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Login(string returnUrl) {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel) {
            if (ModelState.IsValid) {
                IdentityUser user = await userManager.FindByEmailAsync(loginModel.Email);

                if (user != null) {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded) {
                        return Redirect(loginModel?.ReturnUrl ?? "/User");
                    }
                }
            }
            TempData["LoginMessage"] = "Forkert Login";
            return View(loginModel);
        }


        [HttpGet]
        public async Task<RedirectResult> LogOut(string returnUrl = "/user/Login") {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

    }
}
