using System;

namespace matrica
{
    class Matrix
    {
        private double[,] data;

        // === КОНСТРУКТОР 1: ВВОД n×m ===
        public Matrix(int n, int m)
        {
            data = new double[n, m];
            Console.WriteLine($"введите элементы массива {n}×{m}:");

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"[{i},{j}] = ");
                    data[i, j] = double.Parse(Console.ReadLine());
                }
        }

        // === ТЕХНИЧЕСКИЙ КОНСТРУКТОР (НЕ СПРАШИВАЕТ ВВОД) ===
        private Matrix(double[,] array)
        {
            data = array;
        }

        // === КОНСТРУКТОР 2: СЛУЧАЙНЫЙ n×n ===
        public Matrix(int n)
        {
            data = new double[n, n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i > j)
                        data[i, j] = rnd.Next(-70, 151);
                    else
                        data[i, j] = rnd.Next(17, 171);
                }
        }

        // === КОНСТРУКТОР 3: РОМБ n×n ===
        public Matrix(int n, bool pattern)
        {
            data = new double[n, n];
            int center = n / 2;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    int di = i - center;
                    if (di < 0) di = -di;

                    int dj = j - center;
                    if (dj < 0) dj = -dj;

                    if (di + dj <= center)
                        data[i, j] = i * 10 + j + 1;
                    else
                        data[i, j] = 0;
                }
        }

        // === ЗАДАНИЕ 2: МАКС ДИАГОНАЛЬ ===
        public double MaxParallelDiagonalSum()
        {
            int n = data.GetLength(0);
            double maxSum = double.MinValue;

            for (int shift = 1; shift < n; shift++)
            {
                double sum = 0;
                for (int i = 0; i < n - shift; i++)
                    sum += data[i, i + shift];
                if (sum > maxSum) maxSum = sum;
            }

            for (int shift = 1; shift < n; shift++)
            {
                double sum = 0;
                for (int i = 0; i < n - shift; i++)
                    sum += data[i + shift, i];
                if (sum > maxSum) maxSum = sum;
            }

            return maxSum;
        }

        // === ТРАНСПОНИРОВАНИЕ (БЕЗ ВВОДА!) ===
        public Matrix Transpose()
        {
            int n = data.GetLength(0);
            int m = data.GetLength(1);

            double[,] t = new double[m, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    t[j, i] = data[i, j];

            return new Matrix(t);
        }

        // === ОПЕРАТОР УМНОЖЕНИЯ ===
        public static Matrix operator *(Matrix A, Matrix B)
        {
            int n = A.data.GetLength(0);
            int m = B.data.GetLength(1);
            int k = A.data.GetLength(1);

            double[,] r = new double[n, m];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    for (int t = 0; t < k; t++)
                        r[i, j] += A.data[i, t] * B.data[t, j];

            return new Matrix(r);
        }

        // === ОПЕРАТОР ВЫЧИТАНИЯ ===
        public static Matrix operator -(Matrix A, Matrix B)
        {
            int n = A.data.GetLength(0);
            int m = A.data.GetLength(1);

            double[,] r = new double[n, m];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    r[i, j] = A.data[i, j] - B.data[i, j];

            return new Matrix(r);
        }

        // === ToString() ===
        public override string ToString()
        {
            string s = "";
            int n = data.GetLength(0);
            int m = data.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    s += data[i, j].ToString().PadLeft(6);
                s += "\n";
            }
            return s;
        }

        public int Rows => data.GetLength(0);
        public int Cols => data.GetLength(1);
    }
}
