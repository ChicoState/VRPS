/*testing by Hector Lopez*/

using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class PlayFramesMemoryTest
{
  PlayFrames_Memory testObj;
  GameObject dummy;

  [SetUp]
  public void Init()
  {
    Debug.Log("set up in PlayFrames_Memory test");
    dummy = new GameObject();
    testObj = dummy.AddComponent<PlayFrames_Memory>();

    GameObject leftsphere = new GameObject("left", typeof(MeshRenderer));
    GameObject rightphere = new GameObject("right", typeof(MeshRenderer));
    testObj.LeftSphere = leftsphere;
    testObj.RightSphere = rightphere;
  }

  [Test]
  public void TestPlayFramesMemory_Play_On()
  {
    //Arrange
    Assert.NotNull(testObj);
    Assert.Null(testObj.sound);

    //Act
    testObj.Play_On();

    //Assert
    Assert.AreEqual(testObj.Play_State, true);
  }

  [Test]
  public void TestPlayFramesMemory_Play_Off()
  {
    //Arrange
    Assert.NotNull(testObj);

    //Act
    testObj.Play_Off();

    //Assert
    Assert.AreEqual(testObj.Play_State, false);
  }
}
