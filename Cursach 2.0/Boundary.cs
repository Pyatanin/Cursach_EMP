namespace Cursach_2._0;

public static class Boundary
{
    public static void Two(Area area, Grid grid, BoundaryData boundary, ref Slae slae, double time)
    {
        foreach (var border in boundary.TwoBorder)
        {
            switch (border)
            {
                case 0:
                {
                    var locTheta = new double[3];
                    for (var i = 0; i < (area.Zpoint - 1); i++)
                    {
                        var num = i * (area.Rpoint - 1);
                        var h = (grid.Node[grid.ElPints[1][num][2]][1] - grid.Node[grid.ElPints[1][num][0]][1]);
                        loc_teta(num, h / 2.0, border, locTheta, grid, time);
                        slae.B[grid.ElPints[0][num][0]] +=
                            h * (4.0 * locTheta[0] + 2.0 * locTheta[1] - locTheta[2]) / 30.0;
                        slae.B[grid.ElPints[0][num][3]] +=
                            h * (2.0 * locTheta[0] + 16.0 * locTheta[1] + 2.0 * locTheta[2]) / 30.0;
                        slae.B[grid.ElPints[0][num][6]] +=
                            h * (-1.0 * locTheta[0] + 2.0 * locTheta[1] + 4.0 * locTheta[2]) / 30.0;
                    }

                    break;
                }
                case 1:
                {
                    var locTheta = new double[3];
                    for (var i = 0; i < (area.Rpoint - 1); i++)
                    {
                        var num = i;
                        var h = (grid.Node[grid.ElPints[1][num][1]][0] - grid.Node[grid.ElPints[1][num][0]][0]);
                        loc_teta(num, h / 2.0, border, locTheta, grid, time);
                        slae.B[grid.ElPints[0][num][0]] +=
                            h * (4.0 * locTheta[0] + 2.0 * locTheta[1] - locTheta[2]) / 30.0;
                        slae.B[grid.ElPints[0][num][1]] +=
                            h * (2.0 * locTheta[0] + 16.0 * locTheta[1] + 2.0 * locTheta[2]) / 30.0;
                        slae.B[grid.ElPints[0][num][2]] +=
                            h * (-1.0 * locTheta[0] + 2.0 * locTheta[1] + 4.0 * locTheta[2]) / 30.0;
                    }

                    break;
                }
                case 2:
                {
                    var locTheta = new double[3];
                    for (var i = 0; i < (area.Zpoint - 1); i++)
                    {
                        var num = i * (area.Rpoint - 1) + area.Zpoint - 2;
                        var h = (grid.Node[grid.ElPints[1][num][2]][1] - grid.Node[grid.ElPints[1][num][0]][1]);
                        loc_teta(num, h / 2.0, border, locTheta, grid, time);
                        slae.B[grid.ElPints[0][num][2]] +=
                            h * (4.0 * locTheta[0] + 2.0 * locTheta[1] - locTheta[2]) / 30.0;
                        slae.B[grid.ElPints[0][num][5]] +=
                            h * (2.0 * locTheta[0] + 16.0 * locTheta[1] + 2.0 * locTheta[2]) / 30.0;
                        slae.B[grid.ElPints[0][num][8]] +=
                            h * (-1.0 * locTheta[0] + 2.0 * locTheta[1] + 4.0 * locTheta[2]) / 30.0;
                    }

                    break;
                }
                case 3:
                {
                    var locTheta = new double[3];
                    for (int i = 0; i < (area.Rpoint - 1); i++)
                    {
                        var num = i + (area.Rpoint - 1) * (area.Zpoint - 2);
                        var h = (grid.Node[grid.ElPints[1][num][1]][0] - grid.Node[grid.ElPints[1][num][0]][0]);
                        loc_teta(num, h / 2.0, border, locTheta, grid, time);
                        slae.B[grid.ElPints[0][num][6]] +=
                            h * (4.0 * locTheta[0] + 2.0 * locTheta[1] - locTheta[2]) / 30.0;
                        slae.B[grid.ElPints[0][num][7]] +=
                            h * (2.0 * locTheta[0] + 16.0 * locTheta[1] + 2.0 * locTheta[2]) / 30.0;
                        slae.B[grid.ElPints[0][num][8]] +=
                            h * (-1.0 * locTheta[0] + 2.0 * locTheta[1] + 4.0 * locTheta[2]) / 30.0;
                    }

                    break;
                }
            }
        }
    }

