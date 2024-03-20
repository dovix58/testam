// using System.IO.Abstractions.TestingHelpers;
// using Collibri.Dtos;
// // using Collibri.Tests.Repositories.Files;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Collibri.Tests.Controllers
// {
// 	public class CreateFileData : TheoryData<IFormFile, string, int, FileInfoDTO?>
// 	{
// 		public CreateFileData()
// 		{
// 			Add(FileTestHelper.CreateTestFormFile("textFile.txt", "Text file test data", "text/plain"),
// 				"00000000000000000000000000000000", 200,
// 				new FileInfoDTO(Guid.Parse("00000000000000000000000000000000"),
// 					Guid.Parse("00000000000000000000000000000001"),
// 					@"C:\Files\00000000000000000000000000000000\textFile.txt",
// 					"textFile.txt", "text/plain", 1));
// 			Add(FileTestHelper.CreateTestFormFile("textFile.txt", "Text file test data", "text/plain"),
// 				"00000000000000000000000000000000", 409, null);
// 		}
// 	}
//
// 	public class DeleteFileData : TheoryData<string, int, FileInfoDTO?>
// 	{
// 		public DeleteFileData()
// 		{
// 			Add("00000000000000000000000000000000", 200,
// 				new FileInfoDTO(Guid.Parse("00000000000000000000000000000000"),
// 					Guid.Parse("00000000000000000000000000000001"),
// 					@"C:\Files\00000000000000000000000000000000\textFile.txt",
// 					"textFile.txt", "text/plain", 1));
// 			Add("00000000000000000000000000000000", 409, null);
// 		}
// 	}
//
// 	public class GetFileData : TheoryData<string, FileStreamResult?>
// 	{
// 		public GetFileData()
// 		{
// 			var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>()
// 			{
// 				{
// 					@"C:\Files\00000000000000000000000000000000\textFile.txt",
// 					new MockFileData("Text file test data")
// 				}
// 			});
//
// 			Add("00000000000000000000000000000000",
// 				FileTestHelper.CreateTestFileStreamResult(fileSystem, @"C:\Files\00000000000000000000000000000000",
// 					"textFile.txt"));
// 			Add("00000000000000000000000000000000", null);
// 		}
// 	}
//
// 	public class UpdateFileNameData : TheoryData<string, string, int, FileInfoDTO?>
// 	{
// 		public UpdateFileNameData()
// 		{
// 			Add("00000000000000000000000000000000", "updatedName.txt", 200,
// 				new FileInfoDTO(Guid.Parse("00000000000000000000000000000000"),
// 					Guid.Parse("00000000000000000000000000000001"),
// 					@"C:\Files\00000000000000000000000000000000\textFile.txt",
// 					"textFile.txt", "text/plain", 1));
// 			Add("00000000000000000000000000000000", "updatedName.txt", 409, null);
// 		}
// 	}
// }