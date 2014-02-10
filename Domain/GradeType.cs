using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class GradeType
    {
        public virtual Guid ID { get; set; }

        public virtual string Name { get; set; }
    }
}
