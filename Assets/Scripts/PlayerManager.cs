using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private List<Player> players;
    private int currPlayer;

    public static List<Action> actions = new List<Action>();

    [SerializeField] private GameObject[] playerPlatforms;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PlaningButtonsController planningUI;

    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetZ;

    [SerializeField] private bool isOffsetAuto;

    private void Start()
    {
        players = new List<Player> { };
        InitPlayers(playerPlatforms.Length);
        FocusPlayer(0);
        GetCurrPlayer().SetBuilding();
    }

    private void InitPlayers(int count)
    {
        for(int i = 0; i < count; i++)
        {
            if (isOffsetAuto)
            {
                offsetY =
                    playerPlatforms[i].transform.localScale.y / 2
                    + transform.localScale.y / 2;
            }

            Vector3 pos = new Vector3(
                playerPlatforms[i].transform.position.x + offsetX,
                playerPlatforms[i].transform.position.y + offsetY,
                playerPlatforms[i].transform.position.z + offsetZ);

            GameObject newPlayer = Instantiate(
                playerPrefab,
                pos,
                playerPlatforms[i].transform.rotation,
                transform.parent);

            Player player = newPlayer.GetComponent<Player>();
            player.PlayerName = "Player " + (i + 1).ToString();
            players.Add(player);
        }
    }

    private void FocusPlayer(int index)
    {
        cameraController.SetTarget(players[index].transform);
        cameraController.LooKAtTarget();
    }

    public void NextPlayerOrStart()
    {
        GetCurrPlayer().EndPlanning();

        if (currPlayer < players.Count-1)
        {
            currPlayer++;
            FocusPlayer(currPlayer);
            GetCurrPlayer().SetBuilding();
            planningUI.StartPlacing();
        }
        else
        {
            foreach(Action action in actions)
            {
                action.Invoke();
            }
            actions.Clear();
            PlayGame();
            planningUI.EndPlanning();
        }
    }

    public Player GetCurrPlayer()
    {
        return players[currPlayer];
    }

    public void SetPlayerWaypointPlaceing()
    {
        GetCurrPlayer().SetWaypointPlacing();
    }

    public void PlayGame()
    {
        GameStageController.Instance.Play();
    }
}
