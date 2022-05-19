namespace Cursach_2._0;

public class Fem
{
    public Grid Grid;
    public Slae Slae;
    public TimeGrid TimeGrid { get; }

    public Fem(Area area, BoundaryData boundary, Initial initial, bool isTimeShem, double time, int func, string str)
    {
        Grid = new Grid(area);
        if (isTimeShem)
        {
            TimeGrid = new TimeGrid(initial);
        }

        Slae = new Slae(area, initial, Grid, TimeGrid, time,func, str);
    }
    public Fem(Area area, BoundaryData boundary, Initial initial, bool isTimeShem, double time, int func)
    {
        Grid = new Grid(area);
        if (isTimeShem)
        {
            TimeGrid = new TimeGrid(initial);
        }

        Slae = new Slae(area, initial, Grid, TimeGrid, time, func);
    }
    public Fem(Area area, BoundaryData boundary, int func)
    {
        Grid = new Grid(area);
        Slae = new Slae(area, Grid, func);
    }
}