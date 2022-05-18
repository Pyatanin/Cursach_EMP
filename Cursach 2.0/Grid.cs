namespace Cursach_2._0;

public class Grid
{
    public double[][] Node { get; }
    public double[] R { get; }
    public double[] Z { get; }
    public int[][][] ElPints { get; }
    public SortedSet<int>[] Connect { get; }

    public Grid(Area area)
    {
        var x = new double[area.Rpoint];
        x[0] = area.Rmin;

        if (Math.Abs(area.DischargeRatioR - 1) > 1e-10)
        {
            //Grid creation is based on the development of a geometric progression
            var sumKx = (1 - Math.Pow(area.DischargeRatioR, area.Rpoint - 1)) /
                        (1 - area.DischargeRatioR);
            var hX = (area.Rmax - area.Rmin) / sumKx;

            for (var i = 1; i < area.Rpoint; i++)
            {
                x[i] = area.Rmin +
                       hX * (1 - Math.Pow(area.DischargeRatioR, i)) / (1 - area.DischargeRatioR);
            }
        }
        else
        {
            var hX = (area.Rmax - area.Rmin) / (area.Rpoint - 1);

            for (var i = 1; i < area.Rpoint; i++)
            {
                x[i] = area.Rmin + i * hX;
            }
        }

        R = new double[2*area.Rpoint-1];
        R[0] = x[0];
        var Ind = 0;
        for (int i = 1; i < area.Rpoint; i++)
        {
            var hr = (x[i] - x[i - 1])/2.0;
            R[i+Ind] = x[i - 1] + hr;
            R[i + Ind + 1] = x[i];
            Ind++;
        }
        var y = new double[area.Zpoint];
        y[0] = area.Zmin;

        if (Math.Abs(area.DischargeRatioZ - 1) > 1e-10)
        {
            //Grid creation is based on the development of a geometric progression
            var sumKy = (1 - Math.Pow(area.DischargeRatioZ, area.Zpoint - 1)) /
                        (1 - area.DischargeRatioZ);
            var hY = (area.Zmax - area.Zmin) / sumKy;

            for (var i = 1; i < area.Zpoint; i++)
            {
                y[i] = area.Zmin +
                       hY * (1 - Math.Pow(area.DischargeRatioZ, i)) / (1 - area.DischargeRatioZ);
            }
        }
        else
        {
            var hY = (area.Zmax - area.Zmin) / (area.Zpoint - 1);

            for (var i = 1; i < area.Zpoint; i++)
            {
                y[i] = area.Zmin + i * hY;
            }
        }

        Z = new double[2*area.Rpoint-1];
        Z[0] = y[0];
        Ind = 0;
        for (int i = 1; i < area.Rpoint; i++)
        {
            var hr = (y[i] - y[i - 1])/2.0;
            Z[i+Ind] = y[i - 1] + hr;
            Z[i + Ind + 1] = y[i];
            Ind++;
        }
        int k = 0;
        Node = new double[area.Rpoint * area.Zpoint][];
        for (int i = 0; i < area.Zpoint; i++)
        for (int j = 0; j < area.Rpoint; j++)
        {
            Node[k] = new double[2];
            Node[k][0] = x[j];
            Node[k][1] = y[i];
            k++;
        }

        ElPints = new int[2][][];
        ElPints[0] = new int[(area.Rpoint - 1) * (area.Zpoint - 1)][];
        ElPints[1] = new int[(area.Rpoint - 1) * (area.Zpoint - 1)][];
        for (int i = 0; i < (area.Zpoint - 1); i++)
        {
            for (int j = 0; j < (area.Rpoint - 1); j++)
            {
                ElPints[0][i * (area.Rpoint - 1) + j] = new int[9];
                ElPints[0][i * (area.Rpoint - 1) + j][0] = 2 * i * (2 * area.Rpoint - 1) + j * 2;
                ElPints[0][i * (area.Rpoint - 1) + j][1] = 2 * i * (2 * area.Rpoint - 1) + j * 2 + 1;
                ElPints[0][i * (area.Rpoint - 1) + j][2] = 2 * i * (2 * area.Rpoint - 1) + j * 2 + 2;
                ElPints[0][i * (area.Rpoint - 1) + j][3] = 2 * i * (2 * area.Rpoint - 1) + j * 2 + 2 * area.Rpoint - 1;
                ElPints[0][i * (area.Rpoint - 1) + j][4] = 2 * i * (2 * area.Rpoint - 1) + j * 2 + 2 * area.Rpoint;
                ElPints[0][i * (area.Rpoint - 1) + j][5] = 2 * i * (2 * area.Rpoint - 1) + j * 2 + 2 * area.Rpoint + 1;
                ElPints[0][i * (area.Rpoint - 1) + j][6] = 2 * (i + 1) * (2 * area.Rpoint - 1) + j * 2;
                ElPints[0][i * (area.Rpoint - 1) + j][7] = 2 * (i + 1) * (2 * area.Rpoint - 1) + j * 2 + 1;
                ElPints[0][i * (area.Rpoint - 1) + j][8] = 2 * (i + 1) * (2 * area.Rpoint - 1) + j * 2 + 2;
                ElPints[1][i * (area.Rpoint - 1) + j] = new int[4];
                ElPints[1][i * (area.Rpoint - 1) + j][0] = i * area.Rpoint + j;
                ElPints[1][i * (area.Rpoint - 1) + j][1] = i * area.Rpoint + j + 1;
                ElPints[1][i * (area.Rpoint - 1) + j][2] = (i + 1) * area.Rpoint + j;
                ElPints[1][i * (area.Rpoint - 1) + j][3] = (i + 1) * area.Rpoint + j + 1;
            }
        }

        Connect = new SortedSet<int>[(2 * area.Rpoint - 1) * (2 * area.Zpoint - 1)];

        for (var i = 0; i < Connect.Length; i++)
        {
            Connect[i] = new SortedSet<int>();
        }

        for (int i = 0; i < (area.Rpoint - 1) * (area.Zpoint - 1); i++)
        {
            for (var j = 0; j < 9; j++)
            {
                for (k = 0; k < 9; k++)
                {
                    if (ElPints[0][i][j] > ElPints[0][i][k])
                    {
                        Connect[ElPints[0][i][j]].Add(ElPints[0][i][k]);
                    }
                }
            }
        }
    }
}