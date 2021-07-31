using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjecticeCreator : ObjectiveCreator
{

    [SerializeField]
    private List<ItemInfo> possibleObjectives;

    public override ItemInfo CreateObjective()
    {
        return GetRandomObjective();
    }

    private ItemInfo GetRandomObjective()
    {
        int randomIndex = Random.Range(0, possibleObjectives.Count);
        return possibleObjectives[randomIndex];
    }
}
