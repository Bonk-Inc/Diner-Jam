using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridPosition))]
public class PlayerMovement : MonoBehaviour
{
    private GridPosition gridPosition;
    private GameobjectMap map;
    private Animator animator;

    public Vector2Int LookingAt { get; private set; }

    [SerializeField]
    private Sprite frontSprite, sideSprite;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        gridPosition = GetComponent<GridPosition>();
    }

    public void SetMap(GameobjectMap map)
    {
        this.map = map;
    }

    public void Move(MoveDirection direction)
    {
        LookingAt = GetDesiredChange(direction);
        Vector2Int desiredPosition = gridPosition.Position + LookingAt;
        
        if(direction == MoveDirection.UP || direction == MoveDirection.DOWN)
        {
            spriteRenderer.sprite = frontSprite;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(direction == MoveDirection.LEFT)
        {
            spriteRenderer.sprite = sideSprite;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }else if(direction == MoveDirection.RIGHT)
        {
            spriteRenderer.sprite = sideSprite;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        

        if (map.GetCell(desiredPosition) == null)
        {
            animator.SetTrigger("Move");
            gridPosition.SetPosition(desiredPosition);
        }
    }

    private Vector2Int GetDesiredChange(MoveDirection direction)
    {
        return direction switch
        {
            MoveDirection.UP => Vector2Int.up,
            MoveDirection.DOWN => Vector2Int.down,
            MoveDirection.LEFT => Vector2Int.left,
            MoveDirection.RIGHT => Vector2Int.right,
            _ => Vector2Int.zero,
        };
    }

}

public enum MoveDirection
{
    UP,
    DOWN,
    LEFT,
    RIGHT,

    NONE
}
