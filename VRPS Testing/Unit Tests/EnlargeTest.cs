/*testing by Hector Lopez*/

using UnityEngine;
using UnityEditor;
using NUnit.Framework;

/// <summary>
/// Unit test for class large.
/// Notice:
/// 1. all unit test methods are public
/// 2. [SetUp] for init, [Test] for method, [TestFixture] for class
/// 3. for each test case, 3 steps, arrange, act, assert
/// </summary>

[TestFixture]
public class EnlargeTest
{
  Enlarge testObj;
  GameObject dummy;

  [SetUp]
  public void Init()
  {
    Debug.Log("set up in test");
    dummy = new GameObject();
    testObj = dummy.AddComponent<Enlarge>();
    testObj.transform.localScale = Vector3.one; // (1.0, 1.0, 1.0)
    testObj.Start(); // set original scale to vector3.one
  }

  [Test]
  public void TestStart()
  {
    Assert.AreEqual(testObj.Original_Scale, Vector3.one);
    Assert.AreEqual(testObj.Original_Scale, testObj.transform.localScale);
  }

  // test on same enlarge objs, call Inlarge method
  [Test]
  public void SameEnlargeObjs_InlargeTest()
  {
    //Arrange

    //Act
    testObj.Enlarge_Size = 2.0f;
    testObj.Inlarge();

    //Assert
    //The object has a new name
    Vector3 target_localscale = new Vector3(2.0f, 2.0f, 2.0f);
    Assert.AreEqual(testObj.transform.localScale, target_localscale);
  }

  [Test]
  public void SameInlargeObjs_DislargeTest()
  {
    testObj.Dislarge();
    Assert.AreEqual(testObj.transform.localScale, testObj.Original_Scale);
    Assert.AreEqual(testObj.transform.localScale, Vector3.one);
  }

  [TearDown]
  public void Destroy()
  {
    Debug.Log("clean up res");
  }
}
