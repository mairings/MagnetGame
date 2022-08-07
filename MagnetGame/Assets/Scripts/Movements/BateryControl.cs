using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using MagnetGame.Managers;
using MagnetGame.Controllers;
using UnityEngine.SceneManagement;


namespace MagnetGame.Controllers
{
    public class BateryControl : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _batteryCapacityTMP;
        [SerializeField] TextMeshProUGUI _batteryActiveTMP;
        [SerializeField] float _batteryCapacity;
        [SerializeField] float _batteryActive;
        [SerializeField] Material _batteryMaterial;
        [SerializeField] Transform _door;
        [SerializeField] Animator _characterAnimator;
        [SerializeField] Image _fillBattery;
        float _batteryCell;
        float _batteryCollectedCount;



        private void Start()
        {
            
            _batteryCell = 1 / _batteryCapacity;
            //_batteryCapacity = 1;
            _batteryCapacityTMP.text = "/ " + _batteryCapacity.ToString();

        }
 
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Collectible" && other.name != "Bomb" && other.tag != "Barrel")
            {
                other.gameObject.SetActive(false);
                
                _batteryActive += _batteryCell;
                _batteryCollectedCount++;
                _fillBattery.fillAmount = _batteryActive;
                _batteryActiveTMP.text = _batteryCollectedCount.ToString();
                if (_batteryCollectedCount == _batteryCapacity)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);

                    _door.DOMoveY(_door.position.y - 5, 0.5f);
                    _characterAnimator.SetBool("RunB", true);
                    //_characterAnimator.SetFloat("Walk", 1);

                    _characterAnimator.gameObject.transform.GetComponent<PlayFaceAnimations>().leftEye = PlayFaceAnimations.Eyes_Expressions.Happy;
                    _characterAnimator.gameObject.transform.GetComponent<PlayFaceAnimations>().rightEye = PlayFaceAnimations.Eyes_Expressions.Happy;

                    if (SceneManager.GetActiveScene().buildIndex<=6)
                    {
                        LevelAltiveAltindakiler();
                    }
                    switch (SceneManager.GetActiveScene().buildIndex)
                    {
                        case 7:
                            Level7();
                            break;
                        case 8:
                            Level7();
                            break;
                    }
                }

                gameObject.GetComponent<MeshRenderer>().material = _batteryMaterial;
            }
        }

        void LevelAltiveAltindakiler()
        {
            _characterAnimator.transform.DOMoveZ(_characterAnimator.transform.position.z - 7, 2).OnComplete(() => {

                _characterAnimator.SetBool("Dans", true);
                CameraFollow.Instance.Target = _characterAnimator.transform;
                Camera.main.fieldOfView = 40;
                Camera.main.transform.DOLocalRotate(new Vector3(38, 0, 0), 0.4f);
                Camera.main.transform.GetChild(0).gameObject.SetActive(false);
                UIManager.Instance.Win();
                
            });
        }
    
        void Level7()
        {
            _door.GetChild(0).gameObject.SetActive(true);

            CameraFollow.Instance.Target = _door;
           _door.transform.DOMoveY(4, 0.6f).OnComplete(() =>
            {
                _door.transform.DORotate(new Vector3(90, 0, 0), 1f);
                _door.transform.DOMoveZ(18, 1).OnComplete(() => { _door.transform.DOMove(new Vector3(0, -6, 200), 20f); 
                
                });
            });
            UIManager.Instance.Win();
        }
    }
}

