﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamucMathLibrary
{
    /// <summary>
    /// Namuc vector interface for vector
    /// </summary>
    public interface INamVector : IEnumerable
    {
        /// <summary>
        /// Get number of components
        /// </summary>
        Int32 Components { get; }

        /// <summary>
        /// Get or set the elements of the vector
        /// </summary>
        /// <param name="componentIndex"></param>
        /// <returns></returns>
        double this[int componentIndex]
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the norm of the vector
        /// </summary>
        double Norm
        {
            get;
        }

        /// <summary>
        /// Gets the normalize form of the vector.
        /// </summary>
        INamVector Normalize
        {
            get;
        }

    }
    
}
