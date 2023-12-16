using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splashsecuence : MonoBehaviour
{
    public GameObject betaDisclaimer;
    public GameObject greensoupdev;
    public GameObject losba;
    public GameObject lbppro;
    // Start is called before the first frame update
    void Start()
    {
        betaDisclaimer.SetActive(false);
        greensoupdev.SetActive(false);
        losba.SetActive(false);
        lbppro.SetActive(false);
        Invoke("betadisc", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void exito()
    {
       
        SceneManager.LoadScene("InGame");
    }
   
    void betadisc()
    {
        betaDisclaimer.SetActive(true);
        Invoke("betadiscstop", 3);
    }
    void betadiscstop()
    {
        betaDisclaimer.SetActive(false);
        Invoke("greensoupdevo", 2);
    }
    void greensoupdevo()
    {
        greensoupdev.SetActive(true);
        losba.SetActive(true);
        Invoke("greensoupdevostop", 3);
    }
    void greensoupdevostop()
    {
        greensoupdev.SetActive(false);
        losba.SetActive(false);
        Invoke("lbppros", 3);
    }
    void lbppros()
    {
        lbppro.SetActive(true);
        Invoke("lbpprostop", 4);
    }
    void lbpprostop()
    {
        lbppro.SetActive(false);
        Invoke("exito", 2);
    }
}
