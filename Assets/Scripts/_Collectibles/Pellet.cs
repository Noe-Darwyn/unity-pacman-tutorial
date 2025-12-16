using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Pellet : MonoBehaviour
{
    public int points = 10;
    public MonoBehaviour collector;

    protected virtual void Eat()
    {
        GameManager.Instance.PelletEaten(this, collector);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        collector = other.GetComponent<MonoBehaviour>();
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman") ) {
            Eat();
            
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Ghost") ) {
            Eat();
        }

    }

}
