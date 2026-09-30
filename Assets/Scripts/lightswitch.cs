using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightswitch : MonoBehaviour, IInteractable
{
    public GameObject intIcon, lightOn, lightOff, switchOn, switchOff;
    public bool toggle;
    public AudioSource switchSound;

    public string InteractMessage => objectInteractMessage;

    [SerializeField]
    string objectInteractMessage;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                toggle = !toggle;
                if (toggle == true)
                {
                    lightOn.SetActive(true);
                    lightOff.SetActive(false);
                    switchOn.SetActive(true);
                    switchOff.SetActive(false);
                    //switchSound.Play();
                }
                if (toggle == false)
                {
                    lightOn.SetActive(false);
                    lightOff.SetActive(true);
                    switchOn.SetActive(false);
                    switchOff.SetActive(true);
                    //switchSound.Play();
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(false);
        }
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }
}


