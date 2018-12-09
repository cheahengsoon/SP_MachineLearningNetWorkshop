using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Runtime.Api;

namespace MLClustering
{
    class CustData
    {
        [Column("0")]
        public float Male;

        [Column("1")]
        public float Female;

        [Column("2")]
        public float Before2010;

        [Column("3")]
        public float After2010;
    }
    public class ClusterPrediction
    {
        [ColumnName("PredictedLabel")]
        public uint PredictedCustId;

        [ColumnName("Score")]
        public float[] Distancessdfsd;
    }
}
