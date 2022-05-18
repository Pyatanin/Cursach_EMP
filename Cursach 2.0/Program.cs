using System.IO;
using System.Text.Json;

namespace Cursach_2._0;

public static class Program
{
    public static void Main()
    {
       // Elepticheskai();
       // Parobolicheskai();
        TolkoShema4();
    }

    private static void TolkoShema4()
    {
        var area = JsonSerializer.Deserialize<Area>(File.ReadAllText("Data/Area.json"))!;
        var boundary = JsonSerializer.Deserialize<BoundaryData>(File.ReadAllText("Data/Boundary.json"))!;
        var initial = JsonSerializer.Deserialize<Initial>(File.ReadAllText("Data/Initial.json"))!;
        var fem = new Fem(area, boundary, initial, true, 0, "да");

        for (int i = 3; i < fem.TimeGrid.TimeNode.Length; i++)
        {
            var time = fem.TimeGrid.TimeNode[i];

            NonStationary.Shema4(area, initial, fem.TimeGrid, fem.Grid, fem.Slae, i);
            Boundary.Two(area, fem.Grid, boundary, ref fem.Slae, time);
            Boundary.Three(area, fem.Grid, boundary, ref fem.Slae, time);
            Boundary.One(area, fem.Grid, boundary, ref fem.Slae, time);
            var factoriz = new double[3][];
            factoriz[0] = new double[fem.Slae.A.Di.Length];
            factoriz[1] = new double[fem.Slae.A.Al.Length];
            factoriz[2] = new double[fem.Slae.A.Au.Length];
            var k = 0;
            var error = 0.0;
            fem.Slae.LUsq(factoriz[0], factoriz[1], factoriz[2]);
            fem.Slae.LoSPrecond(factoriz[0], factoriz[1], factoriz[2], ref fem.Slae.Qn[i], ref k, ref error);
            Answer(fem, area, k, fem.Slae.Qn[i], error, fem.TimeGrid.TimeNode[i], "Tolko 4");
        }
    }

    public static void Parobolicheskai()
    {
        // считываем данные
        var area = JsonSerializer.Deserialize<Area>(File.ReadAllText("Data/Area.json"))!;
        var boundary = JsonSerializer.Deserialize<BoundaryData>(File.ReadAllText("Data/Boundary.json"))!;
        var initial = JsonSerializer.Deserialize<Initial>(File.ReadAllText("Data/Initial.json"))!;
        var fem = new Fem(area, boundary, initial, true, 0);

        var time = fem.TimeGrid.TimeNode[1];
        // раз 2 слоя
        NonStationary.Shema2(area, initial, fem.TimeGrid, fem.Grid, fem.Slae, 1);
        Boundary.Two(area, fem.Grid, boundary, ref fem.Slae, time);
        Boundary.Three(area, fem.Grid, boundary, ref fem.Slae, time);
        Boundary.One(area, fem.Grid, boundary, ref fem.Slae, time);
        var factoriz = new double[3][];
        factoriz[0] = new double[fem.Slae.A.Di.Length];
        factoriz[1] = new double[fem.Slae.A.Al.Length];
        factoriz[2] = new double[fem.Slae.A.Au.Length];
        var k = 0;
        var error = 0.0;
        Answer(fem, area, k, fem.Slae.Qn[0], error, fem.TimeGrid.TimeNode[0], "Parobolicheskai");
        fem.Slae.LUsq(factoriz[0], factoriz[1], factoriz[2]);
        fem.Slae.LoSPrecond(factoriz[0], factoriz[1], factoriz[2], ref fem.Slae.Qn[1], ref k, ref error);
        Answer(fem, area, k, fem.Slae.Qn[1], error, fem.TimeGrid.TimeNode[1], "Parobolicheskai");

        // раз 3 слоя
        time = fem.TimeGrid.TimeNode[2];
        NonStationary.Shema3(area, initial, fem.TimeGrid, fem.Grid, fem.Slae, 2);
        Boundary.Two(area, fem.Grid, boundary, ref fem.Slae, time);
        Boundary.Three(area, fem.Grid, boundary, ref fem.Slae, time);
        Boundary.One(area, fem.Grid, boundary, ref fem.Slae, time);
        k = 0;
        error = 0.0;
        fem.Slae.LUsq(factoriz[0], factoriz[1], factoriz[2]);
        fem.Slae.LoSPrecond(factoriz[0], factoriz[1], factoriz[2], ref fem.Slae.Qn[2], ref k, ref error);
        Answer(fem, area, k, fem.Slae.Qn[2], error, fem.TimeGrid.TimeNode[2], "Parobolicheskai");
        // три 2 слоя (для проверки)
        //time = fem.TimeGrid.TimeNode[3];
        //NonStationary.Shema2(area, initial, fem.TimeGrid, fem.Grid, fem.Slae, 2);
        //Boundary.Two(area, fem.Grid, boundary, ref fem.Slae, time);
        //Boundary.Three(area, fem.Grid, boundary, ref fem.Slae, time);
        //Boundary.One(area, fem.Grid, boundary, ref fem.Slae, time);
        //k = 0;
        //error = 0.0;
        //fem.Slae.LUsq(factoriz[0], factoriz[1], factoriz[2]);
        //fem.Slae.LoSPrecond(factoriz[0], factoriz[1], factoriz[2], ref fem.Slae.Qn[3], ref k, ref error);
        //Answer(fem, area, k, fem.Slae.Qn[3], error, fem.TimeGrid.TimeNode[3], "Parobolicheskai");

        for (int i = 3; i < fem.TimeGrid.TimeNode.Length; i++)
        {
            time = fem.TimeGrid.TimeNode[i];

            NonStationary.Shema4(area, initial, fem.TimeGrid, fem.Grid, fem.Slae, i);
            Boundary.Two(area, fem.Grid, boundary, ref fem.Slae, time);
            Boundary.Three(area, fem.Grid, boundary, ref fem.Slae, time);
            Boundary.One(area, fem.Grid, boundary, ref fem.Slae, time);
            factoriz = new double[3][];
            factoriz[0] = new double[fem.Slae.A.Di.Length];
            factoriz[1] = new double[fem.Slae.A.Al.Length];
            factoriz[2] = new double[fem.Slae.A.Au.Length];
            k = 0;
            error = 0.0;
            fem.Slae.LUsq(factoriz[0], factoriz[1], factoriz[2]);
            fem.Slae.LoSPrecond(factoriz[0], factoriz[1], factoriz[2], ref fem.Slae.Qn[i], ref k, ref error);
            Answer(fem, area, k, fem.Slae.Qn[i], error, fem.TimeGrid.TimeNode[i], "Parobolicheskai");
        }
    }

