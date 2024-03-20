// using Collibri.Controllers;
// using Collibri.Dtos;
// using Collibri.Repositories;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Collibri.Tests.Controllers
// {
// 	public class FileControllerTests
// 	{
// 		[Theory]
// 		[ClassData(typeof(CreateFileData))]
// 		public void CreateFile_Should_ReturnFileTest(IFormFile fileData, string postId, int statusCode,
// 			FileInfoDTO? expected)
// 		{
// 			// Arrange
// 			var repository = new Mock<IFileRepository>();
// 			var controller = new FileController(repository.Object);
// 			repository.Setup(x => x.CreateFile(fileData, postId)).Returns(expected);
//
// 			// Act
// 			var actual = controller.CreateFile(fileData, postId);
//
// 			// Assert
// 			if (expected == null)
// 			{
// 				Assert.IsType<ConflictObjectResult>(actual);
// 				Assert.Equal(statusCode, ((ConflictObjectResult)actual).StatusCode);
// 			}
// 			else
// 			{
// 				Assert.IsType<OkObjectResult>(actual);
// 				Assert.Equal(statusCode, ((OkObjectResult)actual).StatusCode);
// 			}
// 		}
//
// 		[Theory]
// 		[ClassData(typeof(DeleteFileData))]
// 		public void DeleteFile_Should_ReturnFileTest(string id, int statusCode, FileInfoDTO? expected)
// 		{
// 			// Arrange
// 			var repository = new Mock<IFileRepository>();
// 			var controller = new FileController(repository.Object);
// 			repository.Setup(x => x.DeleteFile(id)).Returns(expected);
//
// 			// Act
// 			var actual = controller.DeleteFile(id);
//
// 			// Assert
// 			if (expected == null)
// 			{
// 				Assert.IsType<ConflictObjectResult>(actual);
// 				Assert.Equal(statusCode, ((ConflictObjectResult)actual).StatusCode);
// 			}
// 			else
// 			{
// 				Assert.IsType<OkObjectResult>(actual);
// 				Assert.Equal(statusCode, ((OkObjectResult)actual).StatusCode);
// 			}
// 		}
//
// 		[Theory]
// 		[ClassData(typeof(GetFileData))]
// 		public void GetFile_Should_ReturnFileStreamResultTest(string id, FileStreamResult? expected)
// 		{
// 			// Arrange
// 			var repository = new Mock<IFileRepository>();
// 			var controller = new FileController(repository.Object);
// 			repository.Setup(x => x.GetFile(id)).Returns(expected);
//
// 			// Act
// 			var actual = controller.GetFile(id);
//
// 			// Assert
// 			Assert.Equal(expected, actual);
// 		}
//
// 		[Theory]
// 		[ClassData(typeof(UpdateFileNameData))]
// 		public void UpdateFileName_Should_ReturnFileTest(string id,
// 			string updatedName, int statusCode, FileInfoDTO? expected)
// 		{
// 			// Arrange
// 			var repository = new Mock<IFileRepository>();
// 			var controller = new FileController(repository.Object);
// 			repository.Setup(x => x.UpdateFileName(id, updatedName))
// 				.Returns(expected);
//
// 			// Act
// 			var actual = controller.UpdateFileName(id, updatedName);
//
// 			// Assert
// 			if (expected == null)
// 			{
// 				Assert.IsType<ConflictObjectResult>(actual);
// 				Assert.Equal(statusCode, ((ConflictObjectResult)actual).StatusCode);
// 			}
// 			else
// 			{
// 				Assert.IsType<OkObjectResult>(actual);
// 				Assert.Equal(statusCode, ((OkObjectResult)actual).StatusCode);
// 			}
// 		}
// 	}
// }