using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class scoreUI : MonoBehaviour
{
    public AudioSource source;
  
    public static int x = 0;
    TextMeshProUGUI score;
    public movement kar;
    public static bool left;
    public static bool right;
  
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        
        if (!kar.mu.GetComponent<AudioSource>().enabled)
            movement.mute = true;
        else
            movement.mute = false;


        if (movement.mute)
            kar.muteit();
        if (PlayerPrefs.GetInt("bloom",0)==1)
            kar.bloomer();

        kar.pause = false;
        x = 0;
        score= this.GetComponent<TextMeshProUGUI>();
       
    }

    // Update is called once per frame
    void Update()
    {

        score.text = x.ToString();

    }
  /*  public void getinput()
    { left = true;
        source.pitch = .7f;
        source.Play();
    } 
    public void getinputr()
    { right=true;
        source.pitch = .8f;
        source.Play();
    }*/
}
