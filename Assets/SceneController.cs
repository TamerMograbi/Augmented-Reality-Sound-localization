using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;



public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        QuitOnConnectionError();
    }

    // Update is called once per frame
    void Update()
    {
        if(Session.Status != SessionStatus.Tracking)
        {
            int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
            // can't do anything if ARCore isn't tracking the user's movement
            //if our status isn't tracking then we just return
            return; 
        }
        // don't want screen to sleep if ARcore has enough info and is actively tracking scene
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    

    void QuitOnConnectionError()
    {
        if(Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            StartCoroutine(CodelabUtils.ToastAndExit("Camera permission is required Dawg.", 5));
        }
        else if (Session.Status.IsError())
        {
            StartCoroutine(CodelabUtils.ToastAndExit("Can't connect to ARcore on device. fix yo shit",5));
        }
    }

}
