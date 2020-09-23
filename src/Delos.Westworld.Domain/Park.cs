using System;
using System.Collections;
using System.Collections.Generic;

namespace Delos.Westworld.Domain
{
    public class Park
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Host> Hosts { get; set; }
    }
}
