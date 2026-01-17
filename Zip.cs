using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HeroesOE.VGlobals;

namespace HeroesOE
{
	internal class Zip
	{
		public static string ReadGZipFile1(string filePath)
		{
			try
			{
				string zip_path = Path.GetTempPath() + @"\" + Path.GetFileName(filePath);
				File.Delete(zip_path);
				File.Copy(filePath, zip_path);
				// Use FileStream to open the compressed file for reading
				using (FileStream fileStream = File.OpenRead(zip_path))
				{
					// Use GZipStream for decompression on top of the file stream
					using (GZipStream gzipStream = new GZipStream(fileStream, CompressionMode.Decompress))
					{
						// Use a StreamReader to read the decompressed stream's content
						// into a string in memory
						using (StreamReader reader = new StreamReader(gzipStream, Globals.encoding))
						{
							return reader.ReadToEnd();
						}
					}
				}
			}
			catch { return ""; }	// if it failed it's probably because the game was writing the save file
		}
		public static byte[] ReadGZipFileToBytes(string filePath)
		{
			try
			{
				using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
				{
					using (GZipStream gzipStream = new GZipStream(fileStream, CompressionMode.Decompress))
					{
						using (MemoryStream outputStream = new MemoryStream())
						{
							gzipStream.CopyTo(outputStream);
							return outputStream.ToArray();
						}
					}
				}
			}
			catch { return []; }
		}
		public static void SaveInMemoryZipToDisk(MemoryStream sourceZipStream, string destinationFilePath)
		{
			// Ensure the source stream is at the beginning before reading
			sourceZipStream.Position = 0;

			// Open the source MemoryStream as a readable ZipArchive
			using (var sourceArchive = new ZipArchive(sourceZipStream, ZipArchiveMode.Read, leaveOpen: true))
			{
				// Create a FileStream for the destination zip file on disk
				using (var destinationFileStream = File.Create(destinationFilePath))
				{
					// Create a destination ZipArchive for writing
					// Use leaveOpen: true so we can ensure the stream position is correct before returning
					using (var destinationArchive = new ZipArchive(destinationFileStream, ZipArchiveMode.Create, leaveOpen: true))
					{
						// Iterate through each entry (file/directory) in the source archive
						foreach (var entry in sourceArchive.Entries)
						{
							// Create a new entry in the destination archive, preserving the full path (including directory structure)
							// Use the same compression level as the source or set a specific one
							var newEntry = destinationArchive.CreateEntry(entry.FullName, CompressionLevel.Optimal);

							// Open the source entry stream
							using (var entryStream = entry.Open())
							{
								// Open the destination entry stream
								using (var newEntryStream = newEntry.Open())
								{
									// Copy the data from the source entry to the destination entry
									entryStream.CopyTo(newEntryStream);
								}
							}
						}
					}
					// At this point, the destinationArchive is disposed and all data has been written to the FileStream.
					// The FileStream is automatically flushed and closed by the 'using' statement.
				}
			}
			Console.WriteLine($"Zip file successfully saved to: {destinationFilePath}");
		}
		public static bool WriteBytesToGzip(byte[] data, string filePath)
		{
			// do several retries since the game may be writing the file
			for(int i = 0; i < 3; ++i)
			{
				if (WriteBytesAsGzip(data, filePath)) return true;
				Thread.Sleep(50);
			}
			return false;
		}

		public static bool WriteBytesAsGzip(byte[] data, string filePath)
		{
			try
			{
				// Create the destination file stream
				using (FileStream compressedFileStream = File.Create(filePath))
				{
					// Create a GZipStream that writes to the file stream
					using (GZipStream gzipStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
					{
						// Write the uncompressed data to the GZipStream
						// The GZipStream handles the compression and writing to the underlying file
						gzipStream.Write(data, 0, data.Length);
						return true;
					}
				}
			}
			catch { return false; }    // if it failed it's probably because the game was writing the save file
		}
		public static void WriteGZipFile(string zip_path, string file)
		{
			try
			{
				var bytes = Globals.encoding.GetBytes(file);
				//string zip_path = Path.GetTempPath() + @"\" + Path.GetFileName(filePath);
				File.Delete(zip_path);
				using (FileStream fs = File.Create(zip_path)) // Create the output file
				{
					using (GZipStream gzipStream = new GZipStream(fs, CompressionMode.Compress)) // Wrap it with GZipStream
					{
						// 3. Write the compressed data
						// The GZipStream handles the compression as the bytes are written
						gzipStream.Write(bytes, 0, bytes.Length);
					}
				}

				VTrace($"************ Wrote {zip_path}");
			}
			catch { VTrace($"************ Failed writing {zip_path}"); }    // if it failed it's probably because the game was writing the save file
		}
	}
}
