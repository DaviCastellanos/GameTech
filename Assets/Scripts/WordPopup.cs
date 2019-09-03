using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordPopup : MonoBehaviour
{
    [SerializeField]
    private Text wordTitle;
    [SerializeField]
    private Button closeButton;

    private Action closingPopup;

    public void DisplayPopup(string word, Action resumeVideo = null)
    {
        closeButton.onClick.AddListener(ClosePopup);
        wordTitle.text = word;
        gameObject.SetActive(true);

        if (resumeVideo != null)
        {
            closingPopup = resumeVideo;
        }
    }

    void ClosePopup()
    {
        gameObject.SetActive(false);

        if (closingPopup != null)
            closingPopup();
    }
}
