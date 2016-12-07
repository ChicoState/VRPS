/*testing by Hector Lopez*/

using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class ReticleTest
{
  Reticle testObj;
  GameObject dummy;
  MeshRenderer meshrenderer;

  [SetUp]
  public void Init()
  {
    Debug.Log("set up in ReticleTest");
    dummy = new GameObject();
    testObj = dummy.AddComponent<Reticle>();
    meshrenderer = testObj.gameObject.AddComponent<MeshRenderer>();
    testObj.Start();
  }

  [Test]
  public void Test_Rotate_Off()
  {
    //Arrange
    Assert.NotNull(testObj);
    Assert.NotNull(meshrenderer);

    //Act
    testObj.Rotate_Off();

    //Assert
    Assert.AreEqual(testObj.stair_to_select, false);
    Assert.AreEqual(meshrenderer.enabled, false);
  }

  [Test]
  public void Test_Rotate_On()
  {
    //Arrange
    Assert.NotNull(testObj);

    //Act
    testObj.Rotate_On();

    //Assert
    Assert.AreEqual(testObj.stair_to_select, true);
    Assert.AreEqual(meshrenderer.enabled, true);
  }
}
