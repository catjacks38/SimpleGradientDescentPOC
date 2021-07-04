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

        // Partial derivative of m
        // d/dm = 2x(xm - y + b)

        private float calcPartialDerivM(float x, float y)
        {
            return (2 * x) * (x * model.m - y + model.b);
        }

        // Partial derivative of b
        // d/db = 2(b - y + mx)

        private float calcPartialDerivB(float x, float y)
        {
            return 2 * (model.b - y + (model.m * x));
        }

        // Gets partial derivatives of both m and b for each (X, Y) tuple in the trainSet list, and sums them all up.
        // Then gets the mean of all partial derivatives, and inverts both of them
        // And returns them as the final descending gradient in tuple form.

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

        // Gets the step of m and b, by multiplying the corresponding partial derivatives of the gradient by the lr (learning rate)
        // Adds the corresponding steps to m and b

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
