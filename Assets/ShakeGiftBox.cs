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
    bool isUnlock = false;
    [SerializeField]
    bool isShaked = false;
    [SerializeField]
    bool previousOpen = false;
    [SerializeField]
    AnimationCurve animationCurve;
    float elapsedTime = 0f;



    
    // This function is use to shake GiftBox.
    private void OnEnable()
    {
        EventHandler.OnGiftBoxShakeAnimation += ListenerOnGiftBoxShakeAnimation;
        EventHandler.OnNextGiftColliderShake += ListenerOnNextGiftColliderShake;
    }
    private void OnDisable()
    {
        EventHandler.OnGiftBoxShakeAnimation -= ListenerOnGiftBoxShakeAnimation;
        EventHandler.OnNextGiftColliderShake += ListenerOnNextGiftColliderShake;
    }

    private void ListenerOnNextGiftColliderShake(int id)
    {
        if(id == this.id)
        {
            this.previousOpen = true;
            this.isShaked = true;

        }
           
        if ( id == this.id && this.isUnlock == true)
        {
           // this.isShaked = true;
            print(" " + " " + this.id + isShaked);
            GiftShakeAnimation();
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ClickOnGiftBox();
        }
        
    }
    public void ListenerOnGiftBoxShakeAnimation(int id)
    {
        if(this.id == id)
        {
            this.isUnlock = true;
            if(this.previousOpen == true && this.isShaked == true)
            {
                GiftShakeAnimation();
            }

        }
        if(this.id == id && this.id == 10)
        {
            this.isShaked = true;
            this.previousOpen = true;
            GiftShakeAnimation();

        }
        
       
    }
   public async void GiftShakeAnimation()
    {
        if (this.isShaked == true && previousOpen == true)
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
            isShaked = false;
        }
    }
    void ClickOnGiftBox()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);
        if(hit && hit.collider != null)
        {
            int id = hit.collider.gameObject.GetComponent<ShakeGiftBox>().id;
            if(id == 10)
            {
                EventHandler.Instance.InvokeOnNextGiftColliderShake(50);
            }
            if(id == 50)
            {
                EventHandler.Instance.InvokeOnNextGiftColliderShake(200);

            }
            if(id == 200)
            {
                EventHandler.Instance.InvokeOnNextGiftColliderShake(400);

            }
            if(id == 400)
            {
                EventHandler.Instance.InvokeOnNextGiftColliderShake(800);

            }

        }
    }
    
    
}