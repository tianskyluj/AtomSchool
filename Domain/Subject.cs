using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Subject
    {
        public virtual Guid ID { get; set; }

        public virtual string Name { get; set; }
    }
}
