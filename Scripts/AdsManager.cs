using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AdsManager : MonoBehaviour
{
    //Objects and variables
    public Text Coinstext;
    public Text ConsoleText;
    public GameObject CanvasDetails;
    static int coins = 0;
   
    //Bools for check ad status
    bool IsCheckingVideoStatus;
    bool IsCheckingBannerStatus;
    bool IsCheckingInterstitialStatus;

    
    // Intance of AdsManager Object
    public static AdsManager instance;
    private void Awake()
    {
            CheckInstance();

    }

    private void CheckInstance()
    {
        if (instance != null)
        {
            Destroy(CanvasDetails);
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        //Keep Objects for next scene
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(CanvasDetails);
    }

    private void Start()
    {
        // Initialize MAS SDK
        if (PlayerPrefs.HasKey("COPPA"))
        {

            bool COPPACheck = PlayerPrefs.GetInt("COPPA",0) == 1;
              
        if (COPPACheck) 
        {

            if (!Yodo1U3dAds.isInitialized)
            {
                Yodo1U3dAds.InitializeSdk();
                Debug.Log("SDK initialized, COPPA AGREE");

                ConsoleText.text = "SDK initialized, COPPA AGREE";
             
                Yodo1U3dAds.SetLogEnable(true);
      
                Coinstext.text = "Coins: " + coins.ToString();
            }
        }

       else if(!COPPACheck)
        {
            if (!Yodo1U3dAds.isInitialized)
            {
                Yodo1U3dAds.InitializeSdk();
                Debug.Log("SDK initialized, COPPA NOT AGREE");

                ConsoleText.text = "SDK initialized, COPPA NOT AGREE";

                Yodo1U3dAds.SetLogEnable(true);

                Coinstext.text = "Coins: " + coins.ToString();
            }

        }
        }

    }


    public void ShowVideoReward()
    {
        RewaredVideoEvents();
        ConsoleText.text = "Rewarded Video Ad Clicked ";

        //we check the video status
        if (!IsCheckingVideoStatus)
            StartCoroutine(CheckVideoStatus());
    }

    public void ShowBanner()
    {
        BannerEvents();
        ConsoleText.text = "Banner Ad Clicked ";
        //we check the banner status
        if (!IsCheckingBannerStatus)
            StartCoroutine(CheckBannerStatus());
    }

    public void ShowInterstitial()
    {
        InterstitialEvents();
        ConsoleText.text = "Interstitial Ad Clicked ";
        //we check interstitial status
        if (!IsCheckingInterstitialStatus)
            StartCoroutine(CheckInterstitialStatus());
    }

    //Corutine for Rewarded Video callbacks
    IEnumerator CheckVideoStatus()
    {
        IsCheckingVideoStatus = true;
        bool isReady = false;// Check if the rewarded video is ready ();
        bool isFail = false;
        int maxDelay = 1;// max waiting time;
        Debug.Log(isReady);
        int currentClock = 0;


        while (!isReady && !isFail)
        {
            isReady = Yodo1U3dAds.VideoIsReady();
            yield return new WaitForSeconds(1);
            currentClock++;
            if (currentClock >= maxDelay)
                isFail = true;
            ConsoleText.text = "Rewarded Video Not Ready";
        }

        //If no errors and we are ready then...
        if (!isFail && isReady)
        {
            Debug.Log(isReady);
            ConsoleText.text = "Rewarded Video Ready";
            Yodo1U3dAds.ShowVideo();
        }

        IsCheckingVideoStatus = false;
    }


    //Corutine for Banner callbacks
    IEnumerator CheckBannerStatus()
    {
        IsCheckingBannerStatus = true;
        bool isReady = false;// Check if the banner is ready ();
        bool isFail = false;
        int maxDelay = 1;// max waiting time;
        Debug.Log(isReady);
        int currentClock = 0;


        while (!isReady && !isFail)
        {
            isReady = Yodo1U3dAds.BannerIsReady();
            yield return new WaitForSeconds(1);
            currentClock++;
            if (currentClock >= maxDelay)
                isFail = true;
            ConsoleText.text = "Banner Ad Not Ready";
        }

        //If no errors and we are ready then...
        if (!isFail && isReady)
        {
            Debug.Log(isReady);
            Yodo1U3dAds.SetBannerAlign(Yodo1U3dConstants.BannerAdAlign.BannerAdAlignTop
            | Yodo1U3dConstants.BannerAdAlign.BannerAdAlignHorizontalCenter);
            Yodo1U3dAds.ShowBanner();
            ConsoleText.text = "Banner Ad Ready";
        }

        IsCheckingBannerStatus = false;
    }

    //Corutine for Interstitial callbacks
    IEnumerator CheckInterstitialStatus()
    {
        IsCheckingInterstitialStatus = true;
        bool isReady = false;// Check if the interstitial is ready ();
        bool isFail = false;
        int maxDelay = 1;// max waiting time;
        int currentClock = 0;


        while (!isReady && !isFail)
        {
            isReady = Yodo1U3dAds.InterstitialIsReady();
            yield return new WaitForSeconds(1);
            currentClock++;
            if (currentClock >= maxDelay)
                isFail = true;
            ConsoleText.text = "Interstitial Ad Not Ready";
        }

        //If no errors and we are ready then...
        if (!isFail && isReady)
        {
            Debug.Log(isReady);
            Yodo1U3dAds.ShowInterstitial();
            ConsoleText.text = "Interstitial Ad Ready";
        }

        IsCheckingInterstitialStatus = false;
    }

    //Function for show the events in the Scene console
    public void ShowTextInConsole(string text_)
    {
        Debug.Log(text_);
        ConsoleText.text = (text_);
    }

    // Rewarded Video Callbacks
    public void RewaredVideoEvents()
    {
     
		Yodo1U3dSDK.setRewardVideoDelegate((Yodo1U3dConstants.AdEvent adEvent, string error) =>
        {
            // Show error code in Unity Console
            Debug.Log("RewardVideoDelegate:" + adEvent + "\n" + error);

           // Check event type
            switch (adEvent)
            {
               // Click Event
                case Yodo1U3dConstants.AdEvent.AdEventClick:
                    //mostramos por consola que este video fue clickeado
                    Debug.Log("Rewarded video ad has been clicked.");
                    ShowTextInConsole("el video fue clickeado");
					ConsoleText.text = "Rewarded Video ad has been clicked.";
                                      
                break;

                //Close Event
                case Yodo1U3dConstants.AdEvent.AdEventClose:
                    Debug.Log("Rewarded video ad has been closed.");
                    ConsoleText.text = "Rewarded Video Closed";
                    break;


                // Succes Ad Event
                case Yodo1U3dConstants.AdEvent.AdEventShowSuccess:
                    Debug.Log("Rewarded video ad has shown successful.");
                    ConsoleText.text = "Rewarded Video Success";
                    break;

                //Failed Ad Event
                case Yodo1U3dConstants.AdEvent.AdEventShowFail:
                    Debug.Log("Rewarded video ad show failed, the error message:" + error);
                    ConsoleText.text = "Rewarded Video Fail";
                    break;

                // Finished Ad Event
                // 15 Coins Reward
                // Here you write your reward code
                case Yodo1U3dConstants.AdEvent.AdEventFinish:
                    Debug.Log("Rewarded video ad has been played finish, give rewards to the player.");
                    coins += 15;
					Coinstext.text = "Coins: " + coins.ToString();
                    ConsoleText.text = "Rewarded Video Showed with Succes \n Reward Received +15 Coins";
                    
                    break;
            }
        });
    }
	
	public void BannerEvents()
	{
			          					
		Yodo1U3dSDK.setBannerdDelegate((Yodo1U3dConstants.AdEvent adEvent,string error)=>
    { 
        //Show error code in Unity Console
        Debug.Log ("BannerdDelegate:" + adEvent + "\n" + error); 
        switch (adEvent) 
          { 
            //Click Event
            case Yodo1U3dConstants.AdEvent.AdEventClick: 
                Debug.Log("Banner ad has been clicked.");
                ConsoleText.text = "Banner Ad Clicked";
                break; 
            //Close Event
            case Yodo1U3dConstants.AdEvent.AdEventClose: 
                Debug.Log("Banner ad has been closed.");
                ConsoleText.text = "Banner Ad Closed";
                break; 
            // Succes Ad Event
            // 5 Coins Reward
            case Yodo1U3dConstants.AdEvent.AdEventShowSuccess: 
                Debug.Log("Banner ad has been shown successful."); 
				coins += 5;
				Coinstext.text = "Coins: " + coins.ToString();
                ConsoleText.text = "Banner Ad Showed with Suces \n Reward Received + 5 coins";
               

                break; 
            //Failed Ad Event
            case Yodo1U3dConstants.AdEvent.AdEventShowFail: 
                Debug.Log("Banner ad has been show failed, the error message:" + error);
                ConsoleText.text = "Banner Ad Failed";
                break; 
		
        }
});
				
	}
	
	
	
	public void InterstitialEvents ()
	{

		Yodo1U3dSDK.setInterstitialAdDelegate((Yodo1U3dConstants.AdEvent adEvent, string error) =>
        {
            Debug.Log("[Yodo1 Ads] InterstitialAdDelegate:" + adEvent + "\n" + error);
            switch (adEvent)
            {
                //Click Event
                case Yodo1U3dConstants.AdEvent.AdEventClick:
                    Debug.Log("[Yodo1 Ads] Interstital advertising has been clicked.");
                    ConsoleText.text = "Interstitial Ad Clicked";
                    break;
                //Close Event
                case Yodo1U3dConstants.AdEvent.AdEventClose:
                    Debug.Log("[Yodo1 Ads] Interstital advertising has been closed.");
                    ConsoleText.text = "Interstitial Ad Closed";
                    break;
                //Succes Ad Event
                //10 Coins Reward
                case Yodo1U3dConstants.AdEvent.AdEventShowSuccess:
                    Debug.Log("[Yodo1 Ads] Interstital advertising has been shown.");
                    coins += 10;
                    Coinstext.text = "Coins: " + coins.ToString();
                    ConsoleText.text = "Interstitial Ad Showed with Success \n Reward Received + 10 Coins";
                    
                    break;
                //Failed Ad Event
                case Yodo1U3dConstants.AdEvent.AdEventShowFail:
                    Debug.Log("[Yodo1 Ads] Interstital advertising show failed, the error message:" + error);
                    ConsoleText.text = "Interstitial Ad failed";
                    break;
            }

        });
    }
	
}
