// using System.IO.Abstractions.TestingHelpers;
// using Collibri.Dtos;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using FileInfo = Collibri.Models.FileInfo;
//
// namespace Collibri.Tests.Repositories.Files
// {
//     public class CreateFileData : TheoryData<MockFileSystem, List<FileInfo>, IFormFile, string, FileInfoDTO?>
//     {
//         public CreateFileData()
//         {
//             const string postId = "00000000000000000000000000000000";
//             var fileSystem = new MockFileSystem();
//             var path = FileTestHelper.GetPath(postId, fileSystem);
//             fileSystem.AddFile(path + "\\textFile.txt", new MockFileData("Text file test data"));
//             fileSystem.AddFile(path + "\\pdfFile.pdf", new MockFileData("PDF file test data"));
//             fileSystem.AddFile(path + "\\pngFile.png", new MockFileData(new byte[] { 0x12, 0x34, 0x56, 0xd2 }));
//             var files = new List<FileInfo>
//             {
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000001"), PostId = Guid.Parse(postId),
//                     Path = path + "\\textFile.txt",
//                     Name = "textFile.txt", ContentType = "text/plain", Lenght = 19
//                 },
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000002"), PostId = Guid.Parse(postId),
//                     Path = path + "\\pdfFile.pdf",
//                     Name = "pdfFile.pdf", ContentType = "application/pdf", Lenght = 30
//                 },
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000003"), PostId = Guid.Parse(postId),
//                     Path = path + "\\pngFile.png",
//                     Name = "pngFile.png", ContentType = "image/png", Lenght = 4
//                 }
//             };
//             
//             Add(fileSystem, files, FileTestHelper.CreateTestFormFile("textFile1.txt", "Text file test data", "text/plain"), postId,
//                 new FileInfoDTO(Guid.Parse("00000000000000000000000000000004"),
//                     Guid.Parse(postId),
//                     $@"{path}\00000000000000000000000000000000\textFile1.txt",
//                     "textFile1.txt", "text/plain", 0));
//            // No extension
//             Add(fileSystem, files, FileTestHelper.CreateTestFormFile("textFile", "Text file test data", "text/plain"), postId,
//                 new FileInfoDTO(Guid.Parse("00000000000000000000000000000005"),
//                     Guid.Parse(postId),
//                     $@"{path}\textFile",
//                     "textFile", "text/plain", 0));
//             Add(fileSystem, files, FileTestHelper.CreateTestFormFile("pngFile2.png",
//                     System.Text.Encoding.UTF8.GetString(new byte[] { 0x12, 0x34, 0x56, 0xd2 }), "image/png"), postId,
//                 new FileInfoDTO(Guid.Parse("00000000000000000000000000000006"),
//                     Guid.Parse(postId),
//                     $@"{path}\pngFile2.png",
//                     "pngFile2.png", "image/png", 0));
//         }
//     }
//
//     public class DeleteFileData : TheoryData<MockFileSystem, List<FileInfo>, string, FileInfoDTO?>
//     {
//         public DeleteFileData()
//         {
//             const string postId = "00000000000000000000000000000001";
//             var fileSystem = new MockFileSystem();
//             var path = FileTestHelper.GetPath(postId, fileSystem);
//             fileSystem.AddFile(path + "\\textFile.txt", new MockFileData("Text file test data"));
//             fileSystem.AddFile(path + "\\pdfFile.pdf", new MockFileData("PDF file test data"));
//             fileSystem.AddFile(path + "\\pngFile.png", new MockFileData(new byte[] { 0x12, 0x34, 0x56, 0xd2 }));
//             fileSystem.AddFile(path + "\\noExtension", new MockFileData("No extension file test data"));
//             var files = new List<FileInfo>()
//             {
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000001"), PostId = Guid.Parse(postId),
//                     Path = path + "\\textFile.txt",
//                     Name = "textFile.txt", ContentType = "text/plain", Lenght = 19
//                 },
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000002"), PostId = Guid.Parse(postId),
//                     Path = path + "\\pdfFile.pdf",
//                     Name = "pdfFile.pdf", ContentType = "application/pdf", Lenght = 30
//                 },
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000003"), PostId = Guid.Parse(postId),
//                     Path = path + "\\pngFile.png",
//                     Name = "pngFile.png", ContentType = "image/png", Lenght = 4
//                 },
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000004"), PostId = Guid.Parse(postId),
//                     Path = path + "\\noExtension",
//                     Name = "noExtension", ContentType = "text/plain", Lenght = 27
//                 }
//             };
//             
//             Add(fileSystem, files, "00000000000000000000000000000001", new FileInfoDTO(Guid.Parse("00000000000000000000000000000001"),
//                 Guid.Parse(postId),
//                 @$"{path}\textFile.txt",
//                 "textFile.txt", "text/plain", 19));
//             // Should return null
//             Add(fileSystem, files, "10000000000000000000000000000000", null);
//             // No extension
//             Add(fileSystem, files, "00000000000000000000000000000004", new FileInfoDTO(Guid.Parse("00000000000000000000000000000004"),
//                 Guid.Parse(postId),
//                 $@"{path}\noExtension",
//                 "noExtension", "text/plain", 27));
//         }
//     }
//
//     public class GetAllFilesData : TheoryData<MockFileSystem, List<FileInfo>, string, IEnumerable<FileInfoDTO>>
//     {
//         public GetAllFilesData()
//         {
//             const string postId1 = "00000000000000000000000000000001";
//             const string postId2 = "00000000000000000000000000000002";
//             var fileSystem = new MockFileSystem();
//             var path1 = FileTestHelper.GetPath(postId1, fileSystem);
//             var path2 = FileTestHelper.GetPath(postId2, fileSystem);
//             fileSystem.AddFile(path1 + "\\textFile.txt", new MockFileData("Text file test data"));
//             fileSystem.AddFile(path1 + "\\pdfFile.pdf", new MockFileData("PDF file test data"));
//             fileSystem.AddFile(path2 + "\\pngFile.png", new MockFileData(new byte[] { 0x12, 0x34, 0x56, 0xd2 }));
//             fileSystem.AddFile(path2 + "\\noExtension", new MockFileData("No extension file test data"));
//             var files = new List<FileInfo>()
//             {
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000001"), PostId = Guid.Parse(postId1),
//                     Path = path1 + "\\textFile.txt",
//                     Name = "textFile.txt", ContentType = "text/plain", Lenght = 19
//                 },
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000002"), PostId = Guid.Parse(postId1),
//                     Path = path1 + "\\pdfFile.pdf",
//                     Name = "pdfFile.pdf", ContentType = "application/pdf", Lenght = 30
//                 },
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000003"), PostId = Guid.Parse(postId2),
//                     Path = path2 + "\\pngFile.png",
//                     Name = "pngFile.png", ContentType = "image/png", Lenght = 4
//                 },
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000004"), PostId = Guid.Parse(postId2),
//                     Path = path2 + "\\noExtension",
//                     Name = "noExtension", ContentType = "text/plain", Lenght = 27
//                 }
//             };
//             Add(fileSystem, files, postId1, new List<FileInfoDTO>()
//             {
//                 new FileInfoDTO()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000001"), PostId = Guid.Parse(postId1),
//                     Path = path1 + "\\textFile.txt",
//                     Name = "textFile.txt", ContentType = "text/plain", Lenght = 19
//                 },
//                 new FileInfoDTO()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000002"), PostId = Guid.Parse(postId1),
//                     Path = path1 + "\\pdfFile.pdf",
//                     Name = "pdfFile.pdf", ContentType = "application/pdf", Lenght = 30
//                 },
//             });
//             Add(fileSystem, files, postId2, new List<FileInfoDTO>()
//             {
//                 new FileInfoDTO()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000003"), PostId = Guid.Parse(postId2),
//                     Path = path2 + "\\pngFile.png",
//                     Name = "pngFile.png", ContentType = "image/png", Lenght = 4
//                 },
//                 new FileInfoDTO()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000004"), PostId = Guid.Parse(postId2),
//                     Path = path2 + "\\noExtension",
//                     Name = "noExtension", ContentType = "text/plain", Lenght = 27
//                 }
//             });
//             Add(fileSystem, files, "00000000000000000000000000000003", new List<FileInfoDTO>());
//         }
//     }
//
//     public class GetFileData : TheoryData<MockFileSystem, List<FileInfo>, string, FileStreamResult?>
//     {
//         public GetFileData()
//         {
//             const string postId = "00000000000000000000000000000002";
//             var fileSystem = new MockFileSystem();
//             var path = FileTestHelper.GetPath(postId, fileSystem);
//             fileSystem.AddFile(path + "\\textFile.txt", new MockFileData("Text file test data"));
//             fileSystem.AddFile(path + "\\pdfFile.pdf", new MockFileData("PDF file test data"));
//             fileSystem.AddFile(path + "\\pngFile.png", new MockFileData(new byte[] { 0x12, 0x34, 0x56, 0xd2 }));
//             fileSystem.AddFile(path + "\\noExtension", new MockFileData("No extension file test data"));
//             var files = new List<FileInfo>()
//             {
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000001"), PostId = Guid.Parse(postId),
//                     Path = path + "\\textFile.txt",
//                     Name = "textFile.txt", ContentType = "text/plain", Lenght = 19
//                 },
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000002"), PostId = Guid.Parse(postId),
//                     Path = path + "\\pdfFile.pdf",
//                     Name = "pdfFile.pdf", ContentType = "application/pdf", Lenght = 30
//                 },
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000003"), PostId = Guid.Parse(postId),
//                     Path = path + "\\pngFile.png",
//                     Name = "pngFile.png", ContentType = "image/png", Lenght = 4
//                 },
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000004"), PostId = Guid.Parse(postId),
//                     Path = path + "\\noExtension",
//                     Name = "noExtension", ContentType = "text/plain", Lenght = 27
//                 }
//             };
//             Add(fileSystem, files, "00000000000000000000000000000001",
//                 FileTestHelper.CreateTestFileStreamResult(fileSystem, path, "textFile.txt"));
//             // Should return null
//             Add(fileSystem, files, "10000000000000000000000000000000", null);
//             Add(fileSystem, files, "00000000000000000000000000000004",
//                 FileTestHelper.CreateTestFileStreamResult(fileSystem, path, "noExtension"));
//             Add(fileSystem, files, "00000000000000000000000000000003",
//                 FileTestHelper.CreateTestFileStreamResult(fileSystem, path, "pngFile.png"));
//         }
//     }
//     
//     public class UpdateFileNameData  : TheoryData<MockFileSystem, List<FileInfo>, string, string, FileInfoDTO?>
//     {
//         public UpdateFileNameData()
//         {
//             const string postId = "00000000000000000000000000000003";
//             var fileSystem = new MockFileSystem();
//             var path = FileTestHelper.GetPath(postId, fileSystem);
//             fileSystem.AddFile(path + "\\textFile.txt", new MockFileData("Text file test data"));
//             fileSystem.AddFile(path + "\\pdfFile.pdf", new MockFileData("PDF file test data"));
//             fileSystem.AddFile(path + "\\pngFile.png", new MockFileData(new byte[] { 0x12, 0x34, 0x56, 0xd2 }));
//             fileSystem.AddFile(path + "\\noExtension", new MockFileData("No extension file test data"));
//             var files = new List<FileInfo>()
//             {
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000001"), PostId = Guid.Parse(postId),
//                     Path = path + "\\textFile.txt",
//                     Name = "textFile.txt", ContentType = "text/plain", Lenght = 19
//                 },
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000002"), PostId = Guid.Parse(postId),
//                     Path = path + "\\pdfFile.pdf",
//                     Name = "pdfFile.pdf", ContentType = "application/pdf", Lenght = 30
//                 },
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000003"), PostId = Guid.Parse(postId),
//                     Path = path + "\\pngFile.png",
//                     Name = "pngFile.png", ContentType = "image/png", Lenght = 4
//                 },
//                 new FileInfo()
//                 {
//                     Id = Guid.Parse("00000000000000000000000000000004"), PostId = Guid.Parse(postId),
//                     Path = path + "\\noExtension",
//                     Name = "noExtension", ContentType = "text/plain", Lenght = 27
//                 }
//             };
//             Add(fileSystem, files, "00000000000000000000000000000001", "anotherTextFile.txt",
//                 new FileInfoDTO(Guid.Parse("00000000000000000000000000000001"),
//                     Guid.Parse(postId),
//                     $@"{path}\anotherTextFile.txt",
//                     "anotherTextFile.txt", "text/plain", 19));
//             // Should return null
//             Add(fileSystem, files, "00000000000000000000000000000099", "anotherTextFile.txt", null);
//         }
//     }
// }