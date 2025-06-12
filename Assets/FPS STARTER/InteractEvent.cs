using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractEvent : MonoBehaviour
{
    public UnityEvent interactObject;
    public UnityEvent interactQuit;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactObject.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            interactQuit.Invoke();
        }
    }
}
