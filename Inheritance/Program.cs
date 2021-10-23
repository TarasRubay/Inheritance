using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            StorageColect colect = new StorageColect();
            int menu = 100, switch_on = menu, max_menu = 5;
            do
            {
                switch (switch_on)
                {
                    case 100:
                        do
                        {
                            Console.WriteLine("1 - add storage");
                            Console.WriteLine("2 - count memory size all storage");
                            Console.WriteLine("3 - count copy time");
                            Console.WriteLine("4 - Count Storage to copy file");
                            Console.WriteLine("5 - copy files to storeges");
                            Console.WriteLine("0 - exit");
                            try
                            {
                                switch_on = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                            }
                            catch (Exception a)
                            {
                                Console.WriteLine(a.Message);
                            }
                        } while (switch_on < 0 || switch_on > max_menu);


                        break;
                    case 1:
                        Console.WriteLine("add storage");///////////////////////////////////////////// name menu
                        do
                        {
                            do
                            {
                            Console.WriteLine("1 - Flash");
                            Console.WriteLine("2 - DVD disc");
                            Console.WriteLine("3 - HDD");
                            Console.WriteLine("0 - exit");
                            try
                            {
                                switch_on = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                            }
                            catch (Exception a)
                            {
                                Console.WriteLine(a.Message);
                            }
                            } while (switch_on < 0 || switch_on > 3);
                            if (switch_on == 1) AddFlash(ref colect);
                            else if (switch_on == 2) AddDVD(ref colect);
                            else if (switch_on == 3) AddHDD(ref colect);
                            else if(switch_on == 0) switch_on = 0;
                            else switch_on = 1;
                        } while (switch_on != 0);
                        switch_on = menu;
                        break;
                    case 2:
                        Console.WriteLine("count memory size all storage");///////////////////////////////////////////// name menu
                        if (colect.Count == 0) Console.WriteLine("Colection is empty");
                        double all_size_free = 0;
                        double all_size = 0;
                        foreach (Storage item in colect)
                        {
                            Console.WriteLine(item);
                            all_size_free += item.GetFreeMemory();
                            all_size += item.GetMemorySize();
                        }
                        Console.WriteLine();
                        Console.WriteLine($"free memory all device: {all_size_free} GB ({all_size_free*1024}) MB" +
                            $"\nmemory all device: {all_size} GB ({all_size * 1024}) MB");
                        Console.WriteLine();
                        switch_on = menu;
                        break;
                    case 3:
                        Console.WriteLine("count copy time");///////////////////////////////////////////// name menu
                        do
                        {
                            Console.WriteLine("enter size all file (in GB)the ones you want to copy");
                            try
                            {
                                switch_on = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                            }
                            catch (Exception a)
                            {
                                Console.WriteLine(a.Message);
                            }
                        } while (switch_on < 0);
                        double siz = 0;
                        foreach (Storage item in colect)
                            siz += item.GetFreeMemory();
                        
                        if (switch_on > siz) Console.WriteLine($"not enough memory, Add new storage et have size: {switch_on - siz} GB");
                        else
                        {
                            int tmp = 0;
                            for (int i = 0; i < colect.Count; i++)
                            {
                                if (colect[i] is Flash)
                                {
                                   Flash f = (Flash)colect[i];
                                    tmp += ((Convert.ToInt32((f.GetFreeMemory() * 1024) / FIle) - 1) * FIle) / f.Speed_sec;
                                }
                                else if (colect[i] is DVD)
                                {
                                    DVD f = (DVD)colect[i];
                                    tmp += ((Convert.ToInt32((f.GetFreeMemory() * 1024) / FIle) - 1) * FIle) / f.SpeedWriteSec;
                                }
                                else if (colect[i] is HDD)
                                {
                                    HDD f = (HDD)colect[i];
                                    tmp += ((Convert.ToInt32((f.GetFreeMemory() * 1024) / FIle) - 1) * FIle) / f.Speed_sec;
                                }
                            }
                            Console.WriteLine($"time write sec: {tmp} min: ({(double)tmp/60:F2})");
                        }
                        switch_on = menu;
                        break;
                    case 4:
                        Console.WriteLine("Count Storage to copy file");///////////////////////////////////////////// name menu
                        do
                        {
                            Console.WriteLine("enter size all file (in GB)the ones you want to copy");
                            try
                            {
                                switch_on = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                            }
                            catch (Exception a)
                            {
                                Console.WriteLine(a.Message);
                            }
                        } while (switch_on < 0);
                        
                        int count_flash = 0;
                        int count_dvd = 0;
                        int count_hdd = 0;
                        double count_mem = 0;
                        if (colect.Count != 0)
                        {
                            while (count_mem < switch_on * 1024)
                            {
                                for (int i = 0; i < colect.Count; i++)
                                {
                                    if (colect[i] is Flash && count_mem < switch_on * 1024)
                                    {
                                        Flash f = (Flash)colect[i];
                                        count_mem += (Convert.ToInt32((f.GetMemorySize() * 1024) / FIle) - 1) * FIle;
                                        count_flash++;
                                    }
                                    else if (colect[i] is DVD && count_mem < switch_on * 1024)
                                    {
                                        DVD f = (DVD)colect[i];
                                        count_mem += (Convert.ToInt32((f.GetMemorySize() * 1024) / FIle) - 1) * FIle;
                                        count_dvd++;
                                    }
                                    else if (colect[i] is HDD && count_mem < switch_on * 1024)
                                    {
                                        HDD f = (HDD)colect[i];
                                        count_mem += (Convert.ToInt32((f.GetMemorySize() * 1024) / FIle) - 1) * FIle;
                                        count_hdd++;
                                    }
                                }
                            }
                        Console.WriteLine($"necessary" +
                            $"\nFlash: {count_flash}" +
                            $"\nDVD: {count_dvd}" +
                            $"\nHDD: {count_hdd}");
                        }
                        else Console.WriteLine("You dont have storages");
                            switch_on = menu;
                        break;
                    case 5:
                        Console.WriteLine("copy files to storeges");///////////////////////////////////////////// name menu
                        do
                        {
                            Console.WriteLine("enter size all file (in GB)the ones you want to copy");
                            try
                            {
                                switch_on = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                            }
                            catch (Exception a)
                            {
                                Console.WriteLine(a.Message);
                            }
                        } while (switch_on < 0);
                        switch_on *= 1024;
                        double size_free = 0;
                       
                        foreach (Storage item in colect)
                            size_free += item.GetFreeMemory();
                        size_free *= 1024;

                        if (colect.Count != 0 && size_free > switch_on)
                        {

                            while (switch_on != 0)
                            {
                                
                                for (int i = 0; i < colect.Count; i++)
                                {
                                    if (colect[i] is Flash && switch_on != 0)
                                    {
                                        Console.Write("Flash");
                                        Flash f = (Flash)colect[i];
                                        if(((colect[i].GetFreeMemory() * 1024) > (double)switch_on && (double)switch_on < FIle))
                                        {
                                            f.CopyFile(switch_on);
                                            switch_on = 0;
                                            Console.Write(".");
                                        }
                                        else
                                        {

                                        while ((colect[i].GetFreeMemory() * 1024) > FIle && (double)switch_on > FIle)
                                        {
                                            f.CopyFile(FIle);
                                            switch_on -= FIle;
                                            Console.Write(">");
                                            Thread.Sleep(5000 / f.Speed_sec);
                                            }
                                        }
                                        Console.WriteLine();
                                    }
                                    if (colect[i] is DVD && switch_on != 0)
                                    {
                                        Console.Write("DVD");
                                        DVD f = (DVD)colect[i];
                                        if (((colect[i].GetFreeMemory() * 1024) > (double)switch_on && (double)switch_on < FIle))
                                        {
                                            f.CopyFile(switch_on);
                                            switch_on = 0;
                                            Console.Write(".");
                                        }
                                        else
                                        {

                                            while ((colect[i].GetFreeMemory() * 1024) > FIle && (double)switch_on > FIle)
                                            {
                                                f.CopyFile(FIle);
                                                switch_on -= FIle;
                                                Console.Write(">");
                                                Thread.Sleep(5000/f.SpeedWriteSec);
                                            }
                                        }
                                        Console.WriteLine();
                                    }
                                    if (colect[i] is HDD && switch_on != 0)
                                    {
                                        HDD f = (HDD)colect[i];
                                        Console.Write($"HDD");
                                        if (((colect[i].GetFreeMemory() * 1024) > (double)switch_on && (double)switch_on < FIle))
                                        {
                                            f.CopyFile(switch_on);
                                            switch_on = 0;
                                            Console.Write(".");
                                        }
                                        else
                                        {

                                            while ((colect[i].GetFreeMemory() * 1024) > FIle && (double)switch_on > FIle)
                                            {
                                                f.CopyFile(FIle);
                                                switch_on -= FIle;
                                                Console.Write(">");
                                                Thread.Sleep(5000 / f.Speed_sec);
                                            }
                                        }
                                        Console.WriteLine();
                                    }

                                }
                            }

                        }
                        else if (size_free < switch_on) Console.WriteLine($"not enough memory");
                        else Console.WriteLine("You dont have storages");
                        switch_on = menu;
                        break;
                    
                    default:
                        break;
                }

            } while (switch_on != 0);
        }


        public static int FIle = 780;
        public static void AddFlash(ref StorageColect stor) {
            Console.WriteLine("Flash");
            int size = -1;
            do
            {
                Console.WriteLine("Enter size GB");
                try
                {
                    size = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception a)
                {
                    Console.WriteLine(a.Message);
                }
            } while (size < 0);

            Console.WriteLine("Enter name");
            stor.Add(new Flash(Console.ReadLine(),size));
            Console.WriteLine("ADD Flash completed");
             
        }
        public static void AddDVD(ref StorageColect stor)
        {
            Console.WriteLine("DVD disc");
            Console.WriteLine("Enter name");
            stor.Add(new DVD(Console.ReadLine()));
            Console.WriteLine("ADD DVD completed");
        }
        public static void AddHDD(ref StorageColect stor)
        {
            Console.WriteLine("HDD");
            int size = -1;
            do
            {
                Console.WriteLine("Enter size GB");
                try
                {
                    size = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception a)
                {
                    Console.WriteLine(a.Message);
                }
            } while (size < 0);

            Console.WriteLine("Enter name");
            stor.Add(new HDD(Console.ReadLine(), size));
            Console.WriteLine("ADD HDD completed");
        }
    }
}
