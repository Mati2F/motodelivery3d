using UnityEngine;

public class DerrotaScreen : MonoBehaviour
{
    void Start()
    {
        MusicManager.instance.ReproducirSonido(
            MusicManager.instance.sonidoDerrota
        );
    }
}
