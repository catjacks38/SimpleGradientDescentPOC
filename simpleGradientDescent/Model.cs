using System;
using System.Collections.Generic;

namespace Model
{
    class LinearModel
    {
        public float m;
        public float b;

        public LinearModel(float slope, float yIntercept)
        {
            m = slope;
            b = yIntercept;
        }

        public float forward(float x)
        {
            return (m * x) + b;
        }
    }
}
