﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using d1den.MathLibrary;

namespace TestForLibrary
{
    class MatrixTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateMatrixByConstructors()
        {
            var matrix1 = new Matrix(2, 2);
            var matrix2 = new Matrix(2, 2.34);
            var matrix3 = new Matrix(new int[,] { { 1, 2 }, { 3, 4 } });
            var matrix4 = new Matrix(new double[,] { { 1.1, 2.2 }, { 3.3, 4.4 } });
            if (matrix1.RowCount == matrix1.ColumnCount && matrix1.RowCount == 2 &&
                matrix2[0, 0] == 2.34 && matrix2[1, 1] == 2.34 && matrix2[0, 1] == 0 && matrix2[1, 0] == 0)
                Assert.Pass();
        }
        [Test]
        public void CreateMatrixByMethods()
        {
            var matrix1 = Matrix.GetEyeMatrix(2);
            var matrix2 = Matrix.GetZerosMatrix(1);
            var matrix3 = Matrix.GetOnesMatrix(2);
            if (matrix1[0,0] == 1.0 && matrix1[1,1] == 1.0 && matrix1[0,1] == 0 && matrix1[1, 0] == 0 &&
                matrix2[0, 0] == 0 &&
                matrix3[0,0] == 1.0 && matrix3[1, 1] == 1.0 && matrix3[0, 1] == 1 && matrix3[1, 0] == 1)
                Assert.Pass();
        }

        [Test]
        public void GetMatrixDataTest()
        {
            var matrix1 = Matrix.GetEyeMatrix(2);
            double[,] array1 = (double[,])matrix1;
            int[,] array2 = matrix1.Int32MatrixData;
            array1[0, 0] = 2;
            array2[0, 0] = 2;
            if (matrix1[0, 0] == 1)
                Assert.Pass();
        }
    }
}