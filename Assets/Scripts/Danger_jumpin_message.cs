using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Danger_jumpin_message : MonoBehaviour
{
    public PlayerController player;
    public ObstacleController obstacle;
    private VideoPlayer videoPlayer;

    private GameObject[] wins;
    private bool crushed = false;
    public bool win_on { get => crushed; set => crushed = value; }
    
    private int counter = 50;

    void Start()
    {
        videoPlayer = GameObject.Find("Screen").GetComponent<VideoPlayer>();
        wins = GameObject.FindGameObjectsWithTag("danger_window");
        foreach (GameObject win in wins)
        {
            win.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if (win_on)
        {
            if (counter > 0)
            {
                Stop();
                counter--;
            }
            else
            {
                Resume();
                counter = 50;
            }
        }
        else
        {
            foreach (GameObject win in wins)
            {
                win.SetActive(false);
            }
        }
    }

    void Stop()
    {
        foreach (GameObject win in wins)
        {
            win.SetActive(true);
        }
        videoPlayer.playbackSpeed = 0;
        player.WheelSpeed = 0.0f;
        player.turnSpeed = 0.0f;
        player.ridingSpeed = 0.0f;
        obstacle.initSpeed = 0.0f;
        obstacle.initScale = 0.0f;
    }

    void Resume()
    {
        win_on = false;
        videoPlayer.frame = videoPlayer.frame - 40;
        videoPlayer.playbackSpeed = 1;
        player.WheelSpeed = 40.0f;
        player.turnSpeed = 30.0f;
        player.ridingSpeed = 30.0f;
        obstacle.initSpeed = 0.1f;
        obstacle.initScale = 0.01f;
    }
}

