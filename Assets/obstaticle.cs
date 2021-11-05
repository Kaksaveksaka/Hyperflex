using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaticle : MonoBehaviour
{
    
    public GameObject LBoundary;
    public GameObject RBoundary;
    public GameObject obstat;
    
    public bool init = true;
    public float gap = 7.6f;
    public float gap2 = 4.1f;
    public float timeRemaining = 1.5f;
    float ActTime;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        y = ScreenManager.SM.getScreenWidth() / 11.5f;
        ActTime = timeRemaining;
        timeRemaining = 0;
        
        float x = Random.Range(y * gap, y* gap2);

        Instantiate(obstat, new Vector3(x, -10-4.8f, 0), transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
      
            timeRemaining -= Time.deltaTime;

        if (init && timeRemaining <= 0)
        {
            //ActTime = ActTime-.1f;
            Debug.Log(ActTime);
            timeRemaining = ActTime;
            init = false;
            InitObstat();
        }       
      
    }
    void InitObstat()
    {
        Debug.Log(y*gap2);
        Debug.Log(y* gap);
        float x = Random.Range(y  *gap, y*gap2)*10;
        x = (int)x;
        x = (float)x / 10;
        Debug.Log(x);
     
        {
          
            Instantiate(obstat, new Vector3(x, -10, 0), transform.rotation);
            init = true;
           
        }
        }
   
   
}
