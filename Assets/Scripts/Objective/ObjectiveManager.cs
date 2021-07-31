using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField]
    private List<ItemInfo> currentObjectives;

    [SerializeField]
    private DishUIManager UIHandler;

    [SerializeField]
    private ObjectiveCreator creator;

    [SerializeField]
    private int minObjectives, maxObjectives;

    [SerializeField]
    private float minAddDelay, maxAddDelay;

    private void Awake()
    {
        if(minObjectives > maxObjectives)
        {
            throw new System.Exception("Minimum amout of objectives should be higher than the maximum amount.");
        }

        FillObjeciveToMinimum();
    }

    private void RemoveObjective(ItemInfo info)
    {
        currentObjectives.Remove(info);
        UIHandler.RemoveDish(info);

        FillObjeciveToMinimum();
    }

    private void FillObjeciveToMinimum()
    {
        while(currentObjectives.Count < minObjectives)
        {
            AddCurrentObjective();
        }
    }

    private void AddCurrentObjective()
    {
        if(currentObjectives.Count >= maxObjectives)
        {
            return;
        }
        ItemInfo newObjective = CreateNewObjective();
        currentObjectives.Add(newObjective);
        UIHandler.AddDishUI(newObjective);
    }

    private ItemInfo CreateNewObjective()
    {
        return creator.CreateObjective();
    }

    private IEnumerator ObjectiveAddTimer()
    {
        while (true)
        {
            float addDelay = Random.Range(minAddDelay, maxAddDelay);
            yield return new WaitForSeconds(addDelay);

            AddCurrentObjective();
        }

    }

}
