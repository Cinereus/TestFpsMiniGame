using UnityEngine;

namespace Utilities.ObjectPool
{
   public class PoolObject : MonoBehaviour
   {
      private Transform _poolParent;

      public void SaveParentReference(Transform parent)
      {
         _poolParent = parent;
      }
   
      public void ReturnToPool()
      {
         transform.parent = _poolParent;
         gameObject.SetActive(false);
      }
   }
}
