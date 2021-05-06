using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    public int gems;
    public Upgrades upgrades;
    public GameObject ClickBullet;
    public int WinGame;
    public int level;
    public int wingames;
    //public Vector3 clickbulletposition;
    //public Camera camera;
    //public Turret turret;
    //public string enemyTag = "Enemy";
    //public Transform target;
    //private Enemy targetEnemy;


    void Start ()
    {
        GameIsOver = false;
        upgrades = FindObjectOfType<Upgrades>();
        WinGame = PlayerPrefs.GetInt("WinGame");
    }

    public void GetGems()
    {

    }

    //public void updatetarget ()
    //{
    //    GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
    //    float shortestDistance = Mathf.Infinity;
    //    GameObject nearestEnemy = null;

    //    foreach (GameObject enemy in enemies)
    //    {
    //        float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
    //        if (distanceToEnemy < shortestDistance)
    //        {
    //            shortestDistance = distanceToEnemy;
    //            nearestEnemy = enemy;
    //        }
    //    }
    //    if (nearestEnemy != null && shortestDistance <= 1000)
    //    {
    //        target = nearestEnemy.transform;
    //        targetEnemy = nearestEnemy.GetComponent<Enemy>();
    //    }
    //    else
    //    {
    //        target = null;
    //    }
    //}

    void Update()
    {
        //Vector3 mouse = Input.mousePosition;
        //Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        //RaycastHit hitt;
        //if (Physics.Raycast(castPoint, out hitt, Mathf.Infinity))
        //    updatetarget();

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray clickbulletposition = camera.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    GameObject clickbullet;

        //        if (Physics.Raycast(clickbulletposition, out hit)) { 
        //            clickbullet = Instantiate(ClickBullet, hit.point, Quaternion.identity);
        //        clickbullet.transform.position = new Vector3(clickbullet.transform.position.x, 2, clickbullet.transform.position.z);
        //        turret.UpdateTarget();
        //        Bullet bullet = clickbullet.GetComponent<Bullet>();

        //        if (bullet != null)
        //            bullet.Seek(turret.target);
        //    }
        //}

        if (GameIsOver)
            return;

       if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame ()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        if (level >= WinGame)
        {
            gems = PlayerPrefs.GetInt("Gems");
            gems += wingames;
            Debug.Log("You got one Gem!");
            Debug.Log(gems);
            PlayerPrefs.SetInt("Gems", gems);
            WinGame++;
            PlayerPrefs.SetInt("WinGame", WinGame);
        }
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
