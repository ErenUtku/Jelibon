using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedBackGround : MonoBehaviour
{
    public Sprite[] animated;
    public Image animateimage;
    public float BgSpeed = 10f;

    private void Update()
    {
        animateimage.sprite = animated[(int)(Time.time * BgSpeed) % animated.Length];
    }
}
