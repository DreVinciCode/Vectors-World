using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public Transform cam;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public float xDistance = 0.127f;
    //0.129, 0.128

    Dictionary<(int, int), (float, float)> tileValues = new Dictionary<(int, int), (float, float)>();
    Dictionary<string, float> JointOffset_Dictionary = new Dictionary<string, float>();
    (int, int) curr_loc;  


    //JointOffset_Dictionary.Add("testt", 0.34f);
    //tileValues.Add((1,1),(0.929f,0.19f));

    //(int, int) curr_loc = 



    private void Start()
    {
        JointOffset_Dictionary.Add("tes", 0.5f);
        tileValues.Add((1, 1), (0.929f, 0.19f));

        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        Vector3 direct = new Vector3(horiz, 0f, vert).normalized;

        if (direct.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direct.x, direct.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.MovePosition(transform.position + moveDir * speed * Time.deltaTime);
        }
    }

    void functionMove()
    {
        transform.position = Vector3.MoveTowards(tran); 
    }
}
