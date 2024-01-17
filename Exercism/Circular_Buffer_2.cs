class CircularBuffer<T>
{
    private int pointer;
    private int oldest;
    public int capacity;
    private int count;
    T[] items;
        
    public CircularBuffer(int capacity)
    {
        this.capacity = capacity;
        items = new T[capacity];
    }

    public void Write(T item)
    {
        if (count == capacity) throw new InvalidOperationException("Cannot write to full buffer");
        items[pointer] = item;
        pointer = (pointer + 1 ) % capacity;
        count++;
    }
    public void Clear()
    {
        Array.Clear(items, 0, capacity);
        pointer = 0;
        oldest = 0;
        count = 0;
    }

    public T Read()
    {
        if (count == 0) throw new InvalidOperationException("Cannot read from empty buffer");
        else
        {
            var value = items[oldest];
            items[oldest] = default(T);
            oldest = (oldest + 1) % capacity;
            count--;
            return value;
        }
    }
    public void Overwrite(T value)
    {
        if (count == capacity)
        {
            Read();
            Write(value);
        } 
        else
            Write(value);
    }
}