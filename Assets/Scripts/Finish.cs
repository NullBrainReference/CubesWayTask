using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private ScorePanelController scorePanel;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggerEntered");
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            EndGame(player);
        }
    }

    private void EndGame(Player player)
    {
        scorePanel.ShowScore(player);
        GameStageController.Instance.Pause();
    }
}
