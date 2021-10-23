using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class StorageColect 
    {
        Storage[] storages = new Storage[0];
        public StorageColect() { }
        public StorageColect(params Storage[] storages)
        {
            Array.Resize(ref storages, storages.Length);
            Array.Copy(storages, 0, storages, 0, storages.Length);
        }

        public Storage this[int ind]
        {
            get => storages[ind]; set => storages[ind] = value;
        }

        public int Count { get => storages.Length; }

        public void Add(Storage s)
        {
            Array.Resize(ref storages, Count + 1);
            storages[Count - 1] = s;
        }

        public IEnumerator GetEnumerator()
        {
            return storages.GetEnumerator();
        }

        private class StorageENumerator : IEnumerable
        {
            int curentPosition = -1;
            StorageColect colection;
            public StorageENumerator(StorageColect st)
            {
                colection = st;
            }
            public void Reset()
            {
                curentPosition = -1;
            }
            public object Current
            {
                get => colection[curentPosition];
            }
            public bool MoveNext()
            {
                return ++curentPosition < colection.Count;

            }

            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }   
    }
}
