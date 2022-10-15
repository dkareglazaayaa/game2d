using UnityEngine;

public class GeneratorScript : MonoBehaviour
{

    public GameObject[] objects;

    private float height;
    private float width;

    public int _coinCount=0;

    void Start()
    {

        height = Camera.main.orthographicSize * 2-1;
        width = Camera.main.orthographicSize * Camera.main.aspect * 2-1;

        Generator(0,1,3); // spikes
        _coinCount=Generator(1,2,4); //coins
    }

    void Update()
    {

    }
    public int Generator(int index,int min,int max)
    {
        int count = 0;

        int num = Random.Range(min, max);
        count += num;

        // слева снизу
        for (int i = 0; i < num; i++)
        {
            float offsetX = Random.Range(-width / 2, -1);
            float offsetY = Random.Range(-height / 2, -1);

            Instantiate(objects[index],new Vector2(offsetX, offsetY), new Quaternion(0, 0, 0, 0));
        }
        num = Random.Range(min, max);
        count += num;
        // справа сверху
        for (int i = 0; i < num; i++)
        {
            float offsetX = Random.Range(1, width / 2-2);
            float offsetY = Random.Range(1, height / 2-2);

            Instantiate(objects[index], new Vector2(offsetX, offsetY), new Quaternion(0, 0, 0, 0));
        }
        num = Random.Range(min, max);
        count += num;
        // справа снизу
        for (int i = 0; i < num; i++)
        {
            float offsetX = Random.Range(width / 2, 1);
            float offsetY = Random.Range(-height / 2, -1);

            Instantiate(objects[index], new Vector2(offsetX, offsetY), new Quaternion(0, 0, 0, 0));
        }
        num = Random.Range(min, max);
        count += num;
        // слева сверху
        for (int i = 0; i < num; i++)
        {
            float offsetX = Random.Range(-width / 2, -1);
            float offsetY = Random.Range(height / 2, 1);

            Instantiate(objects[index], new Vector2(offsetX, offsetY), new Quaternion(0, 0, 0, 0));
        }
        return count;
    }
    
}
