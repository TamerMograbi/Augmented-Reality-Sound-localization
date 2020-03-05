using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using System;

public class ArrowController : MonoBehaviour
{
    public Camera firstPersonCamera;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(.25f, .25f, .25f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = firstPersonCamera.transform.position;
        camPos.y -= 5f;
        transform.LookAt(camPos);

        Vector2 pos = new Vector2(Screen.width * .5f, Screen.height * .5f);
        Ray ray = firstPersonCamera.ScreenPointToRay(pos);
        Vector3 anchorPosition = ray.GetPoint(5f);

        transform.position = Vector3.Lerp(transform.position, anchorPosition,
              Time.smoothDeltaTime * speed);
        ProcessTouches();

    }

    void ProcessTouches()
    {
        Touch touch;
        if (Input.touchCount != 1 ||
            (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }
        //this doesn't work because lookAt(camera) is always called in update and cancels it
        transform.Rotate(0f, 45f, 0f,Space.Self);
    }
}
