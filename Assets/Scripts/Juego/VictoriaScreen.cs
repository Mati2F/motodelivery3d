using UnityEngine;

public class VictoriaScreen : MonoBehaviour
{
    void Start()
    {
        MusicManager.instance.ReproducirSonido(
            MusicManager.instance.sonidoVictoria
        );
    }
}