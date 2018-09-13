using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestWorldState
{

    [Test]
    public void TestWorldStateSimplePasses()
    {
        // Use the Assert class to test conditions.
        var w = new GOAP.WorldState(4);
        Assert.IsTrue(w.IsEmpty(0));
        Assert.IsTrue(w.IsEmpty(1));
        Assert.IsTrue(w.IsEmpty(2));
        Assert.IsTrue(w.IsEmpty(3));
        w.SetTrue(0);
        Assert.IsFalse(w.IsEmpty(0));
        Assert.AreEqual(true, w.IsTrue(0));
    }

    [Test]
    public void TestWorldStateSatisfy()
    {
        var condition = new GOAP.WorldState(4);

        condition.SetTrue(0);
        condition.SetFalse(1);

        var effect = new GOAP.WorldState(4);

        Assert.IsFalse(effect.DoesSatisify(condition));
        effect.SetTrue(0);
        effect.SetFalse(1);
        effect.SetFalse(2);
        Assert.IsTrue(effect.DoesSatisify(condition));
    }

    [Test]
    public void TestWorldStateApply()
    {
        var state = new GOAP.WorldState(4);

        var effect = new GOAP.WorldState(4);
        effect.SetTrue(0);

        state.ApplyState(effect);

        Assert.IsTrue(state.IsTrue(0));
    }


}
