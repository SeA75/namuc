using System;

namespace Namuc
{
    public class Vector3D
    {
        public Vector3D()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Vector3D(double ix, double iy, double iz)
        {
            x = ix;
            y = iy;
            z = iz;
        }



        public double x;

        public double y;

        public double z;

        public void Invert()
        {
            x = -x;
            y = -y;
            z = -z;
        }


        public double Magnitude()
        {
            return Math.Sqrt( (Math.Pow(x,2)+Math.Pow(y,2) + Math.Pow(z,2)));
        }

        public double SquareMagnitude()
        {
            return (Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }

        public void Normalize()
        {
            double u = Magnitude();

            x /= u;
            y /= u;
            z /= u;
        }

        //public Vector3D ScalarMultiplication(double m)
        //{
        //    Vector3D ret = new Vector3D(m * x, m * y, m * z);
        //    return ret;
        //}

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector3D operator *(Vector3D v1, double value)
        {
            return new Vector3D(v1.x *value, v1.y * value, v1.z * value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.x+v2.x, v1.y+v2.y, v1.z+v2.z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3D ComponentProduct(Vector3D v1, Vector3D v2 )
        {
            return new Vector3D(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        public void SelfComponentProduct(Vector3D v1)
        {
            x = v1.x * x;
            y = v1.y * y;
            z = v1.z * z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <returns></returns>
        public double ScalarProduct(Vector3D v1)
        {
            return (x * v1.x + y * v1.y + z * v1.z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3D VectorProduct(Vector3D v1, Vector3D v2)
        {
            return new Vector3D((v1.y * v2.z) - (v1.z * v2.y), (v1.z * v2.x) - (v1.x * v2.z), (v1.x * v2.y) - (v1.y - v2.x));
        }

    }
}
