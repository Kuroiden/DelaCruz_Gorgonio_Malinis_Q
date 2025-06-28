using DoorScript;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public Player player;
    public GameManager gameManager;
    public GameObject mainUI;
    public GameObject notebook;
    public GameObject notice;
    public GameObject entranceDoor;

    public Text task;
    public Text prompt;
    public Text dialogue;
    public Text notesA;
    public Text notesB;
    public Text notesC;
    public Text notesD;
    public Text notesE;

    public int setObjID = 0;
    bool[] isChecked = new bool[8];
    public int cluesCleared = 0;
    public bool isNotebookActive = false;

    public float dialogueTimer;

    private Outline outline;

    void Start()
    {
        if (setObjID == 0) this.transform.localRotation = Quaternion.Euler(0, 10, 0);
        outline = GetComponent<Outline>();
    }

    void Update()
    {
        notice.SetActive(false);

        if (Input.GetKeyDown(KeyCode.R))
        {
            isNotebookActive = !isNotebookActive;
            notice.SetActive(false);
        }

        notebook.SetActive(isNotebookActive);
        mainUI.SetActive(!isNotebookActive);
        player.playerCanMove = !isNotebookActive;

        if (dialogueTimer > 0)
        {
            dialogueTimer -= Time.deltaTime;
            if (dialogueTimer <= 0)
            {
                dialogue.text = "";
                dialogueTimer = 0;
            }
        }

        if (cluesCleared > 6)
        {
            task.text = "Investigation complete.";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (setObjID == 0 && !isChecked[0])
        {
            dialogue.text = "No sign of struggle here. Did the victim know the killer?";
            dialogueTimer = 7.0f;

            isChecked[0] = true;
            notesA.text = "- Door showed no signs of forced entry.";

            notice.SetActive(true);
        }
        else if (!isChecked[setObjID])
        {
            prompt.text = "[F] Inspect";
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (!isChecked[setObjID]) outline.enabled = true;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isChecked[setObjID])
            {
                dialogue.text = "I should check elsewhere...";
                dialogueTimer = 3.0f;
            }
            else
            {
                isChecked[setObjID] = true;
                outline.enabled = false;
                notice.SetActive(true);

                switch (setObjID)
                {
                    case 1:
                        dialogue.text = "Still wet... not from the water. Killer didn’t even wipe it. Panic?";
                        dialogueTimer = 10.0f;
                        notesB.text = "- A bloody knife was found next to the toilet. Must have been dropped in a panic. Bathroom is covered in blood overall. Victim's body is in the tub with bloody water.";
                        cluesCleared += 1;
                        break;

                    case 2:
                        dialogue.text = "Who the hell is Matt?";
                        dialogueTimer = 5.0f;
                        notesC.text = "- A smartphone was found in the kitchen, still showing a heated chat conversation with \"Matt\".\n\t(Latest message: \"Fine. Come over. But this is the last time.\")";
                        cluesCleared += 1;
                        break;

                    case 3:
                        dialogue.text = "She wasn't alone. But only one person walked out.";
                        dialogueTimer = 7.0f;
                        notesD.text += "\n- 2 wine glasses are on the coffee table, one nearly empty. Victim wasn't alone on the day of the incident.";
                        cluesCleared += 1;
                        break;

                    case 4:
                        dialogue.text = "Someone dropped this in a hurry.";
                        dialogueTimer = 5.0f;
                        notesD.text += "\n- A broken wrist watch was found next to the coffee table. It appears to have stopped at 9:47. Possible time of a struggle.";
                        cluesCleared += 1;
                        break;

                    case 5:
                        dialogue.text = "Matt again... this can't be a coincidence.";
                        dialogueTimer = 6.0f;
                        notesE.text += "\n- A broken picture frame was found in the bedroom, depicting a couple, Jen and Matt.\n\t(Picture caption: \"Matt + Jen - Summer 2023\")";
                        cluesCleared += 1;
                        break;

                    case 6:
                        dialogue.text = "Looks like Jen had doubts...";
                        dialogueTimer = 5.0f;
                        notesE.text += "\n- An open journal was found on a desk in the bedroom.\n\t(Latest entry: \"Matt's been different lately...\")";
                        cluesCleared += 1;
                        break;

                    case 7:
                        dialogue.text = "Blood on the window. That’s no accident.";
                        dialogueTimer = 6.0f;
                        notesE.text += "\n- The bedroom window was left opened, with blood on it. Perpetrator must have used it to escape. Floor and walls leading to the room has the same blood.";
                        cluesCleared += 1;
                        break;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        outline.enabled = false;
        prompt.text = "";
    }
}
