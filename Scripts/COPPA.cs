using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yodo1.MAS;

public class COPPA : MonoBehaviour
{
    //Objects, variables
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
	// Prevent show the popup each app boot
	// if the user already setup preferences
        if (PlayerPrefs.HasKey("COPPA"))
        {
            
            Destroy(COPPAPopup);
            return;
        }
            
    }
    void Start()
    {
	//If no previous selection, show the popup
	//Close the popup after selection
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
     //Save user preference for YES 
        PlayerPrefs.SetInt("COPPA", 1);
        Yodo1U3dMas.SetCOPPA(true);
        Debug.Log("User Agree with COPPA");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Agree with COPPA";

        if (COPPAPopup.activeSelf)
            COPPAPopup.SetActive(false);
                    
    }

    public void SetStatusNo()
    {
	 //Save user preference for NO, and automatically
	 //set  GPDR and CCPA to NO closing the other popups 
	 //after that initialize the sdk with this privacy settings
        PlayerPrefs.SetInt("COPPA", 0);
        Yodo1U3dMas.SetCOPPA(false);

        PlayerPrefs.SetInt("GDPR", 0);
        Yodo1U3dMas.SetGDPR(true);

        PlayerPrefs.SetInt("CCPA", 0);
        Yodo1U3dMas.SetCCPA(false);

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

        Yodo1U3dMas.InitializeSdk();

        ConsoleText.text = "SDK initialized, COPPA, GDPR AND CCPA NOT AGREE";

    }

    public void MoreInfo()
    {
	// Open a URL with more info
        Application.OpenURL(DevWebPage);
    }

    
}
