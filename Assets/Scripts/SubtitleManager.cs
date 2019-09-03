using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SubtitleManager : MonoBehaviour
{
    const string FILENAME = "the_dead_dont_die_subs.json";
    List<SubtitleInfo> subtitles;

    [SerializeField]
    public VideoPlayer videoPlayer;
    [SerializeField]
    private GameObject hiperWord;
    [SerializeField]
    private GameObject wordRow;
    [SerializeField]
    private WordPopup wordPopup;

    private GameObject currentRow;
    private Action resumeVideo;

    void Start()
    {
        subtitles = LoadSubs();
    }

    List<SubtitleInfo> LoadSubs()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, FILENAME);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            string[] subsarray = dataAsJson.Split('|');

            subtitles = new List<SubtitleInfo>();

            foreach (string sub in subsarray)
            {
                SubtitleInfo subtitleInfo = JsonUtility.FromJson<SubtitleInfo>(sub);
                subtitles.Add(subtitleInfo);
            }

            return subtitles;
        }
        else
        {
            Debug.LogError("Fail to load subs");
            return null;
        }
    }

    void Update()
    {
        if (subtitles.Count == 0)
            return;

        if (currentRow == null && videoPlayer.time >= subtitles[0].startTime)
        {
            BuildSub(subtitles[0].text);
        }
        else if (currentRow != null && videoPlayer.time >= subtitles[0].endTime)
        {
            DeleteSub();
            subtitles.RemoveAt(0);
        }
    }

    void BuildSub(string text)
    {
        string[] textArray = text.Split(' ');

        currentRow = Instantiate(wordRow, transform);
        foreach (string word in textArray)
        {
            GameObject newWord = Instantiate(hiperWord, currentRow.transform);

            newWord.GetComponent<HiperWord>().Init(word);
            newWord.GetComponent<HiperWord>().OnWordClicked = DisplayWordPopup;
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)currentRow.transform);
    }

    void DeleteSub()
    {
        Destroy(currentRow);
        currentRow = null;
    }

    void DisplayWordPopup(string word)
    {
        resumeVideo = ResumeVideo;
        wordPopup.DisplayPopup(word, resumeVideo);
        videoPlayer.Pause();
    }

    void ResumeVideo()
    {
        videoPlayer.Play();
    }
}
