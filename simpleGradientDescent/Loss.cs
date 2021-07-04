using System;
using System.Collections.Generic;
using Model;

namespace Loss
{
    static class Loss
    {
        static public float MSELoss(List<(float, float)> trainSet, LinearModel model)
        {
            float sum = 0.0f;

            foreach((float, float) set in trainSet)
            {
                sum += (float) Math.Pow((double) set.Item2 - model.forward(set.Item1), 2.0);
            }

            return sum / trainSet.Count;
        }
    }
}
