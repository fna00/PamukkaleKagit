using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application
{
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>>? a, Expression<Func<T, bool>> b)
        {
            if (a == null)
                return b;

            var parameterExpression = a.Parameters[0];

            var substExpressionVisitor = new SubstExpressionVisitor();
            substExpressionVisitor.Subst[b.Parameters[0]] = parameterExpression;

            var body = Expression.AndAlso(a.Body, substExpressionVisitor.Visit(b.Body));

            return Expression.Lambda<Func<T, bool>>(body, parameterExpression);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>>? a, Expression<Func<T, bool>> b)
        {
            if (a == null)
                return b;

            var parameterExpression = a.Parameters[0];

            var substExpressionVisitor = new SubstExpressionVisitor();
            substExpressionVisitor.Subst[b.Parameters[0]] = parameterExpression;

            var body = Expression.OrElse(a.Body, substExpressionVisitor.Visit(b.Body));

            return Expression.Lambda<Func<T, bool>>(body, parameterExpression);
        }

        class SubstExpressionVisitor : ExpressionVisitor
        {
            public Dictionary<Expression, Expression> Subst = new();

            protected override Expression VisitParameter(ParameterExpression node)
                => Subst.TryGetValue(node, out var value) ? value : node;
        }
    }
}
