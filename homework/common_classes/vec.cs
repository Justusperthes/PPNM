using static System.Math;
public class vector
{
    private double[] data;

    public vector(int n)
    {
        data = new double[n];
    }

    public vector(params double[] values)
    {
        data = new double[values.Length];
        for (int i = 0; i < values.Length; i++)
            data[i] = values[i];
    }

    public double this[int i]
    {
        get { return data[i]; }
        set { data[i] = value; }
    }

    public int size
    {
        get { return data.Length; }
    }

    public static vector operator +(vector v1, vector v2)
    {
        int n = v1.size;
        vector result = new vector(n);
        for (int i = 0; i < n; i++)
            result[i] = v1[i] + v2[i];
        return result;
    }

    public static vector operator *(vector v, double c)
    {
        int n = v.size;
        vector result = new vector(n);
        for (int i = 0; i < n; i++)
            result[i] = v[i] * c;
        return result;
    }

    public static vector operator *(vector v, int c)
    {
        int n = v.size;
        vector result = new vector(n);
        for (int i = 0; i < n; i++)
            result[i] = v[i] * c;
        return result;
    }

    public static vector operator -(vector v1, vector v2)
    {
        int n = v1.size;
        vector result = new vector(n);
        for (int i = 0; i < n; i++)
            result[i] = v1[i] - v2[i];
        return result;
    }

    public static vector operator /(vector v, double d)
    {
        int n = v.size;
        vector result = new vector(n);
        for (int i = 0; i < n; i++)
            result[i] = v[i]/d;
        return result;
    }

    public double norm()
    {
        double sum = 0;
        for (int i = 0; i < size; i++)
            sum += data[i] * data[i];
        return Sqrt(sum);
    }

    public vector copy()
    {
        vector copy = new vector(size);
        for (int i = 0; i < size; i++)
            copy[i] = this[i];
        return copy;
    }

    public override string ToString()
    {
        return string.Join(", ", data);
    }
}