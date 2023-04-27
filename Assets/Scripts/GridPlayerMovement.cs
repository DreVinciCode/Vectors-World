using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlayerMovement : MonoBehaviour
{
    Rigidbody cube;
    //GameObject cube; 
    public Transform cam;

    public float speed = 5f;
    public float turnSmoothTime = 0.1f;
    

    Dictionary<(int, int), (float, float)> tileValues = new Dictionary<(int, int), (float, float)>();
    int curr_x = 0; 
    int curr_z = 0; 
    float world_x, world_z; 


    private void Start()
    {
        tileValues.Add((0, 0), (-0.092f, 0.368f));
        tileValues.Add((0, 1), (-0.092f, 0.245f));
        tileValues.Add((0, 2), (-0.092f, 0.122f));
        tileValues.Add((0, 3), (-0.092f, 0.001f));
        tileValues.Add((0, 4), (-0.092f, -0.1194f));

        tileValues.Add((1, 0), (0.034f, 0.368f));
        tileValues.Add((1, 1), (0.034f, 0.245f));
        tileValues.Add((1, 2), (0.034f, 0.122f));
        tileValues.Add((1, 3), (0.034f, 0.001f));
        tileValues.Add((1, 4), (0.034f, -0.1194f));

        tileValues.Add((2, 0), (0.163f, 0.368f));
        tileValues.Add((2, 1), (0.163f, 0.245f));
        tileValues.Add((2, 2), (0.163f, 0.122f));
        tileValues.Add((2, 3), (0.163f, 0.001f));
        tileValues.Add((2, 4), (0.163f, -0.1194f));

        tileValues.Add((3, 0), (0.29f, 0.368f));
        tileValues.Add((3, 1), (0.29f, 0.245f));
        tileValues.Add((3, 2), (0.29f, 0.122f));
        tileValues.Add((3, 3), (0.29f, 0.001f));
        tileValues.Add((3, 4), (0.29f, -0.1194f));

        tileValues.Add((4, 1), (0.418f, 0.368f));
        tileValues.Add((4, 2), (0.418f, 0.245f));
        tileValues.Add((4, 3), (0.418f, 0.122f));
        tileValues.Add((4, 4), (0.418f, 0.001f));
        tileValues.Add((4, 5), (0.418f, -0.1194f));

        tileValues.Add((5, 0), (0.546f, 0.368f));
        tileValues.Add((5, 1), (0.546f, 0.245f));
        tileValues.Add((5, 2), (0.546f, 0.122f));
        tileValues.Add((5, 3), (0.546f, 0.001f));
        tileValues.Add((5, 4), (0.546f, -0.1194f));

        tileValues.Add((6, 0), (0.673f, 0.368f));
        tileValues.Add((6, 1), (0.673f, 0.245f));
        tileValues.Add((6, 2), (0.673f, 0.122f));
        tileValues.Add((6, 3), (0.673f, 0.001f));
        tileValues.Add((6, 4), (0.673f, -0.1194f));

        tileValues.Add((7, 0), (0.802f, 0.368f));
        tileValues.Add((7, 1), (0.802f, 0.245f));
        tileValues.Add((7, 2), (0.802f, 0.122f));
        tileValues.Add((7, 3), (0.802f, 0.001f));
        tileValues.Add((7, 4), (0.802f, -0.1194f));

        tileValues.Add((8, 0), (0.929f, 0.368f));
        tileValues.Add((8, 1), (0.929f, 0.245f));
        tileValues.Add((8, 2), (0.929f, 0.122f));
        tileValues.Add((8, 3), (0.929f, 0.001f));
        tileValues.Add((8, 4), (0.929f, -0.1194f));

        cube = gameObject.GetComponent<Rigidbody>();
        (world_x, world_z) = tileValues[(curr_x, curr_z)];
        cube.transform.position = new Vector3(world_x, 0, world_z);
    }

    void Update()
    {
        switch (FindKeys())
        {
            case "left":
                try
                {
                    Debug.Log("curr:" + curr_x + "" + curr_z);
                    curr_x += 1;
                    (world_x, world_z) = tileValues[(curr_x,curr_z)];
                    cube.transform.position = new Vector3(world_x, 0, world_z);
                }
                catch
                {
                    Debug.Log("Can not move left"); 
                }
                break;
            case "right":
                try
                {
                    Debug.Log("curr:" + curr_x + "" + curr_z);
                    curr_x -= 1;
                    (world_x, world_z) = tileValues[(curr_x, curr_z)];
                    cube.transform.position = new Vector3(world_x, 0, world_z); 
                }
                catch
                {
                    Debug.Log("Can not move right");
                }
                break;
            case "up":
                try
                {
                    Debug.Log("curr:" + curr_x + "" + curr_z);
                    curr_z += 1;
                    (world_x, world_z) = tileValues[(curr_x, curr_z)];
                    cube.transform.position = new Vector3(world_x, 0, world_z);
                }
                catch
                {
                    Debug.Log("Can not move up");
                }
                break;
            case "down":
                try
                {
                    Debug.Log("curr:" + curr_x + "" + curr_z);
                    curr_z -= 1;
                    (world_x, world_z) = tileValues[(curr_x, curr_z)];
                    cube.transform.position = new Vector3(world_x, 0, world_z);
                }
                catch
                {
                    Debug.Log("Can not move down");
                }
                break;
        }

    }

    public string FindKeys()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Left arrow is pressed");
            return "left";
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Right arrow is pressed");
            return "right";

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up arrow is pressed");
            return "up";

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down arrow is pressed");
            return "Down";
        }
            return ""; 
    }
    
}
