using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel;

namespace OrangeBricks.Web.Models
{
    public class Viewing
    {
        [Column(Order=1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ViewingId { get; set; }

        public DateTime ViewingtDateTime { get; set; }

        [ForeignKey("ViewStatus")]
        [DefaultValue("1")]
        public int ViewStatusId { get; set; }
        public ViewStatus ViewStatus { get; set; }
        [Column(Order =2),Key,ForeignKey("User")]
        public string BuyerId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Column(Order = 3), Key, ForeignKey("Property")]
        public int PropertyID { get; set; }
        public Property Property { get; set; }
    }
}