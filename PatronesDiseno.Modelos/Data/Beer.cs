using System;
using System.Collections.Generic;

#nullable disable

namespace PatronesDiseno.Modelos.Data
{
    public partial class Beer
    {
        public int BeerId { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public Guid BrandId { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