    public static void Three(Area area, Grid grid, BoundaryData boundary, ref Slae slae, double time)
    {
        var locUbeta = new double[3];
        var locBondA = new double[3][];
        for (int i = 0; i < 3; i++)
        {
            locBondA[i] = new double[3];
        }

        locBondA[0][0] = 2.0 / 15.0;
        locBondA[0][1] = 1.0 / 15.0;
        locBondA[0][2] = -1.0 / 30.0;
        locBondA[1][0] = 1.0 / 15.0;
        locBondA[1][1] = 8.0 / 15.0;
        locBondA[1][2] = 1.0 / 15.0;
        locBondA[2][0] = -1.0 / 30.0;
        locBondA[2][1] = 1.0 / 15.0;
        locBondA[2][2] = 2.0 / 15.0;
        foreach (var border in boundary.ThreeBorder)
        {
            switch (border)
            {
                case 0:
                {
                    for (var i = 0; i < (area.Zpoint - 1); i++)
                    {
                        var num = i * (area.Rpoint - 1);
                        var beta = Func.Beta();
                        var h = (grid.Node[grid.ElPints[1][num][2]][1] - grid.Node[grid.ElPints[1][num][0]][1]);
                        InsertLocBondA(num, h, border, locBondA, ref slae.A, grid);
                        GetLocalUbeta(num, h / 2.0, border, ref locUbeta, grid, time);
                        slae.B[grid.ElPints[0][num][0]] +=
                            h * beta * (4.0 * locUbeta[0] + 2.0 * locUbeta[1] - locUbeta[2]) / 30.0;
                        slae.B[grid.ElPints[0][num][3]] +=
                            h * beta * (2.0 * locUbeta[0] + 16.0 * locUbeta[1] + 2.0 * locUbeta[2]) / 30.0;
                        slae.B[grid.ElPints[0][num][6]] +=
                            h * beta * (-1.0 * locUbeta[0] + 2.0 * locUbeta[1] + 4.0 * locUbeta[2]) / 30.0;
                    }

                    break;
                }
                case 1:
                {
                    int num;
                    for (int i = 0; i < (area.Rpoint - 1); i++)
                    {
                        num = i;
                        var beta = Func.Beta();
                        var h = (grid.Node[grid.ElPints[1][num][1]][0] - grid.Node[grid.ElPints[1][num][0]][0]);
                        InsertLocBondA(num, h, border, locBondA, ref slae.A, grid);
                        GetLocalUbeta(num, h / 2.0, border, ref locUbeta, grid, time);
                        slae.B[grid.ElPints[0][num][0]] +=
                            h * beta * (4.0 * locUbeta[0] + 2.0 * locUbeta[1] - locUbeta[2]) / 30.0;
                        slae.B[grid.ElPints[0][num][1]] +=
                            h * beta * (2.0 * locUbeta[0] + 16.0 * locUbeta[1] + 2.0 * locUbeta[2]) / 30.0;
                        slae.B[grid.ElPints[0][num][2]] +=
                            h * beta * (-1.0 * locUbeta[0] + 2.0 * locUbeta[1] + 4.0 * locUbeta[2]) / 30.0;
                    }

                    break;
                }
                case 2:
                {
                    for (var i = 0; i < (area.Zpoint - 1); i++)
                    {
                        var num = i * (area.Rpoint - 1) + area.Zpoint - 2;
                        var h = (grid.Node[grid.ElPints[1][num][2]][1] - grid.Node[grid.ElPints[1][num][0]][1]);
                        var beta = Func.Beta();
                        InsertLocBondA(num, h, border, locBondA, ref slae.A, grid);
                        GetLocalUbeta(num, h / 2.0, border, ref locUbeta, grid, time);
                        slae.B[grid.ElPints[0][num][2]] +=
                            h * beta * (4.0 * locUbeta[0] + 2.0 * locUbeta[1] - locUbeta[2]) / 30.0;
                        slae.B[grid.ElPints[0][num][5]] +=
                            h * beta * (2.0 * locUbeta[0] + 16.0 * locUbeta[1] + 2.0 * locUbeta[2]) / 30.0;
                        slae.B[grid.ElPints[0][num][8]] +=
                            h * beta * (-1.0 * locUbeta[0] + 2.0 * locUbeta[1] + 4.0 * locUbeta[2]) / 30.0;
                    }

                    break;
                }
                case 3:
                {
                    for (int i = 0; i < (area.Rpoint - 1); i++)
                    {
                        var num = i + (area.Rpoint - 1) * (area.Zpoint - 2);
                        var h = (grid.Node[grid.ElPints[1][num][1]][0] - grid.Node[grid.ElPints[1][num][0]][0]);
                        var beta = Func.Beta();
                        InsertLocBondA(num, h, border, locBondA, ref slae.A, grid);
                        GetLocalUbeta(num, h / 2.0, border, ref locUbeta, grid, time);
                        slae.B[grid.ElPints[0][num][6]] +=
                            h * beta * (4.0 * locUbeta[0] + 2.0 * locUbeta[1] - locUbeta[2]) / 30.0;
                        slae.B[grid.ElPints[0][num][7]] +=
                            h * beta * (2.0 * locUbeta[0] + 16.0 * locUbeta[1] + 2.0 * locUbeta[2]) / 30.0;
                        slae.B[grid.ElPints[0][num][8]] +=
                            h * beta * (-1.0 * locUbeta[0] + 2.0 * locUbeta[1] + 4.0 * locUbeta[2]) / 30.0;
                    }

                    break;
                }
            }
        }
    }

