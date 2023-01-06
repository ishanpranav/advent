// Copyright (c) 2022 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Advent;

public class Deque<T> : IReadOnlyCollection<T>
{
    private int _head;
    private int _tail;
    private int _version;
    private T[] _buffer;

    public Deque()
    {
        _buffer = Array.Empty<T>();
    }

    /// <inheritdoc/>
    public int Count { get; private set; }

    public int Capacity
    {
        get
        {
            return _buffer.Length;
        }
        set
        {
            if (value < Count || value > Array.MaxLength)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            if (value is 0)
            {
                _buffer = Array.Empty<T>();
            }
            else
            {
                T[] buffer = new T[value];

                if (Count > 0)
                {
                    if (_head < _tail)
                    {
                        Array.Copy(_buffer, _head, buffer, destinationIndex: 0, Count);
                    }
                    else
                    {
                        int partition = Capacity - _head;

                        Array.Copy(_buffer, _head, buffer, destinationIndex: 0, partition);
                        Array.Copy(_buffer, sourceIndex: 0, buffer, partition, _tail);
                    }
                }

                _buffer = buffer;
            }

            if (Count == Capacity)
            {
                _tail = 0;
            }
            else
            {
                _tail = Count;
            }

            _head = 0;
            _version++;
        }
    }

    public T First
    {
        get
        {
            if (Count is 0)
            {
                throw new InvalidOperationException();
            }

            return _buffer[_head];
        }
    }

    public T Last
    {
        get
        {
            if (Count is 0)
            {
                throw new InvalidOperationException();
            }

            return _buffer[(_tail + Capacity - 1) % Capacity];
        }
    }

    public void AddFirst(T item)
    {
        if (Count == Capacity)
        {
            Grow(Count + 1);
        }

        _head = (_head + Capacity - 1) % Capacity;
        _buffer[_head] = item;
        _version++;
        Count++;
    }

    public void AddLast(T item)
    {
        if (Count == Capacity)
        {
            Grow(Count + 1);
        }

        _buffer[_tail] = item;
        _tail++;
        _version++;
        Count++;

        if (_tail == Capacity)
        {
            _tail = 0;
        }
    }

    public int EnsureCapacity(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity));
        }

        if (Capacity < capacity)
        {
            Grow(capacity);

            _version++;
        }

        return Capacity;
    }

    private void Grow(int min)
    {
        if (Capacity is 0)
        {
            Capacity = Math.Max(min, 4);
        }
        else
        {
            Capacity = Math.Max(min, Capacity * 2);
        }
    }

    public T RemoveFirst()
    {
        if (Count is 0)
        {
            throw new InvalidOperationException();
        }

        T result = _buffer[_head];

        if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
        {
            _buffer[_head] = default!;
        }

        _head++;
        _version++;
        Count--;

        if (_head == Capacity)
        {
            _head = 0;
        }

        return result;
    }

    public T RemoveLast()
    {
        if (Count is 0)
        {
            throw new InvalidOperationException();
        }

        _tail = (_tail + Capacity - 1) % Capacity;
        Count--;
        _version++;

        T result = _buffer[_tail];

        if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
        {
            _buffer[_tail] = default!;
        }

        return result;
    }

    public bool Contains(T item)
    {
        if (Count is 0)
        {
            return false;
        }

        if (_head < _tail)
        {
            return Array.IndexOf(_buffer, item, _head, Count) is not -1;
        }

        return Array.IndexOf(_buffer, item, _head, Capacity - _head) is not -1 || Array.IndexOf(_buffer, item, 0, _tail) is not -1;
    }

    public void Clear()
    {
        if (Count is 0)
        {
            return;
        }

        if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
        {
            if (_head < _tail)
            {
                Array.Clear(_buffer, _head, Count);
            }
            else
            {
                Array.Clear(_buffer, _head, Capacity - _head);
                Array.Clear(_buffer, index: 0, _tail);
            }
        }

        _head = 0;
        _tail = 0;
        _version++;
        Count = 0;
    }

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator()
    {
        int version = _version;

        if (_head < _tail)
        {
            for (int i = 0; i < Count; i++)
            {
                assert();

                yield return _buffer[_head + i];
            }
        }
        else
        {
            for (int i = _head; i < Capacity; i++)
            {
                assert();

                yield return _buffer[i];
            }

            for (int i = 0; i < _tail; i++)
            {
                assert();

                yield return _buffer[i];
            }
        }

        void assert()
        {
            if (_version != version)
            {
                throw new InvalidOperationException();
            }
        }
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
