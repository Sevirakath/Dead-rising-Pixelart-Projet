using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Spell : MonoBehaviour
{
    [SerializeField] StatusEffectData _data;
    
    private float _moveSpeed = 5f;

    private SphereCollider _sphereCol;

    private void Awake()
    {
        _sphereCol = GetComponent<SphereCollider>();
        _sphereCol.isTrigger = true;
        _sphereCol.radius = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * _moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy")) return;
        
        var effectable = other.GetComponent<IEffectable>();

        if (effectable != null)
        {
            effectable.ApplyEffect(_data);
        }

        Destroy(this.gameObject);
    }
}
