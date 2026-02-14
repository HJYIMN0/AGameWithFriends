using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : GenericSingleton<PoolingManager>
{
    public override bool ShouldDetatchFromParent() => true;
    public override bool IsDestroyedOnLoad() => false;

    // Lista per tenere traccia di tutte le pool create (opzionale, ma richiesta nel tuo snippet)
    public List<Queue<GameObject>> objectPools = new List<Queue<GameObject>>();

    /// <summary>
    /// Inizializza una Queue specifica passata per riferimento.
    /// </summary>
    /// <param name="prefab">Il prefab da istanziare.</param>
    /// <param name="queue">La variabile Queue del chiamante (usare 'ref').</param>
    /// <param name="poolSize">Dimensione iniziale.</param>
    public void InitializePool(GameObject prefab, ref Queue<GameObject> queue, int poolSize)
    {
        // Inizializziamo la queue qui. Grazie a 'ref', la modifica si riflette nel chiamante.
        queue = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            // CORREZIONE 1: Catturiamo l'istanza creata
            GameObject instance = Instantiate(prefab);

            // Opzionale: Mettiamo ordine nella gerarchia
            instance.transform.SetParent(transform);

            instance.SetActive(false);

            // CORREZIONE 2: Mettiamo in coda l'istanza, NON il prefab
            queue.Enqueue(instance);
        }

        // Aggiungiamo alla lista globale di gestione
        objectPools.Add(queue);
    }

    public GameObject GetPooledObject(GameObject prefab, Queue<GameObject> queue)
    {
        if (queue.Count > 0)
        {
            // Non serve casting (GameObject) perché la Queue è tipizzata
            GameObject pooledObj = queue.Dequeue();
            pooledObj.SetActive(true);
            return pooledObj;
        }
        else
        {
            // Pool vuota: Creiamo nuovo oggetto al volo (Auto-expand)
            GameObject newObj = Instantiate(prefab);
            newObj.transform.SetParent(transform);
            return newObj;
        }
    }

    public void ReturnToPool(GameObject obj, Queue<GameObject> queue)
    {
        obj.SetActive(false);
        queue.Enqueue(obj);
    }
}