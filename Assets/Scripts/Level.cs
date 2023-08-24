using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public bool isFinished = false;

    public List<Transform> waypoints;

    public List<DragAndDrop> blocks;

    public Car car;

    public void FinishLap()
    {
        isFinished = true;
    }

    private void Update()
    {
        if (blocks.Count == 0)
        {
            car.canMove = true;
        }
    }
}