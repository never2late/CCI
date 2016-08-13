using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class StackS
    {
        public Node top;
        public int count = 0;

        public virtual void push(int v)
        {
            if (top == null)
            {
                top = new Node(v);
                top.min = v;
                count++;
                return;
            }

            var node = new Node(v);
            node.min = (top.min > v) ? v : top.min;
            node.next = top;
            top = node;
            count++;
        }

        public virtual int pop()
        {
            if (top == null) return -1;

            var ret = top.value;
            top = top.next;
            count--;
            return ret;
        }

        public virtual int peek()
        {
            return (top == null) ? -1 : top.value;
        }

        public virtual bool isEmpty()
        {
            return top == null;
        }

        public virtual int min()
        {
            if (top == null) return -1;

            return top.min;
        }

        public void sort()
        {
            if (isEmpty() == true) return;

            var sorted = new StackS();
            while (isEmpty() == false)
            {
                var num = pop();
                while (sorted.isEmpty() == false && sorted.peek() > num) push(sorted.pop());
                sorted.push(num);
            }

            top = sorted.top;
        }
    }

    public class Stack1
    {
        private int[] array;
        private int x;
        private int y;
        private int z;
        private int size;

        public Stack1()
        {
            array = new int[99];
            init();
        }

        public Stack1(int size)
        {
            if (size < 3) throw new Exception();

            array = new int[size];
            init();
        }

        private void init()
        {
            x = 0;
            y = array.Length / 3;
            z = array.Length - 1;
            size = array.Length;
        }

        public void push(int v, int i)
        {
            if (i < 0 || i > 2) return;

            if (i == 0)
            {
                if (x >= size / 3) resize();

                array[x++] = v;
            }
            else if (i == 1)
            {
                if (y > z) resize();

                array[y++] = v;
            }
            else
            {
                if (z < y) resize();

                array[z--] = v;
            }
        }

        public int pop(int i)
        {
            if (i < 0 || i > 2) return -1;

            if (i == 0)
            {
                if (x <= 0) return -1;
                var ret = array[--x];
                array[x] = 0;
                return ret;
            }
            else if (i == 1)
            {
                if (y <= size / 3) return -1;
                var ret = array[--y];
                array[y] = 0;
                return ret;
            }
            else
            {
                if (z >= size - 1) return -1;
                var ret = array[++z];
                array[z] = 0;
                return ret;
            }
        }

        private void resize()
        {
            int newSize = size * 2;
            var tmp = new int[newSize];

            for (int i = 0; i < x; i++) tmp[i] = array[i];

            var newY = newSize / 3;
            for (int i = size / 3; i < y; i++) tmp[newY++] = array[i];
            y = newY;

            var newZ = newSize - 1;
            for (int i = size - 1; i > z; i--) tmp[newZ--] = array[i];
            z = newZ;

            size = newSize;
            array = tmp;
        }

        public string toString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                sb.Append("[" + array[i] + "]");
            }
            sb.Append("\nx : " + x + " / y : " + y + " / z : " + z + " / size : " + size);

            return sb.ToString();
        }
    }

    public class Stack2 : StackS
    {
        private StackS minStack;

        public Stack2()
        {
            minStack = new StackS();
        }

        public override void push(int v)
        {
            var node = new Node(v);
            node.next = top;
            top = node;

            if (minStack.peek() == -1 || minStack.peek() >= v)
            {
                minStack.push(v);
            }
        }

        public override int pop()
        {
            if (top == null) return -1;

            var ret = top.value;
            top = top.next;

            if (ret == minStack.peek())
            {
                minStack.pop();
            }
            return ret;
        }

        public override int min()
        {
            return minStack.peek();
        }
    }

    public class SetOfStacks
    {
        public Stack<StackS> stacks;
        private int capacity;

        public SetOfStacks(int c)
        {
            capacity = c;
            stacks = new Stack<StackS>();
        }

        public void push(int v)
        {
            if (isFull() == true)
            {
                var stack = new StackS();
                stacks.Push(stack);
            }

            stacks.Peek().push(v);
        }

        public int pop()
        {
            if (stacks.Count == 0) return -1;

            var ret = stacks.Peek().pop();
            if (stacks.Peek().count == 0) stacks.Pop();
            return ret;
        }

        public int peek()
        {
            if (stacks.Peek() == null) return -1;

            return stacks.Peek().peek();
        }

        private bool isFull()
        {
            return stacks.Count == 0 || stacks.Peek().count % capacity == 0;
        }

        public int popAt(int index)
        {
            if (index < 0 || index >= stacks.Count) return -1;

            var tmpStack = new StackS();
            while (stacks.Count - 1 > index)
            {
                var stack = stacks.Pop();
                while (stack.count > 0) tmpStack.push(stack.pop());
            }

            var ret = pop();
            while (tmpStack.count > 0) push(tmpStack.pop());
            return ret;
        }

        public string toString()
        {
            if (stacks == null || stacks.Count == 0) return "";

            var sb = new StringBuilder();
            var tmpStack = new Stack<StackS>();
            while (stacks.Count > 0)
            {
                var stack = stacks.Pop();
                tmpStack.Push(stack);
                for (var node = stack.top; node != null; node = node.next)
                {
                    sb.Append(node.value + "->");
                }
                sb.Remove(sb.Length - 2, 2);
                sb.Append("\n");
            }

            while (tmpStack.Count > 0) stacks.Push(tmpStack.Pop());

            return sb.ToString();
        }
    }
}
