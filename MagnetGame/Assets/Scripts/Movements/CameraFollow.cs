using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagnetGame.Controllers
{
    public class CameraFollow : MonoBehaviour
    {
        public static CameraFollow Instance {get; private set; }
        public Transform Target;

        public float smoothedSpeed;

        private void Awake()
        {
            if(Instance==null)Instance = this;
        }

        private void Update()
        {
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, Target.position, smoothedSpeed*Time.deltaTime);
            transform.position = smoothedPosition;
        }

    }
}


