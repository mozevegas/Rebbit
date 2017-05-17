using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rebbit.Models
{
    public class Postz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime TimePosted { get; set; } = DateTime.Now;
        public int Upvote { get; set; }
        public int Downvote { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}