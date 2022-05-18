namespace Cursach_2._0;

public class Func
{
    public static double Beta()
    {
        return 1.0;
    }
    public static double Lambda(double r, double z, double t)
    {
        return 1.0;
    }
    public static double Gamma(double r, double z, double t)
    {
        return 0.0;
    }
    public static double Sigma(double r, double z, double t)
    {
        return 1.0;
    }
    public static double RealF(double r, double z, double t) // Реальная функция
    {
        return t*t*t*t;
    }
    public static double Theta(double r, double z, double t, int border) // странный кружочек 2 краевые
    {
        switch (border)
        {
            case 0:
            {
                return 0;
                break;
            }
            case 1:
            {
                return 0;
                break;
            }
            case 2:
            {
                return 0;
                break;
            }
            case 3:
            {
                return 0;
                break;
            }
        }

        return 0;
    }

    public static double Ubeta(double r, double z, double t, int border) // 3 краевые коэф
    {
        switch (border)
        {
            case 0:
            {
                return 5+t*t;
                break;
            }
            case 1:
            {
                return 5+t*t;
                break;
            }
            case 2:
            {
                return 5+t*t;
                break;
            }
            case 3:
            {
                return 5+t*t;
                break;
            }
        }

        return 0;
    }

    public static double Ug(double r, double z, double t, int border) // 1 кроевые
    {
        switch (border)
        {
            case 0:
            {
                return t*t*t*t;
                break;
            }
            case 1:
            {
                return t*t*t*t;
                break;
            }
            case 2:
            {
                return t*t*t*t;
                break;
            }
            case 3:
            {
                return t*t*t*t;
                break;
            }
        }
        return 0;
    }

    public static double F(double r, double z, double t) // правая часть
    {
        return 4*t*t*t;
    }
}