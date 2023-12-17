namespace Sandbox.Solutions.Medium;

public class Twitter
{
    private readonly IDictionary<int, ISet<int>> _followers = new Dictionary<int, ISet<int>>();
    private readonly IDictionary<int, ISet<Post>> _posts = new Dictionary<int, ISet<Post>>();
    private static int PostOrder = 1;

    private class MaxHeapComparer : IComparer<int>
    {
        public int Compare(int x, int y) => y.CompareTo(x);
    }

    public Twitter()
    { }

    public void PostTweet(int userId, int tweetId)
    {
        var post = new Post(tweetId, PostOrder++);

        if (!_posts.ContainsKey(userId))
            _posts.Add(userId, new HashSet<Post>());

        _posts[userId].Add(post);
    }

    public IList<int> GetNewsFeed(int userId)
    {
        // priority queue on datetime when post appeared
        // your posts and of your followers
        var pq = new PriorityQueue<int, int>(new MaxHeapComparer());
        var postList = new int[10];

        _posts.TryGetValue(userId, out var posts);
        if (posts is not null)
        {
            foreach (var post in posts)
            {
                pq.Enqueue(post.Id, post.Time);
            }
        }

        _followers.TryGetValue(userId, out var followers);
        if (followers is not null)
        {
            foreach (var follower in followers)
            {
                _posts.TryGetValue(follower, out var followerPosts);
                if (followerPosts is null)
                    continue;

                foreach (var post in followerPosts)
                {
                    pq.Enqueue(post.Id, post.Time);
                }
            }
        }

        var count = 0;
        while (pq.Count != 0 && count < 10)
        {
            postList[count] = pq.Dequeue();
            count++;
        }

        return postList[..count];
    }

    public void Follow(int followerId, int followeeId)
    {
        if (!_followers.ContainsKey(followerId))
            _followers.Add(followerId, new HashSet<int>());

        _followers[followerId].Add(followeeId);
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (_followers.TryGetValue(followerId, out var follower))
            follower.Remove(followeeId);
    }

    private class Post
    {
        public Post(int id, int time)
        {
            Id = id;
            Time = time;
        }

        public int Id { get; }
        public int Time { get; }
    }
}