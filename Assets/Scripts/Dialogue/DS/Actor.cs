using UnityEngine;
 
public class Actor : MonoBehaviour
{
    public string Name;
    public DialogueSO Dialogue;
 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpeakTo();
        }
    }
 
    // Trigger dialogue for this actor
    public void SpeakTo()
    {
        DialogueController.Instance.StartDialogue(Name, Dialogue.RootNode);
    }
}