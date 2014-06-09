using System;
using System.Linq.Expressions;

namespace VerseFlow.Mvp.Core
{
	public static class PropertyName
	{
		public static string Get<TProperty>(Expression<Func<TProperty>> property)
		{
			var lambda = (LambdaExpression)property;
			var unar = lambda.Body as UnaryExpression;

			MemberExpression memberExpression = unar != null
				? (MemberExpression)unar.Operand
				: (MemberExpression)lambda.Body;

			return memberExpression.Member.Name;
		}
	}
}