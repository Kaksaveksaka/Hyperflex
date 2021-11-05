using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
   
    TextMeshProUGUI High;
    
    // Start is called before the first frame update
    void Start()
    {
        High = this.GetComponent<TextMeshProUGUI>();



        High.text = PlayerPrefs.GetInt("HS", 0).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
