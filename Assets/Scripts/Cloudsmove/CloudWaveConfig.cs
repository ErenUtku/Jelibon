using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "CloudWaveConfig")]
public class CloudWaveConfig : ScriptableObject
{
    [SerializeField] GameObject waypoints;
    [SerializeField] GameObject CloudPic;
    public float movement=5f;
    [SerializeField] float timeBetweenSpawn=2f;
    
    public List<Transform> GetWayPoints()
    {
        var wavelocation = new List<Transform>();
        foreach (Transform child in waypoints.transform)
        {
            wavelocation.Add(child);
        }
        return wavelocation;
    }
    public GameObject getCloudPic()
    {
        return CloudPic;
    }
    public float GetMovementSpeed()
    {
        return movement;
    }
    public float gettimeBetweenSpawn()
    {
        return timeBetweenSpawn;
    }



}
