using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFile
{
    public class MyPoint
    {
        public double x;
        public double y;

        public MyPoint(double x_tmp, double y_tmp)
        {
            this.x = x_tmp;
            this.y = y_tmp;
        }
    }
}