    public static void One(Area area, Grid grid, BoundaryData boundary, ref Slae slae, double time)
    {
        foreach (var border in boundary.OneBorder)
        {
            switch (border)
            {
                case 0:
                {
                    int num;
                    for (int i = 0; i < (area.Zpoint - 1); i++)
                    {
                        num = i * (area.Rpoint - 1);
                        var h = (grid.Node[grid.ElPints[1][num][2]][1] - grid.Node[grid.ElPints[1][num][0]][1]) / 2.0;
                        double Ugi;
                        for (int j = 0; j < 3; j++)
                        {
                            Ugi = Func.Ug(grid.Node[grid.ElPints[1][num][0]][0],
                                grid.Node[grid.ElPints[1][num][0]][1] + h * j, time, border);
                            del_str(grid.ElPints[0][num][3 * j], Ugi, area, ref slae.A);
                            slae.A.Di[grid.ElPints[0][num][3 * j]] = 1.0;
                            slae.B[grid.ElPints[0][num][3 * j]] = Ugi;
                        }
                    }

                    break;
                }
                case 1:
                {
                    int num;
                    for (int i = 0; i < (area.Rpoint - 1); i++)
                    {
                        num = i;
                        var h = (grid.Node[grid.ElPints[1][num][1]][0] - grid.Node[grid.ElPints[1][num][0]][0]) / 2.0;
                        double Ugi;
                        for (int j = 0; j < 3; j++)
                        {
                            Ugi = Func.Ug(grid.Node[grid.ElPints[1][num][0]][0] + h * j,
                                grid.Node[grid.ElPints[1][num][0]][1], time, border);
                            del_str(grid.ElPints[0][num][j], Ugi, area, ref slae.A);
                            slae.B[grid.ElPints[0][num][j]] = Ugi;
                            slae.A.Di[grid.ElPints[0][num][j]] = 1.0;
                        }
                    }

                    break;
                }
                case 2:
                {
                    int num;
                    for (int i = 0; i < (area.Zpoint - 1); i++)
                    {
                        num = i * (area.Rpoint - 1) + area.Rpoint - 2;
                        var h = (grid.Node[grid.ElPints[1][num][2]][1] - grid.Node[grid.ElPints[1][num][0]][1]) / 2.0;
                        double Ugi;
                        for (int j = 0; j < 3; j++)
                        {
                            Ugi = Func.Ug(grid.Node[grid.ElPints[1][num][1]][0],
                                grid.Node[grid.ElPints[1][num][1]][1] + h * j, time, border);
                            del_str(grid.ElPints[0][num][3 * j + 2], Ugi, area, ref slae.A);
                            slae.B[grid.ElPints[0][num][3 * j + 2]] = Ugi;
                            slae.A.Di[grid.ElPints[0][num][3 * j + 2]] = 1.0;
                        }
                    }

                    break;
                }
                case 3:
                {
                    var num = 0;
                    for (int i = 0; i < (area.Rpoint - 1); i++)
                    {
                        num = i + (area.Rpoint - 1) * (area.Zpoint - 2);
                        var h = (grid.Node[grid.ElPints[1][num][1]][0] - grid.Node[grid.ElPints[1][num][0]][0]) / 2.0;
                        double Ugi;
                        for (int j = 0; j < 3; j++)
                        {
                            Ugi = Func.Ug(grid.Node[grid.ElPints[1][num][2]][0] + h * j,
                                grid.Node[grid.ElPints[1][num][2]][1], time, border);
                            del_str(grid.ElPints[0][num][6 + j], Ugi, area, ref slae.A);
                            slae.B[grid.ElPints[0][num][6 + j]] = Ugi;
                            slae.A.Di[grid.ElPints[0][num][6 + j]] = 1.0;
                        }
                    }

                    break;
                }
            }
        }
    }
    //################################################################################################################################

