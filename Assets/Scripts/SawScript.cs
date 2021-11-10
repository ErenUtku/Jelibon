using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    GameObject []Path;
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
        transform.Rotate(0, 0, 10);
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


        
   /*
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.GetChild(i).transform.position,1);
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.GetChild(i).transform.position, transform.GetChild(i+1).transform.position);
        }
    }
#endif*/
}



/*#if UNITY_EDITOR
[CustomEditor(typeof(SawScript))]
[System.Serializable]

class saweditor : Editor
{
    public override void OnInspectorGUI()
    {
        SawScript sawscript = (SawScript)target;
        if (GUILayout.Button("ADD",GUILayout.MinWidth(100),GUILayout.Width(100)))
        {
            GameObject SawObject = new GameObject();
            SawObject.transform.parent = sawscript.transform;
            SawObject.transform.position = sawscript.transform.position;
            SawObject.name = sawscript.transform.childCount.ToString();

        }
    }
}
#endif*/