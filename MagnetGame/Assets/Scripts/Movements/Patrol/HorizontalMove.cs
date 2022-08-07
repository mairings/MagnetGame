using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MagnetGame.Movement
{
    public class HorizontalMove : MonoBehaviour
    {
        [SerializeField] float _moveValueX, _moveValueY, _moveValueZ;
        [SerializeField] float _rotationWalkX, _rotationWalkY, _rotationWalkZ;
        [SerializeField] float _speed;
        void Start()
        {
            HorizontalMoveObstacle();
        }

        void HorizontalMoveObstacle()
        {
            transform.localRotation = Quaternion.Euler(0, -_rotationWalkY, 0);
            //transform.DORotate(new Vector3(-_rotationWalkX, -_rotationWalkY, -_rotationWalkZ), 0.5f);

            transform.DOLocalMove(new Vector3(transform.localPosition.x - _moveValueX, transform.localPosition.y - _moveValueY, transform.localPosition.z - _moveValueZ), _speed).OnComplete(() => {

                //transform.DORotate(new Vector3(_rotationWalkX, _rotationWalkY, _rotationWalkZ), 0.5f);
                transform.localRotation = Quaternion.Euler(0, _rotationWalkY, 0);

                transform.DOLocalMove(new Vector3(transform.localPosition.x + _moveValueX, transform.localPosition.y + _moveValueY, transform.localPosition.z + _moveValueZ), _speed).OnComplete(() => { HorizontalMoveObstacle(); });

            });
  
        //        transform.DOLocalMoveX(transform.localPosition.x - _moveValueX, _speed).OnComplete(() => {
        //        transform.DORotate(new Vector3(0, 90, 0), 0.5f);

        //        transform.DOLocalMoveX(transform.localPosition.x + _moveValueX, _speed).OnComplete(() => { HorizontalMoveObstacle(); });
        //    });
        }


    }
}

