using System.IO.Abstractions.TestingHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Collibri.Tests.Models.Files;

static class FileTestHelper
{
	public static FileStreamResult CreateTestFileStreamResult(MockFileSystem fileSystem, string path, string fileName)
	{
		var fileStream = fileSystem.FileStream.New(path + "\\" + fileName, FileMode.Open, FileAccess.Read);
		return new FileStreamResult(fileStream, "application/octet-stream");
	}
        
	public static IFormFile CreateTestFormFile(string fileName, string content)
	{
		var stream = new MemoryStream();
		var writer = new StreamWriter(stream);
		writer.Write(content);
		writer.Flush();
		stream.Position = 0;

		return new FormFile(stream, 0, stream.Length, "file", fileName);
	}

	public static string GetPath(string postId)
	{
		return new DirectoryInfo($@"{Directory.GetParent(
			Directory.GetCurrentDirectory())}\Collibri\Data\Files\{postId}").FullName;
	}
        
	public static bool StreamEquals(Stream a, Stream b)
	{
		if (a == b)
		{
			return true;
		}
    
		if (a == null || b == null)
		{
			throw new ArgumentNullException(a == null ? "a" : "b");
		}

		if (a.Length != b.Length)
		{
			return false;
		}

		for (int i = 0; i < a.Length; i++)
		{
			int aByte = a.ReadByte();
			int bByte = b.ReadByte();
			if (aByte.CompareTo(bByte) != 0)
			{
				return false;
			}
		}

		return true;
	}
}