using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    GameObject GiftPanel;
    
    // This function is use to shake GiftBox.
    private void OnEnable()
    {
        EventHandler.OnGiftBoxShakeAnimation += ListenerOnGiftBoxShakeAnimation;
        EventHandler.OnNextGiftColliderShake += ListenerOnNextGiftColliderShake;
        EventHandler.OnResetGiftBoxStatus += ListenerOnResetGiftBoxStatus;
    }
    private void OnDisable()
    {
        EventHandler.OnGiftBoxShakeAnimation -= ListenerOnGiftBoxShakeAnimation;
        EventHandler.OnNextGiftColliderShake += ListenerOnNextGiftColliderShake;
        EventHandler.OnResetGiftBoxStatus += ListenerOnResetGiftBoxStatus;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickOnGiftBox();
        }

    }

    private void ListenerOnResetGiftBoxStatus()
    {
        isUnlock = false;
        isShaked = false;
        previousOpen = false;
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
           
            print(" " + " " + this.id + isShaked);
            GiftShakeAnimation();
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
            while (this.isShaked ==true)
            {
                elapsedTime += Time.deltaTime;
                float strength = animationCurve.Evaluate(elapsedTime / duration);
                transform.position = startPosition + Random.insideUnitSphere * strength;
                await new WaitForSeconds(0.0f);
                
            }
            
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
                this.isShaked = false;
                EventHandler.Instance.InvokeOnNextGiftColliderShake(50);
                GiftPanel.SetActive(true);
            }
            if(id == 50)
            {
                this.isShaked = false;

                EventHandler.Instance.InvokeOnNextGiftColliderShake(200);
                GiftPanel.SetActive(true);


            }
            if (id == 200)
            {
                this.isShaked = false;

                EventHandler.Instance.InvokeOnNextGiftColliderShake(400);
                GiftPanel.SetActive(true);


            }
            if (id == 400)
            {
                this.isShaked = false;

                EventHandler.Instance.InvokeOnNextGiftColliderShake(800);
                GiftPanel.SetActive(true);

            }
            if (id == 800)
            {
                this.isShaked = false;
                GiftPanel.SetActive(true);

            }

        }
    }
    
    
}