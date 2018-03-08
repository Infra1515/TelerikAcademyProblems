using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public static class FindMajorant
    {
        public static IList<int> MajorantFinder(IList<int> inputList)
        {
            var distinct = new Dictionary<int, int>();
            var majorantSize = inputList.Count / 2 + 1;
            var result = new List<int>();

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
                if (distinct[key] >= majorantSize)
                {
                    result.Add(key);
                }
            }

            return result;
        }
    }
}
