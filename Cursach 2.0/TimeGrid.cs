namespace Cursach_2._0;

public class TimeGrid
{
    public double[] TimeNode { get; }

    public TimeGrid(Initial initial)
    {
        var t = new double[initial.TimePoint];
        t[0] = initial.TimeStart;

        if (Math.Abs(initial.DischargeRatioT - 1) > 1e-10)
        {
            //Grid creation is based on the development of a geometric progression
            var sumKx = (1 - Math.Pow(initial.DischargeRatioT, initial.TimePoint - 1)) /
                        (1 - initial.DischargeRatioT);
            var ht = (initial.TimeFinish - initial.TimeStart) / sumKx;

            for (var i = 1; i < initial.TimePoint; i++)
            {
                t[i] = initial.TimeStart +
                       ht * (1 - Math.Pow(initial.DischargeRatioT, i)) / (1 - initial.DischargeRatioT);
            }
        }
        else
        {
            var ht = (initial.TimeFinish - initial.TimeStart) / (initial.TimePoint - 1);

            for (var i = 1; i < initial.TimePoint; i++)
            {
                t[i] = initial.TimeStart + i * ht;
            }
        }

        TimeNode = t;
    }
}