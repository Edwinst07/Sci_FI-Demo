using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharkman_Store : MonoBehaviour
{

    private UIManager _uIManager;
    [SerializeField]
    private GameObject weapon;
    [SerializeField]
    private AudioClip _clip;

    // Start is called before the first frame update
    void Start()
    {
        _uIManager = Component.FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other){

        if(other.CompareTag("Player")){
            
            _uIManager.TextUIManager(2, true);

            Player player = other.GetComponent<Player>();

            if(player != null){

                if(player.hasCoin){

                    if(Input.GetKey("b")){

                        _uIManager.ChangeCoin();
                        weapon.SetActive(true);
                        AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
                    }
                    
                }
                else{
                    _uIManager.TextUIManager(3,true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other){

        if(other.CompareTag("Player")){

            _uIManager.TextUIManager(2, false);
            _uIManager.TextUIManager(3,false);
        }
    }
}
