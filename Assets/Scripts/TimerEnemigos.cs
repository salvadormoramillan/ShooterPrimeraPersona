using TMPro;
using UnityEngine;

public class TimerEnemigos : MonoBehaviour
{
    public float timer = 0;

    public TMP_Text textoTiempoValor;
    void Start()
    {
        timer = 0;
    }

    void Update()
    {

        timer += Time.deltaTime;
        textoTiempoValor.text = timer.ToString("f1");

    }
    public float getTimerEnemigo()
    {
        return timer;
    }

    public void ReiniciarTimer()
    {
        timer = 0f;
    }
}
