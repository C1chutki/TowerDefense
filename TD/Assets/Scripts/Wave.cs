using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject enemy;
    public int count;
    public float rate;



    public GameObject enemy2;
    public int count2;
    public float rate2;



}





/* 
 using UnityEngine;

[System.Serializable]
public class Wave
{
    public float spawnRate;
    public WaveGroup[] enemies;

    [System.Serializable]
    public class WaveGroup
    {
        public GameObject enemies;
        public int count;
    }

}
 
 */