using System.Linq.Expressions;

namespace ExpressionsForEF.ExpressionHelper;

public class ExpressionBuilder
{
    private Expression _expression;
    private IList<ParameterExpression> _parameters;

    public ExpressionBuilder(ExpressionData expression)
    {
        _expression = expression.Expression;
        _parameters = new List<ParameterExpression>()
        {
            expression.Parameter
        };
    }
    
    public ComplexExpressionData Build()
    {
        return new ComplexExpressionData(_expression, _parameters.AsEnumerable());
    }

    public ExpressionBuilder ApplyAndAlso(ExpressionData expressionData)
    {
        _expression = Expression.AndAlso(_expression, expressionData.Expression);

        if (_parameters.Any(x => x.Name != expressionData.Parameter.Name))
        {
            _parameters.Add(expressionData.Parameter);
        }

        return this;
    }
    
    public ExpressionBuilder OrAndAlso(ExpressionData expressionData)
    {
        _expression = Expression.OrElse(_expression, expressionData.Expression);

        if (_parameters.Any(x => x.Name != expressionData.Parameter.Name))
        {
            _parameters.Add(expressionData.Parameter);
        }

        return this;
    }
    
    
}