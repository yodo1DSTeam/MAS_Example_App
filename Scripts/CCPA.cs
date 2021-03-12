using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yodo1.MAS;

public class CCPA : MonoBehaviour
{
    
	//Objects, variables
	private Text ConsoleText;
    public GameObject CCPAPopup;
    public string DevWebPage;
    

    private void Awake()
    {
       
	   CheckStatus();
    }

    private void CheckStatus()
    {
	// Prevent show the popup each app boot
	// if the user already setup preferences
        if (PlayerPrefs.HasKey("CCPA"))
        {
            Destroy(CCPAPopup);
            return;
        }
            
    }
    void Start()
    {
		//If no previous selection, show the popup
	//Close the popup after selection
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
       
    //Save user preference for YES 
		PlayerPrefs.SetInt("CCPA", 1);
        Yodo1U3dMas.SetCCPA(true);
        PlayerPrefs.Save();
        Debug.Log("User Agree with CCPA");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Agree with CCPA";
        Yodo1U3dMas.InitializeSdk();

        if (CCPAPopup.activeSelf)
            CCPAPopup.SetActive(false);

       
    }

    public void SetStatusNo()
    {
    //Save user preference for NO,
	//and initialize the SDK with this privacy parameters
        PlayerPrefs.SetInt("CCPA", 0);
        Yodo1U3dMas.SetCCPA(false); ;
        PlayerPrefs.Save();
        Debug.Log("User Not Agree with CCPA");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Not Agree with CCPA";
        Yodo1U3dMas.InitializeSdk();

        if (CCPAPopup.activeSelf)
            CCPAPopup.SetActive(false);
    }

    public void MoreInfo()
    {
	 // Open a URL with more info
        Application.OpenURL(DevWebPage);
    }

    
}
