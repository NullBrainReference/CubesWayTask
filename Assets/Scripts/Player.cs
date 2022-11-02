using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string playerName;

    private enum PlayerStage {Waiting, Building, WaySetting, End}
    [SerializeField] private PlayerStage stage;

    [SerializeField] private WaypointFollower waypointfollower;

    [SerializeField] private GameObject platePrefab;

    public string PlayerName 
    { 
        get { return playerName; }
        set { playerName = value; }
    }

    private void Awake()
    {
        stage = PlayerStage.Waiting;
    }

    private void Update()
    {
        if (stage == PlayerStage.Waiting) return;
        if (stage == PlayerStage.End) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                switch (stage)
                {
                    case PlayerStage.Building:
                        Build(hit);
                        break;
                    case PlayerStage.WaySetting:
                        PlaceWaypoint(hit);
                        break;
                }
            }
        }
    }

    private void Build(RaycastHit hit)
    {        
        if (hit.transform.CompareTag("BuildSurface"))
        {
            //Debug.Log("hit at" + point.x.ToString() + "|" + point.y.ToString());
            Instantiate(platePrefab, hit.point, hit.transform.rotation);
        } 
    }

    private void PlaceWaypoint(RaycastHit hit)
    {
        if (hit.transform.CompareTag("WalkableSurface"))
        {
            Debug.Log(hit.transform.gameObject.name);
            Vector3 pos = new Vector3(
                hit.point.x,
                hit.point.y,
                hit.point.z
                );
            waypointfollower.AddWaypoint(hit.point);
        }
    }

    public void SetBuilding()
    {
        stage = PlayerStage.Building;
    }

    public void SetWaypointPlacing()
    {
        stage = PlayerStage.WaySetting;
    }

    public void EndPlanning()
    {
        stage = PlayerStage.End;
    }

    public float getScore()
    {
        return waypointfollower.DeltaX;
    }
}
