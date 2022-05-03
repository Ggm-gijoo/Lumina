using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("수평 이동")]
    [SerializeField]
    private float xDelta;
    [SerializeField]
    private float xMoveSpeed;
    [Header("수직 이동")]
    [SerializeField]
    private float yDelta;
    [SerializeField]
    private float yMoveSpeed;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position; 

    }

    private void FixedUpdate()
    {
        if(xMoveSpeed != 0)
        {
            float xMove = startPosition.x + xDelta * Mathf.Sin(Time.time * xMoveSpeed);
            transform.position = new Vector3(xMove, transform.position.y, transform.position.z);
        }
        if (yMoveSpeed != 0)
        {
            float yMove = startPosition.y + yDelta * Mathf.Sin(Time.time * yMoveSpeed);
            transform.position = new Vector3(transform.position.x, yMove, transform.position.z);
        }
    }
}
