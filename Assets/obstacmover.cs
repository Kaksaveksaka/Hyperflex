using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacmover : MonoBehaviour
{
    public float speed;
    int x;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector2(ScreenManager.SM.getScreenWidth()/11.5f, 1);

        x = Random.Range(1, 6);

        Randomcolor();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime*speed;
        if (transform.position.y <= -40)
            Destroy(this.gameObject);
      //  if (movement.isDead)
            //speed = 0;
    }
    void Randomcolor()
    {

        switch (x)
        {
            case 1:
                this.transform.GetChild(1).GetComponent<Renderer>().material.color = new Color32(0,51,255,255);
                this.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color32(0,51,255,255);
                break;
            case 2:
                this.transform.GetChild(1).GetComponent<Renderer>().material.color = new Color32(255,0,153,255);
                this.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color32(255,0,153,255);
                break;
            case 3:
                this.transform.GetChild(1).GetComponent<Renderer>().material.color = new Color32(0,255,255,255);
                this.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color32(0,255,255,255);
                break;
            case 4:
                this.transform.GetChild(1).GetComponent<Renderer>().material.color = new Color32(255,102,0,255);
                this.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color32(255,102,0,255);
                break;
            case 5:
                this.transform.GetChild(1).GetComponent<Renderer>().material.color = new Color32(0,255,102,255);
                this.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color32(0,255,102,255);
                break;

        }
    }
}
