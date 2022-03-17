using System;

namespace MatrixLibrary
{

    public class Matrix : ICloneable
    {
        /// <summary>
        /// Number of rows.
        /// </summary>
        public int Rows
        {
            get => Array.GetLength(0);
        }

        /// <summary>
        /// Number of columns.
        /// </summary>
        public int Columns
        {
            get => Array.GetLength(1);
        }

        /// <summary>
        /// Gets an array of floating-point values that represents the elements of this Matrix.
        /// </summary>
        public double[,] Array
        {
            get;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Matrix(int rows, int columns)
        {
            if (rows < 0)
            {
                throw new ArgumentOutOfRangeException("rows");
            }
            if (columns < 0)
            {
                throw new ArgumentOutOfRangeException("columns");
            }
            Array = new double[rows, columns];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class with the specified elements.
        /// </summary>
        /// <param name="array">An array of floating-point values that represents the elements of this Matrix.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Matrix(double[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            Array = array;


        }

        /// <summary>
        /// Allows instances of a Matrix to be indexed just like arrays.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <exception cref="ArgumentException"></exception>
        public double this[int row, int column]
        {

            get
            {
                if (row > this.Rows || column > this.Columns || row < 0 || column < 0)
                {
                    throw new ArgumentException("row");
                }

                return this.Array[row, column];
            }
            set
            {
                if (row > this.Rows || column > this.Columns || row < 0 || column < 0)
                {
                    throw new ArgumentException("row");
                }
                this.Array[row, column] = value;
            }



        }

        /// <summary>
        /// Creates a deep copy of this Matrix.
        /// </summary>
        /// <returns>A deep copy of the current object.</returns>
        public object Clone()
        {

            return this.MemberwiseClone();

        }

        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns>New <see cref="Matrix"/> object which is sum of two matrices.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null)
            {
                throw new ArgumentNullException("matrix1");
            }
            if (matrix2 == null)
            {
                throw new ArgumentNullException("matrix2");
            }
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                throw new MatrixException("Wrong dimensions");
            }

            Matrix newMatrix = new Matrix(matrix1.Rows, matrix1.Columns);
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    newMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return newMatrix;


        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns>New <see cref="Matrix"/> object which is subtraction of two matrices</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null)
            {
                throw new ArgumentNullException("matrix1");
            }
            if (matrix2 == null)
            {
                throw new ArgumentNullException("matrix2");
            }
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                throw new MatrixException("Wrong dimensions");
            }


            Matrix newMatrix = new Matrix(matrix1.Rows, matrix1.Columns);
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    newMatrix[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return newMatrix;

        }

        /// <summary>
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns>New <see cref="Matrix"/> object which is multiplication of two matrices.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null)
            {
                throw new ArgumentNullException("matrix1");
            }
            if (matrix2 == null)
            {
                throw new ArgumentNullException("matrix2");
            }
            if (matrix1.Columns != matrix2.Rows)
            {
                throw new MatrixException("Wrong dimensions");
            }

            double temp;
            Matrix resultMatrix = new Matrix(matrix1.Rows, matrix2.Columns);
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix2.Columns; j++)
                {
                    temp = 0;
                    for (int k = 0; k < matrix1.Columns; k++)
                    {
                        temp += matrix1[i, k] * matrix2[k, j];
                    }
                    resultMatrix[i, j] = temp;
                }
            }
            return resultMatrix;



        }

        /// <summary>
        /// Adds <see cref="Matrix"/> to the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for adding.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public Matrix Add(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("matrix");
            }
            if (matrix.Rows != this.Rows || matrix.Columns != this.Columns)
            {
                throw new MatrixException("Wrong dimensions");
            }

            return this + matrix;
        }

        /// <summary>
        /// Subtracts <see cref="Matrix"/> from the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for subtracting.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public Matrix Subtract(Matrix matrix)
        {

            if (matrix == null)
            {
                throw new ArgumentNullException("matrix");
            }
            if (matrix.Rows != this.Rows || matrix.Columns != this.Columns)
            {
                throw new MatrixException("Wrong dimensions");
            }
            return this - matrix;
        }

        /// <summary>
        /// Multiplies <see cref="Matrix"/> on the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for multiplying.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public Matrix Multiply(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("matrix");
            }

            if (matrix.Rows != this.Columns)
            {
                throw new MatrixException("Wrong dimensions");
            }
            return this * matrix;
        }

        /// <summary>
        /// Tests if <see cref="Matrix"/> is identical to this Matrix.
        /// </summary>
        /// <param name="obj">Object to compare with. (Can be null)</param>
        /// <returns>True if matrices are equal, false if are not equal.</returns>
        public override bool Equals(object obj)
        {
            bool isEquils = false;

            if (obj is Matrix)
            {
                Matrix matrix = obj as Matrix;
                if (matrix.Rows == this.Rows && matrix.Columns == this.Columns)
                {
                    for (int i = 0; i < this.Rows; i++)
                        for (int j = 0; j < this.Columns; j++)
                        {
                            if (matrix[i, j] == this[i, j])
                            {
                                isEquils = true;
                            }
                            else
                            {
                                return false;

                            }

                        }
                }
            }

            return isEquils;
        }

        public override int GetHashCode() => base.GetHashCode();
    }

    public class MatrixException : Exception
    {
        public MatrixException(string message)
            : base(message)
        { }
    }
}
