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
	private GameObject memory;


	// Use this for initialization
	void Start()
	{
		sentences = new Queue<Sentence>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		//animator.SetBool("IsOpen", true);
		Debug.Log("Starting new Dialogue");
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
			Destroy(memory.gameObject);

		}
		if (sentence.memory)
        {
			
			memory = Instantiate(sentence.memory);
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
	}

}