    public static void Elepticheskai()
    {
        var area = JsonSerializer.Deserialize<Area>(File.ReadAllText("Data/Area.json"))!;
        var boundary = JsonSerializer.Deserialize<BoundaryData>(File.ReadAllText("Data/Boundary.json"))!;
        var fem = new Fem(area, boundary);

        Boundary.Two(area, fem.Grid, boundary, ref fem.Slae, 0);
        Boundary.Three(area, fem.Grid, boundary, ref fem.Slae, 0);
        Boundary.One(area, fem.Grid, boundary, ref fem.Slae, 0);
        var factoriz = new double[3][];
        factoriz[0] = new double[fem.Slae.A.Di.Length];
        factoriz[1] = new double[fem.Slae.A.Al.Length];
        factoriz[2] = new double[fem.Slae.A.Au.Length];
        fem.Slae.LUsq(factoriz[0], factoriz[1], factoriz[2]);
        var iteration = 0;
        var error = 0.0;
        fem.Slae.LoSPrecond(factoriz[0], factoriz[1], factoriz[2], ref fem.Slae.Q, ref iteration, ref error);
        Answer(fem, area, iteration, fem.Slae.Q, error, 0, "Elepticheskai");
    }

    public static void Answer(Fem fem, Area area, int iteration, double[] q, double error, double time, string str)
    {
        using (System.IO.StreamWriter sw = new System.IO.StreamWriter("Rez.txt", true))
        {
            var realf = new double[q.Length];
            sw.WriteLine($"\n{str}:\ntime:{time}\niteration:{iteration}\nerror:{error}");
            sw.Write("____________________________________________________________\n");
            sw.Write("|__________(r,z)|____________Q|________RealF|_______Q-RealF|\n");
            var k = 0;
            foreach (var z in fem.Grid.Z)
            {
                foreach (var r in fem.Grid.R)
                {
                    realf[k]= Func.RealF(r, z, time);
                    if (q[k] - realf[k] < 0.0)
                        sw.Write(
                            $"|({r:0.0000};{z:0.0000})|  " +
                            "{0,10:0.000000000}|  {1,10:0.000000000}|  {2,10:0.000000000}|\n", q[k], realf[k],
                            q[k] - realf[k]);
                    else
                        sw.Write(
                            $"|({r:0.0000};{z:0.0000})|  " +
                            "{0,10:0.000000000}|  {1,10:0.000000000}|   {2,10:0.000000000}|\n", q[k], realf[k],
                            q[k] - realf[k]);
                    k++;
                }
            }

            var residual = Slae.scalar_prod(realf, realf);

            for (int i = 0; i < q.Length; i++)
            {
                realf[i] -= q[i];
            }

            residual = Slae.scalar_prod(realf, realf) / residual;
            sw.WriteLine($"\nresidual={residual}");
            sw.Close();
        }
    }
}