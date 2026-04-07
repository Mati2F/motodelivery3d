using TMPro;
using UnityEngine;

public class Conteo : MonoBehaviour
{
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
        ActualizarTexto();
    }

    public void sumarPedido()
    {
        pedidosActuales++;
        Debug.Log("Sumando pedido: " + pedidosActuales);
        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        conteoText.text = pedidosActuales + "/" + pedidosTotales;
    }
}
