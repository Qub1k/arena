using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;

    [SerializeField] private float textSpeed;
	[SerializeField] private Vector3 targetPos;

    private string currentSentence;
	[SerializeField] private Transform dialogueWindow;
	private Vector3 initialPosition;    

	//public Animator animator;

	private Queue<string> sentences;
    private bool IsPhraseEnded = true;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
		dialogueWindow.gameObject.SetActive(false);
	}

	public void StartDialogue (Dialogue dialogue)
	{
		dialogueWindow.gameObject.SetActive(true);
		//animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences) //назначаем все заготовленные диалоги в очередь
		{
			sentences.Enqueue(sentence); 
		}

        
		DisplayNextSentence(); //первый диалог вызывает сразу в начале
	}

	public void DisplayNextSentence () //это буит по кнопке
	{
        if (!IsPhraseEnded) //если фраза не закончилось он то ее моментально выводит 
        {
            StopAllCoroutines();
            IsPhraseEnded = true;
            dialogueText.text = currentSentence;
            return;
        }

		if (sentences.Count == 0) //если нет фраз конец
		{
			EndDialogue();
			dialogueWindow.gameObject.SetActive(false);
			return;
		}

        

		currentSentence = sentences.Dequeue(); //удаляется и возвращает первый эл в очереди

        

		StopAllCoroutines();  //прерывает все коррутины
		StartCoroutine(TypeSentence(currentSentence, .1f));
	}

	IEnumerator TypeSentence (string sentence, float delay)
	{
        
        IsPhraseEnded = false;

		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{

			dialogueText.text += letter;

            
			yield return new WaitForSeconds(delay);
            
		}
        
        IsPhraseEnded = true;



        EndOfPhrase();

        
        
	}
    

    private void EndOfPhrase(){
        Debug.Log("конец месседжа");
    }

	void EndDialogue()
	{
        Debug.Log("EndOfDilogue");
		//animator.SetBool("IsOpen", false);
	}


}
