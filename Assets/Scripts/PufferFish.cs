using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PufferFish : MonoBehaviour
{
    GameObject[] Path;
    bool takeItOnce = true;
    Vector3 PathRange;
    int DistanceCounter = 0;
    bool Backward = true;

    void Start()
    {
        Path = new GameObject[transform.childCount];
        for (int i = 0; i < Path.Length; i++)
        {
            Path[i] = transform.GetChild(0).gameObject;
            Path[i].transform.SetParent(transform.parent);

        }
    }
    void FixedUpdate()
    {

        PathFinder();
    }
    void PathFinder()
    {
        if (takeItOnce)
        {
            PathRange = (Path[DistanceCounter].transform.position - transform.position).normalized;
            takeItOnce = false;
        }
        float pathdistance = Vector3.Distance(transform.position, Path[DistanceCounter].transform.position);
        transform.position += PathRange * Time.deltaTime * 10;
        if (pathdistance < 0.5f)
        {
            takeItOnce = true;
            if (DistanceCounter == Path.Length - 1)
            {
                Backward = false;
            }
            else if (DistanceCounter == 0)
            {
                Backward = true;
            }

            if (Backward)
            {
                DistanceCounter++;

            }
            else
            {
                DistanceCounter--;
            }
        }
    }
}
