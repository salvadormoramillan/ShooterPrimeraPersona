using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vidas : MonoBehaviour
{
    private int vidas = 2;
    public TMP_Text textoVida;
    public Transform puntoInicial;
    public GameObject jugador;
    public TimerEnemigos timerEnemigos;

    void Start()
    {
        ActualizarTextoVida();
    }

    public void QuitaVidas()
    {
        vidas--;
        ActualizarTextoVida();

        Jugador jugador = FindAnyObjectByType<Jugador>();
        jugador.characterController.enabled = false;
        jugador.transform.position = puntoInicial.position;
        jugador.characterController.enabled = true;

        DestruirTodosLosEnemigos();
        if (timerEnemigos != null)
            timerEnemigos.ReiniciarTimer();
        else
            Debug.LogWarning("No hay referencia al TimerEnemigos en Vidas");

        
        if (vidas <= 0)
        {
            Debug.Log("Game Over!");

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene("PantallaDerrota");
        }
    }
    public void SumarVida()
    {
        vidas++;
        ActualizarTextoVida();
        Debug.Log("Has ganado una vida. Total: " + vidas);
    }

    void ActualizarTextoVida()
    {
        if (textoVida != null)
        {
            textoVida.text = vidas.ToString();
        }
    }

    void DestruirTodosLosEnemigos()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        foreach (GameObject enemigo in enemigos)
        {
            Destroy(enemigo);
        }
    }
}
