using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ingredient : MonoBehaviour
{
    [SerializeField]
    private string name;

    [SerializeField]
    private IngredientType type;
    
    protected bool Equals(Ingredient other)
    {
        return base.Equals(other) && name == other.name && type == other.type;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        
        return Equals((Ingredient) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = base.GetHashCode();
            hashCode = (hashCode * 397) ^ (name != null ? name.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (int) type;
            return hashCode;
        }
    }
}
