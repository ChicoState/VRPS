/*testing by Hector Lopez*/

using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class ButtonExecuteTest
{
  ButtonExecute testObj;
  GameObject dummy;

  [SetUp]
  public void Init()
  {
    Debug.Log("set up in buttonexecute");
    dummy = new GameObject();
    testObj = dummy.AddComponent<ButtonExecute>();
    GameObject cam = new GameObject("Main camera", typeof(Camera));
    testObj.CameraFacing = cam.GetComponent<Camera>();
  }

  [Test]
  public void UpdateTest()
  {
    //Arrange
    Assert.NotNull(testObj);

    //Act
    testObj.Update();

    //Assert
    Assert.NotNull(testObj);
  }
}
