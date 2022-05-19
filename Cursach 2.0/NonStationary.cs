using System;

namespace Cursach_2._0;

public class NonStationary
{
    public static void Shema2(Area area, Initial initial, TimeGrid timeGrid, Grid grid, Slae slae, int index)
    {
        for (int i = 0; i < slae.A.Di.Length; i++)
            slae.A.Di[i] = slae.GlobalG.Di[i] +
                           slae.GlobalM.Di[i] / (timeGrid.TimeNode[index] - timeGrid.TimeNode[index - 1]);
        for (int i = 0; i < slae.GlobalG.Al.Length; i++)
            slae.A.Al[i] = slae.GlobalG.Al[i] +
                           slae.GlobalM.Al[i] / (timeGrid.TimeNode[index] - timeGrid.TimeNode[index - 1]);
        for (int i = 0; i < slae.GlobalG.Au.Length; i++)
            slae.A.Au[i] = slae.GlobalG.Al[i] +
                           slae.GlobalM.Au[i] / (timeGrid.TimeNode[index] - timeGrid.TimeNode[index - 1]);

        var mqPred = Matrix.Mult(slae.GlobalM, slae.Qn[index - 1]);
        slae.GlobalB.AsSpan().CopyTo(slae.B);
        for (int i = 0; i < slae.B.Length; i++)
        {
            slae.B[i] += mqPred[i] / (timeGrid.TimeNode[index] - timeGrid.TimeNode[index - 1]);
        }
    }

    public static void Shema3(Area area, Initial initial, TimeGrid timeGrid, Grid grid, Slae slae, int index)
    {
        var t = timeGrid.TimeNode[index] - timeGrid.TimeNode[index - 2];
        var t1 = timeGrid.TimeNode[index - 1] - timeGrid.TimeNode[index - 2];
        var t0 = timeGrid.TimeNode[index] - timeGrid.TimeNode[index - 1];

        var coefM = (t + t0) / (t * t0);

        for (int i = 0; i < slae.A.Di.Length; i++)
            slae.A.Di[i] = slae.GlobalG.Di[i] + coefM * slae.GlobalM.Di[i];
        for (int i = 0; i < slae.GlobalG.Al.Length; i++)
            slae.A.Al[i] = slae.GlobalG.Al[i] + coefM * slae.GlobalM.Al[i];
        for (int i = 0; i < slae.GlobalG.Au.Length; i++)
            slae.A.Au[i] = slae.GlobalG.Al[i] + coefM * slae.GlobalM.Au[i];

        var q2 = Matrix.Mult(slae.GlobalM, slae.Qn[index - 2]);
        var qt2 = t0 / (t * t1);
        var q1 = Matrix.Mult(slae.GlobalM, slae.Qn[index - 1]);
        var qt1 = t / (t1 * t0);

        slae.GlobalB.AsSpan().CopyTo(slae.B);
        for (int i = 0; i < slae.B.Length; i++)
        {
            slae.B[i] += -q2[i] * qt2 + q1[i] * qt1;
        }
    }

    public static void Shema4(Area area, Initial initial, TimeGrid timeGrid, Grid grid, Slae slae, int index, int func)
    {
        var t0 = timeGrid.TimeNode[index];
        var t1 = timeGrid.TimeNode[index - 1];
        var t2 = timeGrid.TimeNode[index - 2];
        var t3 = timeGrid.TimeNode[index - 3];

        var t01 = t0 - t1;
        var t02 = t0 - t2;
        var t03 = t0 - t3;

        var t12 = t1 - t2;
        var t23 = t2 - t3;
        var t13 = t1 - t3;


        // var coefM = (t01 * t02 + t01 * t03 + t02 * t03) / t01 * t02 * t03;
        var coefM = 1 / t01 + 1 / t02 + 1 / t03;

        for (int i = 0; i < slae.A.Di.Length; i++)
            slae.A.Di[i] = slae.GlobalG.Di[i] + coefM * slae.GlobalM.Di[i];
        for (int i = 0; i < slae.GlobalG.Al.Length; i++)
            slae.A.Al[i] = slae.GlobalG.Al[i] + coefM * slae.GlobalM.Al[i];
        for (int i = 0; i < slae.GlobalG.Au.Length; i++)
            slae.A.Au[i] = slae.GlobalG.Al[i] + coefM * slae.GlobalM.Au[i];

        var q1 = Matrix.Mult(slae.GlobalM, slae.Qn[index - 1]); //M * q^(j-1)
        var qt1 = (t02 * t03) / (t01 * t12 * t13);
        var q2 = Matrix.Mult(slae.GlobalM, slae.Qn[index - 2]); //M * q^(j-2)
        var qt2 = (t01 * t03) / (t02 * t12 * t23);
        var q3 = Matrix.Mult(slae.GlobalM, slae.Qn[index - 3]); //M * q^(j-3)
        var qt3 = (t01 * t02) / (t03 * t13 * t23);

        Slae.GlobalBildB(area, grid,slae, ref slae.B, t0, func);
        for (int i = 0; i < slae.B.Length; i++)
        {
            slae.B[i] += q3[i] * qt3;
            slae.B[i] -= q2[i] * qt2;
            slae.B[i] += q1[i] * qt1;
        }
    }
}