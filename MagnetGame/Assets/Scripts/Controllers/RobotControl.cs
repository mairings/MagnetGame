using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MagnetGame.Movement;
using MagnetGame.Managers;

namespace MagnetGame.Controllers
{
    public class RobotControl : MonoBehaviour
    {
        bool _canLookAt;
        Collider _collider;
        Animator _animator => transform.parent.GetComponent < Animator >();
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Collectible")
            {
                
                Destroy(transform.parent.GetComponent<HorizontalMove>());
                _canLookAt = true;
                _animator.SetBool("Fire", true);
                _collider = other;
                other.transform.GetChild(1).gameObject.SetActive(true);
                GameManager.Instance.EmptyTimeObject.transform.DOMoveX(1, 0.5f).OnComplete(() => {
                    other.gameObject.SetActive(false);
                    UIManager.Instance.Lose();
                });

            }
        }
        private void FixedUpdate()
        {
            if(_canLookAt && _collider != null)
            {
                transform.parent.transform.LookAt(_collider.transform);
            }

        }
    }
}


