using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace NamucMathLibrary
{
    

    class NamVector : INamVector, ICloneable, IEnumerable
    {
       
        /// <summary>
        /// Elements of the N dimensional vector
        /// </summary>
        private readonly float[] _elements;

        /// <summary>
        /// NUmber of N components of the vector
        /// </summary>
        private uint _numOfComponents;

        /// <summary>
        /// Norm of the vector
        /// </summary>
        private float _norm;
         

        public uint Components
        {
            get { return _numOfComponents; }
        }

        public float this[int componentIndex]
        {
            get
            {
                return this[componentIndex];
            }
            set
            {
                this[componentIndex] = value;
            }
        }

        
        /// <summary>
        /// Calculate the 2 based norm of the N vector
        /// </summary>
        public float Norm
        {
            get {
                double cal = 0;
                foreach (float item in _elements)
                    cal += Math.Pow((float)item, (float)2);
                _norm = (float)Math.Sqrt(cal);
                return _norm; }
        }

        public INamVector Normalized
        {
            get {
                // TODO da rivedere l'algoritmo
                INamVector vect = (NamVector)this.Clone();
                int index = 0;
                foreach (float item in vect)
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
    }
}
