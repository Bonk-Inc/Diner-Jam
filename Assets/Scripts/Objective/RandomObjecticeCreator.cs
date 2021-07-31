using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjecticeCreator : ObjectiveCreator
{

    [SerializeField]
    private List<DishInfo> possibleObjectives;

    public override DishInfo CreateObjective()
    {
        return GetRandomObjective();
    }

    private DishInfo GetRandomObjective()
    {
        int randomIndex = Random.Range(0, possibleObjectives.Count);
        return possibleObjectives[randomIndex];
    }
}
