/*testing by Hector Lopez*/

using UnityEngine;
using UnityEditor;
using NUnit.Framework;

/// <summary>
/// The script will translate gameobject to 2 sphere localpositions
/// </summary>
[TestFixture]
public class TranslateCameraTest
{
  TranslateCamera testObj;
  GameObject dummy;
  GameObject gameobject1, gameobject2;

  [SetUp]
  public void Init()
  {
    Debug.Log("set up in translate camera");
    dummy = new GameObject();
    testObj = dummy.AddComponent<TranslateCamera>();
    gameobject1 = new GameObject("GameObject1", typeof(SphereCollider));
    gameobject2 = new GameObject("GameObject2", typeof(SphereCollider));

    testObj.Sphere1 = gameobject1;
    testObj.Sphere2 = gameobject2;
  }

  [Test]
  public void TestStart()
  {
    Assert.NotNull(testObj);
    testObj.Start();
    Assert.AreEqual(testObj.Location.Length ,2);
    Assert.AreEqual(testObj.Location[0], gameobject1.transform.localPosition);
    Assert.AreEqual(testObj.Location[1], gameobject2.transform.localPosition);
  }

  [Test]
  public void Test_ChangeLocation_Italy()
  {
    //Arrange
    Assert.NotNull(testObj);

    //Act
    testObj.Start();
    testObj.ChangeLocation_Italy();

    //Assert
    Assert.AreEqual(testObj.transform.position, gameobject1.transform.localPosition);
    Assert.AreEqual(testObj.transform.position, testObj.Location[0]);
  }

  [Test]
  public void Test_ChangeLocation_ClassRoom()
  {
    //Arrange
    Assert.NotNull(testObj);

    //Act
    testObj.Start();
    testObj.ChangeLocation_ClassRoom();

    //Assert
    Assert.AreEqual(testObj.transform.position, gameobject1.transform.localPosition);
    Assert.AreEqual(testObj.transform.position, testObj.Location[0]);
  }
}
