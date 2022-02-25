using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public Animator animator;

    private Queue<Sentence> sentences;
    private MemoryContainer memoryContainer;
    public GameObject dialogueCanvas;

    public Canvas canvas;

    private Player player;

    [Header("PA INICIALIZAR MEMORIES")]
    [SerializeField] MouseChecker checker;

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<Sentence>();
        player = FindObjectOfType<Player>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //animator.SetBool("IsOpen", true);
        //Debug.Log("Starting new Dialogue");
        dialogueCanvas.SetActive(true);
        nameText.text = dialogue.npcName;

        sentences.Clear();

        foreach (Sentence sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        player.isBusy = true;
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
        if (memoryContainer)
        {
            //Destroy(memory.gameObject);

        }
        if (sentence.memory)
        {
            var aux = Instantiate(sentence.memory).GetComponent<MemoryContainer>();
            var draggable = aux.draggable;
            draggable.Initialize(checker);
            draggable.SetParent(canvas.transform, false);
            draggable.SetCanvas(canvas);

            var real = aux.real;
            real.Initialize(checker);
            real.transform.SetParent(null);
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            real.transform.position = new Vector3(pos.x, pos.y, real.transform.position.z);
        }
        if (sentence.missionItem)
        {
            for (int i = 0; i < 3; i++)
            {
                var aux = Instantiate(sentence.missionItem).GetComponent<MissionItem>();
                player.AddToInventory(aux);
                aux.gameObject.SetActive(false);

            }
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
        //Debug.Log("End Dialogue.");
        dialogueCanvas.SetActive(false);
        player.isBusy = false;
    }

}
