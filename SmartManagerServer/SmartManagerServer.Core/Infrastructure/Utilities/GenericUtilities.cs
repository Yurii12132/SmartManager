using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SmartManagerServer.Core.Infrastructure.Utilities
{
    public static class GenericUtilities
    {
        public static R GetValue<T, R>(T obj, Expression<Func<T, R>> property)
        {
            var expression = (MemberExpression)property.Body;
            string propertyName = expression.Member.Name;

            return (R)obj.GetType().GetProperty(propertyName).GetValue(obj);
        }

        public static void SetValue<T, V>(T obj, Expression<Func<T, V>> property, V value)
        {
            var expression = (MemberExpression)property.Body;
            string propertyName = expression.Member.Name;

            obj.GetType().GetProperty(propertyName).SetValue(obj, value);
        }
    }
}
