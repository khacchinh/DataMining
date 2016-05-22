using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS
{
    class MatrixCell
    {
        private String true_Class;
        private String predict_Class;
        private int count;

        public String True_Class
        {
            get { return true_Class; }
            set { true_Class = value; }
        }

        public String Predict_Class
        {
            get { return predict_Class; }
            set { predict_Class = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }
}
