using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    
    public class DVD : Storage
    {
        public DVD() { }
        public DVD(string name)
        {
            Model = "16x";
            Name = name;
            size = 4.7;
        }
        double size;
        public double Data { get; private set; }
        int speedReadSec = 21;
        int speedWriteSec = 21;
        public int SpeedReadSec { get => speedReadSec; }
        public int SpeedWriteSec { get => speedWriteSec; }

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
                $"\nmodel: {Model} " +
                $"\ndata: {Data} MB" +
                $"\nread {SpeedReadSec} MB/s" +
                $"\nwrite {SpeedWriteSec} MB/s" +
                $"\nmemory size: {GetMemorySize()} GB ({GetMemorySize() * 1024}) MB" +
                $"\nfree memory: {GetFreeMemory()} GB ({GetFreeMemory() * 1024}) MB";
        }
        
    }
}
