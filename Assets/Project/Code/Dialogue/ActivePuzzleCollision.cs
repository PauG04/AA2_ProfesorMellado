using UnityEngine;

public class ActivePuzzleCollision : Interact
{
    [SerializeField] private BoxCollider2D boxCollider;

    public override void DoAction()
    {
        Interact();
        currentDialogue++;
        NextDialogue();
    }

    public void Interact()
    {
        boxCollider.enabled = true;
    }
}
