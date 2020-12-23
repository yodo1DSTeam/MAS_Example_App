using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GDPR : MonoBehaviour
{
    //Objects, variables
	private Text ConsoleText;
    public GameObject GDPRPopup;
    public string DevWebPage;
    

    private void Awake()
    {
       CheckStatus();
    }

    private void CheckStatus()
    {
	// Prevent show the popup each app boot
	// if the user already setup preferences
        if (PlayerPrefs.HasKey("GDPR"))
        {
            Destroy(GDPRPopup);
            return;
        }
            
    }
    void Start()
    {
	//If no previous selection, show the popup
	//Close the popup after selection
     if(PlayerPrefs.HasKey("GDPR"))
        {
            if (GDPRPopup.activeSelf)
                GDPRPopup.SetActive(false);
        }
     else
        {
            if (!GDPRPopup.activeSelf)
                GDPRPopup.SetActive(true);
        }

    }

    public void SetStatusYes()
    {
    //Save user preference for YES    
        PlayerPrefs.SetInt("GDPR", 1);
        Yodo1U3dAds.SetUserConsent(true);
        Debug.Log("User Agree with GDPR");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Agree with GDPR";

        if (GDPRPopup.activeSelf)
            GDPRPopup.SetActive(false);

       
    }

    public void SetStatusNo()
    {
    //Save user preference for NO     
        PlayerPrefs.SetInt("GDPR", 0);
        Yodo1U3dAds.SetUserConsent(false);
        Debug.Log("User Not Agree with GDPR");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Not Agree with GDPR";

        if (GDPRPopup.activeSelf)
            GDPRPopup.SetActive(false);
    }

    public void MoreInfo()
    {
	// Open a URL with more info
        Application.OpenURL(DevWebPage);
    }

    
}
