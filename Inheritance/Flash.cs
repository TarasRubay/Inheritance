using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Flash : Storage
    {
        public Flash() { }
        public Flash(string name,double _sizeGB) {
            Model = "USB 3.0";
            Name = name;
            size = _sizeGB;
        }
        double size;
        public double Data { get; private set; }
        int speed_sec = 600;
        public int Speed_sec { get => speed_sec; }

        public override void CopyFile(in int dataMB)
        {
            if (GetFreeMemory() * 1024 > dataMB) Data += dataMB;
            else throw new Exception("No free memory");
        }

        public override double GetFreeMemory()
        {
            return size - Data / 1024;
        }

        public override double GetMemorySize()
        {
            return size;
        }



        public override string ToString()
        {
            return $"{base.ToString()} " +
                $"\nname: {Name}" +
                $"\nmodel: {Model} {Speed_sec} MB/s" +
                $"\ndata: {Data} MB" +
                $"\nmemory size: {GetMemorySize()} GB ({GetMemorySize()*1024}) MB" +
                $"\nfree memory: {GetFreeMemory()} GB ({GetFreeMemory() * 1024}) MB";
        }
    }
}
