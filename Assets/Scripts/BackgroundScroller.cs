using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    [SerializeField] float ScrollSpeed = 0.5f;
    Material MyMaterial;
    Vector2 offset;

    void Start()
    {
        MyMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(ScrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        MyMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
