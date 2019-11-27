using System;
using System.Collections.Generic;

namespace SoftServe.BookingSectors.WebAPI.Data.Models
{
    public partial class User
    {
        public User()
        {
            BookingSector = new HashSet<BookingSector>();
        }

        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public int LanguageId { get; set; }
        public byte[] Password { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime ModDate { get; set; }
        public int? ModUserId { get; set; }

        public virtual Language Language { get; set; }
        public virtual UserRole Role { get; set; }
        public virtual ICollection<BookingSector> BookingSector { get; set; }
    }
}
