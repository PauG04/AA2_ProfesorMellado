using UnityEngine;

public enum PlayerState {MOVE, INTERACT, WAIT, PUZZLE}
public class PlayerController : MonoBehaviour
{
    private PlayerState playerState;
    
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private Vector2 lastMoveDir;
    
    [SerializeField] private float interactionDistance = 1f;
    [SerializeField] private LayerMask interactableLayer;

    private Interact currentInteract;
    private bool canInteract;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lastMoveDir = Vector2.down;
        playerState = PlayerState.WAIT;
        currentInteract = null;
    }

    void Update()
    {
        InteractObject();
        States();
    }

    void States()
    {
        ReadInput();
        switch (playerState)
        {
            case PlayerState.MOVE:
                Movement();
                break;
            case PlayerState.WAIT:
                Wait();
                break;
            case PlayerState.INTERACT:
                Interact();
                break;
            case PlayerState.PUZZLE:
                break;
        }
    }

    void ReadInput()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        
        if (inputX != 0)
            movement = new Vector2(inputX, 0);
        else if (inputY != 0)
            movement = new Vector2(0, inputY);
        else
            movement = Vector2.zero;
    }

    void Movement()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        animator.SetFloat("LastMoveX", lastMoveDir.x);
        animator.SetFloat("LastMoveY", lastMoveDir.y);
        
        if (movement == Vector2.zero && playerState != PlayerState.INTERACT)
        {
            ChangeState(PlayerState.WAIT);
        }
        
        if (movement != Vector2.zero)
        {
            lastMoveDir = movement;
        }
    }

    void Wait()
    {
        if (movement != Vector2.zero && playerState != PlayerState.INTERACT)
        {
            ChangeState(PlayerState.MOVE);
        }
    }

    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentInteract != null && canInteract)
        {
            currentInteract.NextDialogue();
        }

    }

    void InteractObject()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerState != PlayerState.INTERACT)
        {
            RaycastHit2D hit = Physics2D.Raycast(rb.position, lastMoveDir, interactionDistance, interactableLayer);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.TryGetComponent<Interact>(out Interact interactable))
                {
                    ChangeState(PlayerState.INTERACT);
                    currentInteract = interactable;
                    currentInteract.InteractObject();
                }
            }
        }
    }

    public void ChangeState(PlayerState newState)
    {
        switch (playerState)
        {
            case PlayerState.MOVE:
                animator.SetBool("IsMoving", false);
                break;
            case PlayerState.WAIT:
                break;
            case PlayerState.INTERACT:
                break;
            case PlayerState.PUZZLE:
                break;
        }

        playerState = newState;

        switch (playerState)
        {
            case PlayerState.MOVE:
                animator.SetBool("IsMoving", true);
                break;
            case PlayerState.WAIT:
                currentInteract = null;
                break;
            case PlayerState.INTERACT:
                canInteract = false;
                Invoke("SetCanInteract", 0.5f);
                break;
            case PlayerState.PUZZLE:
                break;
        }
    }

    private void SetCanInteract()
    {
        canInteract = true;
    }
}
