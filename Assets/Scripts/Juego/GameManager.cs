using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        SeleccionarEdificios();
    }

    void SeleccionarEdificios()
    {
        Building[] edificios = FindObjectsOfType<Building>();

        Debug.Log("Edificios encontrados: " + edificios.Length);

        if (edificios.Length < 3)
        {
            Debug.LogError("No hay suficientes edificios con script Building");
            return;
        }

        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, edificios.Length);
            edificios[index].ActivarAura();
        }
    }
}