using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COPPA : MonoBehaviour
{
    private Text ConsoleText;
    public GameObject COPPAPopup;
    GameObject GDPRPopup;
    GameObject CCPAPopup;
    public string DevWebPage;
    

    private void Awake()
    {
       CheckStatus();
    }

    private void CheckStatus()
    {
        if (PlayerPrefs.HasKey("COPPA"))
        {
            
            Destroy(COPPAPopup);
            return;
        }
            
    }
    void Start()
    {
     if(PlayerPrefs.HasKey("COPPA"))
        {
            if (COPPAPopup.activeSelf)
                COPPAPopup.SetActive(false);
        }
     else
        {
            if (!COPPAPopup.activeSelf)
                COPPAPopup.SetActive(true);
        }

    }

    public void SetStatusYes()
    {
    
        PlayerPrefs.SetInt("COPPA", 1);
        Yodo1U3dAds.SetTagForUnderAgeOfConsent(true);
        Debug.Log("User Agree with COPPA");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Agree with COPPA";

        if (COPPAPopup.activeSelf)
            COPPAPopup.SetActive(false);
                    
    }

    public void SetStatusNo()
    {
        PlayerPrefs.SetInt("COPPA", 0);
        Yodo1U3dAds.SetTagForUnderAgeOfConsent(false);
        
        PlayerPrefs.SetInt("GDPR", 0);
        Yodo1U3dAds.SetUserConsent(false);

        PlayerPrefs.SetInt("CCPA", 0);
        Yodo1U3dAds.SetDoNotSell(false);

        GameObject CCPAPopup = GetComponent<CCPA>().CCPAPopup;
        Debug.Log("User Not Agree with CCPA");
        GameObject GDPRPopup = GetComponent<GDPR>().GDPRPopup;
        Debug.Log("User Not Agree with GDPR");

        CCPAPopup.SetActive(false);
        GDPRPopup.SetActive(false);

        Debug.Log("User Not Agree with COPPA");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Not Agree with COPPA";

        if (COPPAPopup.activeSelf)
            COPPAPopup.SetActive(false);

        Yodo1U3dAds.InitializeSdk();

        ConsoleText.text = "SDK initialized, COPPA, GDPR AND CCPA NOT AGREE";

    }

    public void MoreInfo()
    {
        Application.OpenURL(DevWebPage);
    }

    
}
