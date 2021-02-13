using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorInput : MonoBehaviour
{
    [SerializeField] InputField _inputField;
    [SerializeField] GameObject _door;

    private void Update()
    {
        if(_inputField.text == "abc")
        {
            _door.GetComponent<Animator>().Play("DoorOpen");
        }
    }

}
