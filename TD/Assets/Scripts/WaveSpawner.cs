using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

	public static int EnemiesAlive = 0;

	public Wave[] waves;

	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	private float countdown = 15f;

	public Text waveCountdownText;

	public GameManager gameManager;

	private int waveIndex = 0;

	void Update()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}

		if (waveIndex == waves.Length)
		{
			gameManager.WinLevel();
			this.enabled = false;
		}

		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.0}", countdown);
	}

	IEnumerator SpawnWave()
	{
		PlayerStats.Rounds++;

		Wave wave = waves[waveIndex];

		EnemiesAlive = wave.count + wave.count2;

		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
		}
		
		for (int i = 0; i < wave.count2; i++)
		{
			SpawnEnemy(wave.enemy2);
			yield return new WaitForSeconds(1f / wave.rate2);
		}

		waveIndex++;
	}

	void SpawnEnemy(GameObject enemy)
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
	}

}































/*IEnumerator SpawnWave()
{
	PlayerStats.Rounds++;

	Wave wave = waves[waveIndex];

	for (int z = 0; z < wave.enemies.Length; z++)
	{
		for (int i = 0; i < wave.enemies[z].count; i++)
		{


			SpawnEnemy(wave.enemies[z].enemies);

			EnemiesAlive = wave.enemies[z].count;

			yield return new WaitForSeconds(1f / wave.spawnRate);

		}


		if (waveIndex == waves.Length)
		{
			Debug.Log("TODO - End Level");
			this.enabled = false;
		}
	}
	waveIndex++;
}





*/