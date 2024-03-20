// using System.IO.Abstractions;
// using System.IO.Abstractions.TestingHelpers;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Collibri.Tests.Repositories.Files
// {
// 	static class FileTestHelper
// 	{
// 		public static FileStreamResult CreateTestFileStreamResult(MockFileSystem fileSystem, string path, string fileName)
// 		{
// 			var fileStream = fileSystem.FileStream.New(
// 				path + fileSystem.Path.DirectorySeparatorChar + fileName, FileMode.Open, FileAccess.Read);
// 			return new FileStreamResult(fileStream, "application/octet-stream");
// 		}
//         
// 		public static IFormFile CreateTestFormFile(string fileName, string content, string type)
// 		{
// 			
// 			// var result = new FormFile(stream, 0, stream.Length, "file", fileName)
// 			// {
// 			// 	ContentType = type
// 			// };
// 			// return result;
// 			var file = new Mock<IFormFile>();
// 			var ms = new MemoryStream();
// 			var writer = new StreamWriter(ms);
// 			writer.Write(content);
// 			writer.Flush();
// 			ms.Position = 0;
// 			file.Setup(f => f.FileName).Returns(fileName).Verifiable();
// 			file.Setup(f => f.ContentType).Returns(type).Verifiable();
// 			//file.Setup(f => f.CopyTo(It.IsAny<Stream>())).Verifiable();
// 			return file.Object;
// 		}
//
// 		public static string GetPath(string postId, IFileSystem _fileSystem)
// 		{
// 			return _fileSystem.DirectoryInfo.New(
// 				_fileSystem.Path.Combine(
// 					_fileSystem.Directory.GetParent(Directory.GetCurrentDirectory()).FullName,
// 					"Collibri", "Data", "Files", postId)).FullName;
// 		}
//         
// 		public static bool StreamEquals(Stream a, Stream b)
// 		{
// 			if (a == b)
// 			{
// 				return true;
// 			}
//     
// 			if (a == null || b == null)
// 			{
// 				throw new ArgumentNullException(a == null ? "a" : "b");
// 			}
//
// 			if (a.Length != b.Length)
// 			{
// 				return false;
// 			}
//
// 			for (int i = 0; i < a.Length; i++)
// 			{
// 				int aByte = a.ReadByte();
// 				int bByte = b.ReadByte();
// 				if (aByte.CompareTo(bByte) != 0)
// 				{
// 					return false;
// 				}
// 			}
//
// 			return true;
// 		}
// 	}
// }