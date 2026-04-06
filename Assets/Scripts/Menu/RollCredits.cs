using UnityEngine;

public class RollCredits : MonoBehaviour
{
    public float speed = 100f;
    public float stopY = 0f;

    private RectTransform rectTransform;
    private bool stopped = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        if (!stopped)
        {
            rectTransform.anchoredPosition += Vector2.up * speed * Time.deltaTime;

            if(rectTransform.anchoredPosition.y  >= stopY)
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, stopY);
                stopped = true;
            }
        }
    }
}
