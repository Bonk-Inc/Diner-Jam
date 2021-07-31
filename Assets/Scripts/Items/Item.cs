using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField]
    protected ItemInfo itemValues;
    
    public event Action<Item> OnItemReplaced;

    public abstract bool CombineItem(Item collectedIngredient);

    //TODO Is there a better way, other than destroying itself?
    public virtual void ReplaceItem(Item replaceWith){
        Item item = Instantiate(replaceWith, transform);
        
        OnItemReplaced?.Invoke(item);
        Destroy(gameObject);
    }
}