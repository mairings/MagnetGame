using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MagnetGame.Managers
{
    public class GameManager : MonoBehaviour
    {
        public Joystick joystick;

        private Vector3 commandDirection;

        public GameObject player;

        private Rigidbody playerRb;

        public float playerSpeed = 20;

        public static GameManager Instance { get; private set; }

        public GameObject EmptyTimeObject;

        private void Awake()
        {
            if (Instance == null) Instance = this; 
        }
        private void Start()
        {
            Time.timeScale = 1;
            playerRb = player.GetComponent<Rigidbody>();

        }
        private void Update()
        {
            JoystickCodes();
        }
        void JoystickCodes()
        {
            if (Input.GetMouseButton(0))
            {
                var deltaPosition = joystick.Direction;

                commandDirection = deltaPosition.normalized;

                commandDirection = new Vector3(commandDirection.x, 0, commandDirection.y);

                var playerPos = player.transform.position;

                var playerlookatPosition = playerPos + commandDirection;

                Vector3 targetDir = playerlookatPosition - playerPos;

                player.transform.rotation = Quaternion.LookRotation(targetDir);

                Vector3 targetVelocity = (player.transform.forward * playerSpeed);

                targetVelocity.y = playerRb.velocity.y;

                playerRb.velocity = targetVelocity;

                float magnitude = playerRb.velocity.magnitude;
            }

            if (Input.GetMouseButtonUp(0))
            {
                playerRb.velocity = Vector3.zero;
            }
        }
    }
    
}

