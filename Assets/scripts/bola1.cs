using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class bola1 : MonoBehaviour
{

    [SerializeField] private float force;
    [SerializeField] Rigidbody rb;

    public float velocidad = 5f;
    public float velocidadDeSalto = 50f;
    public float fuerzaDeSalto = 40;
    bool salto = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical) * velocidad * Time.deltaTime;
        transform.Translate(movimiento);

        if (salto && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * velocidadDeSalto * Time.deltaTime, ForceMode.Impulse);
            salto = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Kill"))
        {
            SceneManager.LoadScene(0);
        }

        if (collision.gameObject.CompareTag("Piso"))
        {
            salto = true;
        }
    }
}
