using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeHotDog : MonoBehaviour
{
    [Header("HotDog Object")]
    [SerializeField]
    private GameObject _bread;
    [SerializeField]
    private GameObject _sausage;
    [SerializeField]
    private GameObject _sauce;

    private int index = 0;
    private bool _isFinished = false;

    private void ResetHotDog()
    {
        _bread.SetActive(false);
        _sausage.SetActive(false);
        _sauce.SetActive(false);

        index = 0;
    }

    public void MakeHotdog(GameObject ingredient)
    {
        if (ingredient == _bread && index == 0)
        {
            _bread.SetActive(true);
            index++;
        }
        else if (ingredient == _sausage && index == 1)
        {
            _sausage.SetActive(true);
            index++;
        }
        else if (ingredient == _sauce && index == 2)
        {
            _sauce.SetActive(true);
            _isFinished = true;
        }
        else
        {
            Debug.Log("You're not making it in order!");
            ResetHotDog();
        }
    }

    public void GiveHotdog()
    {
        if (!_bread.activeInHierarchy)
            return;
            
        var hit = Raycast.Instance.GetRayHit();

        if (hit.transform.CompareTag("Customer"))
        {
            if (_isFinished)
                Debug.Log("You Made It!");
            else
                Debug.Log("You Meshed Up!");
        }

        ResetHotDog();
    }
}
