using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftPanel : MonoBehaviour
{
    [SerializeField]
    GameObject SmallGiftBox1;
    [SerializeField]
    GameObject SmallGiftBox2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void GiftBoxButtonClick()
    {
                 SmallGiftBox1.SetActive(true);
                SmallGiftBox2.SetActive(true);

                //timer
                HidePanel();
            
        
    }

    public async void HidePanel()
    {
        await new WaitForSeconds(5f);
        SmallGiftBox1.SetActive(false);
        SmallGiftBox2.SetActive(false);
        this.gameObject.SetActive(false);

    }
}
