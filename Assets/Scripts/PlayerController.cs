using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField]
    private FPSController _fpsController;
    [SerializeField]
    private StandController _standController;
    [SerializeField]
    private Transform _playerTransform;
    [SerializeField]
    private Transform _targetTransform;

    public bool _canChangeCam = false;
    void Update()
    {
        var hitInfo = Raycast.Instance.GetRayHit();

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Handle"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _fpsController.canMove = false;
                    _fpsController.CharacterControl.enabled = false;
                    _standController.enabled = true;

                    _canChangeCam = true;
                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    _fpsController.canMove = true;
                    _fpsController.CharacterControl.enabled = true;
                    _standController.enabled = false;

                    _canChangeCam = false;
                }
            }
        }
        else
        {
            return;
        }
    }

    void FixedUpdate()
    {
        if (_canChangeCam)
        {
            transform.position = _targetTransform.position;
        }
    }
}
