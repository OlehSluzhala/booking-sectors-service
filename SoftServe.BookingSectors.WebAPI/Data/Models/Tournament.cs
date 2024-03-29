﻿using System;
using System.Collections.Generic;

namespace SoftServe.BookingSectors.WebAPI.Data.Models
{
    public partial class Tournament
    {
        public Tournament()
        {
            TournamentSector = new HashSet<TournamentSector>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int PreparationTerm { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime ModDate { get; set; }
        public int? ModUserId { get; set; }

        public virtual ICollection<TournamentSector> TournamentSector { get; set; }
    }
}
