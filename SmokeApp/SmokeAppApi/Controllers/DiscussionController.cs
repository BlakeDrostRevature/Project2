using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmokeApp_Domain.Models;
using SmokeApp_Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmokeAppApi.Controllers {
    public class DiscussionController : Controller {

        private readonly IDiscussionRepo _disRepo;

        public DiscussionController(IDiscussionRepo dr) {
            _disRepo = dr;
        }


        // GET: DiscussionController
        public ActionResult Index() {
            return View();
        }

        // GET: DiscussionController/Details/5
        [HttpGet("discussionlist")]
        public async Task<List<ViewDiscussion>> Details() {
            Task<List<ViewDiscussion>> discussion = _disRepo.DiscussionListAsync();
            List<ViewDiscussion> vdis = await discussion;
            return vdis;
        }

        // GET: DiscussionController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: DiscussionController/Create
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

        // GET: DiscussionController/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: DiscussionController/Edit/5
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

        // GET: DiscussionController/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: DiscussionController/Delete/5
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
