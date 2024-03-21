using System.ComponentModel;



    public abstract class Entity
    {
        public int Id { get; set; }
    }

    public class Post : Entity 
    { 
        public string Name { get; set; }    
        public string ShortDescription { get; set; }       
        public string Category { get; set; }   
        public bool IsPosted { get; set; }        

    }

    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }   
        public int Points { get; set; }
        public int PostedItems { get; set; }
}

    public interface IRepository<T> where T : Entity
    {
        T GetById(int id);
        IList<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);

    }

    public class Blog
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<User> _userRepository;

        public Blog (IRepository<User> userRepository, IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }   

        public bool PublishPost(int userId, int postId )
        {
            User user = _userRepository.GetById(userId);
            Post post = _postRepository.GetById(postId);

            if (user == null)
            {
                Console.WriteLine($"Customer with id {userId} was not found");
                return false;
            }

            if (user.Points < 5)
            {
                Console.WriteLine($"The {user.Name} has only {user.Points}, which is not enougth to publish a post.");
                return false;   
            }

            if (post == null)
        {
            Console.WriteLine($"Post with {postId} was not found");
            return false;
        }

            if (post.Category == null)
            {
                Console.WriteLine($"Please add a category for you post!");
                return false;
            }

            user.Points += 5;
            user.PostedItems++;
            post.IsPosted = true;

            _postRepository.Update(post);
            _userRepository.Update(user);

            Console.WriteLine($"User {user.Name} successfully published the post {post.Name}");

            return true;
        }
    }

    public class GenericRepositoryPatternDemo
    {
        private static void Main(string[] args)
        {
           IRepository<Post> postRepository = new ListRepository<Post>();
           IRepository<User> userRepository = new ListRepository<User>();

        userRepository.Add(new User { Id = 1, Email = "user1@gmail.com", Name = "Karl Yang", Points = 0, PostedItems = 0});
        userRepository.Add(new User { Id = 2, Email = "user2@gmail.com", Name = "Jhon Doe", Points = 30, PostedItems = 10});

        postRepository.Add(new Post { Id = 1, Name = "My story", Category = "Personal", IsPosted = false });
        postRepository.Add(new Post { Id = 2, Name = "At work", IsPosted = false });

        Blog blog = new Blog(userRepository, postRepository);

        blog.PublishPost(1, 1);
        blog.PublishPost(2, 2);
        blog.PublishPost(2, 1);
        blog.PublishPost(3, 1);
        blog.PublishPost(1, 3);
    }
    }

internal class ListRepository<Entity> : IRepository<Post> :
{
}