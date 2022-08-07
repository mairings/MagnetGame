using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace MagnetGame.Controllers
{
    public class ButtonControl : MonoBehaviour
    {
        Sequence seq;
        [SerializeField] Transform _roomChar;
        private void OnCollisionEnter(Collision collision)
        {
           
            seq = DOTween.Sequence();
            if (collision.collider.tag == "Barrel")
            {
                switch (SceneManager.GetActiveScene().buildIndex)
                {
                    case 6:
                        GetComponent<CapsuleCollider>().enabled = false;
                        seq.Append(transform.DOLocalMoveY(0.68f, 0.3f))
                            .OnStepComplete(() => { _roomChar.DOLocalMoveY(-5.29f, 1f); });
                        break;
                    case 7:
                        GetComponent<CapsuleCollider>().enabled = false;
                        print("level 7deyiz");
                        seq.Append(transform.DOLocalMoveY(0.68f, 0.3f))
                            .OnStepComplete(() => { _roomChar.DOLocalMoveY(-5.29f, 1f); });
                        break;
                }

                    
            }
        }
    }
}

