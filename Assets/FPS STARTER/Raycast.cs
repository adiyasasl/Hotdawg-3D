using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public static Raycast Instance;
    public float distance;
    private bool isHit = false;
    public string[] interactableTag;
    RaycastHit hit;

    public LayerMask _layer;
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, _layer))
        {
            if (hit.collider)
            {
                for (int i = 0; i < interactableTag.Length; i++)
                {
                    if (hit.collider.tag == interactableTag[i])
                    {
                        isHit = true;
                    }
                }
            }
        }
        else
        {
            isHit = false;
        }

        if (isHit)
        {
            var interact = hit.collider.GetComponent<InteractObject>();

            if (interact != null)
                interact.SetInteract();
            else
                return;
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distance, Color.red);
    }

    public RaycastHit GetRayHit()
    {
        return hit;
    }

    public string GetTagString()
    {
        return hit.transform.tag;
    }

    public bool GetBoolHit()
    {
        return isHit;
    }
}
