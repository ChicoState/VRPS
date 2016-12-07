/*testing by Hector Lopez*/

using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class TimerTest
{
  Timer testObj;
  GameObject dummy;

  [SetUp]
  public void Init()
  {
    Debug.Log("set up in timer");
    dummy = new GameObject();
    testObj = dummy.AddComponent<Timer>();
    testObj.gameObject.AddComponent<UnityEngine.UI.Text>();
  }

  [Test]
  public void TestTimer_Start()
  {
    //Arrange
    Assert.NotNull(testObj);

    //Act
    testObj.MaxHour = 10;
    testObj.MaxMin = 1;
    testObj.MaxSec = 100;
    testObj.FreeClock = false;
    testObj.Start();

    //Assert
    Assert.AreEqual(testObj.ClockValueProvided, true);
  }

  [Test]
  public void TestTimer_Update()
  {
    //Arrange
    Assert.NotNull(testObj);

    //Act
    testObj.MaxHour = 10;
    testObj.MaxMin = 1;
    testObj.MaxSec = 100;
    testObj.FreeClock = false;
    testObj.ClockValueProvided = false;

    testObj.Start();
    testObj.Update();

    //Assert
    Assert.AreNotEqual(testObj.Text_Box.text, "No Time Provided");
  }
}
