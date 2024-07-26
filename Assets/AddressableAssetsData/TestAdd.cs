using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class TestAdd : MonoBehaviour
{
    [SerializeField] string link;
    [SerializeField] AssetReference reference;
    [SerializeField] Image target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Check()
    {
        LoadSpriteAsyncWithAdd(Random.Range(1, 5));
    }

    async void LoadSpriteAsyncWithAdd(int _id)
    {
        string test = link + _id+".png";
        AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(test);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Sprite sprite = handle.Result;
            target.sprite = sprite;     

        }
        else Debug.Log("Failed to load sprite from Addressables");

        Addressables.Release(handle);
    }

    async Task LoadSpriteAsyncWithReferenceAsync()
    {
        AsyncOperationHandle<Sprite> handle = reference.LoadAssetAsync<Sprite>();

        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Sprite sprite = handle.Result;
            target.sprite = sprite;

        }
        else Debug.Log("Failed to load sprite from Addressables");

        Addressables.Release(handle);
    }
}
