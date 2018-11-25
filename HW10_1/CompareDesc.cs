using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10_1
{
    class CompareDesc : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return -(x.CompareTo(y));
        }
    }
}
