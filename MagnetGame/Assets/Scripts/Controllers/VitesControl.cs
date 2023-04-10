using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagnetGame.Enums;


namespace MagnetGame.Controllers
{
    public class VitesControl : MonoBehaviour
    {
        [Header("Move Stick Vectors")]
        [Header("Change Pole Stick Vectors")]
        [SerializeField] Vector3[] _poleStickForwardBack;
        byte _poleForwardBackCount = 0;

        //Mouse
        Vector3 _pos1, _pos2;


        bool _hold;

        GameObject stick;

        [SerializeField] GameObject _magnet;
        [SerializeField] Material[] _magnetMaterials;
       
        void Update()
        {

            if (Input.GetMouseButtonDown(0))
            {
                _pos1 = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    if (hit.collider.name == "StickRight")
                    {
                        stick = hit.collider.gameObject;
                        _hold = true;
                    }
                    else if (hit.collider.name == "StickLeft")
                    {
                        stick = hit.collider.gameObject;
                        _hold = true;
                    }
                }
            }
            else if (Input.GetMouseButton(0) && _hold)
            {
                
                 _pos2 = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
                 Vector3 delta = _pos1 - _pos2;
                print("delta deðeri" + delta);
                switch (stick.name)
                {
                    case "StickLeft":
                        ControlForwardBackVector(delta);

                        break;
                    case "StickRight":
                        //ControlLeftRightVector(delta);
                        break;

                }

            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (stick == null) return;
                switch (stick.name)
                {
                    case "StickLeft":

                        break;
                        //    case "StickRight":
                        //        stick.transform.localPosition = Vector3.Lerp(stick.transform.localPosition, _forwardBack[1], 1);
                        //        _leftRightCount = 1;
                        //        _forwardBackCount = 1;
                        //        break;

                }
                _hold = false;
               
            }

            //SwitchMoveMagnet();
        }

        void ControlForwardBackVector(Vector3 delta)
        {
            if (delta.y >= 0.05f)
            {

                if (_poleForwardBackCount > 0)
                {
                    _poleForwardBackCount--;

                }
                MagnetPoint.Instance.CanChangePole = true;
                //print("leftRightCount" + _poleForwardBackCount);
                stick.transform.localPosition = Vector3.Lerp(stick.transform.localPosition, _poleStickForwardBack[_poleForwardBackCount], 1);
                //_hold = false;

            }
            else if (delta.y <= -0.05f)
            {
                //print("nesne aþaðýda");
                if (_poleForwardBackCount < 1)
                {
                    _poleForwardBackCount++;
                }
                MagnetPoint.Instance.CanChangePole = false;
                //print("leftRightCount" + _poleForwardBackCount);
                stick.transform.localPosition = Vector3.Lerp(stick.transform.localPosition, _poleStickForwardBack[_poleForwardBackCount], 1);
                //_hold = false;
            }
            ChangePoleMagnet();

        }
        void ChangePoleMagnet()
        {
            switch (_poleForwardBackCount)
            {
                case 0:
                    //print("renk degis0");
                    _magnet.GetComponent<MeshRenderer>().materials[0].color = Color.blue;
                    _magnet.GetComponent<MeshRenderer>().materials[1].color =  Color.red;
                    _magnet.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                    _magnet.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                    break;

                case 1:
                    //print("renk degis1");
                    _magnet.GetComponent<MeshRenderer>().materials[0].color = Color.blue;
                    _magnet.GetComponent<MeshRenderer>().materials[1].color = Color.blue;
                    _magnet.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                    _magnet.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                    break;
            }
        }
       
    }
}
