using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPosts();  
        Task<Post> AddPostAsync(Post post);
        Task<Post?> GetPostByIdAsync(int id);
    }
}
