using System;
using System.Collections.Generic;

namespace Model
{
    class LinearModel
    {
        // Variables of a linear function
        public float m;
        public float b;

        public LinearModel(float slope, float yIntercept)
        {
            m = slope;
            b = yIntercept;
        }

        // Just a simple linear function
        // f(x) = mx + b
        // Simple algebra stuff

        public float forward(float x)
        {
            return (m * x) + b;
        }
    }
}
