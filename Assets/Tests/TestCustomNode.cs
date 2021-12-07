using NUnit.Framework;

namespace Tests
{
    public class TestCustomNode
    {
        [Test]
        public void TestsCreationOfNode()
        {
            // ACT
            var testNode = new CustomNode<int>
            {
                Data = 32,
                Next = new CustomNode<int>(20)
            };
            //Assert
            Assert.AreEqual(32,testNode.Data);
            Assert.NotNull(testNode.Next);
        }
    
    }
}

