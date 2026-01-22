using matrica;
using System;

namespace LabMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ЗАДАНИЕ 1: Ввод массива A (n×m) ===");

            Console.Write("Введите n: ");
            int nA = int.Parse(Console.ReadLine());

            Console.Write("Введите m: ");
            int mA = int.Parse(Console.ReadLine());

            Matrix A = new Matrix(nA, mA);
            Console.WriteLine("\nМатрица A:");
            Console.WriteLine(A);

            // ------------------------------

            Console.WriteLine("=== ЗАДАНИЕ 1: Случайная квадратная матрица B (n×n) ===");

            Console.Write("Введите n для B: ");
            int nB = int.Parse(Console.ReadLine());

            Matrix B = new Matrix(nB);
            Console.WriteLine("\nМатрица B:");
            Console.WriteLine(B);

            // ------------------------------

            Console.WriteLine("=== ЗАДАНИЕ 1: Матрица C (ромб n×n) ===");

            Console.Write("Введите n для ромба C: ");
            int nC = int.Parse(Console.ReadLine());

            Matrix C = new Matrix(nC, true);
            Console.WriteLine("\nМатрица C (ромб):");
            Console.WriteLine(C);

            // ------------------------------

            Console.WriteLine("=== ЗАДАНИЕ 2: Максимальная диагональ параллельная главной ===");

            if (nB == nC) // просто чтобы показать на квадратной матрице
            {
                double maxDiag = B.MaxParallelDiagonalSum();
                Console.WriteLine($"Максимальная сумма диагонали в B: {maxDiag}");
            }
            else
            {
                Console.WriteLine("Для задания 2 нужна квадратная матрица. Используйте B.");
            }

            // ------------------------------

            Console.WriteLine("=== ЗАДАНИЕ 3: Вычисление выражения Aᵀ * B - Cᵀ ===");

            // Проверка совместимости размеров
            if (A.Transpose().Cols != B.Rows)
            {
                Console.WriteLine("Нельзя выполнить Aᵀ * B: несовместимые размеры.");
                return;
            }

            if (B.Cols != C.Transpose().Cols || B.Rows != C.Transpose().Rows)
            {
                Console.WriteLine("Нельзя выполнить Aᵀ * B - Cᵀ: несовместимые размеры.");
                return;
            }

            Matrix AT = A.Transpose();
            Matrix CT = C.Transpose();

            Console.WriteLine("\nAᵀ:");
            Console.WriteLine(AT);

            Console.WriteLine("Cᵀ:");
            Console.WriteLine(CT);

            Matrix mult = AT * B;
            Console.WriteLine("Aᵀ * B:");
            Console.WriteLine(mult);

            Matrix result = mult - CT;
            Console.WriteLine("Aᵀ * B - Cᵀ:");
            Console.WriteLine(result);

            Console.WriteLine("\n=== ГОТОВО ДЛЯ СКРИНШОТА ===");
            Console.WriteLine("Сравните Aᵀ, B, Cᵀ и результат в онлайн-калькуляторе.");
        }
    }
}



// шшаблон пример 

/*
 
 A = 3X3 
ОТ 1 ДО 9

B = 3

C = 3

 
 
 
 
 
 
 
 
 
 
 
 */