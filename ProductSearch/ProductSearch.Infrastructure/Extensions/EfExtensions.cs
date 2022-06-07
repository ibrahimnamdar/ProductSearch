using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace ProductSearch.Infrastructure.Extensions;

public static class EfExtensions
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
    {
        return condition
            ? query.Where(predicate)
            : query;
    }

    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, int, bool>> predicate)
    {
        return condition
            ? query.Where(predicate)
            : query;
    }

    public static IQueryable<T> OrderByDescendingIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, object>> predicate)
    {
        return condition
            ? query.OrderByDescending(predicate)
            : query;
    }

    public static IQueryable<T> OrderByIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, object>> predicate)
    {
        return condition
            ? query.OrderBy(predicate)
            : query;
    }

    public static TExpected GetAttributeValue<T, TExpected>(
        this Enum enumeration,
        Func<T, TExpected> expression)
        where T : Attribute
    {
        MemberInfo memberInfo =
            ((IEnumerable<MemberInfo>)enumeration.GetType().GetMember(enumeration.ToString())).FirstOrDefault<MemberInfo>(
                (Func<MemberInfo, bool>)(member => member.MemberType == MemberTypes.Field));
        T obj = (object)memberInfo != null ? memberInfo.GetCustomAttributes(typeof(T), false).Cast<T>().SingleOrDefault<T>() : default(T);
        return (object)obj == null ? default(TExpected) : expression(obj);
    }

    public static string GetDescription(this Enum enumeration) =>
        enumeration.GetAttributeValue<DescriptionAttribute, string>((Func<DescriptionAttribute, string>)(o => o.Description));
}