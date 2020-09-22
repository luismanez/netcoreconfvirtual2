using System;

namespace Delos.Westworld.Domain
{
    public class Host: Member
    {
        public string Biography { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime LastSystemReview { get; set; }
        public Park CurrentParkAssigned { get; set; }
    }
}