using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController2D controller;
    public float speed;
    private bool Jump;
    private float Horizontal = 0f;


    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal") * speed;
        if (Input.GetButtonDown("Jump"))
            Jump = true;
    }

    private void FixedUpdate()
    {
        controller.Move(Horizontal * Time.fixedDeltaTime, Jump);
        Jump = false;
    }
}
