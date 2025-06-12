using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractObject : MonoBehaviour
{
    [SerializeField]
    private string _nameObj;
    [SerializeField]
    private UnityEvent _interactEvent = null;

    public string NameObj => _nameObj;
    public void SetInteract()
    {
        UIManager.instance.GetInfoText().text = $"{_nameObj}";
    }

    void Update()
    {
        RaycastHit hitInfo = Raycast.Instance.GetRayHit();
        if (hitInfo.collider != null)
        {
            if (Input.GetMouseButtonDown(0) && hitInfo.collider.name == name)
                _interactEvent.Invoke();
            else
                return;
        }
        
    }
}
