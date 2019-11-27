using System;
using System.Collections.Generic;

namespace SoftServe.BookingSectors.WebAPI.Data.Models
{
    public partial class Language
    {
        public Language()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime ModDate { get; set; }
        public int? ModUserId { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
