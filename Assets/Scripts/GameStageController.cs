using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageController : MonoBehaviour
{
    public enum GameStage { Planning, Playing}
    private GameStage stage;

    public GameStage Stage { get { return stage; } }

    public static GameStageController Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }

    public void Play()
    {
        stage = GameStage.Playing;
    }
    public void Pause()
    {
        if(Time.timeScale > 0)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}
