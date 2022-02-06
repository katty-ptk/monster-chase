﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    [HideInInspector]
    public float speed;

    private Rigidbody2D myBody;

    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();

        speed = 7f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2( speed, myBody.velocity.y );
    }

    

}   // class