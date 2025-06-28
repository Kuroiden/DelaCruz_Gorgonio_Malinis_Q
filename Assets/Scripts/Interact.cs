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

    public bool questStart = false;
    public int setObjID = 0;
    bool[] isChecked = new bool[8];

    public int cluesCleared = 0;
    public bool isNotebookActive = false;

    private Outline outline;

    void Start()
    {
        gameManager.clueID = 9;

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

        // if (questStart) dialogue.text = "No sign of struggle here. Did the victim know the killer?";

        if (cluesCleared == 7)
        {
            task.text = "Investigation complete.";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (setObjID == 0 && !isChecked[0])
        {
            gameManager.clueID = setObjID;
            gameManager.dialogueTimer = 7.0f;

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

        if (!isChecked[setObjID]) {
            outline.enabled = true;

            if (Input.GetKeyDown(KeyCode.F))
            {
                gameManager.clueID = setObjID;

                switch (setObjID)
                {
                    case 1:
                        notesB.text = "- A bloody knife was found next to the toilet. Must have been dropped in a panic. Bathroom is covered in blood overall. Victim's body is in the tub with bloody water.";
                        cluesCleared += 1;

                        gameManager.dialogueTimer = 10.0f;
                        break;

                    case 2:
                        notesC.text = "- A smartphone was found in the kitchen, still showing a heated chat conversation with \"Matt\".\n\t(Latest message: \"Fine. Come over. But this is the last time.\")";
                        cluesCleared += 1;

                        gameManager.dialogueTimer = 5.0f;
                        break;

                    case 3:
                        notesD.text += "\n- 2 wine glasses are on the coffee table, one nearly empty. Victim wasn't alone on the day of the incident.";
                        cluesCleared += 1;

                        gameManager.dialogueTimer = 7.0f;
                        break;

                    case 4:
                        notesD.text += "\n- A broken wrist watch was found on the coffee table too. It appears to have stopped at 9:47. Possible time of a struggle?";
                        cluesCleared += 1;

                        gameManager.dialogueTimer = 5.0f;
                        break;

                    case 5:
                        notesE.text += "\n- A broken picture frame was found in the bedroom, depicting a couple, Jen and Matt.\n\t(Picture caption: \"Matt + Jen - Summer 2023\")";
                        cluesCleared += 1;

                        gameManager.dialogueTimer = 6.0f;
                        break;

                    case 6:
                        notesE.text += "\n- An open journal was found on a desk in the bedroom.\n\t(Latest entry: \"Matt's been different lately...\")";
                        cluesCleared += 1;

                        gameManager.dialogueTimer = 5.0f;
                        break;

                    case 7:
                        notesE.text += "\n- The bedroom window was left opened, with blood on it. Perpetrator must have used it to escape. Floor and walls leading to the room has the same blood.";
                        cluesCleared += 1;

                        gameManager.dialogueTimer = 5.0f;
                        break;
                }

                isChecked[setObjID] = true;
                outline.enabled = false;
                notice.SetActive(true);
            }
        }
        else prompt.text = string.Empty;
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        outline.enabled = false;
        prompt.text = "";
    }
}
