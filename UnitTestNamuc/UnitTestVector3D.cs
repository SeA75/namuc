using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Namuc;

namespace UnitTestNamuc
{
    [TestClass]
    public class UnitTestVector3D
    {
        [TestMethod]
        public void Invert_success()
        {
            //Arrange
            var v1 = new Vector3D(1, 2, 3);

            //Act
            v1.Invert();

            //Assert
            Assert.AreEqual(-1, v1.x);
            Assert.AreEqual(-2, v1.y);
            Assert.AreEqual(-3, v1.z);

        }


        [TestMethod]
        [DataRow(1,2,3)]
        [DataRow(-1,-2, -4)]
        [DataRow(0,0,0)]
        public void Magnitude_success(double x, double y, double z)
        {
            //Arrange
            var v1 = new Vector3D(x,y,z);
            double expected = Math.Sqrt(x * x + y * y + z * z);

            //Act
            var result = v1.Magnitude();

            //Assert
            Assert.AreEqual(expected, result);
            
        }

        [TestMethod]
        public void MagnitudeDefault_success()
        {
            //Arrange
            var v1 = new Vector3D();

            //Act
            var result = v1.Magnitude();

            //Assert
            Assert.AreEqual(0, result);

        }


        [TestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(-1, -2, -4)]
        [DataRow(-1, 3, -9)]
        [DataRow(0, 0, 0)]
        public void Normalize_success(double x, double y, double z)
        {
            //Arrange
            var norma = Math.Sqrt(Math.Pow(x,2)+ Math.Pow(y, 2)+ Math.Pow(z, 2));
            var v1 = new Vector3D(x,y,z);

            //Act
            v1.Normalize();

            //Assert
            Assert.AreEqual(v1.x, x/norma);
            Assert.AreEqual(v1.y, y / norma);
            Assert.AreEqual(v1.z, z / norma);
        }

        [TestMethod]
        [DataRow(1, 2, 3,4,5,6)]
        [DataRow(-1, -2, -4,0,3,-3)]
        [DataRow(-1, 3, -9,-3,-5,-9)]
        [DataRow(0, 0, 0,0,0,0)]
        public void AddVectors_success(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            //Arrange
            var v1 = new Vector3D(x1, y1, z1);
            var v2 = new Vector3D(x2, y2, z2);
            //Act
            Vector3D v3 = v1 + v2;

            //Assert
            Assert.AreEqual(x1 + x2, v3.x);
            Assert.AreEqual(y1 + y2, v3.y );
            Assert.AreEqual(z1 + z2, v3.z );
        }

        [TestMethod]
        [DataRow(1, 2, 3, 4)]
        [DataRow(-1, -2, -4, 0)]
        [DataRow(-1, 3, -9, -3)]
        [DataRow(0, 0, 0, 0)]
        public void ScalarProduct_success(double x1, double y1, double z1, double value)
        {
            //Arrange
            var v1 = new Vector3D(x1, y1, z1);
            
            //Act
            Vector3D v3 = v1 * value;

            //Assert
            Assert.AreEqual(x1 * value, v3.x);
            Assert.AreEqual(y1 * value, v3.y );
            Assert.AreEqual(z1 * value, v3.z );
        }

        [TestMethod]
        [DataRow(2, 1, 4, -2, -1, -4, 0, 0, 0)]
        [DataRow(0, 0, 0, 0, 0, 0, 0, 0, 0)]
        [DataRow(4, 6, -3, 2, 4, 5, 42, -26, 4)]
        [DataRow(23, 5, -9, -7, -4, 98, 454, -2191, -57)]
        [DataRow(23, 5, -9, -7, -4, 98, 454, -2191, -57)]
        [DataRow(23, 1, 0, 12, 9, 0, 0, 0, 195)]
        [DataRow(0, 1, 20, 0, 9, 20, -160, 0, 0)]
        [DataRow(12.3, 6.6, -3, 2.2, 4, 5.7, 49.62, -76.71, 34.68)]
        [DataRow(17.1, 23.5, 9, 123.3, 34.9, 0.2, -309.4, 1106.28, -2300.76)]
        public void VectorialProduct_success(double x1, double y1, double z1, double x2, double y2, double z2, double resx, double resy, double resz)
        {
            //Arrange
            var v1 = Vector3D.VectorialProduct(new Vector3D(x1, y1, z1), new Vector3D(x2, y2, z2));



            //Assert
            Vector3D expected = new Vector3D(resx, resy, resz);
            string message = string.Format("Actual vector {0} Expected vector {1}", v1.ToString(), expected.ToString());
            Assert.AreEqual(expected , v1, message);
            
        }

        [TestMethod]
        [DataRow(2, 1, 4, -2, -1, -4, 0, 0, 0)]
        [DataRow(0, 0, 0, 0, 0, 0, 0, 0, 0)]
        [DataRow(4, 6, -3, 2, 4, 5, 42, -26, 4)]
        [DataRow(23, 5, -9, -7, -4, 98, 454, -2191, -57)]
        [DataRow(23, 5, -9, -7, -4, 98, 454, -2191, -57)]
        [DataRow(23, 1, 0, 12, 9, 0, 0, 0, 195)]
        [DataRow(0, 1, 20, 0, 9, 20, -160, 0, 0)]
        public void VectorialProductSame_success(double x1, double y1, double z1, double x2, double y2, double z2, double resx, double resy, double resz)
        {
            //Arrange
            var v1 = Vector3D.VectorialProduct(new Vector3D(x1, y1, z1), new Vector3D(x2, y2, z2));



            //Assert
            Vector3D expected = new Vector3D(resx, resy, resz);
            string message = string.Format("Actual vector {0} Expected vector {1}", v1.ToString(), expected.ToString());
            Assert.IsTrue(expected == v1, message);

        }

