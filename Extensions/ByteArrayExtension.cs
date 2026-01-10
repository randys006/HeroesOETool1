using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ByteArrayExtensions
{
	public static int IndexOf(this byte[] source, byte[] pattern, int startIndex)
	{
		// Use AsSpan() with a slice to start from the specific index.
		// IndexOf returns a relative index within the span.
		int relativeIndex = source.AsSpan(startIndex).IndexOf(pattern.AsSpan());

		// If the pattern is found, convert the relative index back to the absolute index.
		if (relativeIndex != -1)
		{
			return startIndex + relativeIndex;
		}

		// If not found, return -1.
		return -1;
	}
}
