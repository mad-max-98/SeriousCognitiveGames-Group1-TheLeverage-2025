using UnityEngine;

public class AnimalSelector : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Get the parent AnimalGroup and notify it
        AnimalGroup group = GetComponentInParent<AnimalGroup>();
        if (group != null)
        {
            //print("Mouse click");
            group.SelectAnimal(this.gameObject);
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                Collider2D hitCollider = Physics2D.OverlapPoint(touchPos);

                if (hitCollider != null && hitCollider.gameObject == this.gameObject)
                {
                    //print("Mouse touch");
                    AnimalGroup group = GetComponentInParent<AnimalGroup>();
                    if (group != null)
                    {
                        group.SelectAnimal(this.gameObject);
                    }
                }
            }
        }
    }
}