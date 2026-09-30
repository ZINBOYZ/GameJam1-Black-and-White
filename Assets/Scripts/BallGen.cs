using Assets.Scripts;
using UnityEngine;

public class BallGen : MonoBehaviour, IInteractable
{

    [SerializeField]
    private GameObject spawnPrefab;

    [SerializeField]
    string objectInteractMessage;

    public string InteractMessage => objectInteractMessage;

    public void Interact()
    {
        Spawn();
    }

    void Spawn()
    {
        var spawnedObject = Instantiate(spawnPrefab, transform.position + Vector3.up, Quaternion.identity);

        var randomSize = Random.Range(0.1f, 1f);
        spawnedObject.transform.localScale = Vector3.one * randomSize;

        var randomColour = new Color(Random.Range(0.0f, 0.1f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        spawnedObject.GetComponent<MeshRenderer>().material.color = randomColour;
    }
}
