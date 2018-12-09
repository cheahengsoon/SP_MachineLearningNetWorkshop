using MLClustering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPMLnet
{

    static class TestCustData
    {
        internal static readonly CustData PredictionObj = new CustData
        {
            Male = 300f,
            Female = 100f,
            Before2010 = 400f,
            After2010 = 1400f
        };

    }
}
