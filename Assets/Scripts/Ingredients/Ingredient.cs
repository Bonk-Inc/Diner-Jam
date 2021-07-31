using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField]
    private IngredientData data;

    public string Name => data.Name;

    public IngredientData Data => data;

    public event EventHandler<IngredientData> OnDataSet;

    private void Start()
    {
        if(data != null)
        {
            CallDataChangedEvent();
        }
    }

    public void SetData(IngredientData data)
    {
        this.data = data;
        CallDataChangedEvent();
    }

    private void CallDataChangedEvent()
    {
        OnDataSet?.Invoke(this, data);
    }

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
