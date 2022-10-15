using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private Rigidbody2D _rigidBody2d;
    private Queue<Vector2> _allPosSpis;
    public float Speed = 50.0f;
    public LineRenderer line;
    private bool _isDie;
    
    private InteractionScript script;
    private void Start()
    {
        _rigidBody2d = GetComponent<Rigidbody2D>(); 
        _allPosSpis = new Queue<Vector2>();
        script = GetComponent<InteractionScript>();
        line.startWidth = line.endWidth = 0.2f;

        line.positionCount = 1;
        line.SetPosition(0, _rigidBody2d.position);
    }
  
    void Update()
    {

        _isDie =script.isDie;
        if (_isDie)
        {
            Destroy(line);
            return;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 newPos = Camera.main.ScreenToWorldPoint(mousePos);
            _allPosSpis.Enqueue(newPos);

        }
        if (_allPosSpis.Count!=0)
        {
            _rigidBody2d.MovePosition(Vector2.MoveTowards(transform.position, _allPosSpis.Peek(), Speed * Time.deltaTime));
           
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, _rigidBody2d.position);

            if (Vector2.Distance(transform.position, _allPosSpis.Peek()) < 0.01)
            {             
                _allPosSpis.Dequeue();
            }
        }
    }
}
