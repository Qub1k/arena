using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;


interface IInteractable{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    private bool interactableObjectIsNear;
    private IInteractable interactableObject;
    private void Update(){
        if(Input.GetKeyDown(KeyCode.E) && interactableObject != null){
            interactableObject.Interact();
            interactableObject = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        interactableObject = col.GetComponent<IInteractable>();
    }   
    private void OnTriggerExit2D(Collider2D col)
    {
        var _interactableObject = col.GetComponent<IInteractable>();

        if(interactableObject == _interactableObject){
            interactableObject = null;
        }
    }  
}