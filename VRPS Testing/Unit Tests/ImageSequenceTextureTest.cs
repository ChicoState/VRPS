/*testing by Hector Lopez*/

using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class ImageSequenceTextureTest
{
  ImageSequenceTextureArray testObj;
  GameObject dummy;

  [SetUp]
  public void Init()
  {
    Debug.Log("set up in ImageSequenceTextureArray test");
    dummy = new GameObject();
    testObj = dummy.AddComponent<ImageSequenceTextureArray>();
  }

  [Test]
  public void TestImageSequence()
  {
    //Arrange
    Assert.NotNull(testObj);

    //Act
    GameObject another = GameObject.Instantiate<GameObject>(testObj.gameObject);

    //Assert
    Assert.NotNull(another);
  }
}
