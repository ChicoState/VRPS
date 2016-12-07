/*testing by Hector Lopez*/

using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class PushExecuteTest
{
  PushExecute testObj;
  GameObject dummy;

  [SetUp]
  public void Init()
  {
    Debug.Log("set up in PushExecute test");
    dummy = new GameObject();
    testObj = dummy.AddComponent<PushExecute>();
  }

  void TestDelegate()
  {
    testObj.Update();
  }

  [Test]
  public void TestPushExecute_Update()
  {
    //Arrange
    Assert.NotNull(testObj);

    //Act
    //Assert.Catch()
    Assert.Throws<System.NullReferenceException>(TestDelegate);

    //Assert
    GameObject cam_obj = new GameObject("main camera", typeof(Camera));
    testObj.CameraFacing = cam_obj.GetComponent<Camera>();
    testObj.Update();
    Assert.NotNull(testObj);
  }
}
