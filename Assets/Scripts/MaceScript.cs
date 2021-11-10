using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceScript : MonoBehaviour
{
    GameObject[] Path;
    bool takeItOnce = true;
    Vector3 PathRange;
    int DistanceCounter = 0;
    bool Backward = true;
    public GameObject character;
    public GameObject mace;
    RaycastHit2D ray;
    float speed;
    public LayerMask layermask;
    public Sprite Front;
    public Sprite Back;
    SpriteRenderer spriteRenderer;
    
    float projectileSpeed=0f;
    float projectileTargetRange;

    [SerializeField] GameObject projectile;

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        Path = new GameObject[transform.childCount];
        //character = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < Path.Length; i++)
        {
            Path[i] = transform.GetChild(0).gameObject;
            Path[i].transform.SetParent(transform.parent);

        }
    }


    void FixedUpdate()
    {
        Spotted();
        if (ray.collider.tag == "Player")
        {
            speed = 2f;
            spriteRenderer.sprite=Front;
            Fire();
        }
        else
        {
            speed = 0.5f;
            spriteRenderer.sprite = Back;
        }
        PathFinder();
    }
    void Spotted()
    {
        Vector3 raydirection = character.transform.position - mace.transform.position;
        ray = Physics2D.Raycast(mace.transform.position, raydirection,500,layermask);
        //Debug.DrawLine(mace.transform.position, ray.point, Color.magenta);
        
    }
   void Fire()
    {
        projectileSpeed += Time.deltaTime;
        if (projectileSpeed > Random.Range(1f, 3f))
        {
            Instantiate(projectile, mace.transform.position, Quaternion.identity);
            projectileSpeed = 0;
        }
    }
    void PathFinder()
    {
        if (takeItOnce)
        {
            PathRange = (Path[DistanceCounter].transform.position - mace.transform.position).normalized;
            takeItOnce = false;
        }
        float pathdistance = Vector3.Distance(mace.transform.position, Path[DistanceCounter].transform.position);
        mace.transform.position += PathRange * Time.deltaTime * speed;
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
    public Vector2 getDirection()
    {
        return (character.transform.position - mace.transform.position).normalized;
    }


    
}
