using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] List<CloudWaveConfig> waveConfigs;
    public int startingWave = 0;
   IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnCloud());

        } while (true);
    }
    IEnumerator SpawnCloud()
    {
        for(int waveIndex= startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(spawnCloudsInWave(currentWave));
        }
    }
    IEnumerator spawnCloudsInWave(CloudWaveConfig waveconfig)
    {
        for (int clouds = 0; clouds < 1; clouds++)
        {
            var newCloud = Instantiate(waveconfig.getCloudPic(), waveconfig.GetWayPoints()[0].transform.position, Quaternion.identity);
            newCloud.GetComponent<CloudPathing>().SetWaveConfig(waveconfig);
            yield return new WaitForSeconds(waveconfig.gettimeBetweenSpawn());
        }

    }
}
