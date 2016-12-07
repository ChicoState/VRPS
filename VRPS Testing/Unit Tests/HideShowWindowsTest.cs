/*testing by Hector Lopez*/

using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class HideShowWindowsTest
{
  HideShowWindows testObj;
  GameObject dummy;
  Canvas canvas;
  BoxCollider boxcollider;

  [SetUp]
  public void Init()
  {
    Debug.Log("set up in hideshow windows");
    dummy = new GameObject();
    testObj = dummy.AddComponent<HideShowWindows>();
    GameObject wnd = new GameObject();
    canvas= wnd.AddComponent<Canvas>();
    boxcollider = wnd.AddComponent<BoxCollider>();
    testObj.Window = wnd;
  }

  [Test]
  public void TestHideShowWindow_Show()
  {
    //Arrange
    Assert.NotNull(testObj);

    //Act
    testObj.Start();
    testObj.Show();

    //Assert
    Assert.AreEqual(testObj.canv.enabled, true);
    Assert.AreEqual(testObj.BoxColi.enabled, true);
  }

  [Test]
  public void TestHideShowWindow_Hide()
  {
    //Arrange
    Assert.NotNull(testObj);

    //Act
    testObj.Start();
    testObj.Hide();

    //Assert
    Assert.AreEqual(testObj.canv.enabled, false);
    Assert.AreEqual(testObj.BoxColi.enabled, false);
  }
}
