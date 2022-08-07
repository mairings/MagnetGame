using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagnetGame.Controllers
{
    public class MagnetPoint : MonoBehaviour
    {
        public float ForceFactor = 200f;

        List<Rigidbody> rgBalls = new List<Rigidbody>();
        Transform magnetPoint;
        public static MagnetPoint Instance { get; private set; }
        public bool CanChangePole;

        private void Awake()
        {
            if (Instance == null) Instance = this; 
        }

        private void Start()
        {
            CanChangePole = true;
            magnetPoint = GetComponent<Transform>();
        }
        private void FixedUpdate()
        {
            if (CanChangePole)
            {
                foreach (Rigidbody rgbBal in rgBalls)
                {
                    rgbBal.AddForce((magnetPoint.position - rgbBal.position) * ForceFactor * Time.fixedDeltaTime);
                }
            }
            else
            {
                foreach (Rigidbody rgbBal in rgBalls)
                {
                    rgbBal.AddExplosionForce(10f, magnetPoint.position, 20f );
                }
            }
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Collectible" || other.tag == "Barrel")
            {
                rgBalls.Add(other.GetComponent<Rigidbody>());
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Collectible" || other.tag == "Barrel")
            {
                rgBalls.Remove(other.GetComponent<Rigidbody>());
            }
        }
    }
}


