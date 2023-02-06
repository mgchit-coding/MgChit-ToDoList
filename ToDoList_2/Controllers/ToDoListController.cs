using Microsoft.AspNetCore.Mvc;
using ToDoList_2.Models;
using ToDoList_2.Services;

namespace ToDoList_2.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly EntityService _db;
        public ToDoListController(EntityService db) {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Push(ToDoListRequstModel reqModel)
        {
            var item = _db.ToDoList.FirstOrDefault(x => x.taskName == reqModel.TaskName);
            ToDoListDataModel model = new ToDoListDataModel
            {
                listId = Guid.NewGuid().ToString(),
                taskName = reqModel.TaskName,
                createDateTime = DateTime.Now,
            };
            _db.ToDoList.Add(model);
            _db.SaveChanges();
            return Json(new { IsSuccess = true });
        }

        [HttpGet]
        public IActionResult ToDoListDetail()
        {
            var list = _db.ToDoList.ToList();
            var model = list.Select(x => new ToDoListViewModel
            {
                ListId = x.listId,
                TaskName = x.taskName,
                CreatedDateTime = DateTime.Now,
            }).ToList();
            return View("ToDoListDetail",model);
        }
        [HttpPost]
        public IActionResult ToDoListDelete(ToDoListDeleteModel reqModel)
        {
            var item = _db.ToDoList.FirstOrDefault(x => x.listId == reqModel.deleteId);
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.ToDoList.Remove(item);
            _db.SaveChanges();
            return Json(new {IsSuccess = true});
        }

        [HttpPost]
        public IActionResult ToDoListEdit(ToDoListEditModel reqModel)
        {
            var item = _db.ToDoList.FirstOrDefault(x=> x.listId == reqModel.EditId);
            item.taskName = reqModel.EditText;
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.ToDoList.Update(item);
            _db.SaveChanges();
            return Json(new { IsSuccess = true });
        }
    }
}
