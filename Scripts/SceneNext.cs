using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneNext : MonoBehaviour
{

	AdsManager instance;
	
    private void Awake()
    {
		

	}

    void Start()
	{
		instance = AdsManager.instance;
	}

	// Update is called once per frame
	void Update()
	{

	}

	
	public void showAD(string mode)
	{
	
		
		if(instance == null)
		{
			Debug.LogError("Can't Find Ad Manager");
			return;
		}
		
		switch(mode)
		{
			case "Banner":
				instance.ShowBanner();
			break;
			
			case "Interstitial":
				instance.ShowInterstitial();
			break;
			
			case "Video":
				instance.ShowVideoReward();
			
			break;
		}
	}
	
 public void LoadGameLevel()
        { 
			SceneManager.LoadScene("Second");
        }
		
 public void Back()
		{
		Yodo1U3dAds.HideBanner();	
		SceneManager.LoadScene("First");
        }
 
	
	 
}
