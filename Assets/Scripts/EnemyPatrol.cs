using System.Collections;
using Unity.VectorGraphics;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    public int moveAttempt;

    public float cooldown;
    private float lastMoveAttempt;

    public bool smoked;

    public GameObject gameOverPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPoint = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == patrolPoints[targetPoint].position)
        {
            moveTime();
            if (smoked)
            {
                targetPoint = 0;
                smoked = false;
            }
        }
        
        
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("kill"))
        {
            smoked = true;
            Debug.Log("fuck you");
        }


    }
    void moveTime()
    {
        if (Time.time < lastMoveAttempt + cooldown)
            return;

        increaseTargetInt();
    

        lastMoveAttempt = Time.time;
    }
    void increaseTargetInt()
    {
        moveAttempt = Random.Range(0, 3);

        if (moveAttempt == 0)
        {
            targetPoint++;
            Debug.Log("moving");
        }

        

        if (targetPoint >= patrolPoints.Length - 1)
        {
            cooldown = 5;
            moveAttempt = Random.Range(0, 1);
            if (!smoked && moveAttempt == 0)
            {
                StartCoroutine(ending());
                
            }
        }
    }

   IEnumerator ending()
    {
        
        yield return new WaitForSeconds(2);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        targetPoint = 0;
        Debug.Log("GameOver");
        gameOverPanel.SetActive(true);
    }
}
