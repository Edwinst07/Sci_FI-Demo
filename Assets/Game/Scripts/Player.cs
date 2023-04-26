using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject muzzleFlash;
    [SerializeField]
    private GameObject _hitMarketPrefab;
    private AudioSource _audioSource;
    [SerializeField]
    private int currentAnmo;
    [SerializeField]
    private int maxAnmo = 50;
    private UIManager _uiManager;
    public bool hasCoin = false;
    [SerializeField]
    private GameObject weapon;
    
    
    //[SerializeField]
    //private float gravity = 9.8f; 

    // Start is called before the first frame update
    void Start()
    {
    
        _controller = GetComponent<CharacterController>();

        _audioSource = GetComponent<AudioSource>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        currentAnmo = maxAnmo;

        _uiManager = Component.FindObjectOfType<UIManager>();

    }

    
    // Update is called once per frame
    void Update()
    {
        Movement();

        LookShoot();


        if(Input.GetKeyDown("escape")){
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    private void Movement(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        //Vector3 velocity = direction * _speed;
        //velocity.y -= gravity;
        //_controller.Move(velocity * Time.deltaTime);

        Vector3 move = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(move * _speed * Time.deltaTime);

    }

    private void LookShoot(){

        if(Input.GetMouseButton(0) && currentAnmo > 0 && weapon.activeInHierarchy){
            
            Shoot();
            _uiManager.isAmmoText();
        }else{
            muzzleFlash.SetActive(false);
            _audioSource.Stop();

            if(Input.GetKey("r") && currentAnmo == 0){ // solo se puede recargar cuando el currentAnmo este en 0
                StartCoroutine(RechargeTime());
            }

            
        }
    }

    private void Shoot(){

        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;
        currentAnmo--;
        _uiManager.UpdateAmmo(currentAnmo);
        if(Physics.Raycast(rayOrigin, out hitInfo)){
            Debug.Log("Hit: " + hitInfo.transform.name);
            GameObject hitMarker = Instantiate(_hitMarketPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            if(_audioSource.isPlaying == false){
                _audioSource.Play();
            }
            Destroy(hitMarker, 1f); // Wear Destroy without creating scripts
        }

        muzzleFlash.SetActive(true);

    }

    private IEnumerator RechargeTime(){

        yield return new WaitForSecondsRealtime(1.5f);
        currentAnmo = maxAnmo;
        _uiManager.UpdateAmmo(currentAnmo);
    }

}
