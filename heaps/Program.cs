using System;


namespace heaps
{
    class Program
    {

        static int capacity = 1000;
        static void Main(string[] args)
        {
            MinHeap queue = new MinHeap(capacity);

            for (int i = 0; i < capacity; i++){
                queue.Add(new Call().GenerateCaller(i));
            }

            for (int i = 0; i < queue.callers.Length; i++){
                var call = queue.callers[i];
                Console.WriteLine($"{call.CallerFirstName}{call.CallerId} called at {call.TimeCalled.ToString()}");
            }

            var nextCaller = queue.Peek();
            Console.WriteLine($"The next caller is {nextCaller.CallerFirstName}{nextCaller.CallerId} who called at {nextCaller.TimeCalled}");

        }
    }
}
