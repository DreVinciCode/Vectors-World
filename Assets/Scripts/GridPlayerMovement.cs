using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlayerMovement : MonoBehaviour
{
    public GameObject cube; 
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

        tileValues.Add((4, 0), (0.418f, 0.368f));
        tileValues.Add((4, 1), (0.418f, 0.245f));
        tileValues.Add((4, 2), (0.418f, 0.122f));
        tileValues.Add((4, 3), (0.418f, 0.001f));
        tileValues.Add((4, 4), (0.418f, -0.1194f));

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

        (world_x, world_z) = tileValues[(curr_x, curr_z)];
        cube.transform.localPosition = new Vector3(world_x, 0.19f, world_z);
    }

    void Update()
    {
        switch (FindKeys())
        {
            case "left":
                var test_left = curr_x - 1;
                if (tileValues.ContainsKey((test_left, curr_z)))
                {
                    curr_x--;
                    (world_x, world_z) = tileValues[(curr_x, curr_z)];
                    cube.transform.localPosition = new Vector3(world_x, 0.19f, world_z);
                }
                else
                {
                    //Debug.Log("Can't move left");
                }
                break;
            case "right":
                var test_right = curr_x + 1;
                if (tileValues.ContainsKey((test_right, curr_z)))
                {
                    curr_x++;
                    (world_x, world_z) = tileValues[(curr_x, curr_z)];
                    cube.transform.localPosition = new Vector3(world_x, 0.19f, world_z);
                }
                else
                {
                    //Debug.Log("Can't move right");
                }
                break;
            case "up":
                var test_up = curr_z - 1;
                if (tileValues.ContainsKey((curr_x, test_up)))
                {
                    curr_z--;
                    (world_x, world_z) = tileValues[(curr_x, curr_z)];
                    cube.transform.localPosition = new Vector3(world_x, 0.19f, world_z);
                }
                else
                {
                    //Debug.Log("Can't move up");
                }
                break;
            case "down":
                var test_down = curr_z + 1;
                if (tileValues.ContainsKey((curr_x, test_down)))
                {
                    curr_z++;
                    (world_x, world_z) = tileValues[(curr_x, curr_z)];
                    cube.transform.localPosition = new Vector3(world_x, 0.19f, world_z);
                }
                else
                {
                    //Debug.Log("Can't move down");
                }
                break;
        }

    }

    public string FindKeys()
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
            return "down";
        }
            return ""; 
    }
    
}
