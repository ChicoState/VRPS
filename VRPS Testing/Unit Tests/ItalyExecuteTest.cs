/*testing by Hector Lopez*/

using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class ItalyExecuteTest
{
  ItalyExecute testObj;
  GameObject dummy;

  [SetUp]
  public void Init()
  {
    Debug.Log("set up in ItalyExecute test");
    dummy = new GameObject();
    testObj = dummy.AddComponent<ItalyExecute>();
  }

  void TestDelegate()
  {
    testObj.Update();
  }

  [Test]
  public void Test_ItalyExec()
  {
    //Arrange
    Assert.NotNull(testObj);
    Assert.Null(testObj.CameraFacing);

    //Act
    Assert.Catch<System.NullReferenceException>(TestDelegate);

    GameObject cam_obj = new GameObject("main", typeof(Camera));
    testObj.CameraFacing = cam_obj.GetComponent<Camera>();
    testObj.Update();

    //Assert
    Assert.NotNull(testObj);
  }
}
