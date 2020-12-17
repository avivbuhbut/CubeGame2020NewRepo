﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMousePos : MonoBehaviour
{

    public Transform Light;
    public float depth = 10.0f;
    void update()
    {
        FollowMousePosition();
    }

    void FollowMousePosition()
    {
        var mousePos = Input.mousePosition;
        var wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y,depth)); //you need a new vector3 because of the variables it takes XYZ Z= depth
       // transform.position = wantedPos;
        Light.transform.position = Input.mousePosition;
    }
}
