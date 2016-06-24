using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NamucMathLibrary;

namespace NamucMathLibraryTest
{
    [TestClass]
    public class UnitTestVector
    {
        [TestMethod]
        public void TestVectorCtor()
        {
            //Arrange
            var elems = new double[3]{1,2,3};
            INamVector vector = new NamVector(elems);
            
            //Act

            //Assert
            Assert.AreEqual(1,vector[0] );
            Assert.AreEqual(2, vector[1]);
            Assert.AreEqual(3, vector[2]);

        }

        [TestMethod]
        public void TestVectorLengh()
        {
            var elems = new double[3];
            elems[0] = 1;
            elems[1] = 2;
            elems[2] = 3;
            INamVector vector = new NamVector(elems);

            //Assert
            Assert.AreEqual(3, vector.Components);

        }

        [TestMethod]
        public void TestVectorNorm()
        {
            //Arrange
            double one = 1;
            double two = 2;
            double three = 3;
            var elems = new double[3];
            elems[0] = one;
            elems[1] = two;
            elems[2] = three;
            INamVector vector = new NamVector(elems);
            var expectedNorm = Math.Sqrt((one + Math.Pow(two, 2) + Math.Pow(three, 2)));

            //Act
            double norm = vector.Norm;

            //Assert
            Assert.AreEqual(expectedNorm, norm );
        }

        [TestMethod]
        public void TestVectorEqual()
        {
            //arrange
            var elems = new double[3] {1, 2, 3};
            INamVector vector1 = new NamVector(elems);
            var elems2 = new double[3]{1,2,3};
            INamVector vector2 = new NamVector(elems2);
            
            //Assert
           Assert.AreEqual(vector1, vector2);
            Assert.AreEqual(vector1, vector1);
            Assert.AreEqual(vector2, vector2);


        }

        [TestMethod]
        public void TestVectorNotEqual()
        {
            //arrange
            var elems = new double[] { 1, 2, 3 };
            INamVector vector1 = new NamVector(elems);
            var elems2 = new double[] { 1, 2, 4 };
            INamVector vector2 = new NamVector(elems2);
            
            //Assert
            Assert.AreNotEqual(vector1, vector2);
            Assert.AreNotEqual(vector1, null);



        }

        [TestMethod]
        public void TestVectorNormalize()
        {
            //arrange
            var elems = new double[] {1, 2, 3};
            INamVector vector1 = new NamVector(elems);
            
            INamVector expectedNormalizedVector =
                new NamVector(new[] {1/(Math.Sqrt(14)), Math.Sqrt((double) 2/7), Math.Sqrt((double) 9/14)});


            //Act
           INamVector normalizedVector = vector1.Normalize;


            //Assert
            Assert.AreNotEqual(expectedNormalizedVector, normalizedVector);
        }

        [TestMethod]
        public void TestVectorEquality()
        {
            //arrange
            var Myelems = new double[] { 1, 2, 3 };
            NamVector vector1 = new NamVector(Myelems);
            var elems2 = new double[] { 1, 2, 3 };
            NamVector vector2 = new NamVector(elems2);

            var elems3 = new double[] { 1, 5, 3 };
            NamVector vector3 = new NamVector(elems3);

          
            //Assert
            Assert.IsTrue(vector1 == vector1);
            Assert.IsTrue(vector1 == vector2);
            Assert.IsFalse(vector1 == vector3);
        }

        [TestMethod]
        public void TestVectorInEquality()
        {
            //arrange
            
            var elems = new double[] { 1, 3, 3 };
            NamVector vector1 = new NamVector(elems);
            var elems2 = new double[] { 1, 2, 3 };
            NamVector vector2 = new NamVector(elems2);
            var elems3 = new double[] { 1, 3, 3 };
            NamVector vector3 = new NamVector(elems3);



            //Assert
            Assert.IsTrue(vector1 != vector2);
            Assert.IsFalse(vector1 != vector3);
        }

        [TestMethod]
        public void TestVectorToString()
        {
            //arrange
            var elems = new double[3];
            elems[0] = 1;
            elems[1] = 2;
            elems[2] = 3;
            INamVector vector = new NamVector(elems);
            String expected = "1:2:3";
            String result = vector.ToString();

            //Assert
            Assert.AreEqual(expected, result);

        }

    }
}
