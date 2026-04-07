using UnityEngine;

public class AddCollidersToScene : MonoBehaviour
{
    void Start()
    {
        MeshRenderer[] objects = FindObjectsOfType<MeshRenderer>();

        foreach (MeshRenderer obj in objects)
        {
            if (obj.GetComponent<Collider>() == null)
            {
                obj.gameObject.AddComponent<BoxCollider>();
            }
        }

        Debug.Log("Colliders agregados a todos los objetos");
    }
}