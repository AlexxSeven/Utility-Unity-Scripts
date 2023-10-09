using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class A7CamRotato : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 5;
    [SerializeField] [Range(0, 10)] private float speed = 0;
    [SerializeField] private Vector3 rotationAxis = new Vector3(0, 1, 0);

    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = cam.transform.position;
    }

    void LateUpdate()
    {
        Vector3 newPosition = cam.transform.position;
        Vector3 direction = previousPosition - newPosition;

        float rotationAroundAxis = -direction.x + speed;

        cam.transform.position = target.position;

        cam.transform.Rotate(rotationAxis, rotationAroundAxis, Space.World);

        cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

        previousPosition = newPosition;
    }
}