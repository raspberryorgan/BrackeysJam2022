using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	private Queue<Sentence> sentences;
	private DraggableMemory memory;
	public GameObject dialogueCanvas;

	public Canvas canvas;

	// Use this for initialization
	void Start()
	{
		sentences = new Queue<Sentence>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		//animator.SetBool("IsOpen", true);
		Debug.Log("Starting new Dialogue");
		dialogueCanvas.SetActive(true);
		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (Sentence sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		Sentence sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence.text));
		if (memory)
		{
			//Destroy(memory.gameObject);

		}
		if (sentence.memory)
        {			
			memory = Instantiate(sentence.memory).GetComponent<DraggableMemory>();
			memory.SetParent(canvas.transform, false);
			memory.SetCanvas(canvas);			
        }
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		//animator.SetBool("IsOpen", false);
		Debug.Log("End Dialogue.");
		dialogueCanvas.SetActive(false);
	}

}
