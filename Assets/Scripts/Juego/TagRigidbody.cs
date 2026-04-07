using UnityEngine;

public class TagRigidbody : MonoBehaviour
{
    [System.Serializable]
    public class ConfiguracionTag
    {
        public string tag;
        public float masa = 1f;
        public float drag = 0f;
        public float angularDrag = 0.05f;
    }

    public ConfiguracionTag[] configuraciones;

    void Start()
    {
        foreach (ConfiguracionTag config in configuraciones)
        {
            GameObject[] objetos = GameObject.FindGameObjectsWithTag(config.tag);

            foreach (GameObject obj in objetos)
            {
                Rigidbody rb = obj.GetComponent<Rigidbody>();

                if (rb == null)
                {
                    rb = obj.AddComponent<Rigidbody>();
                }

                rb.mass = config.masa;
                rb.linearDamping = config.drag;
                rb.angularDamping = config.angularDrag;
            }
        }
    }
}