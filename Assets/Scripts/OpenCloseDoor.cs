using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseDoor : MonoBehaviour
{
    public Text prompt;
    public GameObject door;

    string msg;
    public bool isDoorOpen = false;

    private void Update()
    {
        
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            float rotation = isDoorOpen ? 0 + (2 * Time.deltaTime) : 90 - (2 * Time.deltaTime);
            isDoorOpen = isDoorOpen ? false : true;

            if (!isDoorOpen) {
                prompt.text = "[F] Open Door";

                //door.transform.localPosition = Vector3(0, 0, 0);
                door.transform.localRotation = Quaternion.Euler(0, rotation, 0);

            } 
            else {
                door.transform.localRotation = Quaternion.Euler(0, rotation, 0);
                prompt.text = "[F] Close Door"; 
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        prompt.text = "";
    }
}
