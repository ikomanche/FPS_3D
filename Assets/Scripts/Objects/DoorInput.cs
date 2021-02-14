using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorInput : MonoBehaviour
{
    [SerializeField] InputField _inputField;
    [SerializeField] GameObject _door;
    [SerializeField] GameObject _player;
      

    public void DoorHandler(string password)
    {
        if(password == "Kevin12" || password == "kevin12")
        {
            _door.GetComponent<Animator>().Play("DoorOpen");
            gameObject.SetActive(false);
        }
    }

    public void TextInput()
    {
        DoorHandler(_inputField.text);        
    }

}
