﻿//
// MIT License
// Copyright ©2010 Eric Maupin
// All rights reserved.

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace System.Runtime.CompilerServices
{
	[AttributeUsage (AttributeTargets.Method)]
	public sealed class ExtensionAttribute
		: Attribute
	{
		public ExtensionAttribute() {}
	}
}

namespace libavnet
{
	public static class Extensions
	{
		internal static void ThrowIfError (this int status)
		{
			switch (status)
			{
				case FFmpeg.AVERROR_IO:
					throw new IOException();

				case FFmpeg.AVERROR_NOFMT:
					throw new InvalidOperationException ("Unknown format");

				case FFmpeg.AVERROR_NOMEM:
					throw new OutOfMemoryException();

				case FFmpeg.AVERROR_NOTSUPP:
					throw new NotSupportedException();
				
				case FFmpeg.AVERROR_NUMEXPECTED:
					throw new InvalidOperationException ("Number syntax expected in file name");

				case FFmpeg.AVERROR_INVALIDDATA:
					throw new InvalidOperationException ("Invalid data");

				case 0:
					return;

				case FFmpeg.AVERROR_UNKNOWN:
				default:
					throw new Exception ("Unknown error");
			}
		}
	}
}