        [TestMethod]
        [DataRow(2, 1, 4, -2, -1, -4, 3, -4, 4)]
        [DataRow(0, 0, 0, 0, 0, 0, 0, 0, 0)]
        [DataRow(4, 6, -3, 2, 4, 5, 422, -261, 43)]
        [DataRow(23, 5, -9, -7, -4, 98, 54, -91, -527)]
        [DataRow(23, 5, -9, -7, -4, 98, -454, -21, -57)]
        [DataRow(23, 1, 0, 12, 9, 0, 0, 0, 1953)]
        [DataRow(0, 1, 20, 0, 9, 20, -1622, 10, 0)]
        public void VectorialProductDistributiveProperty_success(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3)
        {
            Vector3D v1 = new Vector3D(x1, y1, z1);
            Vector3D v2 = new Vector3D(x2, y2, z2);
            Vector3D v3 = new Vector3D(x3, y3, z3);

            Vector3D res1 = v2 + v3;
            Vector3D dist1 = Vector3D.VectorialProduct(v1, res1);

            Vector3D dist2 = Vector3D.VectorialProduct(v1, v2) + Vector3D.VectorialProduct(v1, v3);

            Assert.AreEqual(dist1, dist2);
        }


        [TestMethod]
        [DataRow(2, 1, 4, -2, -1, -4)]
        [DataRow(0, 0, 0, 0, 0, 0)]
        [DataRow(4, 6, -3, 2, 4, 5)]
        [DataRow(23, 5, -9, -7, -4, 98)]
        [DataRow(23, 5, -9, -7, -4, 98)]
        [DataRow(23, 1, 0, 12, 9, 0)]
        [DataRow(0, 1, 20, 0, 9, 20)]
        public void VectorialProductBilinearProperty_success(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double landa = 43;
            Vector3D v1 = new Vector3D(x1, y1, z1);
            Vector3D v2 = new Vector3D(x2, y2, z2);
            
            Vector3D res1 = Vector3D.VectorialProduct(  v1 * landa, v2);
            Vector3D res2 = Vector3D.VectorialProduct(v1, v2 * landa);           

            Assert.AreEqual(res1, res2);
        }


        [TestMethod]
        [DataRow(2, 1, 4, -2, -1, -4, 3, -4, 4)]
        [DataRow(4, 6, -3, 2, 4, 5, 422, -261, 43)]
        [DataRow(23, 5, -9, -7, -4, 98, 54, -91, -527)]
        [DataRow(23, 5, -9, -7, -4, 98, -454, -21, -57)]
        [DataRow(23, 1, 0, 12, 9, 0, 0, 0, 1953)]
        [DataRow(0, 1, 20, 0, 9, 20, -1622, 10, 0)]
        public void VectorialProductAssociativeProperty_success(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3)
        {
            Vector3D v1 = new Vector3D(x1, y1, z1);
            Vector3D v2 = new Vector3D(x2, y2, z2);
            Vector3D v3 = new Vector3D(x3, y3, z3);

            
            Vector3D res1 = Vector3D.VectorialProduct( Vector3D.VectorialProduct(v1, v2), v3);

            Vector3D res2 = Vector3D.VectorialProduct(v1, Vector3D.VectorialProduct(v2, v3));

            Assert.AreNotEqual(res1, res2);
        }


        [TestMethod]
        [DataRow(2, 1, 4, -2, -1, -4, 3, -4, 4)]
        [DataRow(0, 0, 0, 0, 0, 0, 0, 0, 0)]
        [DataRow(4, 6, -3, 2, 4, 5, 422, -261, 43)]
        [DataRow(23, 5, -9, -7, -4, 98, 54, -91, -527)]
        [DataRow(23, 5, -9, -7, -4, 98, -454, -21, -57)]
        [DataRow(23, 1, 0, 12, 9, 0, 0, 0, 1953)]
        [DataRow(0, 1, 20, 0, 9, 20, -1622, 10, 0)]
        public void ProductVectorJacobiIdentity_success(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3)
        {
            Vector3D v1 = new Vector3D(x1, y1, z1);
            Vector3D v2 = new Vector3D(x2, y2, z2);
            Vector3D v3 = new Vector3D(x3, y3, z3);
            Vector3D expected = new Vector3D();
            Vector3D result = Vector3D.VectorialProduct(v1, Vector3D.VectorialProduct(v2, v3)) + Vector3D.VectorialProduct(v2, Vector3D.VectorialProduct(v3, v1)) +
               Vector3D.VectorialProduct(v3, Vector3D.VectorialProduct(v1, v2));
            
            Assert.AreEqual(expected, result);
        }





    }
}
