using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ingredient : MonoBehaviour
{
    [SerializeField] 
    private string name;

    public string Name => name;
    
    protected bool Equals(Ingredient other)
    {
        return name == other.name;
    }
    
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        
        return obj.GetType() == GetType() && Equals((Ingredient) obj);
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}
