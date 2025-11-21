using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GeneracionEnemigos : MonoBehaviour
{

    public Transform[] PuntosInicio;
    private float tiempoEntreEnemigos = 0;
    public GameObject enemigo;
    public GameObject esqueletos;
    public Transform objetos;

    public TimerEnemigos timerEnemigos;
    public float refesrcoEnemigo = 1f;
    public float VelocidadEnemigos = 3.5f;
    public float dificultaEnemigos = 0;


    void Start()
    {
        timerEnemigos = FindAnyObjectByType<TimerEnemigos>();
        StartCoroutine("DificultadCreacionEnemigo");
    }


    void Update()
    {

        dificultaEnemigos = timerEnemigos.getTimerEnemigo();

        if (dificultaEnemigos > 0 && dificultaEnemigos < 30)
        {
            refesrcoEnemigo = 2.0f;
            VelocidadEnemigos = 3.5f;
        }

        if (dificultaEnemigos > 30 && dificultaEnemigos < 60)
        {
            refesrcoEnemigo = 1.0f;
            VelocidadEnemigos = 4.0f;
        }
        if (dificultaEnemigos > 60)
        {
            refesrcoEnemigo = 0.5f;
            VelocidadEnemigos = 4.5f;
        }

    }

    IEnumerator DificultadCreacionEnemigo()
    {
        yield return new WaitForSeconds(refesrcoEnemigo);
        CreaEnemigo();
        StartCoroutine("DificultadCreacionEnemigo");
    }
    void CreaEnemigo()
    {
        if (Time.time > tiempoEntreEnemigos)
        {
            int aleatorioPuntosInicios = Random.Range(0, 3);

           
            GameObject prefabElegido;

            if (Random.value < 0.5f)
                prefabElegido = enemigo;     
            else
                prefabElegido = esqueletos;  

            GameObject nuevoEnemigo = Instantiate(
                prefabElegido,
                PuntosInicio[aleatorioPuntosInicios].position,
                PuntosInicio[aleatorioPuntosInicios].rotation,
                objetos
            );

            NavMeshAgent agent = nuevoEnemigo.GetComponent<NavMeshAgent>();
            if (agent != null)
                agent.speed = VelocidadEnemigos;
        }
    }
}
