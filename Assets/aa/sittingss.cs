using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sittingss : MonoBehaviour
{
    public GameObject siting;

    public Slider slid;
    public Text textsistty;
    public controlPlayer2 cp; 
    // Start is called before the first frame update
    void Start()
    {
        siting.SetActive(false);
        slid.value = 80;
    }

    // Update is called once per frame
    void Update()
    {
       if(siting.activeSelf)
       {
            textsistty.text = slid.value.ToString();
            cp.MouseSensX = slid.value;
            cp.MouseSensY = slid.value;
        }    

    }
    public void clicksinting()
    {
        if(siting.activeSelf)
        {
            siting.SetActive(false);
        }
        else
        {
            siting.SetActive(true);
        }
    }
}
