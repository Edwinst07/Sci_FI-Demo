using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private const int V = 1;
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private Image inventory;
    [SerializeField]
    private Button textUIManager;

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {}

    public void UpdateAmmo(int count){

        ammoText.text = "Ammo: " + count;
    }

    public void collectedCoin(){
        inventory.gameObject.SetActive(true);
    }

    public void ChangeCoin(){
        inventory.gameObject.SetActive(false);
    }

    public void isAmmoText(){
        ammoText.gameObject.SetActive(true);
    }

    public void TextUIManager(int opc, bool active){

        if(active){
            textUIManager.gameObject.SetActive(true);

            switch(opc){
                case 1:
                textUIManager.GetComponentInChildren<Text>().text = "Collect coin press E";
                break;
                case 2:
                textUIManager.GetComponentInChildren<Text>().text = "Buy a weapon press B";
                break;
                case 3:
                textUIManager.GetComponentInChildren<Text>().text = "You have no money";
                break;
                default:
                Debug.Log("option in TextUIManager invalid !!...");
                break;
            }

        }else if (!active){
            textUIManager.gameObject.SetActive(false);
        }

    }

}
