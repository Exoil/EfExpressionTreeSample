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
        Expression? expression = null;
        var parameter = Expression.Parameter(typeof(User), parameterName);
        var property = Expression.Property(parameter, "Cash");
        var constant = Expression.Constant(valueToCompare);
        
        switch (binaryOperator)
        {
            case BinaryOperator.Equal:
                expression = Expression.Equal(property, constant);
                break;
            case BinaryOperator.NotEqual:
                expression = Expression.Equal(property, constant);
                break;
            case BinaryOperator.Greater:
                expression = Expression.Equal(property, constant);
                break;
            case BinaryOperator.GreaterOrEqual:
                expression = Expression.Equal(property, constant);
                break;
            case BinaryOperator.Lesser:
                expression = Expression.Equal(property, constant);
                break;
            case BinaryOperator.LesserOrEqual:
                expression = Expression.Equal(property, constant);
                break;
        }

        return new ExpressionData(expression!, parameter);
    }

    public static ExpressionData GetBinaryExpressionNullable<I>(
        string parameterName,
        BinaryOperator binaryOperator,
        I valuetoCompare,
        I minValue)
    {
        ExpressionData? expressionData = null;
        var parameter = Expression.Parameter(typeof(User), parameterName);
        var property = Expression.Coalesce(
            Expression.Property(parameter, "Cash"),
            Expression.Constant(minValue));
        var constant = Expression.Constant(valuetoCompare);
        Expression? expression = null;
        
        switch (binaryOperator)
        {
            case BinaryOperator.Equal:
                expression = Expression.Equal(property, constant);
                break;
            case BinaryOperator.NotEqual:
                expression = Expression.Equal(property, constant);
                break;
            case BinaryOperator.Greater:
                expression = Expression.Equal(property, constant);
                break;
            case BinaryOperator.GreaterOrEqual:
                expression = Expression.Equal(property, constant);
                break;
            case BinaryOperator.Lesser:
                expression = Expression.Equal(property, constant);
                break;
            case BinaryOperator.LesserOrEqual:
                expression = Expression.Equal(property, constant);
                break;
        }

        return new ExpressionData(expression!, parameter);
    }
}