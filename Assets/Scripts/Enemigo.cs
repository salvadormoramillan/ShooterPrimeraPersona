using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform playerTransform;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerTransform = FindAnyObjectByType<Jugador>()?.transform;
    }

    void Update()
    {
        if (playerTransform != null)
            navMeshAgent.destination = playerTransform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            Debug.Log("Jugador tocado — pierde una vida");


            Vidas vidasJugador = FindAnyObjectByType<Vidas>();
            if (vidasJugador != null)
            {
                vidasJugador.QuitaVidas();
            }
        }
    }
}
