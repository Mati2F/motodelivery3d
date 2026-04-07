using UnityEngine;

public class Building : MonoBehaviour
{
    public bool esObjetivo = false;
    public bool entregado = false;

    private GameObject aura;
    public Material auraMaterial;

    void Awake()
    {
        CrearAura();
    }

    void CrearAura()
    {
        GameObject cilindro = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cilindro.name = "AURA";

        cilindro.transform.SetParent(transform);
        cilindro.transform.localPosition = Vector3.zero;
        cilindro.transform.localScale = new Vector3(30f, 30f, 30f);

        Renderer rend = cilindro.GetComponent<Renderer>();
        if (auraMaterial != null)
        {
            rend.material = auraMaterial;
        }

        Collider col = cilindro.GetComponent<Collider>();
        col.isTrigger = true;
        cilindro.AddComponent<AuraDetector>().Init(this);

        aura = cilindro;
        aura.SetActive(false);
    }

    public void ActivarAura()
    {
        esObjetivo = true;

        if (aura != null)
            aura.SetActive(true);
    }
    public void DesactivarAura()
    {
        if (aura != null)
            aura.SetActive(false);

        Conteo.instance.sumarPedido();
    }
    public class AuraDetector : MonoBehaviour
    {
        private Building building;

        public void Init(Building b)
        {
            building = b;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !building.entregado && building.esObjetivo)
            {
                building.entregado = true;
                building.DesactivarAura();
            }
        }
    }
}