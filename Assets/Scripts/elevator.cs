using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class elevator : MonoBehaviour
{
    public Text prompt;
    public CharacterController player;
    public GameObject GFloor;
    public GameObject floor2;

    public int floor;

    private void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (floor == 1) prompt.text = "[F] Go to 2F";
            if (floor == 2) prompt.text = "[F] Go to the ground floor";
        }
    }

    public void OnTriggerStay(Collider other)
    {
        this.GetComponent<Outline>().enabled = true;

        if (Input.GetKeyDown(KeyCode.F))
        {
            this.GetComponent<Outline>().enabled = false;

            if (floor == 1)
            {
                player.transform.position = floor2.transform.position;
                prompt.text = "";
                player.transform.localRotation = Quaternion.Euler(0, -90, 0);
            }

            if (floor == 2)
            {
                player.transform.position = GFloor.transform.position;
                prompt.text = "";
                player.transform.localRotation = Quaternion.Euler(0, -90, 0);
            }            
        }
    }

    void OnTriggerExit(Collider other)
    {
        this.GetComponent<Outline>().enabled = false;
        prompt.text = "";
    }
}

