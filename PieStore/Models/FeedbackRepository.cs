namespace PieStore.Models
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _context;
        public FeedbackRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddFeedback(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();

        }
        
        // public void GetFeedbackById(int feedbackId)
        // {
        //     _context.Feedbacks.First(x => x.feedbackId == feedbackId);

        // }
    }
}