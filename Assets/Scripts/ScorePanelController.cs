using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class ScorePanelController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI winnerText;

    public void ShowScore(Player winner)
    {
        transform.gameObject.SetActive(true);

        scoreText.text = "Way length = " + winner.getScore().ToString("0.0");

        winnerText.text = winner.PlayerName;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
