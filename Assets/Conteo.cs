using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Conteo : MonoBehaviour
{
    [SerializeField] float tiempoLimite = 80f;

    private float tiempoRestante;
    private bool juegoTerminado = false;

    public static Conteo instance;

    [SerializeField] TextMeshProUGUI conteoText;
    private int pedidosActuales;
    [SerializeField] int pedidosTotales = 3;

    void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        tiempoRestante = tiempoLimite;
        ActualizarTexto();
    }

    void Update()
    {
        if (juegoTerminado) return;

        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0f)
        {
            Debug.Log("TIEMPO TERMINADO");
            Derrota();
        }
    }

    public void sumarPedido()
    {
        if (juegoTerminado) return;

        pedidosActuales++;
        Debug.Log("Sumando pedido: " + pedidosActuales);
        ActualizarTexto();

        if (pedidosActuales >= pedidosTotales)
        {
            Victoria();
        }
    }
    void Victoria()
    {
        juegoTerminado = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MusicManager.instance.DetenerMusica();

        UnityEngine.SceneManagement.SceneManager.LoadScene("Victoria");
    }

    void Derrota()
    {
        juegoTerminado = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MusicManager.instance.DetenerMusica();

        UnityEngine.SceneManagement.SceneManager.LoadScene("Derrota");
    }

    void ActualizarTexto()
    {
        conteoText.text = "Pedidos: " + pedidosActuales + "/" + pedidosTotales;
    }
}
