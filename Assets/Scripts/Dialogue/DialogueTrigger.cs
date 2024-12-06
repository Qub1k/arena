using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractable {

	[SerializeField] private Vector3 targetPos;

	private DialogueManager dialogueManager;
	public Dialogue dialogue;
	private Transform dialogueWindow;
	private Vector3 initialPosition;


	private void Start(){
		dialogueWindow = GetComponentInParent<Transform>();
		dialogueManager = FindAnyObjectByType<DialogueManager>();

		initialPosition = transform.position;
	}

    private void TriggerDialogue()
	{
		dialogueManager.StartDialogue(dialogue);

	}
	public void Interact(){
		TriggerDialogue();
	}
}
