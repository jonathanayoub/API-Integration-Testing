using System.Reflection;

namespace ApiIntegrationTesting.Tests;

/// <summary>
/// Utility for cloning objects.
/// </summary>
internal class ObjectCloningUtility
{
    /// <summary>
    /// Shallow clone an array of entities with simple type properties only. Useful for cloning EF entities with navigation properties, etc
    /// </summary>
    public static TEntity[] ShallowCloneArraySimpleTypes<TEntity>(TEntity[] entities)
        where TEntity : class, new()
    {
        ArgumentNullException.ThrowIfNull(entities);

        var clonedArray = new TEntity[entities.Length];

        for (var i = 0; i < entities.Length; i++)
        {
            clonedArray[i] = ShallowCloneSimpleTypes(entities[i]);
        }

        return clonedArray;
    }

    private static TEntity ShallowCloneSimpleTypes<TEntity>(TEntity entity)
        where TEntity : class, new()
    {
        ArgumentNullException.ThrowIfNull(entity);

        var clone = new TEntity();
        PropertyInfo[] properties = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (PropertyInfo property in properties)
        {
            if (!property.CanRead || !property.CanWrite) continue;
            
            Type propertyType = property.PropertyType;
            
            if (!propertyType.IsPrimitive
                && !propertyType.IsValueType
                && propertyType != typeof(string)) continue;
            
            object value = property.GetValue(entity);
            property.SetValue(clone, value);
        }

        return clone;
    }
}
