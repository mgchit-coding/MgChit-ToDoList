using Microsoft.EntityFrameworkCore;
using ToDoList_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ToDoList_2.Services
{
    public class EntityService : DbContext
    {
        public EntityService(DbContextOptions options) : base(options) 
        {

        }
        public DbSet<ToDoListDataModel> ToDoList { get; set; }
    }
}
