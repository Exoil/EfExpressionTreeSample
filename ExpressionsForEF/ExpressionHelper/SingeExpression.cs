using System.Linq.Expressions;
using ExpressionsForEF.Entities;
using ExpressionsForEF.ExpressionHelper.Enums;

namespace ExpressionsForEF.ExpressionHelper;

public static class SingeExpression<T>
{
    public static ExpressionData GetBinaryExpression<I>(
        string parameterName,
        BinaryOperator binaryOperator,
        I valueToCompare)
    {
        ExpressionData? expressionData = null;
        var parameter = Expression.Parameter(typeof(User), parameterName);
        var property = Expression.Property(parameter, "Cash");
        
        if (typeof(I) == typeof(Nullable) || property is Nullable)
        {
            expressionData = GetBinaryExpressionNullable(
                parameterName,
                binaryOperator,
                valueToCompare);
        }

        switch (expression)
        {
            
        }
        

        var constant = Expression.Constant(valueToCompare);

        return expressionData;
    }

    private static ExpressionData GetBinaryExpressionNullable<I>(
        string parameterName,
        BinaryOperator binaryOperator,
        I? valuetoCompare)
    {
        ExpressionData? expressionData = null;
        var parameter = Expression.Parameter(typeof(User), parameterName);
        var property = Expression.Property(parameter, "Cash");
        var constant = Expression.Constant(valuetoCompare);

        return expressionData;
    }
}