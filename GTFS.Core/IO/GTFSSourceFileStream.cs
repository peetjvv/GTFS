﻿// The MIT License (MIT)

// Copyright (c) 2014 Ben Abelshausen

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using GTFS.Core.IO.CSV;
using System;
using System.IO;

namespace GTFS.Core.IO
{
    /// <summary>
    /// Represents a GTFS source file wrapping a stream.
    /// </summary>
    public class GTFSSourceFileStream : IGTFSSourceFile
    {
        /// <summary>
        /// Holds the stream.
        /// </summary>
        private Stream _stream;

        /// <summary>
        /// Creates a new GTFS file stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="name"></param>
        public GTFSSourceFileStream(Stream stream, string name)
        {
            _stream = stream;
            this.Name = name;
        }

        /// <summary>
        /// Gets the name of this file.
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Holds the current reader.
        /// </summary>
        private CSVStreamReader _reader;

        /// <summary>
        /// Requests a new enumerator.
        /// </summary>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerator<string[]> GetEnumerator()
        {
            if(_reader != null)
            {
                throw new InvalidOperationException("A GTFSSourceFileStream can only spawn one enumerator.");
            }
            _reader = new CSVStreamReader(_stream);
            return _reader;
        }

        /// <summary>
        /// Requests a new enumerator.
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}