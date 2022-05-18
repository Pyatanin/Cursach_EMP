namespace Cursach_2._0;

public class Matrix
{
    public int[] Ig;
    public int[] Jg;
    public double[] Al;
    public double[] Au;
    public double[] Di;

    public Matrix()
    {
    }

    public Matrix(double[] di, double[] al, double[] au, int[] ig, int[] jg)
    {
        Di = di;
        Al = al;
        Au = au;
        Ig = ig;
        Jg = jg;
    }

    public static double[] Mult(Matrix matrix, double[] vec)
    {
        var res = new double[vec.Length];
        for (int i = 0; i < vec.Length; i++)
        {
            res[i] = matrix.Di[i] * vec[i];
            for (int j = matrix.Ig[i]; j < matrix.Ig[i + 1]; j++)
            {
                res[i] += matrix.Al[j] * vec[matrix.Jg[j]];
                res[matrix.Jg[j]] += matrix.Au[j] * vec[i];
            }
        }

        return res;
    }

    public static void Profile(Area area, Grid grid, Matrix matrix)
    {
        matrix.Ig = new int[(2 * area.Rpoint - 1) * (2 * area.Zpoint - 1) + 1];
        matrix.Di = new double[(2 * area.Rpoint - 1) * (2 * area.Zpoint - 1)];
        matrix.Ig[0] = 0;
        matrix.Ig[0] = 0;
        var buck = new List<int>();
        for (var i = 0; i < (2 * area.Rpoint - 1) * (2 * area.Zpoint - 1); i++)
        {
            var k = 0;
            for (var j = 0; j < grid.Connect[i].Count(); j++)
            {
                k++;
                buck.Add(grid.Connect[i].ElementAt(j));
            }

            matrix.Ig[i + 1] = matrix.Ig[i] + k;
        }

        matrix.Jg = buck.ToArray();
    }
}