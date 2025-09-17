using Microsoft.AspNetCore.Mvc;
using DemoGitHubWeb.Models;

namespace DemoGitHubWeb.Controllers
{
    public class MasterDataController : Controller
    {
        public static readonly string APIKey = "AIzaSyD-EXEMPLEKEA1234567890ABCDEFGHIJK";
        // Hardcoded master data list
        private static List<MasterDataItem> masterData = new List<MasterDataItem>
        {
            new MasterDataItem { Id = 1, Name = "Item 1", Description = "Description 1" },
            new MasterDataItem { Id = 2, Name = "Item 2", Description = "Description 2" },
            new MasterDataItem { Id = 3, Name = "Item 3", Description = "Description 3" }
        };

        public IActionResult Index()
        {
            return View(masterData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MasterDataItem item)
        {
            item.Id = masterData.Max(x => x.Id) + 1;
            masterData.Add(item);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var item = masterData.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(MasterDataItem item)
        {
            var existing = masterData.FirstOrDefault(x => x.Id == item.Id);
            if (existing == null) return NotFound();
            existing.Name = item.Name;
            existing.Description = item.Description;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = masterData.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = masterData.FirstOrDefault(x => x.Id == id);
            if (item != null) masterData.Remove(item);
            return RedirectToAction("Index");
        }
    }
}
