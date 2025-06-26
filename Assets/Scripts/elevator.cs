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
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (floor == 1)
            {
                player.transform.position = floor2.transform.position;
                player.transform.rotation = floor2.transform.rotation;
                prompt.text = "[F] Go to the ground floor";
            }

            if (floor == 2)
            {
                player.transform.position = GFloor.transform.position;
                player.transform.rotation = GFloor.transform.rotation;
                prompt.text = "[F] Go to 2F";
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        prompt.text = "";
    }
}

