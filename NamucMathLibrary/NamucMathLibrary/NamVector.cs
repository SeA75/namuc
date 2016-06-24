using System;
using System.Collections;
using System.Linq;
using System.Text;


namespace NamucMathLibrary
{
    

    public class NamVector : INamVector, ICloneable, IEnumerable
    {
        public NamVector(int numOfComponent) 
        {
            _numOfComponents = numOfComponent;
            _elements = new double[_numOfComponents];
            Tolerance = 0.000001;
        }

        public NamVector(double[] components)
        {
            _numOfComponents = components.Length;
            _elements = new double[components.Length];
            for (int i = 0; i < _numOfComponents; i++)
                _elements[i] = components[i];
            Tolerance = 0.000001;

        }

        public override bool Equals(object obj)
        {
            if(obj is NamVector && obj != null)
            {
                NamVector temp;
                temp = (NamVector)obj;
                for(int i = 0; i < temp._numOfComponents; i++)
                {
                    if (Math.Abs(temp[i] - this[i]) > Tolerance)
                        return false;
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

       
        /// <summary>
        /// Elements of the N dimensional vector
        /// </summary>
        private readonly double[] _elements;

        /// <summary>
        /// NUmber of N components of the vector
        /// </summary>
        private readonly int _numOfComponents;

        /// <summary>
        /// Norm of the vector
        /// </summary>
        private double _norm;
         

        public int Components
        {
            get { return _numOfComponents; }
        }

        public double this[int componentIndex]
        {
            get
            {
                return _elements[componentIndex];
            }
            set
            {
                _elements[componentIndex] = value;
            }
        }

        
        /// <summary>
        /// Calculate the 2 based norm of the N vector
        /// </summary>
        public double Norm
        {
            get {
                double cal = 0;
                foreach (double item in _elements)
                    cal += Math.Pow((double)item, (double)2);
                _norm = (double)Math.Sqrt(cal);
                return _norm; }
        }

        public INamVector Normalize
        {
            get {
                // TODO da rivedere l'algoritmo
                INamVector vect = (NamVector)this.Clone();
                int index = 0;
                foreach (double item in vect)
                {
                    vect[index] = item / _norm;
                    index++;
                }
                return vect;
                
            }
        }



        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public IEnumerator GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        public override string ToString()
        {
            string sep = ":";
            return String.Join(sep, _elements);
        }

        public static NamVector operator +(NamVector c1, NamVector c2)
        {
            if (c1._numOfComponents != c2._numOfComponents)
                throw new InvalidOperationException("vectors have different size");

            int length = c2._numOfComponents;
            double[] elems = new double[length];
            for (int i = 0; i < length; i++)
            {
                elems[i] = c1[i] + c2[i];
            }
            return new NamVector(elems);
        }

        
        public static bool operator ==(NamVector a, NamVector b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            if(a._numOfComponents != b._numOfComponents)
                return false;

            for (int counter = 0; counter < a._numOfComponents;counter++ )
            {
                if (Math.Abs(a[counter] - b[counter]) > Tolerance)
                    return false;
            }
            // Return true if the fields match:
            return true;
        }

        public static bool operator !=(NamVector a, NamVector b)
        {
            return !(a == b);
        }

        public static double Tolerance { get; set; }
    }
}
