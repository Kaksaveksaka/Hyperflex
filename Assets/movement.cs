using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public GameObject BF, BF1, BO, BO1, M, M1, UM, UM1;
    public AudioSource kol;
    bool walhit = false;
    bool walhit1 = false;
    public GameObject BLboundary;
    public GameObject TRboundary;
    public float speed;
    public GameObject LeftPoint;
    public GameObject rightPoint;
    public static bool isDead;
    public GameObject gameUI;
    public GameObject MM;
    public GameObject butun;
    public bool pause;
    static bool restar;
    public static bool bloom;
    public static bool mute;
    public GameObject bloo;
    public GameObject mu;
    public GameObject mu1;
    bool left = false;
    bool right = false;
    float ScreenWidth;
    public AudioSource source;
    public float m=1;
    public float m1=1;
    public PlayGames pp;
    private void Awake()
    {
        pause = true;
        Time.timeScale = 0f;
        
        setboundaries();
        gameUI.SetActive(false);
          if(restar)
        { MM.SetActive(false); 
         butun.SetActive(true); }
        if (mute||PlayerPrefs.GetInt("mute",0)==1)
        {
            muteit();
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        ScreenWidth = Screen.width;
      /*  this.transform.localScale = new Vector2(ScreenManager.SM.getScreenWidth()/4.7130f ,
   ScreenManager.SM.getScreenHeight()/4.7130f );*/


        Debug.Log(bloom);
        if(PlayerPrefs.GetInt("bloom",0)==1)
        {
            bloomer();
        } 
    }
    // Update is called once per frame
    void Update()
    {
      
        if (!pause)
        {
            movelefr();

            int i = 0;
            //loop over every touch found
            
            while (i < Input.touchCount)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    if (Input.GetTouch(i).position.x > ScreenWidth / 2 && !right)
                    {
                        source.pitch = .7f;
                        source.Play();

                        right = true;

                    }
                    if (Input.GetTouch(i).position.x < ScreenWidth / 2 && !left)
                    {
                        source.pitch = .8f;
                        source.Play();
                        left = true;

                    }
                }
                ++i;
            }

            /*if (scoreUI.left || walhit)
            {
               
                Time.timeScale = 1f;
                scoreUI.left = false;
                transform.position = Vector3.Lerp(transform.position, LeftPoint.transform.position, Time.deltaTime * speed);
                walhit = true;
                walhit1 = false;

            }
            if (scoreUI.right || walhit1)
            {
                
                Time.timeScale = 1f;
                scoreUI.right = false;
                transform.position = Vector3.Lerp(transform.position, rightPoint.transform.position, Time.deltaTime * speed);
                walhit = false;
                walhit1 = true;
            }*/
        }
    }
    void setboundaries()
    { Vector3 point = new Vector3();
        point = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
        TRboundary.transform.position = point;
        point = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        BLboundary.transform.position = point;




    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        walhit = false; walhit1 = false;
        if (collision.gameObject.tag == "Obst")
        {
            kol.Play();
            if (!mu.GetComponent<AudioSource>().enabled)
            {
                mute = true;
                PlayerPrefs.SetInt("mute", 1);
            }
            else
            {
                mute = false;
                PlayerPrefs.SetInt("mute", 0);

            }


            Time.timeScale = 0f;
            if(scoreUI.x>=10)
            { pp.UnlockAchievement();


                if (scoreUI.x >= 25)
                {
                    pp.UnlockAchievement1();
                    if (scoreUI.x >= 50)
                    {
                        pp.UnlockAchievement2();

                        if (scoreUI.x >= 100)
                        {
                            pp.UnlockAchievement3();
                        }
                    }

                }
            }
            pause = true;
            if (scoreUI.x > PlayerPrefs.GetInt("HS", 0))
            {
                Debug.Log("HS is " + PlayerPrefs.GetInt("HS", 5).ToString());
                PlayerPrefs.SetInt("HS", scoreUI.x);
                pp.AddScoreToLeaderboard(scoreUI.x);
               
            }
            gameUI.SetActive(true);
            butun.transform.GetChild(0).gameObject.SetActive(false);
            butun.transform.GetChild(1).gameObject.SetActive(false);

            PlayGames.notLog = false;
        }
    }
   public void restart()
    {
        if (!mu.GetComponent<AudioSource>().enabled)
        {
            mute = true;
            PlayerPrefs.SetInt("mute", 1);
        }
        else
        {
            mute = false;
            PlayerPrefs.SetInt("mute", 0);

        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restar = true;

    }
    public void menubutton()
    {
        PlayGames.notLog = true;

        pause = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restar = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            scoreUI.x++;
            if (m < 2f)
            {
                m = m + 0.02f;
                m1 = m1 + 0.01f;
            }
        }
    }
    public void quit()
    {
        Application.Quit();
    }
    public void bloomon()
    { bloo.SetActive(true);
        PlayerPrefs.SetInt("bloom",1); //bloom on
    } public void bloomoff()
    { bloo.SetActive(false); PlayerPrefs.SetInt("bloom", 0);     //bloom off
    }
    public void muteit()
    {
        M1.SetActive(false); M.SetActive(false); UM.SetActive(true); UM1.SetActive(true);
        mu.GetComponent<AudioSource>().enabled = false;
        mu1.GetComponent<AudioSource>().enabled = false;
    }
    public void bloomer()
    {
        bloo.SetActive(true);
        BO.SetActive(false); BO1.SetActive(false); BF.SetActive(true); BF1.SetActive(true);
    }
    void movelefr()
    {
        if (left || walhit)
        {
            Time.timeScale = m;
            left = false;
            transform.position = Vector3.Lerp(transform.position, LeftPoint.transform.position, Time.deltaTime * speed/m1);
            walhit1 = false;
            walhit = true;
            
        }
        if (right || walhit1)
        {
            Time.timeScale = m;
            right = false;
            transform.position = Vector3.Lerp(transform.position, rightPoint.transform.position, Time.deltaTime * speed/m1);
            walhit = false;
            walhit1 = true;
          
        }
    }
}
