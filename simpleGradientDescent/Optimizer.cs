using System;
using System.Collections.Generic;
using Model;

namespace Optimizer
{
    class GradientDescent
    {
        LinearModel model;
        float lr;

        public GradientDescent(LinearModel linearModel, float step)
        {
            model = linearModel;
            lr = step;
        }

        private float calcPartialDerivM(float x, float y)
        {
            return (2 * x) * (x * model.m - y + model.b);
        }

        private float calcPartialDerivB(float x, float y)
        {
            return 2 * (model.b - y + (model.m * x));
        }

        public (float, float) calcDescendingGradient(List<(float, float)> trainSet)
        {
            float sumM = 0.0f;
            float sumB = 0.0f;

            foreach((float, float) set in trainSet)
            {
                sumM += calcPartialDerivM(set.Item1, set.Item2);
                sumB += calcPartialDerivB(set.Item1, set.Item2);
            }

            return (-sumM / trainSet.Count, -sumB / trainSet.Count);
        }

        public void step(List<(float, float)> trainSet)
        {
            (float, float) descendingGradient = calcDescendingGradient(trainSet);

            float mStep = descendingGradient.Item1 * lr;
            float bStep = descendingGradient.Item2 * lr;

            model.m += mStep;
            model.b += bStep;

            return;
        }

    }
}