    private static void del_str(int node, double ugi, Area area, ref Matrix matrix)
    {
        int CurNode;
        for (int i = matrix.Ig[node]; i < matrix.Ig[node + 1]; i++)
        {
            matrix.Al[i] = 0.0;
        }

        for (int i = node; i < (2 * area.Rpoint - 1) * (2 * area.Zpoint - 1); i++)
        {
            CurNode = matrix.Jg[matrix.Ig[i]];
            int k = 0;
            while ((CurNode <= node) && (k < (matrix.Ig[i + 1] - matrix.Ig[i])))
            {
                if (CurNode == node)
                {
                    matrix.Au[matrix.Ig[i] + k] = 0.0;
                }

                k++;
                if (k < (matrix.Ig[i + 1] - matrix.Ig[i]))
                    CurNode = matrix.Jg[matrix.Ig[i] + k];
            }
        }
    }


    public static void GetLocalUbeta(int num, double h, int border, ref double[] locUbeta, Grid grid, double time)
    {
        for (int i = 0; i < 3; i++)
        {
            switch (border)
            {
                case 0:
                {
                    locUbeta[i] = Func.Ubeta(grid.Node[grid.ElPints[1][num][0]][0],
                        grid.Node[grid.ElPints[1][num][0]][1] + h * i, time, border);
                    break;
                }
                case 1:
                {
                    locUbeta[i] = Func.Ubeta(grid.Node[grid.ElPints[1][num][0]][0] + h * i,
                        grid.Node[grid.ElPints[1][num][0]][1], time, border);
                    break;
                }
                case 2:
                {
                    locUbeta[i] = Func.Ubeta(grid.Node[grid.ElPints[1][num][1]][0],
                        grid.Node[grid.ElPints[1][num][1]][1] + h * i, time, border);
                    break;
                }
                case 3:
                {
                    locUbeta[i] = Func.Ubeta(grid.Node[grid.ElPints[1][num][2]][0] + h * i,
                        grid.Node[grid.ElPints[1][num][2]][1], time, border);
                    break;
                }
                default:
                    break;
            }
        }
    }

    public static void GetIndex(int i, int j, ref int Index, int[] _ig, int[] _jg)
    {
        Index = _ig[i];
        while (_jg[Index] != j)
        {
            Index++;
        }
    }

