using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject textbox;
    public Text task;
    public Text dialogue;
    
    public int clueID;
    public float dialogueTimer;


    // Update is called once per frame
    void Update()
    {
        if (dialogueTimer > 0)
        {
            dialogueTimer -= Time.deltaTime;

            textbox.SetActive(true);
            switch (clueID)
            {
                case 0:
                    dialogue.text = "No sign of struggle here. Did the victim know the killer?";
                    break;

                case 1:
                    dialogue.text = "Still wet... not from the water. Killer didn’t even wipe it. Panic?";
                    break;

                case 2:
                    dialogue.text = "Who the hell is Matt?";
                    break;

                case 3:
                    dialogue.text = "She wasn't alone. But only one person walked out.";
                    break;

                case 4:
                    dialogue.text = "Someone left this in a hurry.";
                    break;

                case 5:
                    dialogue.text = "Matt again... this can't be a coincidence.";
                    break;

                case 6:
                    dialogue.text = "Looks like Jen had doubts...";
                    break;

                case 7:
                    dialogue.text = "Blood on the window. That’s no accident.";
                    break;
            }
        }
        else if (dialogueTimer <= 0)
        {
            textbox.SetActive(false);
            dialogue.text = "";
            dialogueTimer = 0;
        }

        

        //switch (taskID) {
        //    case 1:
        //        task.text = "Enter the crime scene";
        //        break;
        //    case 2:
        //        task.text = "Find the weapon used";
        //        break;
        //    case 7:
        //        task.text = "Investigation complete";
        //        break;
        //    default:
        //        task.text = "Search for clues";
        //        break;
        //}
    }

    void setTimer()
    {
        switch (clueID)
        {
            case 0:
                dialogueTimer = 7.0f;
                break;
            case 1:
                dialogueTimer = 10.0f;
                break;
            case 2:
                dialogueTimer = 5.0f;
                break;
            case 3:
                dialogueTimer = 7.0f;
                break;
            case 4:
                dialogueTimer = 5.0f;
                break;
            case 5:
                dialogueTimer = 6.0f;
                break;
            case 6:
                dialogueTimer = 5.0f;
                break;
            case 7:
                dialogueTimer = 6.0f;
                break;
        }
    }
}
