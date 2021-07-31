using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private GameobjectMap gameobjectMap;
    private GridPosition gridPosition;
    private PlayerMovement playerMovement;

    private GameObject inventory;

    public bool HasItem(){
        return inventory != null;
    }

    public GameObject GetInventoryItem(){
        GameObject item = inventory;
        inventory = null;
        item.transform.SetParent(null);
        item.transform.localScale = Vector3.one;
        return item;
    }

    public bool PutInInventory(GameObject gobj){
        if(HasItem())
            return false;

        gobj.transform.SetParent(transform);
        gobj.transform.localPosition = Vector3.up * 0.65f;
        gobj.transform.localScale = Vector3.one * 0.6f;
        inventory = gobj;
        return true;
    }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        gridPosition = GetComponent<GridPosition>();
    }

    public GameobjectMap GameobjectMap
    {
        get => gameobjectMap;
        set => SetGameobjectMap(value);
    }

    private void SetGameobjectMap(GameobjectMap newGameobjectMap)
    {
        gameobjectMap = newGameobjectMap;
    }

    private void SetGridPosition(GridPosition newGridPosition)
    {
        gridPosition = newGridPosition;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryInteract();
        }
    }

    private void TryInteract(){
        GameObject obj = FindObjectInLookingDirection();
        if (obj == null){
            return;
        }
        InteractableTile interactable = obj.GetComponent<InteractableTile>();
        if(interactable == null){
            return;
        }
        interactable.Interact(this);
    }

    private GameObject FindObjectInLookingDirection(){
        Vector2Int position = gridPosition.Position + playerMovement.LookingAt;
        return gameobjectMap.GetCell(position);
    }


}
