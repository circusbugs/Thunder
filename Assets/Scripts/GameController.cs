using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public string message;
    public PlayerMovement movement;
    public Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        MessageScreen();
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = movement.GetDirection();
    }

    private void MessageScreen ()
    {
        textBox.text = message;
    }

    private void ClickMessageScreen ()
    {
      //  textBox.SetActive(false);
    }


}
