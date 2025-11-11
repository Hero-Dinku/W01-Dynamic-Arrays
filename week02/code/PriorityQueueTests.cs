using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueue_Tests
{
    [TestMethod]
    // Scenario: Basic priority queue functionality with different priorities
    // Expected Result: Highest priority item should be dequeued first
    // Defect(s) Found: 
    // - Loop condition was _queue.Count - 1 instead of _queue.Count (missing last element)
    // - Used >= instead of > for priority comparison (broke FIFO for same priorities)
    // - Item wasn't being removed from the queue after dequeue
    public void TestPriorityQueue_BasicPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 3);
        priorityQueue.Enqueue("Medium", 2);
        
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Multiple items with same highest priority
    // Expected Result: First item with highest priority should be dequeued first (FIFO)
    // Defect(s) Found: 
    // - Priority comparison used >= which would always pick the last item with same priority
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First High", 3);
        priorityQueue.Enqueue("Second High", 3);
        priorityQueue.Enqueue("Third High", 3);
        priorityQueue.Enqueue("Low", 1);
        
        Assert.AreEqual("First High", priorityQueue.Dequeue());
        Assert.AreEqual("Second High", priorityQueue.Dequeue());
        Assert.AreEqual("Third High", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Empty queue dequeue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None - this was already implemented correctly
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    [TestMethod]
    // Scenario: Complex scenario with mixed priorities
    // Expected Result: Correct ordering based on priority and insertion order
    // Defect(s) Found: Same as previous tests - improper loop condition and priority comparison
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 5);
        priorityQueue.Enqueue("E", 1);
        
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("E", priorityQueue.Dequeue());
    }
}