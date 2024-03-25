using RepositoryPattern.Data;
using RepositoryPattern.Domain;
using RepositoryPattern.Exceptions;
using RepositoryPattern.Interfaces;
using System.Data;
using System.Xml.Linq;

public class GenericRepositoryPatternDemo
    {
    private static void Main(string[] args)
    {
        IRepository<Post> postRepository = new Repository<Post>();
        IRepository<User> userRepository = new Repository<User>();
    
        try
        {
            userRepository.Add(new User { Id = 1, Email = "user1@gmail.com", Name = "Karl Yang", Points = 0, PostedItems = 0 });
            userRepository.Add(new User { Id = 2, Email = "user2@gmail.com", Name = "Jhon Doe", Points = 30, PostedItems = 10 });

            postRepository.Add(new Post { Id = 1, Name = "My story", Category = "Personal", IsPosted = false });
            postRepository.Add(new Post { Id = 2, Name = "At work", IsPosted = false });

            var item1 = postRepository.GetById(1);            

            var listName = userRepository.GetAll();

            foreach (var item in listName)
            {
                Console.WriteLine(item.Name);
            }

            item1.Name = "Was changed";
            postRepository.Update(item1);

            var itemUpdated = postRepository.GetById(1);
            Console.WriteLine(itemUpdated.Name);

            Blog blog = new Blog(userRepository, postRepository);

            blog.PublishPost(1, 1);
            blog.PublishPost(2, 2);
            blog.PublishPost(2, 1);
            blog.PublishPost(3, 1);
            blog.PublishPost(1, 3);
        }
        catch (EntityNotFoundException ex)
        {
            Console.WriteLine(ex.Message);            
        }        
#if (DEBUG)
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            var inner = ex.InnerException;

            while (inner != null)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

#endif
    }
}

