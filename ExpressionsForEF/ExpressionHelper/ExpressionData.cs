using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace ExpressionsForEF.ExpressionHelper;

public record ExpressionData(
    Expression Expression,
    ParameterExpression Parameter);
    
public record ComplexExpressionData(
    Expression Expression,
    IEnumerable<ParameterExpression> Parameters);