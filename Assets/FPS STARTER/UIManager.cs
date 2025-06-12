using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI interactText;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        var hit = Raycast.Instance.GetBoolHit();

        if (!hit)
            interactText.text = "";
    }

    public TextMeshProUGUI GetInfoText()
    {
        return interactText;
    }
}
