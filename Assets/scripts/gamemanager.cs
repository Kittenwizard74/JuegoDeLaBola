using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public TextMeshProUGUI wintext;
    public int moneda;
    public bool win = false;

    void Update()
    {
        
        if (win == false)
        {
            wintext.text = "coins: " + moneda + "/5";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("moneda")) 
        {
            moneda++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Win") && moneda >= 5)
        {
            win = true;
            wintext.text = "you win!";
        }
    }
}
