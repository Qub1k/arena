using UnityEngine;
 
public class Actor : MonoBehaviour, IInteractable
{
    public string Name;
    public DialogueSO Dialogue;
 
    // Trigger dialogue for this actor
    public void PlayDialogue()
    {
        DialogueController.Instance.StartDialogue(Name, Dialogue.RootNode);
    }
    public void Interact()
    {
        PlayDialogue();
    }
}