using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class LightSwitch1 : MonoBehaviour, IInteractable
{
    public string InteractMessage => objectInteractMessage;

    [SerializeField]
    public bool isOn = false;
    public bool isSwitchOn;
    public GameObject lightOn, lightOff, switchOn, switchOff;

    [SerializeField]
    string objectInteractMessage;

    public float cooldown;
    private float switchLastOn;


    public void Interact()
    {
        Switch();
        isOn = !isOn;
    }

    public void Switch()
    {
            lightOn.SetActive(true);
            lightOff.SetActive(false);
            switchOn.SetActive(true);
            switchOff.SetActive(false);
        

        StartCoroutine(disableSwitch());  
    }

    private IEnumerator disableSwitch()
    {
        
        yield return new WaitForSeconds(cooldown);

        lightOn.SetActive(false);
        lightOff.SetActive(true);
        switchOn.SetActive(false);
        switchOff.SetActive(true);
    }
}
 