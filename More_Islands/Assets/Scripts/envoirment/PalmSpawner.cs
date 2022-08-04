using UnityEngine;

public class PalmSpawner : MonoBehaviour
{
    [SerializeField]private GameObject _palmPrefab;
    [SerializeField]private float _range;
    [SerializeField]private float _count;
    void Start()
    {
        spawnPalms();
    }


    private void spawnPalms()
    {
        for(int i = 0; i < _count; i++)
        {
        Vector3 randomPosition = new Vector3(Random.Range(-_range/2, _range/2), 0, Random.Range(-_range/2, _range/2));
        Quaternion randomQuaternion = new Quaternion(0, Random.Range(0f, 360f),0,100);

        float randomMoment = Random.Range(0f, 1f);
        

        if(randomMoment < 0.4f)
            Instantiate(_palmPrefab, transform.position + randomPosition,  randomQuaternion);
        }
       
    }

        private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
