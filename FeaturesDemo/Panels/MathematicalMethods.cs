namespace FeaturesDemo.Panels
{
    /// <summary>
    /// Examples of mathematical methods
    /// </summary>
    public class MathematicalMethods
    {
        /// <summary>
        /// This method takes two integers as input parameters and returns their sum.
        /// </summary>
        /// <param name="a">The first integer number to be added.</param>
        /// <param name="b">The second integer number to be added.</param>
        /// <returns>The sum of the two input integers.</returns>
        public  int AddNumbers(int a, int b)
        {
            // Calculate and return the sum of the two input integers
            return a + b;
        }

        /// <summary>
        /// Calculates the average of three numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <returns>The average of the three numbers.</returns>
        public  double CalculateAverage(double a, double b, double c)
        {
            return (a + b + c) / 3;
        }

        /// <summary>
        /// Finds the maximum value between two numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The larger of the two numbers.</returns>
        public  int FindMaximum(int a, int b)
        {
            return (a > b) ? a : b;
        }

        /// <summary>
        /// Calculates the power of a number raised to an exponent.
        /// </summary>
        /// <param name="baseNumber">The base number.</param>
        /// <param name="exponent">The exponent to raise the base number to.</param>
        /// <returns>The result of baseNumber^exponent.</returns>
        public  double CalculatePower(double baseNumber, int exponent)
        {
            return Math.Pow(baseNumber, exponent);
        }

        /// <summary>
        /// Checks if the sum of two numbers is divisible by a given divisor.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="divisor">The divisor to check divisibility.</param>
        /// <returns>True if divisible, otherwise false.</returns>
        public  bool IsSumDivisibleBy(int a, int b, int divisor)
        {
            int sum = a + b;
            return sum % divisor == 0;
        }


    }
}
