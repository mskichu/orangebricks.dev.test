using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Web.Models
{
   
    public class ViewStatus
    {
        [Key]
        public int StatusId { get; set; }

        public string StatusName { get; set; }
    }
}