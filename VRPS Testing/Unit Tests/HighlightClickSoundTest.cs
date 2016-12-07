/*testing by Hector Lopez*/

using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class HighlightClickSoundTest
{
  HighLightClickSound testObj;
  GameObject dummy;

  [SetUp]
  public void Init()
  {
    Debug.Log("set up in HighLightClickSound");
    dummy = new GameObject();
    testObj = dummy.AddComponent<HighLightClickSound>();
  }

  [Test]
  public void TestHighlightClick_PlaySound()
  {
    //Arrange

    //Act

    //Assert
  }
}
