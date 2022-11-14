using System;
using System.Linq;

public class CircularBuffer<T>
{
	  int?[] buffer;
		int position =0;  
    public CircularBuffer(int capacity)
    {
				buffer =new int[capacity];
                buffer[0].Value;
    }

    public T Read()
    {
			int output = buffer[position].Value;
				if(position == capacity){
					position = 0;
				}else{
					position++;
				}
				return output.Value; 
    }

    public void Write(T value)
    {
				if(buffer[position].HasValue )
        throw new Exception("buffer full");
    }

    public void Overwrite(T value)
    {
			buffer[position] = (int)value;
    }

    public void Clear()
    {
		
			buffer.forEach(i=> i = null);			
    }
}
