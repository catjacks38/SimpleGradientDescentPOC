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

            LinearModel model = new LinearModel(0.0f, 0.0f);

            GradientDescent optim = new GradientDescent(model, 0.1f);

            List<(float, float)> trainSet = new List<(float, float)>(){ (0.0f, -1.0f), (1.0f, 1.0f), (2.0f, 3.0f), (3.0f, 5.0f) };

            for (int epoch = 0; epoch < epochs; epoch++)
            {
                Console.WriteLine("E: " + epoch + "/" + epochs + "  L: " + MSELoss(trainSet, model));
                optim.step(trainSet);
            }

            Console.WriteLine("M: " + model.m + "  B: " + model.b);
            
        }
    }
}
