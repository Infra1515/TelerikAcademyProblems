using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public static class RemoveAllOddNumbers
    {

        public static IList<int> RemoveOdd(IList<int> inputList)
        {
            var distinct = new Dictionary<int, int>();
            var result = new List<int>(inputList);

            for (int i = 0; i < inputList.Count; i++)
            {
                var currentKey = inputList[i];
                if (distinct.ContainsKey(currentKey))
                {
                    distinct[currentKey]++;
                }
                else
                {
                    distinct.Add(currentKey, 1);
                }
            }

            foreach (var key in distinct.Keys)
            {
                if (distinct[key] % 2 != 0)
                {
                    result.RemoveAll(x => x == key);
                }
            }

            return result;
        }
    }
}
