using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientocamara1 : MonoBehaviour
{
    public Transform jugador;
    public Vector3 offset;
    public float suavizado = 5f;

    void FixedUpdate()
    {
        Vector3 posicionDeseada = jugador.position + offset;
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavizado * Time.fixedDeltaTime);
    }
}