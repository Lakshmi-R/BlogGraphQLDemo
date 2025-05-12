using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext db;
        public PostRepository(BlogDbContext dbContext) 
        { 
           db = dbContext;
        }
        public async Task<Post> AddPostAsync(Post post)
        {
            db.posts.Add(post);
            await db.SaveChangesAsync();

            return post;
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return db.posts.Include(p => p.Author).ToList();
        }

        public async Task<Post?> GetPostByIdAsync(int id)
        {
            return await db.posts.Include(p => p.Author).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
