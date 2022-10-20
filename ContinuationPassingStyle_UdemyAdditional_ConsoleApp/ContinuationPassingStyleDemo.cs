using System;
using System.Numerics;

namespace ContinuationPassingStyle_UdemyAdditional_ConsoleApp
{
    class ContinuationPassingStyleDemo
    {
        static void Main(string[] args)
        {
            var solver = new QuadraticEquationSolver();
            Tuple<Complex, Complex> solution;
            var flag = solver.Start(1, 10, 16,out solution);
        }
    }
}
