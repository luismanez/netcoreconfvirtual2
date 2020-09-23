using System;

namespace Delos.Westworld.Domain
{
    public class Host
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Park CurrentPark { get; set; }
        public Guid CurrentParkId { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime LastSystemReview { get; set; }
    }
}