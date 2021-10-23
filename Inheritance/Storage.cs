using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public abstract class Storage
    {
        protected string Name { get; set; }
        protected string Model { get; set; }
        public abstract double GetMemorySize();
        public abstract void CopyFile(in int dataMB);
        public abstract double GetFreeMemory();
        public override string ToString()
        {
            return $"{this.GetType().Name,10} ";
        }
    }
}
