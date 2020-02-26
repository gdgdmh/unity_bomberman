using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SimpleEditTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void SimpleEditTestSimplePasses()
        {
			// 実験用として各種Assertを使ってみるサンプル
			// a == b
            Assert.AreEqual(2, 1 + 1);
			// a != b
            Assert.AreNotEqual(3, 1 + 1);
            // a == true
            Assert.IsTrue(2 == 2);
			// a == false
            Assert.IsFalse(2 == 3);

			{
				int[] array = null;
				// a == null
                Assert.IsNull(array);
            }

			{
                int value = 1;
				// a != null
                Assert.IsNotNull(value);
            }
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator SimpleEditTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
