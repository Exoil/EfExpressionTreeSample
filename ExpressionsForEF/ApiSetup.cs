using System.Linq.Expressions;
using ExpressionsForEF.DAL;
using ExpressionsForEF.Entities;
using ExpressionsForEF.ExpressionHelper;
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
                var parameter = Expression.Parameter(typeof(User), "p");
                var property = Expression.Property(parameter, "Age");
                var constant = Expression.Constant(20);
                var greater = Expression.GreaterThan(property, constant);
                var expressionBuilder = new ExpressionBuilder(new ExpressionData(greater, parameter));
                var secondConstant = Expression.Constant(43);
                var lesser = Expression.LessThan(property, secondConstant);
                expressionBuilder.ApplyAndAlso(new ExpressionData(lesser, parameter));
                var andExpression = expressionBuilder.Build();
                
                
                var test = context.Users.FirstOrDefault(
                    Expression.Lambda<Func<User, bool>>(andExpression.Expression, andExpression.Parameters));

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