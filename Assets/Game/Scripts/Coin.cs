using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField] 
    private Button textCoin;
    //public bool collectCoin = false;
    [SerializeField]
    private AudioClip _clip;
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start() {

        _uiManager = Component.FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update() {}

    private void OnTriggerStay(Collider other){

        if(other.CompareTag("Player")){

            textCoin.gameObject.SetActive(true);

            if(Input.GetKey("e")){

                AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
                
                if(_uiManager != null){
                    _uiManager.collectedCoin();
                }
                
                Player player = other.GetComponent<Player>();

                if(player != null){

                    player.hasCoin = true;
                }

                this.gameObject.SetActive(false);
                textCoin.gameObject.SetActive(false);
            }

        }
    }

    private void OnTriggerExit(Collider other){

        if(other.CompareTag("Player")){

            textCoin.gameObject.SetActive(false);
        }
    }

}
