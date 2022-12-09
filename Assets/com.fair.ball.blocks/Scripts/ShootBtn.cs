using UnityEngine;
using UnityEngine.EventSystems;

public class ShootBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool IsPressing { get; set; }

    private float nextFire;
    private const float fireRate = 0.15f;

    private void Update()
    {
        if(!IsPressing)
        {
            return;
        }

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Debug.Log("fire");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        IsPressing = true;
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Debug.Log("fire");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsPressing = false;
    }
}
