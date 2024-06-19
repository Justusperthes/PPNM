using System;
using System.Collections.Generic;

public class Halton
{
    private int index;
    private int base_;

    public Halton(int base_)
    {
        this.index = 0;
        this.base_ = base_;
    }

    private double HaltonSequence(int index, int base_)
    {
        double result = 0;
        double f = 1.0 / base_;
        int i = index;
        while (i > 0)
        {
            result = result + f * (i % base_);
            i = i / base_;
            f = f / base_;
        }
        return result;
    }

    public double Next()
    {
        return HaltonSequence(index++, base_);
    }

    public void Reset()
    {
        index = 0;
    }
}
