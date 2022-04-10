using UnityEngine;

//Attached to the Player only, as it handles the input
[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [field: SerializeField] public bool MovementInputLocked { get; set; }

    private CharacterController charController;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (MovementInputLocked) return;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        charController.MoveAxis(h, v);
    }
}
