using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform PlayerPos;
    public float minX;
    public float maxX;
    private Vector3 pos;

    // Update is called once per frame
    void Update()
    {
        if (PlayerPos.transform.position.x > minX && PlayerPos.transform.position.x < maxX)
        {
            pos = new Vector3(PlayerPos.transform.position.x, transform.position.y, transform.position.z);
            transform.position = pos;
        }
    }
}
