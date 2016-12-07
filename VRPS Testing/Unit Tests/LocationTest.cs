/*testing by Hector Lopez*/

using UnityEngine;
using UnityEditor;
using NUnit.Framework;

[TestFixture]
public class LocationTest
{
  location testObj;
  GameObject dummy;
  Vector3 oldPosition, oldScale;
  Quaternion oldRotation;

  [SetUp]
  public void Init()
  {
    Debug.Log("set up in test");
    dummy = new GameObject();
    testObj = dummy.AddComponent<location>();
    oldPosition = testObj.transform.position;
    oldRotation = testObj.transform.rotation;
    oldScale = testObj.transform.localScale;
  }

  [Test]
  public void TestLocation()
  {
    //Arrange
    Assert.NotNull(testObj);

    //Act
    testObj.Start();

    //Assert
    // since translate only affects position, rotation & scale should not be changed
    Assert.AreNotEqual(testObj.transform.position, oldPosition);
    Assert.AreNotSame(testObj.transform.rotation, oldRotation); // objs are not same, but value is equal
    Assert.AreEqual(testObj.transform.rotation, oldRotation);
    Assert.AreEqual(testObj.transform.localScale, oldScale);
  }
}
