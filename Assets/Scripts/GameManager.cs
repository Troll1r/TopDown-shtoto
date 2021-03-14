using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool ready1;
    public bool ready2;


    public GameObject Button1;
    public GameObject Button2;

    void Start()
    {
       
    }
    public void FirstPressReady()
    {
        ready1 = true;
        Button1.SetActive(false);
        

    }
    public void SecondPressReady()
    {
        ready2 = true;
        Button2.SetActive(false);
        


    }

    void Update()
    {
        print(ready1);
        print(ready2);
        if (ready1 == true && ready2 == true)
            SceneManager.LoadScene(1);
        
    }



}
