using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

static public class AssetBundleDictionnary {
	
	static public Dictionary<string, AssetBundleRef> dictAssetBundleRefs;
	static AssetBundleDictionnary (){
       dictAssetBundleRefs = new Dictionary<string, AssetBundleRef>();
   }
	
	// Class with the AssetBundle reference, url and version
    public class AssetBundleRef {
       public AssetBundle assetBundle = null;
       public int version;
       public string url;
       public AssetBundleRef(string strUrlIn, int intVersionIn) {
           url = strUrlIn;
           version = intVersionIn;
       }
    };
	
	public static void addAssetRef(string url, int version){
		//create abref
		AssetBundleRef abRef = new AssetBundleRef (url, version);
		//adding to library
		dictAssetBundleRefs.Add (url + version.ToString(), abRef);
	}
	
	/// Gets the asset bundle reading the dictionnary
	/// </summary>
	/// <returns>
	/// the asset bundle or NULL
	/// </returns>
	/// <param name='url'>
	/// URL.
	/// </param>
	/// <param name='version'>
	/// Version.
	/// </param>
    public static AssetBundle getAssetBundle (string url, int version){
       string keyName = url + version.ToString();
       AssetBundleRef abRef;
       if (dictAssetBundleRefs.TryGetValue(keyName, out abRef))
			
			//dic
			//dicta
			//dictAssetBundleRefs.
				
            return abRef.assetBundle;
       else
           return null;
    }
}
