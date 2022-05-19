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
        return 1.0;
    }

    public static double Sigma(double r, double z, double t)
    {
        return 1.0;
    }

    public static double RealF(double r, double z, double t,double function) // Реальная функция
    {
        switch (function)
        {
            case 1: return 5; //u=5
            case 2: return 5 + Math.Pow(t, 1); //u=5+t
            case 3: return 5 + Math.Pow(t, 2); //u=5+t^2
            case 4: return 5 + Math.Pow(t, 3); //u=5+t^3
            case 5: return 5 + Math.Pow(t, 4); //u=5+t^4
            case 6: return 5 + Math.Pow(t, 5); //u=5+t^5
            case 7: return 5 + Math.Sin(t); //u=5+sin(t)
            case 8: return 5 + Math.Exp(t); //u=5+e^t

            case 9: return Math.Pow(r, 1) + Math.Pow(z, 1); //u=r+z
            case 10: return Math.Pow(r, 1) + Math.Pow(z, 1) + Math.Pow(t, 1); //u=r+z+t
            case 11: return Math.Pow(r, 1) + Math.Pow(z, 1) + Math.Pow(t, 2); //u=r+z+t^2
            case 12: return Math.Pow(r, 1) + Math.Pow(z, 1) + Math.Pow(t, 3); //u=r+z+t^3
            case 13: return Math.Pow(r, 1) + Math.Pow(z, 1) + Math.Pow(t, 4); //u=r+z+t^4
            case 14: return Math.Pow(r, 1) + Math.Pow(z, 1) + Math.Pow(t, 5); //u=r+z+t^5
            case 15: return Math.Pow(r, 1) + Math.Pow(z, 1) + Math.Sin(t); //u=r+z+sin(t)
            case 16: return Math.Pow(r, 1) + Math.Pow(z, 1) + Math.Exp(t); //u=r+z+e^t

            case 17: return Math.Pow(r, 2) + Math.Pow(z, 2); //u=r^2+z^2
            case 18: return Math.Pow(r, 2) + Math.Pow(z, 2) + Math.Pow(t, 1); //u=r^2+z^2+t
            case 19: return Math.Pow(r, 2) + Math.Pow(z, 2) + Math.Pow(t, 2); //u=r^2+z^2+t^2
            case 20: return Math.Pow(r, 2) + Math.Pow(z, 2) + Math.Pow(t, 3); //u=r^2+z^2+t^3
            case 21: return Math.Pow(r, 2) + Math.Pow(z, 2) + Math.Pow(t, 4); //u=r^2+z^2+t^4
            case 22: return Math.Pow(r, 2) + Math.Pow(z, 2) + Math.Pow(t, 5); //u=r^2+z^2+t^5
            case 23: return Math.Pow(r, 2) + Math.Pow(z, 2) + Math.Sin(t); //u=r^2+z^2+sin(t)
            case 24: return Math.Pow(r, 2) + Math.Pow(z, 2) + Math.Exp(t); //u=r^2+z^2+e^t

            case 25: return Math.Pow(r, 3) + Math.Pow(z, 3);                  //u=r^3+z^3
            case 26: return Math.Pow(r, 3) + Math.Pow(z, 3) + Math.Pow(t, 1); //u=r^3+z^3+t
            case 27: return Math.Pow(r, 3) + Math.Pow(z, 3) + Math.Pow(t, 2); //u=r^3+z^3+t^2
            case 28: return Math.Pow(r, 3) + Math.Pow(z, 3) + Math.Pow(t, 3); //u=r^3+z^3+t^3
            case 29: return Math.Pow(r, 3) + Math.Pow(z, 3) + Math.Pow(t, 4); //u=r^3+z^3+t^4
            case 30: return Math.Pow(r, 3) + Math.Pow(z, 3) + Math.Pow(t, 5); //u=r^3+z^3+t^5
            case 31: return Math.Pow(r, 3) + Math.Pow(z, 3) + Math.Sin(t); //   u=r^3+z^3+sin(t)
            case 32: return Math.Pow(r, 3) + Math.Pow(z, 3) + Math.Exp(t); //   u=r^3+z^3+e^t

            case 33: return Math.Pow(r, 4) + Math.Pow(z, 4); //                 u=r^4+z^4
            case 34: return Math.Pow(r, 4) + Math.Pow(z, 4) + Math.Pow(t, 1); //u=r^4+z^4+t
            case 35: return Math.Pow(r, 4) + Math.Pow(z, 4) + Math.Pow(t, 2); //u=r^4+z^4+t^2
            case 36: return Math.Pow(r, 4) + Math.Pow(z, 4) + Math.Pow(t, 3); //u=r^4+z^4+t^3
            case 37: return Math.Pow(r, 4) + Math.Pow(z, 4) + Math.Pow(t, 4); //u=r^4+z^4+t^4
            case 38: return Math.Pow(r, 4) + Math.Pow(z, 4) + Math.Pow(t, 5); //u=r^4+z^4+t^5
            case 39: return Math.Pow(r, 4) + Math.Pow(z, 4) + Math.Sin(t); //   u=r^4+z^4+sin(t)
            case 40: return Math.Pow(r, 4) + Math.Pow(z, 4) + Math.Exp(t); //   u=r^4+z^4+e^t

            case 41: return Math.Pow(r, 5) + Math.Pow(z, 5); //                 u=r^3+z^3
            case 42: return Math.Pow(r, 5) + Math.Pow(z, 5) + Math.Pow(t, 1); //u=r^3+z^3+t
            case 43: return Math.Pow(r, 5) + Math.Pow(z, 5) + Math.Pow(t, 2); //u=r^3+z^3+t^2
            case 44: return Math.Pow(r, 5) + Math.Pow(z, 5) + Math.Pow(t, 3); //u=r^3+z^3+t^3
            case 45: return Math.Pow(r, 5) + Math.Pow(z, 5) + Math.Pow(t, 4); //u=r^3+z^3+t^4
            case 46: return Math.Pow(r, 5) + Math.Pow(z, 5) + Math.Pow(t, 5); //u=r^3+z^3+t^5
            case 47: return Math.Pow(r, 5) + Math.Pow(z, 5) + Math.Sin(t); //   u=r^3+z^3+sin(t)
            case 48: return Math.Pow(r, 5) + Math.Pow(z, 5) + Math.Exp(t); //   u=r^3+z^3+e^t

            case 49: return Math.Sin(r) + Math.Sin(z); //                       u=sin(r)+sin(z)
            case 50: return Math.Sin(r) + Math.Sin(z) + Math.Pow(t, 1); //      u=sin(r)+sin(z)+t
            case 51: return Math.Sin(r) + Math.Sin(z) + Math.Pow(t, 2); //      u=sin(r)+sin(z)+t^2
            case 52: return Math.Sin(r) + Math.Sin(z) + Math.Pow(t, 3); //      u=sin(r)+sin(z)+t^3
            case 53: return Math.Sin(r) + Math.Sin(z) + Math.Pow(t, 4); //      u=sin(r)+sin(z)+t^4
            case 54: return Math.Sin(r) + Math.Sin(z) + Math.Pow(t, 5); //      u=sin(r)+sin(z)+t^5
            case 55: return Math.Sin(r) + Math.Sin(z) + Math.Sin(t); //         u=sin(r)+sin(z)+sin(t)
            case 56: return Math.Sin(r) + Math.Sin(z) + Math.Exp(t); //         u=sin(r)+sin(z)+e^t

            case 57: return Math.Exp(r) + Math.Exp(z); //                       u=exp(r)+exp(z)
            case 58: return Math.Exp(r) + Math.Exp(z) + Math.Pow(t, 1); //      u=exp(r)+exp(z)+t
            case 59: return Math.Exp(r) + Math.Exp(z) + Math.Pow(t, 2); //      u=exp(r)+exp(z)+t^2
            case 60: return Math.Exp(r) + Math.Exp(z) + Math.Pow(t, 3); //      u=exp(r)+exp(z)+t^3
            case 61: return Math.Exp(r) + Math.Exp(z) + Math.Pow(t, 4); //      u=exp(r)+exp(z)+t^4
            case 62: return Math.Exp(r) + Math.Exp(z) + Math.Pow(t, 5); //      u=exp(r)+exp(z)+t^5
            case 63: return Math.Exp(r) + Math.Exp(z) + Math.Sin(t); //         u=exp(r)+exp(z)+sin(t)
            case 64: return Math.Exp(r) + Math.Exp(z) + Math.Exp(t); //         u=exp(r)+exp(z)+e^t
        }

        return 0;
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
                return 5;
                break;
            }
            case 1:
            {
                return 5;
                break;
            }
            case 2:
            {
                return 5 + t * t;
                break;
            }
            case 3:
            {
                return 5 + t * t;
                break;
            }
        }

        return 0;
    }

    public static double Ug(double r, double z, double t, int border, double function) // 1 кроевые
    {
        return RealF(r,  z, t,function);
        return 0;
    }

    public static double F(double r, double z, double t,double function) // правая часть
    {
        switch (function)
        {
            case 1: return 0; //                                                   u=5
            case 2: return 1; //                                                   u=5+t
            case 3: return 2 * Math.Pow(t, 1); //                                  u=5+t^2
            case 4: return 3 * Math.Pow(t, 2); //                                  u=5+t^3
            case 5: return 4 * Math.Pow(t, 3); //                                  u=5+t^4
            case 6: return 5 * Math.Pow(t, 4); //                                  u=5+t^5
            case 7: return Math.Cos(t); //                                         u=5+sin(t)
            case 8: return Math.Exp(t); //                                         u=5+e^t

            case 9: return  -(1/r + 0); //                                  u=r+z
            case 10: return -(1/r + 0) + 1; //                             u=r+z+t
            case 11: return -(1/r + 0) + 2 * Math.Pow(t, 1); //            u=r+z+t^2
            case 12: return -(1/r + 0) + 3 * Math.Pow(t, 2); //            u=r+z+t^3
            case 13: return -(1/r + 0) + 4 * Math.Pow(t, 3); //            u=r+z+t^4
            case 14: return -(1/r + 0) + 5 * Math.Pow(t, 4); //            u=r+z+t^5
            case 15: return -(1/r + 0) + Math.Cos(t); //                   u=r+z+sin(t)
            case 16: return -(1/r + 0) + Math.Exp(t); //                   u=r+z+e^t

            case 17: return -(4 + 2); //                        u=r^2+z^2
            case 18: return -(4 + 2) + 1; //                    u=r^2+z^2+t
            case 19: return -(4 + 2) + 2 * Math.Pow(t, 1); //   u=r^2+z^2+t^2
            case 20: return -(4 + 2) + 3 * Math.Pow(t, 2); //   u=r^2+z^2+t^3
            case 21: return -(4 + 2) + 4 * Math.Pow(t, 3); //   u=r^2+z^2+t^4
            case 22: return -(4 + 2) + 5 * Math.Pow(t, 4); //   u=r^2+z^2+t^5
            case 23: return -(4 + 2) + Math.Cos(t); //          u=r^2+z^2+sin(t)
            case 24: return -(4 + 2) + Math.Exp(t); //          u=r^2+z^2+e^t

            case 25: return -(9 * Math.Pow(r, 1) + 6 * Math.Pow(z, 1)); //                       u=r^3+z^3
            case 26: return -(9 * Math.Pow(r, 1) + 6 * Math.Pow(z, 1)) + 1; //               //  u=r^3+z^3+t
            case 27: return -(9 * Math.Pow(r, 1) + 6 * Math.Pow(z, 1)) + 2 * Math.Pow(t, 1); //  u=r^3+z^3+t^2
            case 28: return -(9 * Math.Pow(r, 1) + 6 * Math.Pow(z, 1)) + 3 * Math.Pow(t, 2); //  u=r^3+z^3+t^3
            case 29: return -(9 * Math.Pow(r, 1) + 6 * Math.Pow(z, 1)) + 4 * Math.Pow(t, 3); //  u=r^3+z^3+t^4
            case 30: return -(9 * Math.Pow(r, 1) + 6 * Math.Pow(z, 1)) + 5 * Math.Pow(t, 4); //  u=r^3+z^3+t^5
            case 31: return -(9 * Math.Pow(r, 1) + 6 * Math.Pow(z, 1)) + Math.Cos(t); //         u=r^3+z^3+sin(t)
            case 32: return -(9 * Math.Pow(r, 1) + 6 * Math.Pow(z, 1)) + Math.Exp(t); //         u=r^3+z^3+e^t

            case 33: return -(16 * Math.Pow(r, 2) + 12 * Math.Pow(z, 2)); //                     u=r^4+z^4
            case 34: return -(16 * Math.Pow(r, 2) + 12 * Math.Pow(z, 2)) + 1; //               //u=r^4+z^4+t
            case 35: return -(16 * Math.Pow(r, 2) + 12 * Math.Pow(z, 2)) + 2 * Math.Pow(t, 1); //u=r^4+z^4+t^2
            case 36: return -(16 * Math.Pow(r, 2) + 12 * Math.Pow(z, 2)) + 3 * Math.Pow(t, 2); //u=r^4+z^4+t^3
            case 37: return -(16 * Math.Pow(r, 2) + 12 * Math.Pow(z, 2)) + 4 * Math.Pow(t, 3); //u=r^4+z^4+t^4
            case 38: return -(16 * Math.Pow(r, 2) + 12 * Math.Pow(z, 2)) + 5 * Math.Pow(t, 4); //u=r^4+z^4+t^5
            case 39: return -(16 * Math.Pow(r, 2) + 12 * Math.Pow(z, 2)) + Math.Cos(t); //       u=r^4+z^4+sin(t)
            case 40: return -(16 * Math.Pow(r, 2) + 12 * Math.Pow(z, 2)) + Math.Exp(t); //       u=r^4+z^4+e^t

            case 41: return -(25 * Math.Pow(r, 3) + 20 * Math.Pow(z, 3)); //                     u=r^3+z^3
            case 42: return -(25 * Math.Pow(r, 3) + 20 * Math.Pow(z, 3)) + 1; //               //u=r^3+z^3+t
            case 43: return -(25 * Math.Pow(r, 3) + 20 * Math.Pow(z, 3)) + 2 * Math.Pow(t, 1); //u=r^3+z^3+t^2
            case 44: return -(25 * Math.Pow(r, 3) + 20 * Math.Pow(z, 3)) + 3 * Math.Pow(t, 2); //u=r^3+z^3+t^3
            case 45: return -(25 * Math.Pow(r, 3) + 20 * Math.Pow(z, 3)) + 4 * Math.Pow(t, 3); //u=r^3+z^3+t^4
            case 46: return -(25 * Math.Pow(r, 3) + 20 * Math.Pow(z, 3)) + 5 * Math.Pow(t, 4); //u=r^3+z^3+t^5
            case 47: return -(25 * Math.Pow(r, 3) + 20 * Math.Pow(z, 3)) + Math.Cos(t); //       u=r^3+z^3+sin(t)
            case 48: return -(25 * Math.Pow(r, 3) + 20 * Math.Pow(z, 3)) + Math.Exp(t); //       u=r^3+z^3+e^t

            case 49: return -((Math.Cos(r) - r * Math.Sin(r)) / r - Math.Sin(z)); //                           u=sin(r)+sin(z)
            case 50: return -((Math.Cos(r) - r * Math.Sin(r)) / r - Math.Sin(z)) + 1; //               //      u=sin(r)+sin(z)+t
            case 51: return -((Math.Cos(r) - r * Math.Sin(r)) / r - Math.Sin(z)) + 2 * Math.Pow(t, 1); //      u=sin(r)+sin(z)+t^2
            case 52: return -((Math.Cos(r) - r * Math.Sin(r)) / r - Math.Sin(z)) + 3 * Math.Pow(t, 2); //      u=sin(r)+sin(z)+t^3
            case 53: return -((Math.Cos(r) - r * Math.Sin(r)) / r - Math.Sin(z)) + 4 * Math.Pow(t, 3); //      u=sin(r)+sin(z)+t^4
            case 54: return -((Math.Cos(r) - r * Math.Sin(r)) / r - Math.Sin(z)) + 5 * Math.Pow(t, 4); //      u=sin(r)+sin(z)+t^5
            case 55: return -((Math.Cos(r) - r * Math.Sin(r)) / r - Math.Sin(z)) + Math.Cos(t); //             u=sin(r)+sin(z)+sin(t)
            case 56: return -((Math.Cos(r) - r * Math.Sin(r)) / r - Math.Sin(z)) + Math.Exp(t); //             u=sin(r)+sin(z)+e^t-r*
            
            case 57: return -((Math.Exp(r) + r * Math.Exp(r)) / r + Math.Exp(z)); //                           u=exp(r)+exp(z)
            case 58: return -((Math.Exp(r) + r * Math.Exp(r)) / r + Math.Exp(z)) + 1; //               //      u=exp(r)+exp(z)+t
            case 59: return -((Math.Exp(r) + r * Math.Exp(r)) / r + Math.Exp(z)) + 2 * Math.Pow(t, 1); //      u=exp(r)+exp(z)+t^2
            case 60: return -((Math.Exp(r) + r * Math.Exp(r)) / r + Math.Exp(z)) + 3 * Math.Pow(t, 2); //      u=exp(r)+exp(z)+t^3
            case 61: return -((Math.Exp(r) + r * Math.Exp(r)) / r + Math.Exp(z)) + 4 * Math.Pow(t, 3); //      u=exp(r)+exp(z)+t^4
            case 62: return -((Math.Exp(r) + r * Math.Exp(r)) / r + Math.Exp(z)) + 5 * Math.Pow(t, 4); //      u=exp(r)+exp(z)+t^5
            case 63: return -((Math.Exp(r) + r * Math.Exp(r)) / r + Math.Exp(z)) + Math.Cos(t); //             u=exp(r)+exp(z)+sin(t)
            case 64: return -((Math.Exp(r) + r * Math.Exp(r)) / r + Math.Exp(z)) + Math.Exp(t); //             u=exp(r)+exp(z)+e^t
        }

        return 0;
    }
}