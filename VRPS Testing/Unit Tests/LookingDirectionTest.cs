/*testing by Hector Lopez*/

using UnityEngine;
using UnityEditor;
using NUnit.Framework;

[TestFixture]
public class LookingDirectionTest
{
  looking_direction testObj;
  GameObject dummy;

  [SetUp]
  public void Init()
  {
    Debug.Log("set up in test");
    dummy = new GameObject();
    testObj = dummy.AddComponent<looking_direction>();
    GameObject cam_obj = new GameObject("Main camera", typeof(Camera));
    testObj.CameraFacing = cam_obj.GetComponent<Camera>();
  }

  [Test]
  public void TestLookingDirectionUpdate()
  {
    //Arrange
    Assert.NotNull(testObj);

    //Act
    //Try to rename the GameObject
    testObj.Update();

    //Assert
    //The object has a new name
    Assert.NotNull(testObj);
  }
}
