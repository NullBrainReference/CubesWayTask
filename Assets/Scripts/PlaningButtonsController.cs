using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class PlaningButtonsController : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject endPlacingButton;

    private void Start()
    {
        StartPlacing();
    }

    public void EndPlacing()
    {
        playButton.SetActive(true);
        endPlacingButton.SetActive(false);
    }

    public void StartPlacing()
    {
        playButton.SetActive(false);
        endPlacingButton.SetActive(true);
    }

    public void EndPlanning()
    {
        panel.SetActive(false);
    }

    
}
