using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class PriorityQueue : IEnumerable<Todo>
    {
        private Todo First { get; set; }
        public int Count { get { return getCount(); } }

        public void Enqueue(Todo newTodo)
        {
            if(First == null)
            {
                First = newTodo;
                return;
            }
            else if(newTodo.Priority > First.Priority)
            {
                newTodo.Next = First;
                First = newTodo;
            }
            else {
                Todo currentTodo = First;
                while(currentTodo.Next != null && currentTodo.Next.Priority >= newTodo.Priority)
                {
                    currentTodo = currentTodo.Next;
                }
                newTodo.Next = currentTodo.Next;
                currentTodo.Next = newTodo;
            }
        }

        public Todo Dequeue()
        {
            Todo beingDequeued = First;
            First = First.Next;
            return beingDequeued;
        }

        public Todo Peek()
        {
            return First;
        }
        
        public void Clear()
        {
            First = null;
        }

        public IEnumerator<Todo> GetEnumerator()
        {
            return new PriorityQueueEnumerator(this);
        }

        private int getCount()
        {
            int count = 0;

            Todo currentTodo = First;

            while(currentTodo != null)
            {
                count++;
                currentTodo = currentTodo.Next;
            }

            return count;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PriorityQueueEnumerator(this);
        }

        class PriorityQueueEnumerator : IEnumerator<Todo>
        {
            private Todo currentTodo;
            private int index;
            private PriorityQueue priorityQueue;

            public PriorityQueueEnumerator(PriorityQueue pq)
            {
                priorityQueue = pq;
                index = -1;
                currentTodo = null;
            }

            public Todo Current => currentTodo;

            object IEnumerator.Current => currentTodo;

            public void Dispose()
            {
                // throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                index++;
                if(index >= priorityQueue.Count)
                {
                    return false;
                }
                Todo t = priorityQueue.First;
                for(int i = 0; i < index; i++)
                {
                    t = t.Next;
                }
                currentTodo = t;
                return true;
            }

            public void Reset()
            {
                index = -1;
                currentTodo = null;
            }
        }
    }
}
