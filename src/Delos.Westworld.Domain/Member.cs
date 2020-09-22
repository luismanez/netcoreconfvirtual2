using System;

namespace Delos.Westworld.Domain
{
    public class Member
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Park CurrentPark { get; set; }
    }
}