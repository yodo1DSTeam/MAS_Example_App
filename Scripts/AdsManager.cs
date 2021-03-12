using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yodo1.MAS;


public class AdsManager : MonoBehaviour
{
    //Objects and variables
    public Text Coinstext;
    public Text ConsoleText;
    public GameObject CanvasDetails;
    static int coins = 0;
   
 
    
      private void Start()
    {
        // Initialize MAS SDK
		// Check COPPA and avoid ask the user
		// every time the app boot
        if (PlayerPrefs.HasKey("COPPA"))
        {

            bool COPPACheck = PlayerPrefs.GetInt("COPPA",0) == 1;
              
        if (COPPACheck) 
        {

                Yodo1U3dMas.InitializeSdk();
                Debug.Log("SDK initialized, COPPA AGREE");

                ConsoleText.text = "SDK initialized, COPPA AGREE";
                     
				
				//Show the events in the Scene console
                Coinstext.text = "Coins: " + coins.ToString();
            
        }

       else if(!COPPACheck)
        {
                Yodo1U3dMas.InitializeSdk();
                Debug.Log("SDK initialized, COPPA NOT AGREE");

                ConsoleText.text = "SDK initialized, COPPA NOT AGREE";

              
                Coinstext.text = "Coins: " + coins.ToString();
            
        }
       }

    }


    public void ShowVideoReward()
    {
        
        ConsoleText.text = "Rewarded Video Ad Clicked ";
        Yodo1U3dMas.ShowRewardedAd();
        RewardedVideoEvents();
        
    }

    public void ShowBanner()
    {
        
        ConsoleText.text = "Banner Ad Clicked ";
        Yodo1U3dMas.ShowBannerAd();
        BannerEvents();
                
    }

    public void ShowInterstitial()
    {
        
        ConsoleText.text = "Interstitial Ad Clicked ";
        Yodo1U3dMas.ShowInterstitialAd();
        InterstitialEvents();
                
    }

    


    //Function for show the events in the Scene console
    public void ShowTextInConsole(string text_)
    {
        Debug.Log(text_);
        ConsoleText.text = (text_);
    }

    
    public void RewardedVideoEvents()
    {
	    Yodo1U3dMas.SetRewardedAdDelegate((Yodo1U3dAdEvent adEvent, Yodo1U3dAdError error) => {
            Debug.Log("[Yodo1 Mas] RewardVideoDelegate:" + adEvent.ToString() + "\n" + error.ToString());
            switch (adEvent)
            {
                case Yodo1U3dAdEvent.AdClosed:
                    Debug.Log("[Yodo1 Mas] Reward video ad has been closed.");
                    break;
                case Yodo1U3dAdEvent.AdOpened:
                    Debug.Log("[Yodo1 Mas] Reward video ad has shown successful.");
                    break;
                case Yodo1U3dAdEvent.AdError:
                    Debug.Log("[Yodo1 Mas] Reward video ad error, " + error);
                    break;
                case Yodo1U3dAdEvent.AdReward:
                    Debug.Log("[Yodo1 Mas] Reward video ad reward, give rewards to the player.");
                    coins += 15;
                    Coinstext.text = "Coins: " + coins.ToString();
                    ConsoleText.text = "Rewarded Video Showed with Succes \n Reward Received +15 Coins";
                    break;
            }

        });

    }
	
	public void BannerEvents()
	{
	        					
        Yodo1U3dMas.SetBannerAdDelegate((Yodo1U3dAdEvent adEvent, Yodo1U3dAdError error) => {
            Debug.Log("[Yodo1 Mas] BannerdDelegate:" + adEvent.ToString() + "\n" + error.ToString());
            switch (adEvent)
            {
                case Yodo1U3dAdEvent.AdClosed:
                    Debug.Log("[Yodo1 Mas] Banner ad has been closed.");
                    break;
                case Yodo1U3dAdEvent.AdOpened:
                    Debug.Log("[Yodo1 Mas] Banner ad has been shown.");
                    coins += 5;
                    Coinstext.text = "Coins: " + coins.ToString();
                    ConsoleText.text = "Banner Ad Showed with Suces \n Reward Received + 5 coins";
                    break;
                case Yodo1U3dAdEvent.AdError:
                    Debug.Log("[Yodo1 Mas] Banner ad error, " + error.ToString());
                    break;
            }
        });

    }
	
	
	
	public void InterstitialEvents ()
	{
        Yodo1U3dMas.SetInterstitialAdDelegate((Yodo1U3dAdEvent adEvent, Yodo1U3dAdError error) => {
            Debug.Log("[Yodo1 Mas] InterstitialAdDelegate:" + adEvent.ToString() + "\n" + error.ToString());
            switch (adEvent)
            {
                case Yodo1U3dAdEvent.AdClosed:
                    Debug.Log("[Yodo1 Mas] Interstital ad has been closed.");
                    break;
                case Yodo1U3dAdEvent.AdOpened:
                    Debug.Log("[Yodo1 Mas] Interstital ad has been shown.");
                    coins += 10;
                    Coinstext.text = "Coins: " + coins.ToString();
                    ConsoleText.text = "Interstitial Ad Showed with Success \n Reward Received + 10 Coins";
                    break;
                case Yodo1U3dAdEvent.AdError:
                    Debug.Log("[Yodo1 Mas] Interstital ad error, " + error.ToString());
                    break;
            }
        });

    }
	
}
