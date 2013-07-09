using System;
using UnityEngine;
using System.Collections;

public enum levelList{
	JUNGLE = 0,
	TEMPLE = 1,
	CAVERN = 2,
	PYRAMID = 3,
	TITANIC = 4
}

public class AssetLoader : MonoBehaviour {
	public string titanicURL;
	public string AssetName;
	public int version;
	
	private string url;
	
	AssetBundle titanicBundle;
	
	void Start() {
		//StartCoroutine (DownloadAndCache());
		
		//if not already loaded
		if(AssetBundleDictionnary.getAssetBundle(titanicURL, version) == null){
			LoadMap(levelList.TITANIC, () => { });
		}
	}
	
	// 0 titanic
	public void LoadMap(levelList index, System.Action callback){
		StartCoroutine(DownloadAndCache(index, callback));
	}

	IEnumerator DownloadAndCache (levelList index, System.Action callback){
		while (!Caching.ready)
			yield return null;

		// Load the AssetBundle file from Cache if it exists with the same version or download and store it in the cache
		switch (index){
		case levelList.TEMPLE:{
			break;
		}
		case levelList.TITANIC:
			url = titanicURL;
			break;
		}
		
		
		using(WWW www = WWW.LoadFromCacheOrDownload (url, version)){
			yield return www;
			if (www.error != null)
				throw new Exception("WWW download had an error:" + www.error);
			AssetBundle bundle = www.assetBundle;
			titanicBundle = bundle;
			if (AssetName == ""){
				Debug.Log("Object instanciation");
				Instantiate(bundle.mainAsset);
			}
			else{
				Instantiate(bundle.Load(AssetName));
                // Unload the AssetBundles compressed contents to conserve memory
                bundle.Unload(false);
			}
			
			callback();
		}
	}
	
	public void Unload(){
		titanicBundle.Unload(true);
	}
}