using UnityEngine.EventSystems;
using UnityEngine;

public class DestroyObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Ruin ruin;
    public void OnPointerClick(PointerEventData eventData)
    {
        ruin.HitHammer(this.transform.parent.gameObject);
    }
    //public void OnPointerClick2D(PointerEventData eventData)
    //{
    //    ruin.HitHammer(this.transform.parent.gameObject);
    //}

}
