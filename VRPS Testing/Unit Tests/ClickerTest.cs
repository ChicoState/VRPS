/*testing by Hector Lopez*/

using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class ClickerTest
{
  Clicker testObj;
  GameObject dummy;

  [SetUp]
  public void Init()
  {
    Debug.Log("set up in clicker");
    dummy = new GameObject();
    testObj = dummy.AddComponent<Clicker>();
  }

  [Test]
  public void ClickedTest()
  {
    //Arrange
    Assert.NotNull(testObj);

    //Act
    bool clicked = testObj.clicked();

    //Assert
    Assert.AreEqual(clicked, Input.anyKeyDown);
  }
}
