using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class x : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadGiroCamara = 2.0f;
    public float fuerzaSalto = 5.0f;
    private bool enSuelo;

    private float rotacionX = 0;

    void Update()
    {
        // Movimiento del objeto
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical) * velocidadMovimiento * Time.deltaTime;
        transform.Translate(movimiento);

        // Giro de la cámara
        float giroHorizontal = Input.GetAxis("Mouse X") * velocidadGiroCamara;
        rotacionX -= Input.GetAxis("Mouse Y") * velocidadGiroCamara;
        rotacionX = Mathf.Clamp(rotacionX, -90, 90);

        transform.Rotate(Vector3.up * giroHorizontal);
        Camera.main.transform.localRotation = Quaternion.Euler(rotacionX, 0, 0);

        // Salto
        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            enSuelo = false;
        }
    }

    // Detectar si el personaje está en el suelo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
}
