using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 5;
    Vector3 move;
    Vector3 moveGoal;

    private void Start()
    {
        moveGoal = transform.position;
    }
    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        moveGoal = transform.position + direction * speed;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(moveGoal, transform.position, 1 * Time.deltaTime);
    }
}
