using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugControls : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private GameObject controls;
    [SerializeField]
    private GameObject X;

    private void Awake()
    {
        button.onClick.AddListener(Click);
    }

    private void Click()
    {
        controls.SetActive(!controls.activeInHierarchy);
        X.SetActive(!X.activeInHierarchy);
    }
}