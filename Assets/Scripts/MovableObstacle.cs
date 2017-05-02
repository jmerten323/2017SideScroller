using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObstacle : MonoBehaviour {

    public GameObject Platform;
    public float moveSpeed;
    public Transform currentPoint;
    public Transform[] points;
    public int pointsSelection;

    void Start()
    {
        currentPoint = points[pointsSelection];
    }

    void Update()
    {
        Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

        if (Platform.transform.position == currentPoint.position)
        {
            pointsSelection++;

            if (pointsSelection == points.Length)
            {
                pointsSelection = 0;
            }

            currentPoint = points[pointsSelection];
        }
    }
}
