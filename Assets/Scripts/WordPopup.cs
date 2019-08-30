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

    public void DisplayPopup(string word)
    {
        closeButton.onClick.AddListener(ClosePopup);
        wordTitle.text = word;
        gameObject.SetActive(true);
    }

    void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}
