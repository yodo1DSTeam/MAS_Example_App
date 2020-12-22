using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCPA : MonoBehaviour
{
    private Text ConsoleText;
    public GameObject CCPAPopup;
    public string DevWebPage;
    

    private void Awake()
    {
       CheckStatus();
    }

    private void CheckStatus()
    {
        if (PlayerPrefs.HasKey("CCPA"))
        {
            Destroy(CCPAPopup);
            return;
        }
            
    }
    void Start()
    {
     if(PlayerPrefs.HasKey("CCPA"))
        {
            if (CCPAPopup.activeSelf)
                CCPAPopup.SetActive(false);
        }
     else
        {
            if (!CCPAPopup.activeSelf)
                CCPAPopup.SetActive(true);
        }

    }

    public void SetStatusYes()
    {
       
        PlayerPrefs.SetInt("CCPA", 1);
        Yodo1U3dAds.SetDoNotSell(true);
        PlayerPrefs.Save();
        Debug.Log("User Agree with CCPA");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Agree with CCPA";
        Yodo1U3dAds.InitializeSdk();

        if (CCPAPopup.activeSelf)
            CCPAPopup.SetActive(false);

       
    }

    public void SetStatusNo()
    {
        
        PlayerPrefs.SetInt("CCPA", 0);
        Yodo1U3dAds.SetDoNotSell(false);
        PlayerPrefs.Save();
        Debug.Log("User Not Agree with CCPA");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Not Agree with CCPA";
        Yodo1U3dAds.InitializeSdk();

        if (CCPAPopup.activeSelf)
            CCPAPopup.SetActive(false);
    }

    public void MoreInfo()
    {
        Application.OpenURL(DevWebPage);
    }

    
}
