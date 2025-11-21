using TMPro;
using UnityEngine;

public class Puntos : MonoBehaviour
{
    int puntos = 0;
    public TMP_Text textoPuntosvalor;
    void Start()
    {
        puntos = 0;
        textoPuntosvalor.text = puntos.ToString();

    }

    void Update()
    {

    }

    public void sumapuntos()
    {
        puntos++;
        textoPuntosvalor.text = puntos.ToString();
    }
}
