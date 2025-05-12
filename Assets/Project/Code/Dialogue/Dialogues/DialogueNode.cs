using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "ScriptableObjects/DialogueNode", order = 2)]

public class DialogueNode : ScriptableObject
{
    public DialogueType dialogueType;
    public DialogueSpeaker dialogueSpeaker;
    [TextArea(3, 10)] public string dialogueText;
}

public enum DialogueType
{
    ACTION,
    DIALOGUE,
    FINISH
}

public enum DialogueSpeaker
{
    PLAYER,
    OBJECT
}
