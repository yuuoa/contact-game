using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCheckpoint : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(DialogueStarter());
        }
    }

    public IEnumerator DialogueStarter()
    {
        yield return new WaitForSeconds(0.2f);
        dialogueTrigger.TriggerDialogue();
    }
}
