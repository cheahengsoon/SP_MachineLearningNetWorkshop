using Microsoft.ML.Legacy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Legacy.Data;
using Microsoft.ML.Legacy.Trainers;
using Microsoft.ML.Legacy.Transforms;
using MLClustering;

namespace SPMLnet
{
    class Program
    {
        static readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "custTrain.csv");
        static readonly string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "custClusteringModel.zip");
        static async Task Main(string[] args)
        {
            PredictionModel<CustData, ClusterPrediction> model = await Train();

            var prediction = model.Predict(TestCustData.PredictionObj);
            Console.WriteLine($"Cluster: {prediction.PredictedCustId}");
            Console.WriteLine($"Distances: {string.Join(" ", prediction.Distancessdfsd)}");
            Console.ReadLine();
        }

        public static async Task<PredictionModel<CustData, ClusterPrediction>> Train()
        {


            // Start Learning
            var pipeline = new LearningPipeline();

            // Load Train Data
            pipeline.Add(new TextLoader(_dataPath).CreateFrom<CustData>(useHeader: true, separator: ','));
            // </Snippet6>

            // Add Features columns
            pipeline.Add(new ColumnConcatenator(
                    "Features",
                    "Male",
                    "Female",
                    "Before2010",
                    "After2010"));

            // Add KMeansPlus Algorithm for k=3 (We have 3 set of clusters)
            pipeline.Add(new KMeansPlusPlusClusterer() { K = 3 });


            // Start Training the model and return the model
            var model = pipeline.Train<CustData, ClusterPrediction>();
            return model;
        }
    }
}
