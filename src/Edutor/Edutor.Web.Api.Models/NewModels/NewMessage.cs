using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models.NewModels
{
    public class NewMessage 
    {
        //public int ConversationId { get; set; }
        //public int MessageId { get; set; }
        public int ToId { get; set; }
        public int FromId { get; set; }

        [Required]
        [StringLength(400)]
        public string Text { get; set; }
    }
}
