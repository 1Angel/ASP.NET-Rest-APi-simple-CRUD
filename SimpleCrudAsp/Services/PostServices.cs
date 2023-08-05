using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SimpleCrudAsp.Data;
using SimpleCrudAsp.models;

namespace SimpleCrudAsp.Services
{
    public class PostServices
    {
        private readonly ApplicationDbContext _context;
        public PostServices(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Post>> GetAll()
        {
            var posts = await  _context.Posts.ToListAsync();
            return posts;
        }

        public async Task<Post?> GetByID(int id)
        {
            var postsid = await _context.Posts.FindAsync(id);
            return postsid;
        }

        public async Task<Post> CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return await _context.Posts.FindAsync(post.Id);
        }

        public async void DeletePost(int id)
        {
            var postid = await _context.Posts.FindAsync(id);

            _context.Posts.Remove(postid);
            await _context.SaveChangesAsync();
        }

        public async Task<Post> UpdatePost(int id, Post post)
        {
            var posts = await _context.Posts.FindAsync(id);

            posts.Title = post.Title;
            posts.Description = post.Description;

            await _context.SaveChangesAsync();
            return post;
        }
    }
}
