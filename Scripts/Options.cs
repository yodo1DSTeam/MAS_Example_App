using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public GameObject OptionsCanvas;
    private Text ConsoleText;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void Modify()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("User Preferences Deleted, Waiting for setup new preferences.");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Preferences Deleted \n Waiting for setup new preferences.";
        OptionsCanvas.SetActive(true);
    }

    public void COPPAYES()
    {
        PlayerPrefs.SetInt("COPPA", 1);
        Yodo1U3dAds.SetTagForUnderAgeOfConsent(true);
        Debug.Log("User Agree with COPPA");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Agree with COPPA";
             
    }
    public void COPPANO()
    {
        PlayerPrefs.SetInt("COPPA", 0);
        Yodo1U3dAds.SetTagForUnderAgeOfConsent(false);
        Debug.Log("User Not Agree with COPPA");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Not Agree with COPPA";
    }

    public void GDPRYES()
    {

        PlayerPrefs.SetInt("GDPR", 1);
        Yodo1U3dAds.SetUserConsent(true);
        Debug.Log("User Agree with GDPR");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Agree with GDPR";
              
    }
    public void GDPRNO()
    {
        PlayerPrefs.SetInt("GDPR", 0);
        Yodo1U3dAds.SetUserConsent(false);
        Debug.Log("User Not Agree with GDPR");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Not Agree with GDPR";

    }

    public void CCPAYES()
    {

        PlayerPrefs.SetInt("CCPA", 1);
        Yodo1U3dAds.SetDoNotSell(true);
        Debug.Log("User Agree with CCPA");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Agree with CCPA";

    }

    public void CCPANO()
    {

        PlayerPrefs.SetInt("CCPA", 0);
        Yodo1U3dAds.SetDoNotSell(false);
        Debug.Log("User Not Agree with CCPA");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Not Agree with CCPA";

    }

    public void Save()
    {

        PlayerPrefs.Save();
        SceneManager.LoadScene("First");

        Debug.Log("New Preferences Saved");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "New Preferences Saved \n Please restart the app for use the new configuration";
       
    }




}
