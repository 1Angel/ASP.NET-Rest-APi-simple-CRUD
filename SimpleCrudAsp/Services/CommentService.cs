using Microsoft.EntityFrameworkCore;
using SimpleCrudAsp.Data;
using SimpleCrudAsp.models;

namespace SimpleCrudAsp.Services
{
    public class CommentService
    {
        private readonly ApplicationDbContext _context;
        public CommentService(ApplicationDbContext context)
        {
            _context= context;
        }

        public async Task<ICollection<Comment>> CommentsList()
        {
            var comments = await _context.Comments.ToListAsync();
            return comments;
        }

        public async Task<Comment> CommentById(int id)
        {
            var commentid = await _context.Comments.FindAsync(id);
            return commentid;
        }


        public async Task<Comment> CreateComment(Comment comments)
        {
            _context.Comments.Add(comments);
            _context.SaveChanges();
            return await _context.Comments.FindAsync(comments.Id);
        }

        public async void DeleteComment(int id)
        {
            var commentid= await _context.Comments.FindAsync(id);
            _context.Comments.Remove(commentid);
            await _context.SaveChangesAsync();
        }
    }
}
