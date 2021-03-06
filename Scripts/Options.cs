using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Yodo1.MAS;

public class Options : MonoBehaviour
{

	//Objects, variables 

    public GameObject OptionsCanvas;
    private Text ConsoleText;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void Modify()
    {
	//Delete all previous playerprefs 
	//for setup new privacy preferences
        PlayerPrefs.DeleteAll();
        Debug.Log("User Preferences Deleted, Waiting for setup new preferences.");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Preferences Deleted \n Waiting for setup new preferences.";
        OptionsCanvas.SetActive(true);
    }

    public void COPPAYES()
    {
	//Set COPPA to YES
        PlayerPrefs.SetInt("COPPA", 1);
        Yodo1U3dMas.SetCOPPA(true);
        Debug.Log("User Agree with COPPA");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Agree with COPPA";
             
    }
    public void COPPANO()
    {
	//Set COPPA to NO
        PlayerPrefs.SetInt("COPPA", 0);
        Yodo1U3dMas.SetCOPPA(false);
        Debug.Log("User Not Agree with COPPA");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Not Agree with COPPA";
    }

    public void GDPRYES()
    {
	//Set GDPR to YES
        PlayerPrefs.SetInt("GDPR", 1);
        Yodo1U3dMas.SetGDPR(true);
        Debug.Log("User Agree with GDPR");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Agree with GDPR";
              
    }
    public void GDPRNO()
    {
	//Set GDPR to NO
        PlayerPrefs.SetInt("GDPR", 0);
        Yodo1U3dMas.SetGDPR(false);
        Debug.Log("User Not Agree with GDPR");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Not Agree with GDPR";

    }

    public void CCPAYES()
    {
	//Set CCPA to YES
        PlayerPrefs.SetInt("CCPA", 1);
        Yodo1U3dMas.SetCCPA(true);
        Debug.Log("User Agree with CCPA");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Agree with CCPA";

    }

    public void CCPANO()
    {
	//Set CCPA to NO
        PlayerPrefs.SetInt("CCPA", 0);
        Yodo1U3dMas.SetCCPA(false);
        Debug.Log("User Not Agree with CCPA");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "User Not Agree with CCPA";

    }

    public void Save()
    {
	//Save the new privacy preferences.
        PlayerPrefs.Save();
        SceneManager.LoadScene("First");

        Debug.Log("New Preferences Saved");
        Text ConsoleText = GetComponent<AdsManager>().ConsoleText;
        ConsoleText.text = "New Preferences Saved \n Please restart the app for use the new configuration";
       
    }




}
