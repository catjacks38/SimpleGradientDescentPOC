using System;
using System.Collections.Generic;
using Model;
using Optimizer;
using static Loss.Loss;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            int epochs = 50;

            // Initializes the linear model parameters (m and b)
            LinearModel model = new LinearModel(0.0f, 0.0f);

            // Initializes optimizer with the linear model, and the learning rate
            GradientDescent optim = new GradientDescent(model, 0.1f);

            // Train set
            List<(float, float)> trainSet = new List<(float, float)>(){ (0.0f, -1.0f), (1.0f, 1.0f), (2.0f, 3.0f), (3.0f, 5.0f) };

            // Iterates over every epoch
            for (int epoch = 0; epoch < epochs; epoch++)
            {
                // Writes loss and current epoch
                Console.WriteLine("E: " + epoch + "/" + epochs + "  L: " + MSELoss(trainSet, model));

                // Optimizes/steps model
                optim.step(trainSet);
            }

            // Outputs new fitted parameters
            Console.WriteLine("M: " + model.m + "  B: " + model.b);
            
        }
    }
}
