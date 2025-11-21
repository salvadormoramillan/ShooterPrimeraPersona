using UnityEngine;

public class CajaVida : MonoBehaviour
{
    public Vidas scriptVidas;          
    public Transform[] posiciones;     

    void Start()
    {
        if (scriptVidas == null)
            scriptVidas = FindAnyObjectByType<Vidas>();
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Jugador"))
        {
            if (scriptVidas != null)
            {
                scriptVidas.SumarVida();
            }

           
            MoverCaja();
        }
    }

    void MoverCaja()
    {
        if (posiciones.Length == 0) return;

        int aleatorio = Random.Range(0, posiciones.Length);
        transform.position = posiciones[aleatorio].position;
    }
}
