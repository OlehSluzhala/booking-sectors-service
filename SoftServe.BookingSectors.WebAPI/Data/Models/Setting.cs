using System;
using System.Collections.Generic;

namespace SoftServe.BookingSectors.WebAPI.Data.Models
{
    public partial class Setting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxBookingDays { get; set; }
        public int MaxBookingSectors { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime ModDate { get; set; }
        public int? ModUserId { get; set; }
    }
}
