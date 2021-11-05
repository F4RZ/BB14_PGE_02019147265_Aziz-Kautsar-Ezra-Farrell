using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour
{
    public Button btnAdd;
    public Button btnUse;
    public Text txCoin;

    int coin = 0;
    string placementId = "rewardedVideo";
    private string gameId = "1678494";
    private string gameId = "1678493";

    void Start()
    {
        if (btnAdd) btnAdd.onClick.AddListener(ShowAd)
        if (btnUse) btnUse.onClick.AddListener(UseCoin);
        if (Advertisement.isSupported) 
        {
            Advertisement.Initialize(gameId, true);
        }
    }

    void Update()
    {
        if (btnAdd) btnAdd.interactable = Advertisement.IsReady(placementId);
        btnUse.interactable = (coin > 0);
    }

    void ShowAd()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;
        Advertisement.Show(placementId, options);
    }

    void HandleShowResult(ShowResult result) 
    {
        if (result == ShowResult.Finished)
        {
            Debug.Log("Video selesai - tawarkan coin ke pemain");
            coin += 50;
            txCoin.text = "Coin: " + coin;
        }

        else if (result == ShowResult.Skipped)
        {
        Debug.LogWarning("Video dilewati - tidak menawarkan coin ke pemain");
        }

        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video tidak ditampilkan");
        }
    }
    void UseCoin() 
    {
        if (coin > 0)
        {
            coin -= 10;
            txCoin.text = "Coin: " + coin;
        }
    }
}
