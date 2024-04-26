using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace burger.Models
{
        [Table("tblMenu")]
        public class tblMenu
        {
            [Key]
            public int MenuID { get; set; }
            public string? MenuName{ get; set; }
            public bool? IsActive{  get; set; }
            public string? ControllerName{ get; set; }
            public string? ActionName{ get; set; }
            public int Levels{  get; set; }
            public int ParentID{ get; set; }
            public string? Link{ get; set; }
            public int MenuOrder{get; set; }
            public int Position{ get; set; }
        }
}
