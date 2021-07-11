using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueSc : MonoBehaviour
{
    public GameObject dialogue;

    public void CloseDialogue()
    {
        dialogue.gameObject.SetActive (false);
    }
}
