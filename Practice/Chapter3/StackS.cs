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

        public void push(int v)
        {
            if (top == null)
            {
                top = new Node(v);
                return;
            }

            var node = new Node(v);
            node.next = top;
            top = node;
        }

        public int pop()
        {
            if (top == null) return -1;

            var ret = top.value;
            top = top.next;
            return ret;
        }
    }

    public class Stack2
    {
        private int[] array;
        private int x;
        private int y;
        private int z;
        private int size;

        public Stack2()
        {
            array = new int[99];
            init();
        }

        public Stack2(int size)
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
}
