using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseDoor : MonoBehaviour
{
    public Text prompt;
    public Text dialogue;
    public GameObject door;

    string msg;
    public bool isDoorOpen = false;
    public bool isDoorLocked = false;

    public float rotation;

    private void Update()
    {
        rotation = isDoorOpen ? 0 + (2 * Time.deltaTime) : 90 - (2 * Time.deltaTime);
        if (isDoorOpen && rotation > 0 ) rotation = 90;
        else if (!isDoorOpen && rotation > 0 ) rotation = 0;
        door.transform.localRotation = Quaternion.Euler(0, rotation, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            prompt.text = isDoorOpen ? "[F] Close Door" : "[F] Open Door";            
        }
    }

    public void OnTriggerStay(Collider other)
    {
        this.GetComponent<Outline>().enabled = true;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isDoorLocked) dialogue.text = "This doesn't seem be the right room...";
            else
            {
                isDoorOpen = isDoorOpen ? false : true;

                if (!isDoorOpen)
                {
                    prompt.text = "[F] Open Door";
                    
                }
                else
                {
                    prompt.text = "[F] Close Door";
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        dialogue.text = "";
        this.GetComponent<Outline>().enabled = false;
        prompt.text = "";
    }
}
