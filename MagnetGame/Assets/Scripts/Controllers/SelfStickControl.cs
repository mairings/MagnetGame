using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagnetGame.Enums;

namespace MagnetGame.Controllers
{
    public class SelfStickControl : MonoBehaviour
    {
        [SerializeField] VitesSticksEnums _stickType;
        public VitesSticksEnums StickType => _stickType;

        private void Update()
        {
           
        }
    }
}

