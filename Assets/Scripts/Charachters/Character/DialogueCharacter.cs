using Unity.VisualScripting;
using UnityEngine;

public class DialogueCharacter : MonoBehaviour
{

    private DialogueTrigger dialogueTrigger;

    private void Start(){
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

}
