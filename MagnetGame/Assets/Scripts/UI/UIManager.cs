using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using GoogleMobileAds.Api;

namespace MagnetGame.Managers
{
    public class UIManager : MonoBehaviour
    {
        //[SerializeField] TextMeshProUGUI _scoreTMP;
        [SerializeField] GameObject _completePanel, _failPanel;
        [SerializeField] TextMeshProUGUI _gameLevelInfo;

        InterstitialAd fulladmob;
        public static UIManager Instance { get; private set; }
        int _score { get; set; }


        private void Start()
        {
            _gameLevelInfo.text = SceneManager.GetActiveScene().buildIndex.ToString(); /*(PlayerPrefs.GetInt("Level")).ToString()*/
            RequestFull();
        }
        private void Awake()
        {
            if (Instance == null) Instance = this;
        }

        //Score arttýrýr
        public void IncreaseScore()
        {
            _score++;
            //_scoreTMP.text = _score.ToString();
        }

        public void Win()
        {
            if (_failPanel.activeSelf == true) return;
            ShowInterstitialAd();
            _completePanel.SetActive(true);
            GameManager.Instance.joystick.gameObject.SetActive(false);
        }

        public void Lose()
        {
            if (_completePanel.activeSelf == true) return;
            ShowInterstitialAd();
            _failPanel.SetActive(true);
            GameManager.Instance.joystick.gameObject.SetActive(false);

        }



        public void RestartLevel()
        {
            SceneManager.LoadSceneAsync(0);
        }

        public void RequestFull()
        {
            string idFull = "ca-app-pub-5132010851762612/8811571814";
            fulladmob = new InterstitialAd(idFull);
            AdRequest adRequest = new AdRequest.Builder().Build();
            fulladmob.LoadAd(adRequest);

        }

        public void ShowInterstitialAd()
        {
            if (fulladmob.IsLoaded())
            {
                fulladmob.Show();
                RequestFull();
            }
            else
            {
                RequestFull();
            }
        }




    }
}

