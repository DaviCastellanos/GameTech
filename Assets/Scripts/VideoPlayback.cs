using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayback : MonoBehaviour
{
    const string DEAD_DONT_DIE = "the_dead_dont_die";

    [SerializeField]
    public AudioSource audioSource;

    [SerializeField]
    public VideoPlayer videoPlayer;

    [SerializeField]
    public Text timmer;

    [SerializeField]
    public GameObject pauseBlocker;

    private bool videoInitialized;

    private void Start()
    {
        StartCoroutine("SetVideo");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(videoPlayer.time);
        }
    }

    private void PauseVideo()
    {
        videoPlayer.Pause();
        audioSource.Pause();
        CancelInvoke("UpdateTimmer");
    }

    private void ResumeVideo()
    {
        videoPlayer.Play();
        audioSource.Play();
        InvokeRepeating("UpdateTimmer", 0, 1);
        pauseBlocker.SetActive(false);
    }

    private void UpdateTimmer()
    {
        int minutes = Mathf.FloorToInt((float)videoPlayer.time / 60F);
        int seconds = Mathf.FloorToInt((float) videoPlayer.time - minutes * 60);
        timmer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private IEnumerator SetVideo()
    {
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, DEAD_DONT_DIE + ".mp4");

        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
            yield return null;

        //rawImage.texture = videoPlayer.texture;
        //yield return new WaitForEndOfFrame();

        PlayVideo();

        pauseBlocker.SetActive(false);

        while (videoPlayer.time < 117)
        {
            yield return null;
        }

        StopVideo();
    }

    private void PlayVideo()
    {
        audioSource.Play();
        videoPlayer.Play();
        InvokeRepeating("UpdateTimmer", 0, 1);
    }

    private void StopVideo()
    {
        //detector.StopDetector();
        //chartMaker.DrawTime((int)videoPlayer.time);
        videoPlayer.Stop();
        audioSource.Stop();
        StopCoroutine(SetVideo());
        //chartMaker.drawLines();
        CancelInvoke("UpdateTimmer");
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0); 
    }

}
