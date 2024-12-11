using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    public SpriteRenderer characterRenderer, weaponRenderer;

    [SerializeField] GameObject tutorialPanel;

    private Player player;
    private ChangeWeapon changeWeapon;
    private Machete machete;
    private FlintlockPistol pistol;
    private GoldenMachete goldenMachete;
    private InteractableBox interactableBox;
    private bool canHandleInput = true;

    private bool isAttacking = false;
    private float lastAttackTime;
    public float attackDelay;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
        changeWeapon = GetComponentInParent<ChangeWeapon>();
        aimTransform = transform.Find("PlayerAim");

        // Default weapon
        machete = GetComponentInChildren<Machete>();
        interactableBox = GetComponentInChildren<InteractableBox>();
    }

    private void Update()
    {
        HandleAiming();
        HandleAttack();
    }

    private void HandleAiming()
    {
        Vector3 mousePosition = UtilityFunctions.GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 localScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = +1f;
        }

        aimTransform.localScale = localScale;

        if (aimTransform.eulerAngles.z > 0 && aimTransform.eulerAngles.z < 180)
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder - 1;
        }
        else
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder + 1;
        }
    }

private void HandleAttack()
{
    if (canHandleInput && !isAttacking)
    {
        // Check if tutorialPanel is not null before accessing its properties or methods
        if (tutorialPanel == null || !tutorialPanel.activeSelf)
        {
            if (Input.GetMouseButtonDown(0) && (SceneManager.GetActiveScene().name != "WhalerIsland2" && SceneManager.GetActiveScene().name != "SkullIsland2" && SceneManager.GetActiveScene().name != "SkullIsland3" && SceneManager.GetActiveScene().name != "SkullIsland4"))
            {
                isAttacking = true;
                lastAttackTime = Time.time;

                if (changeWeapon.macheteSprite.activeSelf)
                {
                    machete.DetectColliders();
                }

                if (changeWeapon.pistolSprite.activeSelf)
                {
                    pistol.Shoot();
                }
            }

            if (Input.GetKeyDown(KeyCode.F) && (SceneManager.GetActiveScene().name != "Tutorial2" && SceneManager.GetActiveScene().name != "WhalerIsland4" && SceneManager.GetActiveScene().name != "WhalerIsland6" && SceneManager.GetActiveScene().name != "GiantSkeletonDungeon" && SceneManager.GetActiveScene().name != "DemonDungeon" && SceneManager.GetActiveScene().name != "RegentsHaven2" && SceneManager.GetActiveScene().name != "RegentsHaven4"))
            {
                interactableBox.DetectColliders();
            }
        }
    }

    if (isAttacking && Time.time - lastAttackTime >= attackDelay)
    {
        isAttacking = false;
    }
}


    public void ToggleInputHandling(bool enableInput)
    {
        canHandleInput = enableInput;
    }

    public void EquipMachete()
    {
        machete = GetComponentInChildren<Machete>();
    }

    public void EquipPistol()
    {
        pistol = GetComponentInChildren<FlintlockPistol>();
    }

    public void EquipGoldenMachete()
    {
        goldenMachete = GetComponentInChildren<GoldenMachete>();
    }
}