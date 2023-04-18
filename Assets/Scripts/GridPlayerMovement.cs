using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlayerMovement : MonoBehaviour
{
    Rigidbody cube;
    //public Transform cam;

    public float speed = 5f;
    //public float turnSmoothTime = 0.1f;
    //private float turnSmoothVelocity;
    //public float Distance = 0.127f;

    Dictionary<(int, int), (float, float)> tileValues = new Dictionary<(int, int), (float, float)>();
    int curr_x, curr_z; 
    float world_x, world_y; 


    private void Start()
    {
        tileValues.Add((1, 1), (0.929f, 0.368f));
        tileValues.Add((1, 2), (0.929f, 0.245f));
        tileValues.Add((1, 3), (0.929f, 0.122f));
        tileValues.Add((1, 4), (0.929f, 0.001f));
        tileValues.Add((1, 5), (0.929f, -0.1194f));

        tileValues.Add((2, 1), (0.802f, 0.368f));
        tileValues.Add((2, 2), (0.802f, 0.245f));
        tileValues.Add((2, 3), (0.802f, 0.122f));
        tileValues.Add((2, 4), (0.802f, 0.001f));
        tileValues.Add((2, 5), (0.802f, -0.1194f));

        tileValues.Add((3, 1), (0.673f, 0.368f));
        tileValues.Add((3, 2), (0.673f, 0.245f));
        tileValues.Add((3, 3), (0.673f, 0.122f));
        tileValues.Add((3, 4), (0.673f, 0.001f));
        tileValues.Add((3, 5), (0.673f, -0.1194f));

        tileValues.Add((4, 1), (0.546f, 0.368f));
        tileValues.Add((4, 2), (0.546f, 0.245f));
        tileValues.Add((4, 3), (0.546f, 0.122f));
        tileValues.Add((4, 4), (0.546f, 0.001f));
        tileValues.Add((4, 5), (0.546f, -0.1194f));

        tileValues.Add((5, 1), (0.418f, 0.368f));
        tileValues.Add((5, 2), (0.418f, 0.245f));
        tileValues.Add((5, 3), (0.418f, 0.122f));
        tileValues.Add((5, 4), (0.418f, 0.001f));
        tileValues.Add((5, 5), (0.418f, -0.1194f));

        tileValues.Add((6, 1), (0.29f, 0.368f));
        tileValues.Add((6, 2), (0.29f, 0.245f));
        tileValues.Add((6, 3), (0.29f, 0.122f));
        tileValues.Add((6, 4), (0.29f, 0.001f));
        tileValues.Add((6, 5), (0.29f, -0.1194f));

        tileValues.Add((7, 1), (0.163f, 0.368f));
        tileValues.Add((7, 2), (0.163f, 0.245f));
        tileValues.Add((7, 3), (0.163f, 0.122f));
        tileValues.Add((7, 4), (0.163f, 0.001f));
        tileValues.Add((7, 5), (0.163f, -0.1194f));

        tileValues.Add((8, 1), (0.034f, 0.368f));
        tileValues.Add((8, 2), (0.034f, 0.245f));
        tileValues.Add((8, 3), (0.034f, 0.122f));
        tileValues.Add((8, 4), (0.034f, 0.001f));
        tileValues.Add((8, 5), (0.034f, -0.1194f));

        tileValues.Add((9, 1), (-0.092f, 0.368f));
        tileValues.Add((9, 2), (-0.092f, 0.245f));
        tileValues.Add((9, 3), (-0.092f, 0.122f));
        tileValues.Add((9, 4), (-0.092f, 0.001f));
        tileValues.Add((9, 5), (-0.092f, -0.1194f));

        cube = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        switch (findKeys())
        {
            case "left":
                try
                {
                    curr_z += 1;
                    (world_x, world_y) = tileValues[(curr_x,curr_z)];
                    cube.transform.position = new Vector3(world_x, 0, world_y) * speed * Time.deltaTime;
                }
                catch
                {
                    Debug.Log("Can not move left"); 
                }
                break;
            case "right":
                try
                {
                    curr_z -= 1;
                    (world_x, world_y) = tileValues[(curr_x, curr_z)];
                    cube.transform.position = new Vector3(world_x, 0, world_y) * speed * Time.deltaTime;
                }
                catch
                {
                    Debug.Log("Can not move right");
                }
                break;
            case "up":
                try
                {
                    curr_x += 1;
                    (world_x, world_y) = tileValues[(curr_x, curr_z)];
                    cube.transform.position = new Vector3(world_x, 0, world_y) * speed * Time.deltaTime;
                }
                catch
                {
                    Debug.Log("Can not move up");
                }
                break;
            case "down":
                try
                {
                    curr_x -= 1;
                    (world_x, world_y) = tileValues[(curr_x, curr_z)];
                    cube.transform.position = new Vector3(world_x, 0, world_y) * speed * Time.deltaTime;
                }
                catch
                {
                    Debug.Log("Can not move down");
                }
                break;
        }


        //float horiz = Input.GetAxisRaw("Horizontal");
        //float vert = Input.GetAxisRaw("Vertical");
        //Vector3 direct = new Vector3(horiz, 0f, vert).normalized;

        //if (direct.magnitude >= 0.1f)
        //{
        //    float targetAngle = Mathf.Atan2(direct.x, direct.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        //    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //    transform.rotation = Quaternion.Euler(0f, angle, 0f);
        //    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        //    rb.MovePosition(transform.position + moveDir * speed * Time.deltaTime);
        //}
    }

    public string findKeys()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return "left";
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return "right";

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return "up";

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return "Down";
        }
            return ""; 
    }

    //void functionMove()
    //{
    //    transform.position = Vector3.MoveTowards(tran); 
    //}
}
