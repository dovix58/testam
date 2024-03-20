// using System.IO.Abstractions.TestingHelpers;
// using AutoMapper;
// using Collibri.Data;
// using Collibri.Dtos;
// using Collibri.Repositories.DbImplementation;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Moq.EntityFrameworkCore;
// using FileInfo = Collibri.Models.FileInfo;
//
// namespace Collibri.Tests.Repositories.Files
// {
//     public class FileRepositoryTests
//     {
//         [Theory]
//         [ClassData(typeof(CreateFileData))]
//         public void CreateFile_Should_ReturnFileTest(MockFileSystem fileSystem, List<FileInfo> fileInfos, IFormFile fileData,
//             string postId, FileInfoDTO? expected)
//         {
//             var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
//             var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
//             IMapper mapper = new Mapper(configuration);
//
//             var dataContext = new Mock<DataContext>();
//             dataContext.Setup<DbSet<FileInfo>>(x => x.FileInfos).ReturnsDbSet(fileInfos);
//
//             var fileRepository = new DbFileRepository(dataContext.Object, mapper, fileSystem.FileSystem);
//             // Act
//             var actual = fileRepository.CreateFile(fileData, postId);
//
//             // Assert
//             expected.Id = actual.Id;
//             expected.Path = actual.Path;
//             Assert.Equivalent(expected, actual);
//             Assert.True(fileSystem.File.Exists(expected.Path));
//         }
//
//         [Theory]
//         [ClassData(typeof(DeleteFileData))]
//         public void DeleteFile_Should_ReturnFileTest(MockFileSystem fileSystem, List<FileInfo> fileInfos, string id, FileInfoDTO? expected)
//         {
//             // Arrange
//             var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
//             var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
//             IMapper mapper = new Mapper(configuration);
//
//             var dataContext = new Mock<DataContext>();
//             dataContext.SetupGet(x => x.FileInfos).ReturnsDbSet(fileInfos);
//             var fileRepository = new DbFileRepository(dataContext.Object, mapper, fileSystem.FileSystem);
//
//             // Act
//             var actual = fileRepository.DeleteFile(id);
//
//             // Assert
//             if (expected == null)
//                 Assert.Null(actual);
//             else
//             {
//                 Assert.Equivalent(expected, actual);
//                 Assert.True(!fileSystem.FileExists(expected.Path));
//             }
//         }
//
//         [Theory]
//         [ClassData(typeof(GetAllFilesData))]
//         public void GetAllFiles_Should_ReturnAllFileInfosInPost(MockFileSystem fileSystem, List<FileInfo> fileInfos, string postId,
//             IEnumerable<FileInfoDTO> expected)
//         {
//             // Arrange
//             var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
//             var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
//             IMapper mapper = new Mapper(configuration);
//
//             var dataContext = new Mock<DataContext>();
//             dataContext.SetupGet(x => x.FileInfos).ReturnsDbSet(fileInfos);
//             var fileRepository = new DbFileRepository(dataContext.Object, mapper, fileSystem.FileSystem);
//             
//             // Act
//             var actual = fileRepository.GetAllFiles(postId);
//             
//             // Assert
//             Assert.Equivalent(expected, actual);
//         }
//         
//         [Theory]
//         [ClassData(typeof(GetFileData))]
//         public void GetFile_Should_ReturnFileStreamResultTest(MockFileSystem fileSystem, List<FileInfo> fileInfos, string id,
//             FileStreamResult? expected)
//         {
//             // Arrange
//             var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
//             var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
//             IMapper mapper = new Mapper(configuration);
//
//             var dataContext = new Mock<DataContext>();
//             dataContext.SetupGet(x => x.FileInfos).ReturnsDbSet(fileInfos);
//             var fileRepository = new DbFileRepository(dataContext.Object, mapper, fileSystem.FileSystem);
//
//             // Act
//             var actual = fileRepository.GetFile(id);
//
//             // Assert
//             if (expected == null)
//                 Assert.Null(actual);
//             else
//             {
//                 Assert.True(FileTestHelper.StreamEquals(expected.FileStream, actual.FileStream));
//             }
//         }
//
//         [Theory]
//         [ClassData(typeof(UpdateFileNameData))]
//         public void UpdateFileName_Should_ReturnFileTest(MockFileSystem fileSystem, List<FileInfo> fileInfos, string id,
//             string updatedName, FileInfoDTO? expected)
//         {
//             // Arrange
//             var profile = new Collibri.Repositories.DbImplementation.Mapper.AutoMapper();
//             var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
//             IMapper mapper = new Mapper(configuration);
//
//             var dataContext = new Mock<DataContext>();
//             dataContext.Setup<DbSet<FileInfo>>(x => x.FileInfos).ReturnsDbSet(fileInfos);
//             var fileRepository = new DbFileRepository(dataContext.Object, mapper, fileSystem.FileSystem);
//
//             // Act
//             var actual = fileRepository.UpdateFileName(id, updatedName);
//
//             // Assert
//             if (expected == null)
//                 Assert.Null(actual);
//             else
//             {
//                 Assert.Equivalent(expected, actual);
//                 Assert.True(fileSystem.FileExists(expected.Path));
//             }
//         }
//     }
// }