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

        internal const double TOLLERANCE = .00001;



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

        public override string ToString()
        {
            return string.Format("x: {0} - y: {1} - z: {2}", x, y, z);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Vector3D);
        }

        public bool Equals(Vector3D p)
        {
            // If parameter is null, return false.
            if (Object.ReferenceEquals(p, null))
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, p))
            {
                return true;
            }

            // Define the tolerance for variation in their values
            double difference_x = Math.Abs(p.x * TOLLERANCE);
            double difference_y = Math.Abs(p.y * TOLLERANCE);
            double difference_z = Math.Abs(p.z * TOLLERANCE);

            if (Math.Abs(p.x - x) <= difference_x)
            {
                if (Math.Abs(p.y - y) <= difference_y)
                {
                    if (Math.Abs(p.z - z) <= difference_z)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
            
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32( (x * 0x100000) + (y * 0x1000) + (z * 0x100000));
        }

        public static bool operator ==(Vector3D lhs, Vector3D rhs)
        {
            // Check for null.
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles the case of null on right side.
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Vector3D lhs, Vector3D rhs)
        {
            return !(lhs == rhs);
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
        public static Vector3D VectorialProduct(Vector3D v1, Vector3D v2)
        {
            return new Vector3D((v1.y * v2.z) - (v1.z * v2.y), (v1.z * v2.x) - (v1.x * v2.z), (v1.x * v2.y) - (v1.y * v2.x));
        }

    }
}
