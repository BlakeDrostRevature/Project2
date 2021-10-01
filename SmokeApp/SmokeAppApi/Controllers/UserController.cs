using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmokeApp_Domain.Models;
using SmokeApp_Domain.ViewModels;
using SmokeApp_Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmokeAppApi.Controllers {
    public class UserController : Controller {

        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo ur) {
            _userRepo = ur;
        }

        // GET: UserController
        public ActionResult Index() {
            return View();
        }

        // GET: UserController/Details/5
        [HttpGet("userlist")]
        public async Task<List<ViewUser>> Details() {
            Task<List<ViewUser>> users = _userRepo.UserListAsync();
            List<ViewUser> users1 = await users;
            return users1;
        }

        [HttpGet("login/{username}/{password}")]
        public async Task<ActionResult<ViewUser>> Login(string username, string password) {
            if (!ModelState.IsValid) return BadRequest();
            ViewUser vu = new ViewUser() { Username = username, Password = password };
            ViewUser vu1 = await _userRepo.LoginUserAsync(vu);

            

            if (vu1 == null) {
                return NotFound();
            }

            if (vu.Password != vu1.Password)
            {
                return new ViewUser { /*Username = "Wrong Password", Password = "1234"*/ };
            }
            return Ok(vu1);
        }

        [HttpPost("register/{fname}/{lname}/{email}/{username}/{password}/{dob}")]
        public async Task<ActionResult<ViewUser>> Register(string fname, string lname, string email, string username, string password, DateTime dob) {
            if (!ModelState.IsValid) return BadRequest();
            ViewUser vu = new ViewUser {
                FirstName = fname,
                LastName = lname,
                Username = username,
                Email = email,
                Dob = dob,
                Password = password
            };
            ViewUser u1 = await _userRepo.RegisterUserAsync(vu);
            if(u1 == null) {
                return NotFound();
            }
            return u1;
        }

        //Get a list of ViewGame that a user is subscribed to
        [HttpGet("subscriptions/{username}")]
        public async Task<List<ViewGame>> GetSubscriptions(string username) {
            Task<List<ViewGame>> games = _userRepo.UserSubscribedGamesAsync(username);
            List<ViewGame> games1 = await games;
            return games1;
        }

        // GET: UserController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
    }
}
