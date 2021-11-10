using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class CharactrerControl : MonoBehaviour
{
   
    public float speed = 10;
    public float jump = 5f;
    public Text healthtext;
    public float hp = 100;
    
    

    [Header("Level")]
    public Image BlackScreen;
    public float WaitToLoad = 4f;

    [Header("Wait")]
    [SerializeField] Sprite[] Wait;
    [Header("Run")]
    [SerializeField] Sprite[] Run;
    [Header("Jump")]
    [SerializeField] Sprite[] Jump;

    SpriteRenderer spriterenderer;

    float horizontal = 0;
    float WaitTime = 0;
    float RunTime = 0;
    float transition;
    float mainmenutime;
    public float BsSpeed = 0.04f;

    Rigidbody2D Physic;
    Rigidbody2D rb2d;

    Vector3 vec;
    Vector3 CameraLastPos;
    Vector3 CameraFirstPos;

    bool jumpOnce;
    //GameObject Camera;

    int Waitcounter = 0;
    int Runcounter = 0;

    [SerializeField] AudioClip CoinSound;
    [SerializeField] [Range(0, 1)] float CoinSoundVolume = 0.5f;

    BoxCollider2D boxcollider;

    public float hangtime=2f;
    private float hangcounter;

    private void Awake()
    {
        Time.timeScale = 1;
    }



    void Start()
    {
        //PlayerPrefs.DeleteAll();

        spriterenderer = GetComponent<SpriteRenderer>();
        Physic = GetComponent<Rigidbody2D>();
        rb2d = transform.GetComponent<Rigidbody2D>();

        boxcollider = transform.GetComponent<BoxCollider2D>();
        BlackScreen.gameObject.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex -1 > PlayerPrefs.GetInt("WhichLevel"))
        {
            PlayerPrefs.SetInt("WhichLevel", SceneManager.GetActiveScene().buildIndex - 1);
        }   
        //Camera = GameObject.FindGameObjectWithTag("MainCamera");
        //CameraFirstPos = Camera.transform.position - CameraLastPos;
        healthtext.text = "" + hp;


       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //jumpOnce = true;

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Cloud" || collision.gameObject.tag == "GiveHealth")
        {
            jumpOnce = true;
        }
        if (collision.gameObject.tag == "NonGround")
        {
            return;
        }
        
        
        if (collision.gameObject.tag == "Bouncer")
        {
            jumpOnce = false;
            JumpAnimation();
        }
        if (collision.gameObject.tag == "Slider")
        {
            jumpOnce = false;
            JumpAnimation();
        }

    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpikeAndEnemy")
        {
            healthtext.text = "" + hp;
        }

        if (collision.gameObject.tag == "Projectile")
        {
            hp-= 5;
            healthtext.text = "" + hp;

        }
       
        if (collision.gameObject.tag == "FallOff")
        {
            transform.position = new Vector2(78, 0);

        }
        if (collision.gameObject.tag == "Coins")
        {
            AudioSource.PlayClipAtPoint(CoinSound, transform.position, CoinSoundVolume);
            FindObjectOfType<LevelController>().CoinsPicked();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "FinishLine")
        {
            
            FindObjectOfType<LevelController>().LevelCompleted();
           
        }
        if (collision.gameObject.tag == "LastLine")
        {

            FindObjectOfType<LastLevel>().lastlevel();

        }
        if (collision.gameObject.tag == "GiveHealth")
        {
            hp += 10;
            healthtext.text = "" + hp;
            collision.GetComponent<EdgeCollider2D>().enabled = false;
            if (hp > 100)
            {
                hp = 100;
                healthtext.text = "" + hp;
            }
        }
        
    }

    void Update()
    {

        healthtext.text = "" + hp;

        if (CrossPlatformInputManager.GetButtonDown("Jump") && jumpOnce)
        {
            jumpOnce = false;
            Physic.velocity = new Vector2(Physic.velocity.x, jump);
        }
        if (CrossPlatformInputManager.GetButtonUp("Jump") && Physic.velocity.y > 0)
        {
            Physic.velocity = new Vector2(Physic.velocity.x, Physic.velocity.y * 0.7f);

        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpOnce)
        {
            jumpOnce = false;
            Physic.velocity = new Vector2(Physic.velocity.x, jump);
        }
        if (Input.GetKeyUp(KeyCode.Space) && Physic.velocity.y > 0)
        {
            Physic.velocity = new Vector2(Physic.velocity.x, Physic.velocity.y * 0.7f);

        }


        /*if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            if (jumpOnce)
            {
                Physic.velocity = new Vector2(Physic.velocity.x, 10);
                jumpOnce = false;
            }

        }
        if (CrossPlatformInputManager.GetButtonUp("Jump"))
        {
            if (jumpOnce)
            {
                Physic.velocity = new Vector2(Physic.velocity.x, 0);
            }

        }*/
    }

    /*private void HangCounter()
    {
        if (jumpOnce)
        {
            hangcounter = hangtime;
        }
        else
        {
            hangcounter -= Time.deltaTime;
        }
    }*/

    void FixedUpdate()
    {
        CharacterMovement();
        Animation();
        if (hp <= 0)
        {
            healthtext.enabled = false;
            transition += BsSpeed;
            BlackScreen.gameObject.SetActive(true);
            BlackScreen.color = new Color(0,0,0,transition);
            mainmenutime += Time.deltaTime;
            if (mainmenutime >1.5f)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
    /* void LateUpdate()
    {
       // CameraControll();
    }*/
    void CharacterMovement()
    {
        horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        vec = new Vector3(horizontal * speed, Physic.velocity.y, 0);
        Physic.velocity = vec;



    }

    /*void CameraControll()
    {
        CameraLastPos = CameraFirstPos + transform.position;
        Camera.transform.position = Vector3.Lerp(Camera.transform.position, CameraLastPos, 0.8f);

    
    }*/
    void Animation()
    {
      
        if (jumpOnce)
        {
            if (horizontal == 0)
            {
                WaitTime += Time.deltaTime;
                if (WaitTime > 0.05f)
                {
                    spriterenderer.sprite = Wait[Waitcounter++];
                    if (Waitcounter == Wait.Length)
                    {
                        Waitcounter = 0;
                    }
                    WaitTime = 0;
                }

            }
            else if (horizontal > 0)
            {
                RunTime += Time.deltaTime;
                if (RunTime > 0.01f)
                {
                    spriterenderer.sprite = Run[Runcounter++];
                    if (Runcounter == Run.Length)
                    {
                        Runcounter = 0;
                    }
                    RunTime = 0;
                }
                transform.localScale = new Vector3(1, 1, 1);
            }



            else if (horizontal < 0)
            {
                RunTime += Time.deltaTime;
                if (RunTime > 0.01f)
                {
                    spriterenderer.sprite = Run[Runcounter++];
                    if (Runcounter == Run.Length)
                    {
                        Runcounter = 0;
                    }
                    RunTime = 0;
                }
                transform.localScale = new Vector3(-1, 1, 1);
            }

        }
        else        
        {
            JumpAnimation();
        }
    }
    private void JumpAnimation()
    {
        if (Physic.velocity.y > 0)
        {
            spriterenderer.sprite = Jump[0];
        }
        else
        {
            spriterenderer.sprite = Jump[1];
        }
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public void getRgb(GameObject Character)
    {
       GetComponent<Rigidbody2D>();
    }
   
   



}
