using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeGiftBox : MonoBehaviour
{
    [SerializeField]
    int id;
    [SerializeField]
    float duration = 1f;
    [SerializeField]
    AnimationCurve animationCurve;
    float elapsedTime = 0f;


    
    // This function is use to shake GiftBox.
    private void OnEnable()
    {
        EventHandler.OnGiftBoxShakeAnimation += ListenerOnGiftBoxShakeAnimation;
    }
    private void OnDisable()
    {
        EventHandler.OnGiftBoxShakeAnimation -= ListenerOnGiftBoxShakeAnimation;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ClickOnGiftBox();
        }
        
    }
    public async void ListenerOnGiftBoxShakeAnimation(int id)
    {
        if (id == this.id)
        {
            Vector3 startPosition = transform.position;
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float strength = animationCurve.Evaluate(elapsedTime / duration);
                transform.position = startPosition + Random.insideUnitSphere * strength;
                await new WaitForSeconds(0.0f);
                print("Gift Shake Complete");
            }
            transform.position = startPosition;
        }
    }

    void ClickOnGiftBox()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);
        if(hit && hit.collider != null)
        {
            Debug.Log("hit with " + hit.collider.gameObject.name);
        }
    }
    
    
}