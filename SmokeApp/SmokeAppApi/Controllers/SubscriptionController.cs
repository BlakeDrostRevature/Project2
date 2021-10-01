using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmokeApp_Domain.Models;
using SmokeApp_Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmokeAppApi.Controllers {
    public class SubscriptionController : Controller {

        private readonly ISubscriptionRepo _subRepo;

        public SubscriptionController(ISubscriptionRepo sr) {
            _subRepo = sr;
        }

        //return all subscriptions
        [HttpGet("subscriptionlist")]
        public async Task<List<ViewSubscription>> GetAllSubscriptionsAsync() {
            Task<List<ViewSubscription>> subs = _subRepo.SubscriptionListAsync();
            List<ViewSubscription> sub1 = await subs;
            return sub1;
        }
        [HttpGet("subscriptionlist/{username}")]
        public async Task<List<ViewSubscription>> GetUserSubscriptionsAsync(string username) {
            List<ViewSubscription> vs = await _subRepo.GetCurrentSubsForUserAsync(username);
            return vs;
        }

        [HttpPost("subscriptionlist/{username}/{gameid}")]
        public async Task<ActionResult<ViewSubscription>> SubscribeToGame(string username, int gameid) {
            if (!ModelState.IsValid) return BadRequest();
            ViewSubscription response = await _subRepo.MakeASubscription(username, gameid);
            if (response == null) {
                return NotFound();
            }
            else
                return response;
        } 
        
        // GET: SubscriptionController
        public ActionResult Index() {
            return View();
        }

        // GET: SubscriptionController/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: SubscriptionController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: SubscriptionController/Create
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

        // GET: SubscriptionController/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: SubscriptionController/Edit/5
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

        // GET: SubscriptionController/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: SubscriptionController/Delete/5
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
