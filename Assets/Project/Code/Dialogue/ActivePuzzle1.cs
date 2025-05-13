using UnityEngine;
using System.Collections;

public class ActivePuzzle1 : Interact
{
    [SerializeField] private GameObject interactToActive;
    [SerializeField] private Transform uiParent;
    [SerializeField] private float growDuration;

    public override void DoAction()
    {
        Interact();
        currentDialogue++;
        NextDialogue();
        canvas.SetActive(false);
        profesorIndication.SetActive(false);
        NPCIndication.SetActive(false);
        playerController.ChangeState(PlayerState.PUZZLE);
    }

    public override void EndConversation()
    {

    }

    public void Interact()
    {
        GameObject obj = Instantiate(interactToActive, uiParent);
        RectTransform rt = obj.GetComponent<RectTransform>();
        rt.localScale = Vector3.zero;
        StartCoroutine(GrowObject(rt));
    }

    private IEnumerator GrowObject(Transform target)
    {
        Vector3 finalScale = Vector3.one;
        float elapsedTime = 0f;

        while (elapsedTime < growDuration)
        {
            float t = elapsedTime / growDuration;
            target.localScale = Vector3.Lerp(Vector3.zero, finalScale, t);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        target.localScale = finalScale;
    }
}
