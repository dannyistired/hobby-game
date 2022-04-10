using UnityEngine;

//Can be attached to any character that moves, Does NOT handle input
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float stoppingDistance = 0.2f;

    private bool movingToPoint;
    private Vector2 targetMovePoint;
    private Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!movingToPoint) return;

        Vector2 dir = (targetMovePoint - (Vector2)transform.position).normalized;

        if (Vector2.Distance(transform.position, targetMovePoint) > stoppingDistance)
        {
            rbody.velocity = dir * moveSpeed;
        }
        else //Reached destination
        {
            movingToPoint = false;
        }
    }

    //Used primarily for Player characters (MUST BE IN UPDATE METHOD)
    public void MoveAxis(float horizontal, float vertical)
    {
        Vector2 dir = new Vector2(horizontal, vertical).normalized;

        rbody.velocity = dir * moveSpeed;
    }

    //Used primarily for NPC characters but can be used on the Player too in cutscenes
    public void MoveToPoint(Vector2 targetPoint)
    {
        targetMovePoint = targetPoint;
        movingToPoint = true;
    }

    //Used primarily for NPC characters
    public void StopMoving()
    {
        movingToPoint = false;
    }

    //Returns true if the character is moving
    public bool CharacterMoving()
    {
        return (!Mathf.Approximately(rbody.velocity.x, 0) || !Mathf.Approximately(rbody.velocity.y, 0)) || movingToPoint;
    }
}
