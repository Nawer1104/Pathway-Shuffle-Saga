using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 2;

    int index = 0;

    private Vector3 startPos;

    public bool isLoop = true;

    public Level currentLevel;

    public bool canMove;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (!canMove) return;

        Vector3 destination = currentLevel.waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05)
        {
            if (index < currentLevel.waypoints.Count - 1)
            {
                index++;
            }
            else
            {
                StartCoroutine(Finish());
            }
        }
    }

    public IEnumerator Finish()
    {
        yield return new WaitForSeconds(1);

        currentLevel.FinishLap();
    }
}