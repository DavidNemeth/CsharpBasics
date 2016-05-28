using System;
using System.Linq.Expressions;


namespace ExpressionTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int, bool>> test = i => i > 5;
            
            ConstantExpression constExp = Expression.Constant(5, typeof(int));
            //Console.WriteLine(constExp.NodeType);
            //Console.WriteLine(constExp.Type);
            //Console.WriteLine(constExp.Value);

            ParameterExpression iParam = Expression.Parameter(typeof(int), "i");
            //Console.WriteLine(iParam.NodeType);
            //Console.WriteLine(iParam.Type);
            //Console.WriteLine(iParam.Name);

            BinaryExpression greaterThan = Expression.GreaterThan(iParam, constExp);
            Console.WriteLine(greaterThan.NodeType);
            Console.WriteLine(greaterThan.Type);
            Console.WriteLine(greaterThan.Left);
            Console.WriteLine(greaterThan.Right);
        }
    }
}
