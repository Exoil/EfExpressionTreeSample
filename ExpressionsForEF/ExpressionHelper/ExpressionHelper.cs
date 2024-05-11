using System.Linq.Expressions;
using ExpressionsForEF.Entities;
using ExpressionsForEF.ExpressionHelper.Enums;

namespace ExpressionsForEF.ExpressionHelper;

public static class ExpressionHelper<T>
{
    public static Expression<Func<T, bool>> ToLambdaExpression(
        Expression expression)
        => Expression.Lambda<Func<T, bool>>(expression);
    
    public static Expression<Func<T, bool>> ToLambdaExpression(
        ExpressionData expression)
        => Expression.Lambda<Func<T, bool>>(expression.Expression, expression.Parameter);
    
    public static Expression<Func<T, bool>> ToLambdaExpression(
        ComplexExpressionData expression)
        => Expression.Lambda<Func<T, bool>>(expression.Expression, expression.Parameters);

    public static ExpressionData GetBinaryExpression<I>(
        string parameterName,
        string propertyName,
        BinaryOperator binaryOperator,
        I valueToCompare)
    {
        if (typeof(I) == typeof(string))
        {
            throw new Exception(
                "String is not supported by this method please use method GetBinaryExpression with StringBinaryOperation");
        }
        
        ExpressionData? expressionData = null;
        Expression? expression = null;
        var parameter = Expression.Parameter(typeof(User), parameterName);
        var property = Expression.Property(parameter, propertyName);
        var constant = Expression.Constant(valueToCompare);
        
        switch (binaryOperator)
        {
            case BinaryOperator.Equal:
                expression = Expression.Equal(property, constant);
                break;
            case BinaryOperator.NotEqual:
                expression = Expression.NotEqual(property, constant);
                break;
            case BinaryOperator.Greater:
                expression = Expression.GreaterThan(property, constant);
                break;
            case BinaryOperator.GreaterOrEqual:
                expression = Expression.GreaterThanOrEqual(property, constant);
                break;
            case BinaryOperator.Lesser:
                expression = Expression.LessThan(property, constant);
                break;
            case BinaryOperator.LesserOrEqual:
                expression = Expression.LessThanOrEqual(property, constant);
                break;
        }

        return new ExpressionData(expression!, parameter);
    }

    public static ExpressionData GetBinaryExpressionNullable<I>(
        string parameterName,
        string propertyName,
        BinaryOperator binaryOperator,
        I valuetoCompare,
        I minValue)
    {
        if (typeof(I) == typeof(string))
        {
            throw new Exception(
                "String is not supported by this method please use method GetBinaryExpression with StringBinaryOperation");
        }

        ExpressionData? expressionData = null;
        var parameter = Expression.Parameter(typeof(User), parameterName);
        var property = Expression.Coalesce(
            Expression.Property(parameter, propertyName),
            Expression.Constant(minValue));
        var constant = Expression.Constant(valuetoCompare);
        Expression? expression = null;
        
        switch (binaryOperator)
        {
            case BinaryOperator.Equal:
                expression = Expression.Equal(property, constant);
                break;
            case BinaryOperator.NotEqual:
                expression = Expression.NotEqual(property, constant);
                break;
            case BinaryOperator.Greater:
                expression = Expression.GreaterThan(property, constant);
                break;
            case BinaryOperator.GreaterOrEqual:
                expression = Expression.GreaterThanOrEqual(property, constant);
                break;
            case BinaryOperator.Lesser:
                expression = Expression.LessThan(property, constant);
                break;
            case BinaryOperator.LesserOrEqual:
                expression = Expression.LessThanOrEqual(property, constant);
                break;
        }

        return new ExpressionData(expression!, parameter);
    }

    private static ExpressionData GetBinaryExpression(
        string parameterName,
        string propertyName,
        StringBinaryOperators binaryOperator,
        string valueToCompare)
    {
        ExpressionData? expressionData = null;
        Expression? expression = null;
        var parameter = Expression.Parameter(typeof(User), parameterName);
        var property = Expression.Property(parameter, propertyName);
        var constant = Expression.Constant(valueToCompare);
        
        switch (binaryOperator)
        {
            case StringBinaryOperators.Equal:
                expression = Expression.Equal(property, constant);
                break;
            case StringBinaryOperators.NotEqual:
                expression = Expression.NotEqual(property, constant);
                break;
            case StringBinaryOperators.Like:
                break;
        }

        return new ExpressionData(expression!, parameter);
    }
}