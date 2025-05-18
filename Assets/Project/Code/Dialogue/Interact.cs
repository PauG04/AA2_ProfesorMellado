using System.Collections;
using TMPro;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] protected GameObject canvas;
    [SerializeField] protected TextMeshProUGUI textBox;
    [SerializeField] protected Dialogues dialogue;
    [SerializeField] protected GameObject profesorIndication;
    [SerializeField] protected GameObject NPCIndication;
    [SerializeField] protected TextMeshProUGUI NPCtext;

    [SerializeField] protected PlayerController playerController;

    [SerializeField] private AudioClip talkAudio;

    protected int currentDialogue;
    protected Coroutine typingCoroutine;
    protected bool isTyping;

    protected bool canEnd;

    public virtual void InteractObject()
    {
        canvas.SetActive(true);
        currentDialogue = 0;
        canEnd = false;
        isTyping = false;
        NPCtext.text = dialogue.interactableName;
        NextDialogue();
    }

    public virtual void NextDialogue()
    {
        if (isTyping)
        {
            CompleteCurrentText();
            return;
        }

        if(canEnd)
        {
            EndConversation();
            return;
        }

        if (currentDialogue == dialogue.dialogueNodes.Count)
        {
            canEnd = true;
            return;
        }

        var node = dialogue.dialogueNodes[currentDialogue];

        switch (dialogue.dialogueNodes[currentDialogue].dialogueType)
        {
            case DialogueType.ACTION:
                DoAction();
                break;
            case DialogueType.DIALOGUE:

                if(dialogue.dialogueNodes[currentDialogue].dialogueSpeaker == DialogueSpeaker.PLAYER)
                {
                    profesorIndication.SetActive(true);
                    NPCIndication.SetActive(false);
                }
                else
                {
                    profesorIndication.SetActive(false);
                    NPCIndication.SetActive(true);
                    if (dialogue.interactableName.Length == 0)
                        NPCIndication.SetActive(false);
                }

                if (typingCoroutine != null) StopCoroutine(typingCoroutine);
                typingCoroutine = StartCoroutine(TypeText(node.dialogueText));
                break;
        }
    }

    public virtual void DoAction()
    {

    }

    private IEnumerator TypeText(string text)
    {
        isTyping = true;
        textBox.text = "";
        foreach (char c in text)
        {
            textBox.text += c;
            if (!char.IsWhiteSpace(c) && talkAudio != null)
            {
                AudioManager.Instance.PlaySFX(talkAudio, Random.Range(0.9f, 1.2f));
            }
            yield return new WaitForSeconds(0.03f); 
        }
        isTyping = false;
        currentDialogue++;
    }

    private void CompleteCurrentText()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        textBox.text = dialogue.dialogueNodes[currentDialogue].dialogueText;
        isTyping = false;
        currentDialogue++;
    }

    public virtual void EndConversation()
    {
        canvas.SetActive(false);
        profesorIndication.SetActive(false);
        NPCIndication.SetActive(false);
        playerController.ChangeState(PlayerState.WAIT);
    }

    public int GetIndex() {  return currentDialogue; }
}
