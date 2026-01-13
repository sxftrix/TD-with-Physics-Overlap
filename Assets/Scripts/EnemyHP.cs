using UnityEngine;

public class EnemyHP : MonoBehaviour
{
   public int hp = 2;
   
   public void Damage(int damage)
   {
    hp -= damage;

    if(hp <= 0)
    {
        Destroy(gameObject);
    }
   }
}
