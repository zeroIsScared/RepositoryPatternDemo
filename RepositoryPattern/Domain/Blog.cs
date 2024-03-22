using RepositoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Domain
{
    public class Blog
    {
        private readonly IRepository<Post> _postRepository;    

        private readonly IRepository<User> _userRepository;


        public Blog(IRepository<User> userRepository, IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public bool PublishPost(int userId, int postId)
        {
            try
            {
                Console.WriteLine("Open connection to database");
                User user = _userRepository.GetById(userId);
                Post post = _postRepository.GetById(postId);

                if (user == null)
                {                   
                    Console.WriteLine($"Customer with id {userId} was not found");
                    return false;
                }

                if (user.Points < 5)
                {
                    Console.WriteLine($"The {user.Name} has only {user.Points} points, which is not enougth to publish a post.");
                    return false;
                }

                if (post == null)
                {
                    Console.WriteLine($"Post with {postId} was not found");
                    return false;
                }

                if (post.Category == null)
                {
                    Console.WriteLine($"Please add a category for your post!");
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
            catch 
            {
                throw;

            }
            finally
            {
                Console.WriteLine("Close connection to database");
            }     

        }
        
    }

}
