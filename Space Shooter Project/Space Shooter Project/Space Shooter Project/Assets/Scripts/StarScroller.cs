using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScroller : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 targetPosition;
    public float nyoomDelta;
    public static bool nyoom;

    public void Start()
    {
        nyoom = false;
        transform.position = startPosition;

    }

    public void Update()
    {
        if (nyoom)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, nyoomDelta * Time.deltaTime);
        }
    }
}
