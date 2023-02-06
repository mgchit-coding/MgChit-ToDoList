using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList_2.Models
{
    [Table("TblToDoList")]
    public class ToDoListDataModel
    {
        [Key]
        public string listId { get; set; }
        public string taskName { get; set; }
        public DateTime createDateTime { get; set; }
    }
}
