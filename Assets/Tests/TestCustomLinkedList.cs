using NUnit.Framework;

namespace Tests
{
    public class TestCustomLinkedList
    {
    
        [Test]
        public void TestCustomLinkedListCreation()
        {
            var linkedlist = new CustomLinkedList<int>();
            linkedlist.AddNode(new CustomNode<int>(32));
            linkedlist.AddNode(new CustomNode<int>(20));
            Assert.AreEqual(20, linkedlist.Head.Next.Data);
        }
    }
}

