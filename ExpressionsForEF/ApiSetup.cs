using System.Linq.Expressions;
using ExpressionsForEF.DAL;
using ExpressionsForEF.Entities;
using ExpressionsForEF.ExpressionHelper;
using ExpressionsForEF.ExpressionHelper.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ExpressionsForEF;

public static class ApiSetup
{
    public static void SetEndpoints(this WebApplication applicationBuilder)
    {
        applicationBuilder.MapGet("/", () => "1.0.0")
            .WithName("GetWeatherForecast")
            .WithOpenApi();
        applicationBuilder.MapGet("/test-expression", ([FromServices]AppDbContext context) =>
        {
            try
            {
                var expression = ExpressionHelper<User>.GetBinaryExpression(
                    "p",
                    "Name",
                    BinaryOperator.Greater,
                    "Foo");
                var parameter = Expression.Parameter(typeof(User), "p");
                var property = Expression.Property(parameter, "Cash");
                var constant = Expression.Constant((int?)20);
                var greater = Expression.GreaterThan(
                    Expression.Coalesce(property,  Expression.Constant(int.MinValue)), constant);
                var expressionBuilder = new ExpressionBuilder(new ExpressionData(greater, parameter));
                var secondConstant = Expression.Constant((int?)43);
                var lesser = Expression.LessThan(Expression.Coalesce(property,  Expression.Constant(int.MinValue)),secondConstant);
                expressionBuilder.ApplyAndAlso(new ExpressionData(lesser, parameter));
                var andExpression = expressionBuilder.Build();
                
                var test = context.Users.FirstOrDefault(
                    ExpressionHelper<User>.ToLambdaExpression(expression.Expression, expression.Parameter));

                return Results.Ok(test);
            }
            catch(Exception exception)
            {
                _ = exception;
                return Results.BadRequest(exception);
            }
        });
    }
}