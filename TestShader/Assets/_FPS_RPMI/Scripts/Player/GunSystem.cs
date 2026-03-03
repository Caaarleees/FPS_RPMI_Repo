using UnityEngine;
using UnityEngine.InputSystem;

public class GunSystem : MonoBehaviour
{

    #region General Variables
    [Header("General References")]
    [SerializeField] Camera fpsCam; //Ref si disparamos desde el centro de la cam
    [SerializeField] Transform shootPoint; // Ref si queremos disparar desde la punta del cañón
    [SerializeField] LayerMask impactLayer;// Layer con la que el Raycast interactúa
    RaycastHit hit; // Almacén de la información de los objetos a los que el Raycast puede impactar

    [Header("Weapon Parameters")]
    [SerializeField] int damage = 10;//Daño del arma por bala
    [SerializeField] float range = 100f;//Distancia de disparo
    [SerializeField] float spread = 0f;//Radio de dispersión del arma
    [SerializeField] float shootingCooldown = 0.2f;//Tiempo entre disparos
    [SerializeField] float reloadTime = 1.5f;//Tiempo de recarga en segundos
    [SerializeField] bool allowButtonHold = false;//Si el disparo se ejecuta por click (false) o por mantener (true)


    [Header("Bullet Management")]
    [SerializeField] int ammoSize = 30;//Número de balas por cargador
    [SerializeField] int bulletsPerTap = 1;// Cantidad de balas disparadas por cada ejecución de disparo
    int bulletsLeft; //Cantidad de balas dentro del cargador

    [Header("Feedback References")]
    [SerializeField] GameObject impactEffect; // Ref al VFX de impacto de bala




    [Header("Dev - Gun State Bools")]
    [SerializeField] bool shooting;//Indica si estamos disparando
    [SerializeField] bool canShoot;// Indica si podemos disparar en X momento del juego
    [SerializeField] bool reloading;//Indica si estamos en proceso de recarga
    #endregion


    private void Awake()
    {
        bulletsLeft = ammoSize;//Al iniciar la partida tenemos el cargador lleno de balas
        canShoot = true;//Al iniciar la partida podemos disparar
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        //Este es el método mas importante
        //Aqui se define el disparo por raycast = utilizable con cualquier macánica


        //Almacenar la dirección de disparo y modicarla en caso de haber spread
        Vector3 direction = fpsCam.transform.forward;//Se lanza rayo hacia delante de la cámara
        //Añadir dispersión aleatoria según el valor de spread
        direction.x += Random.Range(-spread, spread);
        direction.y += Random.Range(-spread, spread);

        //DECLARACIÓN DEL RAYCAST
        //Physics.Raycast(Origen del rayo, Dirección del rayo, Almacén de información del impacto, longitud del rayo, Layer con el que interactúa el rayo)
        if (Physics.Raycast(fpsCam.transform.position, direction, out hit, range, impactLayer))
        {
            //Aquí puedo codear todos los efectos que quiero para mi interacción
            Debug.Log(hit.collider.name);
        }
    }

    #region Input Methods
    public void OnShoot(InputAction.CallbackContext context)
    {
        
    }
    public void OnReload(InputAction.CallbackContext context)
    {

    }
    #endregion


}
