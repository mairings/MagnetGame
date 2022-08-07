using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MagnetGame.Managers;
using DG.Tweening;

namespace MagnetGame.Movement
{
    public class BombCode : MonoBehaviour
    {
        [SerializeField] Image _bombClock;
        [SerializeField] [Range(10, 80)] float _bombTime;
        float _bombTimePiece;
        Sequence seq;
        private void Start()
        {
            BombClockFunc();
            _bombTimePiece = 1 / _bombTime;
        }

        void BombClockFunc()
        {
            
            seq = DOTween.Sequence();
            seq.Append(
                GameManager.Instance.EmptyTimeObject.transform.DOMoveX(1, _bombTime).OnUpdate(() =>
                {
                    print(_bombTimePiece + "piece");
                    _bombClock.fillAmount += 0.04f * Time.deltaTime;
                    gameObject.GetComponent<Animator>().SetTrigger("attack01");
                    if (_bombClock.fillAmount > 0.95f)
                    {
                        seq.Complete();
                    }
                    else if (transform.position.y < -14)
                    {
                        
                        transform.parent = null;
                        transform.gameObject.SetActive(false);
                        seq.Complete();
                    }
                })

            ).OnComplete(() => {
                //transform.parent.gameObject.SetActive(false);
                GameManager.Instance.EmptyTimeObject.transform.DOMoveX(2, 1f).OnComplete(() => {
                    transform.parent.parent.parent.DORotate(new Vector3(0, 0, -70), 3);
                    transform.parent.parent.parent.DOMoveY(-50, 3);
                    transform.parent.parent.parent.DOMoveZ(100, 3);
                    transform.parent.parent.parent.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 3).OnComplete(() => 
                    transform.parent.parent.parent.parent.gameObject.SetActive(false));
                    UIManager.Instance.Lose();
                });
            });
            

        }
    }
}

