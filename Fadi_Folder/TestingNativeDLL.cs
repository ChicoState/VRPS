using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.InteropServices;

//the extension .dll can only be used if the DLL is placed in the root directory of the project, 
//otherwise if the DLL is placed anywhere inside the asset folder or its subdirectories (ex plugins) 
//then the .dll must be removed.
public class TestingNativeDLL : MonoBehaviour {
    [DllImport("SampleCW")] 
        private static extern int add(int a, int b);
    //[DllImport("SampleC2")]
    //    private static extern void Calling(Action<int> action);

    ////pointers using safe code
    ////replace SharedAPI* with IntPtr
    //[DllImport("SampleC2")]
    //    private static extern IntPtr PtrFunction(int id);// creates a constructor and defines ID value
    //[DllImport("SampleC2")]
    //    private static extern void CleanMem(IntPtr api, IntPtr Sptr);
    //[DllImport("SampleC2")]
    // private static extern int Print(IntPtr api);
    //[DllImport("SampleC2")]
    //    private static extern IntPtr structPtr();
    //[DllImport("SampleC2")]
    //    private static extern int GetHeight(IntPtr Spt);

    //private GameObject SphereOne;
    //private Material sphereMaterial;
    Text text;
    //IntPtr SharedPTR; // C# pointer 
    //IntPtr StructurePTR;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        //Calling(Icalled);
        ////sphereMaterial = SphereOne.GetComponent<Renderer>().material;
        //SharedPTR = PtrFunction(17);
        //StructurePTR = structPtr();
    }

    private void Icalled(int value)
    {
        //text.text = value.ToString();
    }

    // Update is called once per frame
    void Update () {
        //text.text = "Hello";
        text.text = add(65, 6).ToString();
        // sphereMaterial.mainTexture= 
        //text.text = Print(SharedPTR).ToString();
        //text.text = GetHeight(StructurePTR).ToString();
    }

    //public void OnDestroy()
    //{
    //    CleanMem(SharedPTR, StructurePTR);
    //}
}

