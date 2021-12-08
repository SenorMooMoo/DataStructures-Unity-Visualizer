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
        
        [Test]
        public void TestAtMethod()
        {
            var linkedlist = new CustomLinkedList<int>();
            linkedlist.AddNode(new CustomNode<int>(32));
            linkedlist.AddNode(new CustomNode<int>(20));
            linkedlist.AddNode(new CustomNode<int>(15));
            linkedlist.AddNode(new CustomNode<int>(3));
            Assert.AreEqual(3, linkedlist.At(3).Data);
            Assert.AreEqual(20, linkedlist.At(1).Data);

            
        }
    }
}

