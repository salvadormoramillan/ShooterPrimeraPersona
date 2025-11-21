using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jugador : MonoBehaviour
{
    //movimiento
    private Vector2 inputMovimiento;
    public CharacterController characterController;
    public float velocidad = 5f;
    private Vector3 MovimientoActual;

    //vista
    private Vector2 inputVista;

    //camara
    public Camera camara;
    private float VistaRangoArribaAbajo = 50f;
    private float rotacionvertical;

    //disparo
    public Transform puntoDisparo;
    public GameObject bala;
    public float fuerzaDisparo = 1500f;
    public float tasaDisparo = 0.5f;
    private float tiempoEntreDisparos = 0;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        GestionaMovimiento();
        GestionRotacion();
    }

    private void OnMove(InputValue inputValue)
    {
        inputMovimiento = inputValue.Get<Vector2>();
    }

    private void GestionaMovimiento()
    {
        Vector3 direccionMundo = CalculaDireccionMundo();
        MovimientoActual.x = direccionMundo.x;
        MovimientoActual.z = direccionMundo.z;
        characterController.Move(MovimientoActual * velocidad * Time.deltaTime);
    }
    private void OnLook(InputValue direccionRaton)
    {
        inputVista = direccionRaton.Get<Vector2>();
    }

    private void GestionRotacion()
    {
        float rotacionRatonX = inputVista.x;
        float rotacionRatonY = inputVista.y;

        AplicaRotacionHorizontal(rotacionRatonX);
        AplicaRotacionVertixal(rotacionRatonY);
    }

    private void AplicaRotacionVertixal(float rotacionRatonY)
    {
        rotacionvertical = Mathf.Clamp(rotacionvertical - rotacionRatonY, -VistaRangoArribaAbajo, VistaRangoArribaAbajo);
        camara.transform.localRotation = Quaternion.Euler(rotacionvertical, 0, 0);
    }

    private void AplicaRotacionHorizontal(float rotacionRatonX)
    {
        transform.Rotate(0, rotacionRatonX, 0);
    }
    private Vector3 CalculaDireccionMundo()
    {
        Vector3 inputDirecion = new Vector3(inputMovimiento.x, 0, inputMovimiento.y);
        Vector3 DireccionMundo = transform.TransformDirection(inputDirecion);
        return DireccionMundo.normalized;
    }

    private void OnAttack(InputValue inputValue)
    {
        if (Time.time > tiempoEntreDisparos)
        {
            GameObject nuevaBala;
            nuevaBala = Instantiate(bala, puntoDisparo.position, puntoDisparo.rotation);
            nuevaBala.transform.Rotate(90, 0, 0);
            nuevaBala.GetComponent<Rigidbody>().AddForce(puntoDisparo.forward * fuerzaDisparo);

            tiempoEntreDisparos = Time.time + tasaDisparo;
            Destroy(nuevaBala, 2);


        }
    }
}
