using Collibri.Models.Posts;

namespace Collibri.Tests.Models.Posts
{
    public class CreatePostTestData : TheoryData<Post>
    {
        public CreatePostTestData()
        {
            Add(new Post(Guid.NewGuid(), "user1", "title1", 1, 0, 0, 1,  DateTime.Now, DateTime.Now));
        }
    }

    public class GetAllPostsTestData : TheoryData<int, List<Post>>
    {
        public GetAllPostsTestData()
        {
            Add(1, 
                new List<Post>
                {
                    new Post(Guid.NewGuid(), "user1", "title1", 1, 0, 0, 1,  DateTime.Now, DateTime.Now),
                    new Post(Guid.NewGuid(), "user2", "title2", 1, 0, 0, 1,  DateTime.Now, DateTime.Now),
                    new Post(Guid.NewGuid(), "user3", "title3", 2, 0, 0, 1,  DateTime.Now, DateTime.Now)
                }
            );
            Add(1, new List<Post>());
        }
    }
    
    public class DeletePostByIdTestData : TheoryData<Guid, Post?, List<Post>>
    {
        public DeletePostByIdTestData()
        {
            //Correct input
            Add(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"),
                new Post(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), "user1", "title1", 1, 0, 0, 1,  new DateTime(), new DateTime()),
                new List<Post>
                {
                    new Post(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), "user1", "title1", 1, 0, 0, 1,  new DateTime(), new DateTime()),
                    new Post(Guid.NewGuid(), "user2", "title2", 1, 0, 0, 1,  new DateTime(), new DateTime()),
                    new Post(Guid.NewGuid(), "user3", "title3", 2, 0, 0, 1,  new DateTime(), new DateTime())
                }
            );
            //Failing input
            Add(new Guid("a4e38bc3-2dc0-4c61-a4c9-5ab59f8a5f57"),
                null,
                new List<Post>
                {
                    new Post(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), "user1", "title1", 1, 0, 0, 1,  new DateTime(), new DateTime()),
                }
            );
        }
    }
}