    private static void InsertLocBondA(int num, double h, int border, double[][] locBondA, ref Matrix matrix, Grid grid)
    {
        switch (border)
        {
            case 0:
            {
                int Index = 0;
                var beta = Func.Beta();
                matrix.Di[grid.ElPints[0][num][0]] += h * beta * locBondA[0][0];
                matrix.Di[grid.ElPints[0][num][3]] += h * beta * locBondA[1][1];
                matrix.Di[grid.ElPints[0][num][6]] += h * beta * locBondA[2][2];
                for (int i = 1; i < 3; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        GetIndex(grid.ElPints[0][num][i * 3], grid.ElPints[0][num][3 * j], ref Index, matrix.Ig,
                            matrix.Jg);
                        matrix.Al[Index] += h * beta * locBondA[i][j];
                        matrix.Au[Index] += h * beta * locBondA[i][j];
                    }
                }

                break;
            }
            case 1:
            {
                int Index = 0;
                var beta = Func.Beta();
                matrix.Di[grid.ElPints[0][num][0]] += h * beta * locBondA[0][0];
                matrix.Di[grid.ElPints[0][num][1]] += h * beta * locBondA[1][1];
                matrix.Di[grid.ElPints[0][num][2]] += h * beta * locBondA[2][2];
                for (int i = 1; i < 3; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        GetIndex(grid.ElPints[0][num][i], grid.ElPints[0][num][j], ref Index, matrix.Ig, matrix.Jg);
                        matrix.Al[Index] += h * beta * locBondA[i][j];
                        matrix.Au[Index] += h * beta * locBondA[i][j];
                    }
                }

                break;
            }
            case 2:
            {
                int Index = 0;
                var beta = Func.Beta();
                matrix.Di[grid.ElPints[0][num][2]] += h * beta * locBondA[0][0];
                matrix.Di[grid.ElPints[0][num][5]] += h * beta * locBondA[1][1];
                matrix.Di[grid.ElPints[0][num][8]] += h * beta * locBondA[2][2];
                for (int i = 1; i < 3; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        GetIndex(grid.ElPints[0][num][3 * i + 2], grid.ElPints[0][num][3 * j + 2], ref Index, matrix.Ig,
                            matrix.Jg);
                        matrix.Al[Index] += h * beta * locBondA[i][j];
                        matrix.Au[Index] += h * beta * locBondA[i][j];
                    }
                }

                break;
            }
            case 3:
            {
                int Index = 0;
                var beta = Func.Beta();
                matrix.Di[grid.ElPints[0][num][6]] += h * beta * locBondA[0][0];
                matrix.Di[grid.ElPints[0][num][7]] += h * beta * locBondA[1][1];
                matrix.Di[grid.ElPints[0][num][8]] += h * beta * locBondA[2][2];
                for (int i = 1; i < 3; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        GetIndex(grid.ElPints[0][num][6 + i], grid.ElPints[0][num][6 + j], ref Index, matrix.Ig,
                            matrix.Jg);
                        matrix.Al[Index] += h * beta * locBondA[i][j];
                        matrix.Au[Index] += h * beta * locBondA[i][j];
                    }
                }

                break;
            }
        }
    }

    private static void loc_teta(int num, double h, int border, double[] locTheta, Grid grid, double time)
    {
        for (int i = 0; i < 3; i++)
        {
            switch (border)
            {
                case 0:
                {
                    locTheta[i] = Func.Theta(grid.Node[grid.ElPints[1][num][0]][0],
                        grid.Node[grid.ElPints[1][num][0]][1] + h * i, time, border);
                    break;
                }
                case 1:
                {
                    locTheta[i] = Func.Theta(grid.Node[grid.ElPints[1][num][0]][0] + h * i,
                        grid.Node[grid.ElPints[1][num][0]][1], time, border);
                    break;
                }
                case 2:
                {
                    locTheta[i] = Func.Theta(grid.Node[grid.ElPints[1][num][1]][0],
                        grid.Node[grid.ElPints[1][num][1]][1] + h * i, time, border);
                    break;
                }
                case 3:
                {
                    locTheta[i] = Func.Theta(grid.Node[grid.ElPints[1][num][2]][0] + h * i,
                        grid.Node[grid.ElPints[1][num][2]][1], time, border);
                    break;
                }
            }
        }
    }
}