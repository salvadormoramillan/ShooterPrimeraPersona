using UnityEngine;

public class Bala : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            FindAnyObjectByType<Puntos>().sumapuntos();
            Destroy(other.gameObject);
        }


        Destroy(gameObject);
    }
}
