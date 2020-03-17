using System;

namespace heaps
{
    public class MinHeap{

        private static int cap = 50;
        private int size = 0;
        public Call[] callers;// = new Call[cap];

        public MinHeap() {
            callers = new Call[cap];
        }
        public MinHeap(int _cap) {
            cap = _cap;
            callers = new Call[_cap];
            
        }


        private int GetLeftChildIndex(int parentIndex) {
            return 2 * parentIndex + 1;
        }

        private int GetRightChildIndex(int parentIndex){
            return 2 * parentIndex + 2;
        }

        private int GetParentIndex(int childIndex){
            return (childIndex - 1) / 2;
        }

        private Boolean HasLeftChild(int index){
            return GetLeftChildIndex(index) < size;
        }

        private Boolean HasRightChild(int index){
            return GetRightChildIndex(index) < size;
        }

        private Boolean HasParent(int index){
            return GetParentIndex(index) >= 0;
        }

        private Call LeftChild(int index){
            return callers[GetLeftChildIndex(index)];
        }

        private Call RightChild(int index){
            return callers[GetRightChildIndex(index)];
        }

        private Call Parent(int index){
            return callers[GetParentIndex(index)];
        }

        private void Swap(int indexOne, int indexTwo){
            var temp = callers[indexOne];
            callers[indexOne] = callers[indexTwo];
            callers[indexTwo] = temp;
        }

        private void EnsureCap(){
            if (size == cap){
                Array.Resize(ref callers, cap * 2);
            }
        }
    
        public Call Peek(){
            if (size == 0) throw new Exception();
            return callers[0];
        }

        public Call Pop(){
            if (size == 0) throw new Exception();
            Call call = callers[0];
            callers[0] = callers[size-1];
            size--;
            HeapifyDown();
            return call;
        }

        public void Add(Call call){
            EnsureCap();
            callers[size] = call;
            size++;
            HeapifyUp();
        }

        public void HeapifyUp(){
            int index = size - 1;
            while (HasParent(index) && Parent(index).TimeCalled > callers[index].TimeCalled){
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }

        public void HeapifyDown(){
            int index = 0;
            while (HasLeftChild(index)){
                int smallerChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && RightChild(index).TimeCalled < LeftChild(index).TimeCalled){
                    smallerChildIndex = GetRightChildIndex(index);
                }

                if (callers[index].TimeCalled < callers[smallerChildIndex].TimeCalled){
                    break;
                } else {
                    Swap(index, smallerChildIndex);
                }
                index = smallerChildIndex;
            }
        }
    }

}