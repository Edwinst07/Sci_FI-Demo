using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private Image inventory;

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

    public void isAmmoText(){
        ammoText.gameObject.SetActive(true);
    }

}
